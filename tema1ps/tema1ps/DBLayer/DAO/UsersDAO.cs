using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema1ps.DBLayer.DBModel;

namespace tema1ps.DBLayer.DAO
{
    class UsersDAO
    {
        string address = "Data Source=localhost\\sqlexpress;Initial Catalog=tema1ps;Integrated Security=True;";

        public int addUser(User u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into user  VALUES (@id, @username, @password, @type)";
                    command.Parameters.AddWithValue("@id", u.ID);
                    command.Parameters.AddWithValue("@username", u.username);
                    command.Parameters.AddWithValue("@password", u.password);
                    command.Parameters.AddWithValue("@type", u.type);

                    try
                    {
                        connection.Open();
                        recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return recordsAffected;
        }

        public int deleteUser(int u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE user Where id=@id";
                    command.Parameters.AddWithValue("@id", u);

                    try
                    {
                        connection.Open();
                        recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return recordsAffected;
        }

        public int updateUser(User u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;          
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE user SET  username = @username, password=@password, type=@type Where id=@id";
                    command.Parameters.AddWithValue("@id", u.ID);
                    command.Parameters.AddWithValue("@username", u.username);
                    command.Parameters.AddWithValue("@password", u.password);
                    command.Parameters.AddWithValue("@type", u.type);

                    try
                    {
                        connection.Open();
                        recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                      
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return recordsAffected;
        }

        public User selectUser(int u)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;           
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * from user where id=@id";
                    command.Parameters.AddWithValue("@id", u);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                user = new User {
                                    ID = reader.GetInt32(0),
                                    username = reader.GetString(1),
                                    password= reader.GetString(2),
                                    type= reader.GetInt32(3)
                                };
                            
                        }
                    }
                    catch (SqlException)
                    {
                       
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return user;
        }

        public List<User> getAllUsers()
        {
            List<User> user = new List<User>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;           
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * from [user]";

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                user.Add(new User
                                {
                                    ID = int.Parse(reader["id"].ToString()),
                                    username = reader["username"].ToString(),
                                    password = reader["password"].ToString(),
                                    type = int.Parse(reader["type"].ToString())
                                }); ;

                        }
                    }
                    catch (SqlException e)
                    {
                       
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return user;
        }
    }
}
