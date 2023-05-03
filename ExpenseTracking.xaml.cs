using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoinSensei
{
    /// <summary>
    /// Interaction logic for ExpenseTracking.xaml
    /// </summary>
    public partial class ExpenseTracking : Window
    {
        public ExpenseTracking()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();
        }

        private void Button_Click_ExpenseTrackingInsert(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO ExpenseTracking(entryNumber,description,amount,type,driveLinkReceipts,date) VALUES (@entryNumber,@description,@amount,@type,@driveLinkReceipts,@date)"    , con);
            cmd.Parameters.AddWithValue("@entryNumber", int.Parse(EntryNumber.Text));
            cmd.Parameters.AddWithValue("@description", Description.Text);
            cmd.Parameters.AddWithValue("@amount", Amount.Text);
            cmd.Parameters.AddWithValue("@type", Type.Text);
            cmd.Parameters.AddWithValue("@driveLinkReceipts", DriveLinkReceipts.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(Date.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            EntryNumber.Text = "";
            Description.Text = "";
            Amount.Text = "";
            Type.Text = "";
            DriveLinkReceipts.Text = "";
            Date.Text = "";

            MessageBox.Show("Successfully Inserted!");
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM ExpenseTracking", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }

        private void Button_Click_ExpenseTrackingUpdate(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE ExpenseTracking SET description=@description,amount=@amount,type=@type,driveLinkReceipts=@driveLinkReceipts,date=@date where entryNumber=@entryNumber", con);
            cmd.Parameters.AddWithValue("@entryNumber", int.Parse(EntryNumber.Text));
            cmd.Parameters.AddWithValue("@description", Description.Text);
            cmd.Parameters.AddWithValue("@amount", Amount.Text);
            cmd.Parameters.AddWithValue("@type", Type.Text);
            cmd.Parameters.AddWithValue("@driveLinkReceipts", DriveLinkReceipts.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(Date.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            EntryNumber.Text = "";
            Description.Text = "";
            Amount.Text = "";
            Type.Text = "";
            DriveLinkReceipts.Text = "";
            Date.Text = "";

            MessageBox.Show("Successfully Updated!");
        }

        private void Button_Click_ExpenseTrackingDelete(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE ExpenseTracking WHERE entryNumber=@entryNumber", con);
            cmd.Parameters.AddWithValue("@entryNumber", int.Parse(EntryNumber.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            EntryNumber.Text = "";
            Description.Text = "";
            Amount.Text = "";
            Type.Text = "";
            DriveLinkReceipts.Text = "";
            Date.Text = "";

            MessageBox.Show("Successfully Deleted!");
        }

        private void Button_Click_ExpenseTrackingSearch(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM ExpenseTracking WHERE entryNumber=@entryNumber", con);
            cmd.Parameters.AddWithValue("@entryNumber", int.Parse(EntryNumber.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            MyDataGrid.ItemsSource = dv;
        }
    }
}
