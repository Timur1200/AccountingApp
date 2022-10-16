using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Model
{
    partial class AccountantEntitiesContext
    {
        private static AccountantEntitiesContext _context;
        public static AccountantEntitiesContext GetContext()
        {
            if (_context == null) _context = new AccountantEntitiesContext();
            return _context;
        }
    }
}
