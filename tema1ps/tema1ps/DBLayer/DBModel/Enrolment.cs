using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1ps.DBLayer.DBModel
{
    class Enrolment
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int courseID { get; set; }
        public int grade { get; set; }
    }
}
