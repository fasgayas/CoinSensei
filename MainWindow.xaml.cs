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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinSensei
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

        private void Button_Click_SignUpNow(object sender, RoutedEventArgs e)
        {
            SignUpWindow s1 = new SignUpWindow();
            s1.Show();
            this.Hide();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            SqlConnection conn = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter adapter = new SqlDataAdapter("loginScreen", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;
            adapter.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
            adapter.SelectCommand.Parameters.Add("@match", SqlDbType.Bit).Direction = ParameterDirection.Output;

            conn.Open();
            adapter.SelectCommand.ExecuteNonQuery();
            bool match = (bool)adapter.SelectCommand.Parameters["@match"].Value;
            conn.Close();

            if (match)
                {
                // Navigate to the dashboard screen
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
                }
                else
                {
                // Display error message
                MessageBox.Show("Invalid username or password");
                }
        }

    }
}
