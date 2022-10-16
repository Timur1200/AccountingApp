using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AccountingApp.Service
{
    internal class PageNavigator
    {
        public static Frame Frame { get; set; }

        public static void Back()
        {
            if (Frame.NavigationService.CanGoBack) Frame.NavigationService.GoBack();
        }
    }
}
