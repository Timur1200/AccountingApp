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
        private List<УчетСотрудников> _list;
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            _list = AccountantEntitiesContext.GetContext().УчетСотрудников.ToList();
            DGridClient.ItemsSource = _list;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text == "")
            {
                PageLoaded(null, null);
                return;
            }
            string text = TBoxSearch.Text.ToLower();
            var list = _list.Where(q => q.Фио.ToLower().Contains(text) 
            || q.Должность.Имя.ToLower().Contains(text));
            DGridClient.ItemsSource = list;
        }
    }
}
