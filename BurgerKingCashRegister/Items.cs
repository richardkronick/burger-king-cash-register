using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class Items
    {
        static Menu menu = new Menu();
        static GoodbyeMessages goodByeMessages = new GoodbyeMessages();
        static ConfirmInput confirmInput = new ConfirmInput();
        static NonOrderingActions nonOrderingActions = new NonOrderingActions();

        public static double whopperSubtotal = 0;
        public static double cheeseburgerSubtotal = 0;
        public static double frenchFriesSubtotal = 0;
        public static double cokeSubtotal = 0;

        // remove these four variable in favor of array below
        //public static int totalWhopperQuantity = 0;
        //public static int totalCheeseburgerQuantity = 0;
        //public static int totalFrenchFriesQuantity = 0;
        //public static int totalCokeQuantity = 0;

        public static int[] totalItemQuantity = new int[]
        {
            0, 0, 0, 0 //totalWhopperQuantity, totalCheeseburgerQuantity, totalFrenchFriesQuantity, totalCokeQuantity
        };

        public static double finalWhopperPrice = 0;
        public static double finalCheeseburgerPrice = 0;
        public static double finalFrenchFriesPrice = 0;
        public static double finalCokePrice = 0;
         
        public static double totalPrice = 0;
        public static double subtotalPrice = 0;

        public void Whopper()
        {
            // Prompt user for item amount, confirm as int and store as int
            Console.WriteLine($"How many mouth-watering Whoppers would you like?");
            int whopperQuantity = confirmInput.ConfirmInteger();

            // calculate the sub total for item
            whopperSubtotal = 3.99 * whopperQuantity;

            // calculate total quantity of item, total price of this particular item and total price overall so far
            totalItemQuantity[0] += whopperQuantity;
            finalWhopperPrice += whopperSubtotal;
            totalPrice += whopperSubtotal;

            // return to menu display to allow user to continue order
            menu.DisplayRepeatMenu();
        }

        public void Cheeseburger()
        {
            Console.WriteLine($"How many delicious cheeseburgers would you like?");
            int cheeseburgerQuantity = confirmInput.ConfirmInteger();

            cheeseburgerSubtotal = 2.5 * cheeseburgerQuantity;

            totalItemQuantity[1] += cheeseburgerQuantity;
            finalCheeseburgerPrice += cheeseburgerSubtotal;
            totalPrice += cheeseburgerSubtotal;

            menu.DisplayRepeatMenu();
        }

        public void FrenchFries()
        {
            Console.WriteLine($"How many orders of tasty french fries you would like?");
            int frenchFriesQuantity = confirmInput.ConfirmInteger();

            frenchFriesSubtotal = 0.99 * frenchFriesQuantity;

            totalItemQuantity[2] += frenchFriesQuantity;
            finalFrenchFriesPrice += frenchFriesSubtotal;
            totalPrice += frenchFriesSubtotal;

            menu.DisplayRepeatMenu();
        }

        public void Coke()
        {
            Console.WriteLine($"How many thirst-quenching cokes you would like?");
            int cokeQuantity = confirmInput.ConfirmInteger();

            cokeSubtotal = 1.35 * cokeQuantity;

            totalItemQuantity[3] += cokeQuantity;
            finalCokePrice += cokeSubtotal;
            totalPrice += cokeSubtotal;

            menu.DisplayRepeatMenu();
        }

        // reset all amounts and quantities back to zero
        public void ResetAllAmounts()
        {
            whopperSubtotal = 0;
            cheeseburgerSubtotal = 0;
            frenchFriesSubtotal = 0;
            cokeSubtotal = 0;
            totalPrice = 0;

            totalItemQuantity[0] = 0;
            totalItemQuantity[1] = 0;
            totalItemQuantity[2] = 0;
            totalItemQuantity[3] = 0;

            finalWhopperPrice = 0;
            finalCheeseburgerPrice = 0;
            finalFrenchFriesPrice = 0;
            finalCokePrice = 0;
        }
    }
}
