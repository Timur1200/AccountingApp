using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Model
{
     partial class ПодробностиРасчетногоЛиста
    {
        public override string ToString()
        {
            return $"{Имя}  {Сумма} руб";
        }
    }
}
