using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema1ps.DBLayer.DAO;
using tema1ps.DBLayer.DBModel;

namespace tema1ps.BLLayer
{
    class UserBL
    {
        public int loginUser(string username, string password)
        {
            UsersDAO dao = new UsersDAO();
            List<User> list = new List<User>();

            list = dao.getAllUsers();

            foreach (User u in list)
                if (u.username.Equals(username) && u.password.Equals(password))
                    return u.type;
            return -1;

        }

    }
}
