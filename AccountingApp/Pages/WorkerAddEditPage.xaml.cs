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
    /// Логика взаимодействия для WorkerAddEditPage.xaml
    /// </summary>
    public partial class WorkerAddEditPage : Page
    {
        public WorkerAddEditPage(УчетСотрудников worker)
        {
            InitializeComponent();
            if (worker == null)
            {
                _worker = new УчетСотрудников { Статус=true};
            }
            else
            {
                _worker = worker;
            }
            DataContext = _worker;
        }
        private УчетСотрудников _worker;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PositionCBox.ItemsSource = AccountantEntitiesContext.GetContext().Должность.ToList();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_worker.Код == 0) AccountantEntitiesContext.GetContext().УчетСотрудников.Add(_worker);
            AccountantEntitiesContext.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            PageNavigator.Back();
        }
    }
}
