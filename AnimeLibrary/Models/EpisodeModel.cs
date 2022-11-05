using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLibrary.Models
{
    class EpisodeModel
    {
        public int episodeID { get; set; }
        public string episodeName { get; set; }
        public string episodeDuration { get; set; }
        public int animeID { get; set; }
        public int episodeNumber { get; set; }
        public int seasonNumber { get; set; }

    }
}
