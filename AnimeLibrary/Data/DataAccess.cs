using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;


namespace AnimeLibrary.Data
{
    public class DataAccess
    {
        //connection string
        private string connectionString = "data source=localhost;initial catalog=AL12172022;trusted_connection=true";
        private readonly string _delimiter = "~*~";
        private readonly ILogger _logger;

        public DataAccess(ILogger logger)
        {
            _logger = logger; 
        }

        public AnimeModel GetAnimeModel(int id)
        {
            //create model here, will get returned in the end
            AnimeModel am = new AnimeModel();
            //the physical SQL statement to execute as a string
            //if you need to add parameters, add them in as @variableName
            //they get added later with the line command.Parameters.AddWithValue("anID", id); 
            string queryString =
                "SELECT animeID, animeName, totalEpisodes, totalSeason, publicRating, animeType, airDate, animeThumbnail FROM dbo.Anime WHERE animeID = @anID";
            //connection to the SQL database, using our connectionstring earlier
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //build out our command. sqlcommand has 2 parameters
                //the SQL command as a string. we add params later
                //and the connectionstring, to tell us which database to query against
                SqlCommand command = new SqlCommand(queryString, connection);
                //specific line to add parameters
                command.Parameters.AddWithValue("anID", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        AnimeModel a = new AnimeModel();
                        a.animeID = (int)reader[0];
                        a.animeName = (string)reader[1];
                        a.totalEpisodes = (int)reader[2];
                        a.totalSeason = (int)reader[3];
                        a.publicRating = (double)reader[4];
                        a.animeType = (string)reader[5];
                        a.airDate = (DateTime)reader[6];
                        a.animeThumbnail = (string)reader[7];
                        am = a;
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the Anime Table");
                    throw;
                }

            }
            return am;
        }
    }
}
