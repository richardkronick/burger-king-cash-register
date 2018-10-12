using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate a Menu object
            var menu = new Menu();
            // Display welcome screen
            Console.WriteLine("\nWelcome to Burger King! Here is the menu:\n");
            menu.DisplayMenu();
            Console.Read();
        }
    }
}
