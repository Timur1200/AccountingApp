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
    /// Логика взаимодействия для InfoPayCheckPage.xaml
    /// </summary>
    public partial class InfoPayCheckPage : Page
    {
        public InfoPayCheckPage(РасчетныйЛист расчетныйЛист)
        {
            InitializeComponent();
            _paycheck = расчетныйЛист;
            _Info = new ПодробностиРасчетногоЛиста { РасчетныйЛист = расчетныйЛист };
            DataContext = _Info;
            TBlockPayCheck.Text = $"Номер расчетного листа {расчетныйЛист.Код}";
        }
        private РасчетныйЛист _paycheck;
        private ПодробностиРасчетногоЛиста _Info;
        

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LBox1.ItemsSource = AccountantEntitiesContext.GetContext().ПодробностиРасчетногоЛиста.Where(q => q.КодРасчетногоЛиста == _paycheck.Код).ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (_Info.Сумма == null || _Info.Имя == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения!");
                return;
            }
            AccountantEntitiesContext.GetContext().ПодробностиРасчетногоЛиста.Add(_Info);
            _paycheck.Сумма += _Info.Сумма;
            AccountantEntitiesContext.GetContext().SaveChanges();
            _Info = new ПодробностиРасчетногоЛиста { РасчетныйЛист = _paycheck };
            PageNavigator.Frame.Navigate(new InfoPayCheckPage(_paycheck));
           // PageNavigator.Frame.R();
        }
        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (LBox1.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            _paycheck.Сумма -= (LBox1.SelectedItem as ПодробностиРасчетногоЛиста).Сумма;
            AccountantEntitiesContext.GetContext().ПодробностиРасчетногоЛиста.Remove(LBox1.SelectedItem as ПодробностиРасчетногоЛиста);
            AccountantEntitiesContext.GetContext().SaveChanges();
            PageLoaded(null, null);
        }
    }
}
