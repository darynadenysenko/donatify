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

        //////////////////////////////

        public bool InsertDonator(Donator donator)
        {
            bool success = false;

            string query = $"INSERT INTO donator(Name, LastName, Email, Password) " +
                           $"VALUES ('{donator.Name}', '{donator.LastName}', '{donator.Email}', '{donator.Password}');";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
        public Organisation GetOrganizationByEmail(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                MySqlCommand command = new MySqlCommand("SELECT * FROM Organization WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Types type = (Types)Enum.Parse(
                        typeof(Types), reader.GetString("Type"));
                        return new Organisation
                        {
                            OrganizationID = reader.GetInt32("OrganizationID"),
                            Name = reader.GetString("Name"),
                            Phone = reader.GetString("Phone"),
                            Email = reader.GetString("Email"),
                            Password = reader.GetString("Password"),
                            Mission = reader.GetString("Mission"),
                            Type = type
                        };
                    }
                    return null; // No organization with this email
                }
            }

        }
        public Donator GetDonatorByEmail(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                MySqlCommand command = new MySqlCommand("SELECT * FROM Donator WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Donator
                        {
                            //UserID = reader.GetInt32("UserID"),
                            LastName = reader.GetString("LastName"),
                            Name = reader.GetString("Name"),
                            Email = reader.GetString("Email"),
                            Password = reader.GetString("Password")
                        };
                    }
                    return null; // No user with this email
                }
            }
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
