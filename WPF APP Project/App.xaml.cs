using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_APP_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class Personne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poste { get; set; }
        public string Password { get; set; }
    }
    class Admin : Personne
    {
        private DbConnection dbConnection;

        public Admin()
        {
            dbConnection = new DbConnection();
        }

        public void InsertEmployeeData(string name, string poste, string password,string email)
        {
            string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO employee(name, password,post,email) VALUES (@name, @password, @post , @email)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@post", poste);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);

                    // Execute the query
                    command.ExecuteNonQuery();

                }
                connection.Close();
                
            }
            
        }


    }
}

