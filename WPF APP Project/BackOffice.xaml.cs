using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace WPF_APP_Project
{
    /// <summary>
    /// Interaction logic for BackOffice.xaml
    /// </summary>
    public partial class BackOffice : Window
    {
        public BackOffice()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OperationsAdmin addWindow = new OperationsAdmin();
            addWindow.Show();
            this.Close();
        }
        public void LoadGrid()
        {
            string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM employee";
                MySqlCommand cmd = new MySqlCommand(query, con);

                DataTable dt = new DataTable();

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }

                con.Close();

                datagrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name;
            string password;
            string email;
            string post;
            string id = idField.Text.ToString();

            OperationsAdmin admin = new OperationsAdmin(id);
            if (admin.RetrieveEmployeeData(id))
            {
                admin.Show();
                this.Close();
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string id = idField.Text.ToString();
            //Execute query to delete Employee
            string connectionString = "Server=localhost;Database=cs;User ID=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();

                string query = "Delete from employee WHERE id = @id ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    int result = int.Parse(id);
                    command.Parameters.AddWithValue("@id", result );

                    // Execute the query
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted ");
                    BackOffice bo = new BackOffice();
                    bo.Show();
                    this.Close();


                }
                connection.Close();
            }
        }
    }
}
    