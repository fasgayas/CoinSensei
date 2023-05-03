using Microsoft.VisualBasic;
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
    /// Interaction logic for IncomeStream2.xaml
    /// </summary>
    public partial class IncomeStream2 : Window
    {
        public IncomeStream2()
        {
            InitializeComponent();
        }

        private void Button_Click_IncomeStream2Back(object sender, RoutedEventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();
        }

        private void Button_Click_IncomeStream2Insert(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            string status = "";
            if(Unemployed.IsChecked == true)
            {
                status = Unemployed.Content.ToString();
            }
            else
            {
                status = Self_Employed.Content.ToString();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO IncomeStream(incomeID,categories,allocation,remarks,status) VALUES (@incomeID,@categories,@allocation,@remarks,@status)", con);

            cmd.Parameters.AddWithValue("@incomeID", int.Parse(IncomeID.Text));
            cmd.Parameters.AddWithValue("@categories", Categories.Text);    
            cmd.Parameters.AddWithValue("@allocation", Allocation.Text);   
            cmd.Parameters.AddWithValue("@remarks", Remarks.Text);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();

            IncomeID.Text = "";
            Categories.Text = "";
            Allocation.Text = "";
            Remarks.Text = "";
            status = "";

            MessageBox.Show("Successfully Inserted!");
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM IncomeStream", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }

        private void Button_Click_IncomeStream2Update(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            string status = "";
            if (Unemployed.IsChecked == true)
            {
                status = Unemployed.Content.ToString();
            }
            else
            {
                status = Self_Employed.Content.ToString();
            }

            SqlCommand cmd = new SqlCommand("UPDATE IncomeStream SET categories=@categories,allocation=@allocation,remarks=@remarks,status=@status where incomeID=@incomeID", con);

            cmd.Parameters.AddWithValue("@incomeID", int.Parse(IncomeID.Text));
            cmd.Parameters.AddWithValue("@categories", Categories.Text);
            cmd.Parameters.AddWithValue("@allocation", Allocation.Text);
            cmd.Parameters.AddWithValue("@remarks", Remarks.Text);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();

            IncomeID.Text = "";
            Categories.Text = "";
            Allocation.Text = "";
            Remarks.Text = "";
            status = "";

            MessageBox.Show("Successfully Updated!");
        }

        private void Button_Click_IncomeStream2Delete(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE IncomeStream WHERE incomeID=@incomeID", con);
            cmd.Parameters.AddWithValue("@incomeID", int.Parse(IncomeID.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Deleted!");
        }

        private void Button_Click_IncomeStream2Search(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM IncomeStream WHERE incomeID=@incomeID", con);
            cmd.Parameters.AddWithValue("@incomeID", int.Parse(IncomeID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }
    }
}
