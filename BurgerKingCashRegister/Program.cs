using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class Program
    {
        // user can view orders from a specific date (read from text file)
        // set inventory and, once item reaches zero, it can no longer be ordered and is hidden

        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.DisplayMenu();
        }
    }
}
