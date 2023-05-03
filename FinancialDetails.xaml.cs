using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace CoinSensei
{
    /// <summary>
    /// Interaction logic for FinancialDetails.xaml
    /// </summary>
    public partial class FinancialDetails : Window
    {
        public FinancialDetails()
        {
            InitializeComponent();
        }

        private void Button_Click_FinancialDetailsBack(object sender, RoutedEventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();
        }

        private void Button_Click_FinancialDetailsInsert(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO FinancialDetails(financialID,wishlist,liabilities,financialGoal,earnings) VALUES (@financialID,@wishlist,@liabilities,@financialGoal,@earnings)", con);
            cmd.Parameters.AddWithValue("@financialID", int.Parse(FinancialID.Text));
            cmd.Parameters.AddWithValue("@wishlist", Wishlist.Text);
            cmd.Parameters.AddWithValue("@liabilities", Liabilities.Text);
            cmd.Parameters.AddWithValue("@financialGoal", FinancialGoal.Text);
            cmd.Parameters.AddWithValue("@earnings", Earnings.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            FinancialID.Text = "";
            Wishlist.Text = "";
            Liabilities.Text = "";
            FinancialGoal.Text = "";
            Earnings.Text = "";

            MessageBox.Show("Successfully Inserted!");
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM FinancialDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }

        private void Button_Click_FinancialDetailsUpdate(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            
            SqlCommand cmd = new SqlCommand("UPDATE FinancialDetails SET wishlist=@wishlist,liabilities=@liabilities,financialGoal=@financialGoal,earnings=@earnings where financialID=@financialID", con);
            cmd.Parameters.AddWithValue("@financialID", int.Parse(FinancialID.Text));
            cmd.Parameters.AddWithValue("@wishlist", Wishlist.Text);
            cmd.Parameters.AddWithValue("@liabilities", Liabilities.Text);
            cmd.Parameters.AddWithValue("@financialGoal", FinancialGoal.Text);
            cmd.Parameters.AddWithValue("@earnings", Earnings.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            FinancialID.Text = "";
            Wishlist.Text = "";
            Liabilities.Text = "";
            FinancialGoal.Text = "";
            Earnings.Text = "";

            MessageBox.Show("Successfully Updated!");
        }

        private void Button_Click_FinancialDetailsDelete(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FinancialDetails WHERE financialID=@financialID", con);
            cmd.Parameters.AddWithValue("@financialID", int.Parse(FinancialID.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            FinancialID.Text = "";
            Wishlist.Text = "";
            Liabilities.Text = "";
            FinancialGoal.Text = "";
            Earnings.Text = "";
            
            MessageBox.Show("Successfully Deleted!");
        }

        private void Button_Click_FinancialDetailsSearch(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM FinancialDetails WHERE financialID=@financialID", con);
            cmd.Parameters.AddWithValue("@financialID", int.Parse(FinancialID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }
    }
}
