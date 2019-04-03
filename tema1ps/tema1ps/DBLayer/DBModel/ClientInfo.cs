using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1ps.DBLayer.DBModel
{
    class ClientInfo
    {
        public int userID { get; set; }
        public string name { get; set; }
        public int identityCardNr { get; set; }
        public int CNP { get; set; }
        public string adress { get; set; }
    }
}
