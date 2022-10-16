using AccountingApp.Pages;
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
    /// Логика взаимодействия для AppWin.xaml
    /// </summary>
    public partial class AppWin : Window
    {
        public AppWin()
        {
            InitializeComponent();
            PageNavigator.Frame = MainFrame;
            if (Session.User.КодДолжности == 1)
            {
                AdminPanel.Visibility = Visibility.Visible;
                UserPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                UserPanel.Visibility = Visibility.Visible;
                PageNavigator.Frame.Navigate(new PayCheckPage(Session.User));
            }
            TextBlock1.Text = $"{Session.User.Фио}. Должность: {Session.User.Должность.Имя}";
        }

        private void LeaveClick(object sender, RoutedEventArgs e)
        {
            LoginWin loginWin = new LoginWin();
            loginWin.Show();
            this.Close(); 
        }

        private void PositionClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new IndexPositionPage());
        }

        private void WorkerClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerIndexPage());
        }

        private void SalaryClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new IndexSalaryPage());
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Back();
        }
    }
}
