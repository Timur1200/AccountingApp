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
    /// Логика взаимодействия для IndexPositionPage.xaml
    /// </summary>
    public partial class IndexPositionPage : Page
    {
        public IndexPositionPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = AccountantEntitiesContext.GetContext().Должность.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new AddEditPositionPage(null));
        }
        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem != null)
            {
                try
                {
                    AccountantEntitiesContext.GetContext().Должность.Remove(DGridClient.SelectedItem as Должность);
                    AccountantEntitiesContext.GetContext().SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Данную запись удалить нельзя");
                }
               
            }
            Page_Loaded(null, null);

        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new AddEditPositionPage(DGridClient.SelectedItem as Должность));
        }
    }
}
