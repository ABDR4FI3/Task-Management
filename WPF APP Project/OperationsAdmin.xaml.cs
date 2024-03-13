using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_APP_Project
{
    /// <summary>
    /// Interaction logic for OperationsAdmin.xaml
    /// </summary>
    public partial class OperationsAdmin : Window
    {
        public string id ;
        public OperationsAdmin(string id = "0")
        {

            InitializeComponent();
            this.id = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = name.Text;
            string password = passwordField.Password;
            string Post = role.Text;
            string mail = email.Text;
            Admin a = new Admin();
            if (username != null && password != null && Post != null && mail != null && mail != null)
            {
                a.InsertEmployeeData(username, password, Post, mail);
                BackOffice bo = new BackOffice();
                bo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill the inputs");
            }

        }
        public bool RetrieveEmployeeData(string id)
        {
            string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT name, post, password, email FROM employee WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming you have textboxes named nameTextBox, roleTextBox, passwordBox, emailTextBox
                            name.Text = reader["name"].ToString();
                            role.Text = reader["post"].ToString();
                            passwordField.Password = reader["password"].ToString(); ;
                            email.Text = reader["email"].ToString();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("User not found");
                            return false;
                        }
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string username = name.Text;
                string password = passwordField.Password;
                string Post = role.Text;
                string mail = email.Text;
                connection.Open();

                string query = "Update employee set name = @name , password = @password , post = @post , email = @email where id = @id ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", username);
                    command.Parameters.AddWithValue("@post", Post);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", mail);
                    command.Parameters.AddWithValue("@id", id);

                    // Execute the query
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated ");
                    BackOffice bo = new BackOffice();
                    bo.Show();
                    this.Close();


                }
                connection.Close();

            }
        }
    }
}


    
