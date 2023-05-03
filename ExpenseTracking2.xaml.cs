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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoinSensei
{
    /// <summary>
    /// Interaction logic for ExpenseTracking.xaml
    /// </summary>
    public partial class ExpenseTracking2: Window
    {
        public ExpenseTracking2()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Dashboard f = new Dashboard();
            f.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection("Data Source=FURITTSU\\SQL2022TRAINING;Initial Catalog=CoinSensei1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void Button_Click_ExpenseTrackingInsert(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("dbo.SP_ExpenseTracking_Insert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EntryNumber", int.Parse(EntryNumber.Text));
            com.Parameters.AddWithValue("@Description", Description.Text);
            com.Parameters.AddWithValue("@Amount", SqlMoney.Parse(Amount.Text));
            com.Parameters.AddWithValue("@Type", Type.Text);
            com.Parameters.AddWithValue("@DriveLinkReceipts", DriveLinkReceipts.Text);
            com.Parameters.AddWithValue("@Date", DateTime.Parse(Date.Text));
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully!");
            LoadAllRecords();
        }

        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.SP_ExpenseTracking_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGrid MyDataGrid = new DataGrid(); // create an instance of DataGrid control
            MyDataGrid.ItemsSource = dt.DefaultView;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadAllRecords();
        }

        private void Button_Click_ExpenseTrackingUpdate(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("dbo.SP_ExpenseTracking_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EntryNumber", int.Parse(EntryNumber.Text));
            com.Parameters.AddWithValue("@Description", Description.Text);
            com.Parameters.AddWithValue("@Amount", SqlMoney.Parse(Amount.Text));
            com.Parameters.AddWithValue("@Type", Type.Text);
            com.Parameters.AddWithValue("@DriveLinkReceipts", DriveLinkReceipts.Text);
            com.Parameters.AddWithValue("@Date", DateTime.Parse(Date.Text));
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully!");
            LoadAllRecords();
        }

        private void Button_Click_ExpenseTrackingDelete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you confirm to delete?", "Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                con.Open();
                SqlCommand com = new SqlCommand("dbo.SP_ExpenseTracking_Delete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EntryNumber", int.Parse(EntryNumber.Text));
                com.Parameters.AddWithValue("@Description", Description.Text);
                com.Parameters.AddWithValue("@Amount", SqlMoney.Parse(Amount.Text));
                com.Parameters.AddWithValue("@Type", Type.Text);
                com.Parameters.AddWithValue("@DriveLinkReceipts", DriveLinkReceipts.Text);
                com.Parameters.AddWithValue("@Date", DateTime.Parse(Date.Text));
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully!");
                LoadAllRecords();
            }
        }

        private void Button_Click_ExpenseTrackingSearch(object sender, RoutedEventArgs e)
        {
            SqlCommand com = new SqlCommand("dbo.SP_ExpenseTracking_Search", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EntryNumber", int.Parse(EntryNumber.Text));
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
    }
}
