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
    /// Логика взаимодействия для WorkerIndexPage.xaml
    /// </summary>
    public partial class WorkerIndexPage : Page
    {
        public WorkerIndexPage()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = AccountantEntitiesContext.GetContext().УчетСотрудников.ToList();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new WorkerAddEditPage(null));
        }
        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem != null)
            {
                УчетСотрудников worker = DGridClient.SelectedItem as УчетСотрудников;
                worker.Статус = !(worker.Статус);
                AccountantEntitiesContext.GetContext().SaveChanges();
                
            }
            PageLoaded(null, null);
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new WorkerAddEditPage(null));
        }

       
    }
}
