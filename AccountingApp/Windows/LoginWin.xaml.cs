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
using System.Windows.Shapes;

namespace AccountingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var Users = AccountantEntitiesContext.GetContext().УчетСотрудников.ToList();
            foreach(var item in Users)
            {
                if (item.Телефон == TBoxPhone.Text && item.Пароль == PassBox.Password)
                {
                    Session.User = item;
                    AppWin appWin = new AppWin();
                    appWin.Show();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Пользователь не найден");
        }
    }
}
