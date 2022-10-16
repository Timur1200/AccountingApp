using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Model
{
   partial class РасчетныйЛист
    {
        public string Date
        {
            get
            {
                return Дата.Value.ToString("Y");
            }
        }
    }
}
