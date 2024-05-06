using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class Data
    {
        private string connectionString = "datasource=127.0.0.1; port=3306; username = root; password=; database=donatify;";


        //test if its connected
        public bool TestConnection()
        {
            bool isConnected = false;
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=donatify;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    isConnected = true; // Successfully connected
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            return isConnected;
        }
        //opening a connection
        private int Insert(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, connection);


            try
            {
                connection.Open();
                int result = commandDatabase.ExecuteNonQuery();

                return (int)commandDatabase.LastInsertedId;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return -1; //closing the connection
        }
        public Admin GetAdminByEmail(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT AdminID, Email, Password FROM Admin WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Admin
                            {
                                AdminID = reader.GetInt32("AdminID"),
                                Email = reader.GetString("Email"),
                                Password = reader.GetString("Password")
                            };
                        }
                        else
                        {
                            return null; // No matching admin
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to retrieve admin: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
