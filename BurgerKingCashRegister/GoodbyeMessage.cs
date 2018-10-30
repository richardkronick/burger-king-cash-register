using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class GoodbyeMessage
    {
        internal void ThankYouMessage()
        {
            Console.Clear();
            Console.WriteLine("\n-----------------------------------------------------------------------------");
            Console.WriteLine("Thank you for choosing Burger King. Sorry in advance for the bathroom issues!");
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        internal void QuitMessage()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Burger King's delicious food is now closed to you! I bet you wish you wouldn't have quit!\n" +
                "The king shall now dine alone!\nYour mother was a hamster and your father smelt of elderberries.\nBYE...");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        internal void DisplayCrown()
        {
            Console.WriteLine("\n\n       ___     ___     ___     ___");
            Console.WriteLine("      |   |   |   |   |   |   |   |");
            Console.WriteLine("      \\   /___\\   /___\\   /___\\   /");
            Console.WriteLine("      |                           |");
            Console.WriteLine("       \\                         /");
            Console.WriteLine("       |          The           |");
            Console.WriteLine("        \\         King         /");
            Console.WriteLine("        |                      |");
            Console.WriteLine("        ------------------------");
            Console.WriteLine("         /                    \\");
            Console.WriteLine("        |       /      \\       |");
            Console.WriteLine("        |       O      O       |");
            Console.WriteLine("        |           \\          |");
            Console.WriteLine("        |           _\\         |");
            Console.WriteLine("        |                      |");
            Console.WriteLine("        \\      \\        /      /");
            Console.WriteLine("         \\      \\______/      /");
            Console.WriteLine("          \\                  /");
            Console.WriteLine("           \\________________/");
        }
    }
}
