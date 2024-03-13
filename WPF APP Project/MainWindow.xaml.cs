using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_APP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Boutton Click Event => Check values and redirect to next Page 

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string post = null;
            System.Console.WriteLine(username + ":" + password);

            // Call a method to check credentials and open the next window
            if (CheckCredentials(username, password,out post))
            {
                MessageBox.Show($"This account belongs to :  Post: {post}");
                // Open the next window
                BackOffice AdminHome = new BackOffice();
                AdminHome.Show();

                // Close the current window
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.");
            }
        }

        private bool CheckCredentials(string username, string password,out string post )
        {
            // Instantiate the DbConnection class
            DbConnection dbConnection = new DbConnection();

            //post = null;
            // Use the CheckCredentials method from the DbConnection class
            return dbConnection.CheckCredentials(username, password,out post);
        }

    
    }
}


