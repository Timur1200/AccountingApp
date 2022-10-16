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
    /// Логика взаимодействия для AddEditPositionPage.xaml
    /// </summary>
    public partial class AddEditPositionPage : Page
    {
        public AddEditPositionPage(Должность p)
        {
            InitializeComponent();
            if (p == null)
            {
                _pos = new Должность();
            }
            else
            {
                _pos = p;
            }
            DataContext = _pos;
        }
        private Должность _pos;
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_pos.Код == 0) AccountantEntitiesContext.GetContext().Должность.Add(_pos);
            AccountantEntitiesContext.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            PageNavigator.Back();
        }
    }
}
