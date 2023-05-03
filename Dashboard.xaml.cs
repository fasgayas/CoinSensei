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

namespace CoinSensei
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Button_Click_ExpenseTracking(object sender, RoutedEventArgs e)
        {
            ExpenseTracking g = new ExpenseTracking();
            g.Show();
            this.Hide();
        }

        private void Button_Click_FinancialDetails(object sender, RoutedEventArgs e)
        {
            FinancialDetails h = new FinancialDetails();
            h.Show();
            this.Hide();
        }

        private void Button_Click_IncomeStream(object sender, RoutedEventArgs e)
        {
            IncomeStream2 i = new IncomeStream2();
            i.Show();
            this.Hide();
        }

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Hide();    
        }
    }
}
