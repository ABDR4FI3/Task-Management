using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Windows;
using System.Data;

namespace WPF_APP_Project
{
    public class DbConnection
    {
        // Replace this connection string with your actual connection string
        private string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";

        //Methode to check Credentials for Log in
        public bool CheckCredentials(string username, string password,out String post)
        {
            post = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*), post FROM employee WHERE name = @Username AND password = @Password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows in the result set
                        if (reader.HasRows)
                        {
                            // Read the first row
                            reader.Read();
                            // Retrieve the count and post values
                            int count = reader.GetInt32(0); // Assuming count is the first column
                            post = reader.IsDBNull(1) ? null : reader.GetString(1); // Assuming post is the second column
                            // Now 'count' and 'post' contain the values from the query result
                            return count > 0;
                            
                        }
                        else
                        {
                            return false; // User not found or invalid credentials
                        }
                    }
                }
            }
        }
        //methode To Insert 
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }


}
