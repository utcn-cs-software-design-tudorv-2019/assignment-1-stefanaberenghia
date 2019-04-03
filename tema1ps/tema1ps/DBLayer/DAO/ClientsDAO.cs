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
    class ClientsDAO
    {
        string address = "Data Source=(local);Initial Catalog=tema1ps;Integrated Security=True";

        public int addClientInfo(ClientInfo u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into clientInfo  VALUES (@id, @name, @card, @cnp)";
                    command.Parameters.AddWithValue("@id", u.userID);
                    command.Parameters.AddWithValue("@name", u.name);
                    command.Parameters.AddWithValue("@card", u.identityCardNr);
                    command.Parameters.AddWithValue("@cnp", u.CNP);

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

        public int deleteClientInfo(int u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE clientInfo Where userID=@id";
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

        public int updateClientInfo(ClientInfo u)
        {
            int recordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE clientInfo SET  name = @name, identityCardNumber=@identityCardNumber, CNP=@CNP, adress=@adress Where userID=@id";
                    command.Parameters.AddWithValue("@id", u.userID);
                    command.Parameters.AddWithValue("@name", u.name);
                    command.Parameters.AddWithValue("@identityCardNumber", u.identityCardNr);
                    command.Parameters.AddWithValue("@CNP", u.CNP);
                    command.Parameters.AddWithValue("@adress", u.adress);

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

        public ClientInfo selectClientInfo(int u)
        {
            ClientInfo user = new ClientInfo();
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * from clientInfo Where userID=@id";
                    command.Parameters.AddWithValue("@id", u);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                user = new ClientInfo
                                {
                                    userID = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    identityCardNr = reader.GetInt32(2),
                                    CNP = reader.GetInt32(3),
                                    adress= reader.GetString(4)
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

        public List<ClientInfo> getAllClientInfo()
        {
            List<ClientInfo> user = new List<ClientInfo>();
            using (SqlConnection connection = new SqlConnection(address))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * from clientInfo";

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                user.Add(new ClientInfo
                                {
                                    userID = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    identityCardNr = reader.GetInt32(2),
                                    CNP = reader.GetInt32(3),
                                    adress= reader.GetString(4)
                                }); 

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
    }
}