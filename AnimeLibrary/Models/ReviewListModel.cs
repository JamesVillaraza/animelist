using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLibrary.Models
{
    class ReviewListModel
    {
        public string listName { get; set; }
        public List<int> reviewIDs { get; set; }
        public int accountID { get; set; }

    }
}
