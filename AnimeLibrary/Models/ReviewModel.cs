using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLibrary.Models
{
    class ReviewModel
    {
        public int reviewID { get; set; }
        public string animeTitle { get; set; }
        public StatusOptions statusOptions { get; set; }
        public int episodesWatched { get; set; }
        public double overallRating { get; set; }
        public int accountID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isFavorite { get; set; }



        public enum StatusOptions
        {
            Ongoing,
            Finished,
            Unreleased
            
        }

    }
}
