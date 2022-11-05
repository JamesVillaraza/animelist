using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AnimeLibrary.Models
{
    class AccountModel
    {
        public int accountID { get; set; }
        public string accountName { get; set; }
        public string username { get; set; }
        public SecureString password { get; set; }

    }
}
