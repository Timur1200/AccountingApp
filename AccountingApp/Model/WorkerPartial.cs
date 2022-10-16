using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Model
{
    partial class УчетСотрудников
    {
        public string Status
        {
            get
            {
                if (Статус)
                {
                    return "Работает";
                }else
                {
                    return "Уволен";
                }
            }
        }
    }
}
