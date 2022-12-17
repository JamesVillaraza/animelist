using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLibrary.Data
{
    public class AnimeModel
    {
        public int animeID { get; set; }
        public string animeName { get; set; }
        public int totalEpisodes { get; set; }
        public int totalSeason { get; set; }
        public double publicRating { get; set; }
        public string animeType { get;set; }
        public DateTime airDate { get; set; }
        public string animeThumbnail { get; set; }

        public enum Genre
        {
            Action,
            Adventure,
            Comedy,
            Drama,
            SliceOfLife,
            Fantasy,
            Magic,
            Supernatural,
            Horror,
            Mystery,
            Psychological,
            Romance,
            SciFi
        }
    }
}
