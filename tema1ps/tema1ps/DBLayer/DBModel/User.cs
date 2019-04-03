using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1ps.DBLayer.DBModel
{
    class User
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }
}
