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
using Word = Microsoft.Office.Interop.Word;

namespace AccountingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PayCheckPage.xaml
    /// </summary>
    public partial class PayCheckPage : Page
    {
        public PayCheckPage(УчетСотрудников worker)
        {
            InitializeComponent();
            if (worker == null) PageNavigator.Back();
            _worker = worker;
            
        }
        УчетСотрудников _worker;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {if (Session.User.Должность.Код != 1)
            {
                Btn1.Visibility = Visibility.Collapsed;
                Btn2.Visibility = Visibility.Collapsed;
            }
            TBlockFio.Text = _worker.Фио;
            DGridClient.ItemsSource = AccountantEntitiesContext.GetContext().РасчетныйЛист.Where(q => q.КодСотрудника == _worker.Код).OrderByDescending(q => q.Дата).ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new PayCheckAddEditPage(null,_worker));
        }

        private void InfoPayCheckClick(object sender, RoutedEventArgs e)
        {
            PageNavigator.Frame.Navigate(new InfoPayCheckPage(DGridClient.SelectedItem as РасчетныйЛист));
        }
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/WordFile.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void WordClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись");
                return;
            }
            РасчетныйЛист payCheck = DGridClient.SelectedItem as РасчетныйЛист;
            int? sum1 = payCheck.Дни * payCheck.УчетСотрудников.Должность.ЗарплатаВДень;
            int? sum2 = payCheck.Сумма * 13 / 100;
            int? sum3 = payCheck.Сумма - sum2;
            var listInfo = AccountantEntitiesContext.GetContext().ПодробностиРасчетногоЛиста.Where(q => q.КодРасчетногоЛиста == payCheck.Код).ToList();
            string text = "";
            foreach (var item in listInfo)
            {
                text += $"{item}; ";
            }
            var wordApp = new Word.Application();

            wordApp.Visible = false;
            var wordDocument = wordApp.Documents.Open(TemplateFileName);
            ReplaceWordStub("Id",$"{payCheck.Код}", wordDocument);
            ReplaceWordStub("date", $"{payCheck.Date}", wordDocument);
            ReplaceWordStub("date", $"{payCheck.Date}", wordDocument);
            ReplaceWordStub("Fio", $"{payCheck.УчетСотрудников.Фио}", wordDocument);
            ReplaceWordStub("dni", $"{payCheck.Дни}", wordDocument);
            ReplaceWordStub("Array", $"{text}", wordDocument);
            ReplaceWordStub("sum1", $"{sum1}", wordDocument);
            ReplaceWordStub("sum2", $"{sum2}", wordDocument);
            ReplaceWordStub("sum3", $"{sum3}", wordDocument);

            wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/{Guid.NewGuid()}.docx"));

            wordApp.Visible = true;
        }
    }
}
