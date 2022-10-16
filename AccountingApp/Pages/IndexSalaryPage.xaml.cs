using AccountingApp.Model;
using AccountingApp.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для IndexSalaryPage.xaml
    /// </summary>
    public partial class IndexSalaryPage : Page
    {
        public IndexSalaryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = AccountantEntitiesContext.GetContext().УчетСотрудников.Where(q => q.Статус == true).ToList();
        }

        private void PayCheckClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            PageNavigator.Frame.Navigate(new PayCheckPage(DGridClient.SelectedItem as УчетСотрудников)); 
        }
    }
}
