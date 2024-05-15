using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

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

        public bool InsertOrganisation(Organisation organisation)
        {
            bool success = false;

            try
            {
                
                int typeId = GetTypeIdByName(organisation.Type.ToString());

               
                
                string query = $"INSERT INTO organization (Name, Email, Password, Phone, Mission, TypeID) " +
                               $"VALUES ('{organisation.Name}', '{organisation.Email}', '{organisation.Password}', '{organisation.Phone}', '{organisation.Mission}', {typeId});";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    
                    connection.Open();

                    
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting organisation: " + ex.Message);
            }

            return success;
        }



        public bool DeleteUserAccount(int userId)
        {
            bool success = false;

            string query = "DELETE FROM donator WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
        public bool DeleteOrganisationAccount(int orgId)
        {
            bool success = false;

            string query = "DELETE FROM organization WHERE OrgID = @OrganizationID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@OrganizationID", orgId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }

        public List<Donator> FetchDonatorsFromDatabase()
        {
            List<Donator> donators = new List<Donator>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM donator";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["UserID"]);
                                string name = reader["Name"].ToString();
                                Donator donator = new Donator(name, id);
                               
                                donators.Add(donator);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching donators: " + ex.Message);
                    }
                }
            }

            return donators;
        }
        public List<Organisation> FetchOrganisationsFromDatabase()
        {
            List<Organisation> organisations = new List<Organisation>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM organization";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["OrgID"]);
                                string name = reader["Name"].ToString();
                                string email = reader["Email"].ToString();
                                string phone = reader["Phone"].ToString();
                                string mission = reader["Mission"].ToString();

                                Organisation organisation = new Organisation
                                {
                                    Name = name,
                                    OrganizationID = id,
                                    Email = email,
                                    Phone = phone,
                                    Mission = mission
                                };

                                organisations.Add(organisation);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching donators: " + ex.Message);
                    }
                }
            }

            return organisations;
        }

        public List<Event> FetchEventsFromDatabase()
        {
            List<Event> events= new List<Event>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM event";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["EventID"]);
                                string name = reader["Name"].ToString();
                                string description = reader["Description"].ToString();
                                Event ev = new Event
                                {
                                    Name = name,
                                    EventId = id,
                                    Description = description
                                };

                                events.Add(ev);
                            }
                          }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error fetching donators: " + ex.Message);
                    }
                }
            }

            return events;
        }


        private int GetTypeIdByName(string typeName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                MySqlCommand command = new MySqlCommand("SELECT TypeID FROM types WHERE Name = @Type", connection);
                command.Parameters.AddWithValue("@Type", typeName);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    return -1; 
                }
            }
        }
        private string GetTypeNameById(int typeID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT Name FROM types WHERE TypeID = @TypeID", connection);
                command.Parameters.AddWithValue("@TypeID", typeID);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0); // Index 0 refers to the first (and only) column in the result set
                    }
                    return null; // If no matching type ID found
                }
            }
        }
       
        public bool UpdateEvent(Event updatedEvent)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE event SET Name = @Name, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE EventID = @EventID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", updatedEvent.Name);
                    command.Parameters.AddWithValue("@Description", updatedEvent.Description);
                    command.Parameters.AddWithValue("@StartDate", updatedEvent.StartDate);
                    command.Parameters.AddWithValue("@EndDate", updatedEvent.EndDate);
                    command.Parameters.AddWithValue("@EventID", updatedEvent.EventId);

                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0; // Check if any rows were affected
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating event: " + ex.Message);
                }
            }

            return success;
        }
        public bool DonateToEvent(int eventId, decimal donationAmount)
        {
            bool donationAdded = false;

            // Open a connection to the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve the current amount raised for the event
                string selectQuery = "SELECT CurrentAmountRaised FROM event WHERE EventID = @EventId";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@EventId", eventId);
                decimal currentRaisedAmount = Convert.ToDecimal(selectCommand.ExecuteScalar());

                // Add the donation amount to the current raised amount
                decimal newRaisedAmount = currentRaisedAmount + donationAmount;

                // Update the database with the new raised amount
                string updateQuery = "UPDATE event SET CurrentAmountRaised = @RaisedAmount WHERE EventID = @EventId";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@RaisedAmount", newRaisedAmount);
                updateCommand.Parameters.AddWithValue("@EventId", eventId);
                int rowsAffected = updateCommand.ExecuteNonQuery();

                // Check if the donation was successfully added
                donationAdded = rowsAffected > 0;
            }

            return donationAdded;
        }



        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    string query = "SELECT * FROM event";

                    // Create a command object
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and read the results
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Read each row and create an Event object
                            while (reader.Read())
                            {
                                Event ev = new Event
                                {
                                    EventId = reader.GetInt32(reader.GetOrdinal("EventID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    Description=reader.GetString(reader.GetOrdinal("Description"))
                                };

                                events.Add(ev);
                            }
                        }
                    }
                }
            

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Event>(); // Return an empty list in case of an error
            }
            return events;
        }
        public List<Event> GetOrgEvents(Organisation organisation)
        {
            List<Event> events = new List<Event>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    string query = $"SELECT EventID, Name, StartDate, EndDate, Description FROM event WHERE OrganizerID = {organisation.OrganizationID}";

                    // Create a command object
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and read the results
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Read each row and create an Event object
                            while (reader.Read())
                            {
                                Event ev = new Event
                                {
                                    EventId = reader.GetInt32(reader.GetOrdinal("EventID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    Description = reader.GetString(reader.GetOrdinal("Description"))
                                };

                                events.Add(ev);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Event>(); // Return an empty list in case of an error
            }
            return events;
        }

        public bool UpdateUserInfo(Donator donator)
        {
            bool success = false;
            string query = $"UPDATE donator SET Name = '{donator.Name}', LastName = '{donator.LastName}', Email = '{donator.Email}' WHERE UserID = {donator.UserID}";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                    MySqlCommand command = new MySqlCommand(query, connection);

                    try
                    {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            success = rowsAffected > 0;
                    }
                    catch (Exception ex) 
                     {
                    Console.WriteLine(ex.Message);
                     }


            }
            

            return success;
        }
        public bool UpdateOrganisationInfo(Organisation organisation)
        {
            bool success = false;
            string query = $"UPDATE organization SET Name = '{organisation.Name}', Email = '{organisation.Email}', Phone = '{organisation.Phone}', Mission = '{organisation.Mission}' WHERE OrgID = {organisation.OrganizationID}";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }


            return success;
        }

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
        public bool UpdateUserPassword(int userId, string newPassword)
        {
            bool success = false;

            string query = "UPDATE donator SET Password = @Password WHERE UserID = @UserID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Password", newPassword);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
        public bool UpdateOrganisationPassword(int OrgId, string newPassword)
        {
            bool success = false;

            string query = "UPDATE organization SET Password = @Password WHERE OrgID = @OrgID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Password", newPassword);
                command.Parameters.AddWithValue("@OrgID", OrgId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

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
                        int orgID = reader.GetInt32("OrgID");
                        string typeName = GetTypeNameById(reader.GetInt32("TypeID")); // Assuming TypeID is stored in the Organization table

                        // Parse the type name to the corresponding enum value
                        Types type = (Types)Enum.Parse(typeof(Types), typeName);

                        return new Organisation
                        {
                            OrganizationID = orgID,
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
                        return new Donator(
                        
                            reader.GetInt32("UserID"),
                            reader.GetString("LastName"),
                            reader.GetString("Name"),
                            reader.GetString("Email"),
                            reader.GetString("Password")
                        );
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
        public Event GetEventById(int eventid)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * WHERE EventID = @EventID", connection);
                command.Parameters.AddWithValue("@EventID", eventid);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Event
                            {
                                EventId = reader.GetInt32("EventID"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                StartDate= reader.GetDateTime("StartDate"),
                                EndDate=reader.GetDateTime("EndDate")

                            };
                        }
                        else
                        {
                            return null; // No matching 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to retrieve event: " + ex.Message);
                    return null;
                }
            }
        }
        public bool AddEvent(Event newEvent)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Event (Name, Description, OrganizerID, StartDate, EndDate) " +
                               "VALUES (@Name, @Description, @OrganizerID, @StartDate, @EndDate)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", newEvent.Name);
                command.Parameters.AddWithValue("@Description", newEvent.Description);
                //command.Parameters.AddWithValue("@TargetAmount", newEvent.TargetAmount);
                //command.Parameters.AddWithValue("@CurrentAmountRaised", newEvent.CurrentAmountRaised);
                command.Parameters.AddWithValue("@OrganizerID", newEvent.OrgId);
                command.Parameters.AddWithValue("@StartDate", newEvent.StartDate);
                command.Parameters.AddWithValue("@EndDate", newEvent.EndDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return success;
        }

    }
}
