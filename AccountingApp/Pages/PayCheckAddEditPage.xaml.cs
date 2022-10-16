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
    /// Логика взаимодействия для PayCheckAddEditPage.xaml
    /// </summary>
    public partial class PayCheckAddEditPage : Page
    {
        public PayCheckAddEditPage(РасчетныйЛист расчетныйЛист,УчетСотрудников worker)
        {
            InitializeComponent();
            if (расчетныйЛист == null)
            {
                _PayCheck = new РасчетныйЛист { Дата = DateTime.Now,
                УчетСотрудников = worker,
                };
            }
            else
            {
                _PayCheck = расчетныйЛист;
            }
            DataContext = _PayCheck;
        }
        private bool IsReady = false;
        private РасчетныйЛист _PayCheck;
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (!IsReady)
            {
                MessageBox.Show("Введено некорректное число");
                return;
            }
            _PayCheck.Сумма = Convert.ToInt32(TBoxSum.Text);
            if (_PayCheck.Код == 0)
                AccountantEntitiesContext.GetContext().РасчетныйЛист.Add(_PayCheck);
            AccountantEntitiesContext.GetContext().SaveChanges();
            MessageBox.Show("Расчетный лист создан");
            PageNavigator.Back();
        }
       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = (sender as TextBox).Text;
            bool result = int.TryParse(a, out var number);
            if (result)
            {
                TBoxSum.Text = $"{number*_PayCheck.УчетСотрудников.Должность.ЗарплатаВДень}";
                IsReady = true;
            }
            else
            {
                IsReady = false;
            }
        }
    }
}
