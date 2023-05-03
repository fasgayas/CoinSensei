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
using System.Windows.Markup;

namespace CoinSensei
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(Age.Text) ||
                string.IsNullOrEmpty(Occupation.Text) ||
                string.IsNullOrEmpty(Email.Text) ||
                string.IsNullOrEmpty(GoogleDriveLink.Text) ||
                string.IsNullOrEmpty(Username.Text) ||
                string.IsNullOrEmpty(Password.Text))
                {
                    MessageBox.Show("Please fill in all the required fields.");
                    return;
                }

                SqlConnection conn = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlDataAdapter adapter = new SqlDataAdapter("UserInsert", conn);
                conn.Open();

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id.Text;
                adapter.SelectCommand.Parameters.Add("@Name", SqlDbType.VarChar, (50)).Value = Name.Text;
                adapter.SelectCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age.Text;
                adapter.SelectCommand.Parameters.Add("@Occupation", SqlDbType.VarChar, (50)).Value = Occupation.Text;
                adapter.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar, (50)).Value = Email.Text;
                adapter.SelectCommand.Parameters.Add("@GoogleDriveLink", SqlDbType.VarChar, (200)).Value = GoogleDriveLink.Text;
                adapter.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar, (50)).Value = Username.Text;
                adapter.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar, (50)).Value = Password.Text;
                adapter.SelectCommand.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("User inserted successfully!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
            this.Hide();
        }
    }
}

