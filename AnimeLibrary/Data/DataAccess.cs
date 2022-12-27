﻿using System;
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

        //AnimeModel data access
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
                    while (reader.Read())
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the Anime Table");
                    throw;
                }
                return am;
            }
        }


        public List<AnimeModel> GetAnimeModels()
        {
            //create model here, will get returned in the end
            List<AnimeModel> ams = new List<AnimeModel>();
            //the physical SQL statement to execute as a string
            //if you need to add parameters, add them in as @variableName
            //they get added later with the line command.Parameters.AddWithValue("anID", id); 
            string queryString =
                "SELECT animeID, animeName, totalEpisodes, totalSeason, publicRating, animeType, airDate, animeThumbnail FROM dbo.Anime";
            //connection to the SQL database, using our connectionstring earlier
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //build out our command. sqlcommand has 2 parameters
                //the SQL command as a string. we add params later
                //and the connectionstring, to tell us which database to query against
                SqlCommand command = new SqlCommand(queryString, connection);
                //specific line to add parameters
               

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
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
                        ams.Add(a);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the Anime Table");
                    throw;
                }
                return ams;
            }
        }

        //EpisodeModel data access
        public EpisodeModel GetEpisodeModel(int id)
        {
            //create model here, will get returned in the end
            EpisodeModel em = new EpisodeModel();

            string queryString =
                "SELECT episodeID, episodeName, episodeDuration, animeID, episodeNumber, seasonNumber FROM dbo.Episode WHERE episodeID = @epID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("epID", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EpisodeModel e = new EpisodeModel();
                        e.episodeID = (int)reader[0];
                        e.episodeName = (string)reader[1];
                        e.episodeDuration = (string)reader[2];
                        e.animeID = (int)reader[3];
                        e.episodeNumber = (int)reader[4];
                        e.seasonNumber = (int)reader[5];
                        em = e;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the Episode");
                    throw;
                }
            }
            return em;
        }

        //ReviewListModel data access
        public ReviewListModel GetReviewListModel(int id)
        {
            ReviewListModel rlm = new ReviewListModel();

            string queryString =
                "SELECT listName, reviewIDs, accountID FROM dbo.ReviewList WHERE listName = @lName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("lName", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReviewListModel l = new ReviewListModel();
                        l.listName = (string)reader[0];
                        l.reviewIDs = (List<int>)reader[1];
                        l.accountID = (int)reader[2];
                        rlm = l;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the Review List");
                    throw;
                }
            }
            return rlm;
        }

        public ReviewModel GetReviewModel(int id)
        {
            ReviewModel rm = new ReviewModel();

            string queryString =
                "SELECT reviewID, animeTitle, statusOptions, episodesWatched, overallRating, accountID, startDate, endDate, isFavorite FROM dbo.Review WHERE reviewID = @rID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("rID", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ReviewModel r = new ReviewModel();
                        r.reviewID = (int)reader[0];
                        r.animeTitle = (string)reader[1];
                        r.statusOptions = (ReviewModel.StatusOptions)reader[2];
                        r.episodesWatched = (int)reader[3];
                        r.overallRating = (float)reader[4];
                        r.accountID = (int)reader[5];
                        r.startDate = (DateTime)reader[6];
                        r.endDate = (DateTime)reader[7];
                        r.isFavorite = (bool)reader[8];
                        rm = r;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to access the User Review");
                    throw;
                }

                return rm;
            }
        }
    }
}