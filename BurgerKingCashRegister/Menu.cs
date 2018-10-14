using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BurgerKingCashRegister
{
    class Menu
    {
        // declare global variables
        static Items items = new Items();
        static GoodbyeMessages goodByeMessages = new GoodbyeMessages();
        static NonOrderingActions nonOrderingActions = new NonOrderingActions();
        static ConfirmInput confirmInput = new ConfirmInput();

        static public int inputAsInt = 0;

        public static double whopperPrice = 3.99;
        public static double cheeseburgerPrice = 2.50;
        public static double frenchFriesPrice = .99;
        public static double cokePrice = 1.35;

        public List<string> itemList = new List<string>()
        {
            "Whopper     ",
            "Cheeseburger",
            "French Fries",
            "Coke        "
        };

        //remove the below variables in favor of above List
        //public static string itemOne = "Whopper";
        //public static string itemTwo = "Cheeseburger";
        //public static string itemThree = "French Fries";
        //public static string itemFour = "Coke";

        public void DisplayMenu()
        {
            //Display initial menu
            MenuItems();
            Console.WriteLine("Please enter the number, 1-4, of the first item you would like to order. \nPress '5' to Quit.\n");

            //confirm that input is an integer and that it is within the correct range
            confirmInput.ConfirmIntegerInRange();

            // determine what action to take based on the user's input
            ItemChoice();
        }

        public void DisplayRepeatMenu()
        {
            Console.Clear();

            // display non-initial menu
            Console.WriteLine($"\n------Your total so far is { (Items.totalPrice.ToString("C", CultureInfo.CurrentCulture)) }------\n");
            MenuItems();
            Console.WriteLine("Please enter the number, 1-4, of the next item you would like to order.");
            Console.WriteLine("Press '5' to quit.");
            Console.WriteLine("Press '6' to restart your order.");
            Console.WriteLine("Press '7' to remove an item.");
            Console.WriteLine("Press '8' to change an item's quantity");
            Console.WriteLine("Press '0' to complete your order and see your final order details.\n");
            confirmInput.ConfirmIntegerInRange();
            ItemChoice();
        }

        // Actual Menu items
        public void MenuItems()
        {
            Console.WriteLine($"  1. {itemList.ElementAt(0)} - {(whopperPrice.ToString("C", CultureInfo.CurrentCulture))}");
            Console.WriteLine($"  2. {itemList.ElementAt(1)} - {(cheeseburgerPrice.ToString("C", CultureInfo.CurrentCulture))}");
            Console.WriteLine($"  3. {itemList.ElementAt(2)} - {(frenchFriesPrice.ToString("C", CultureInfo.CurrentCulture))}");
            Console.WriteLine($"  4. {itemList.ElementAt(3)} - {(cokePrice.ToString("C", CultureInfo.CurrentCulture))}\n");
        }

        // determine what action to take based on the user's input
        public void ItemChoice()
        {
            // determine which path to take based off of the user's 0 - 8 int input
            switch (inputAsInt)
            {
                case 0:
                    nonOrderingActions.ShowFinalOrder();
                    break;
                case 1:
                    items.Whopper();
                    break;
                case 2:
                    items.Cheeseburger();
                    break;
                case 3:
                    items.FrenchFries();
                    break;
                case 4:
                    items.Coke();
                    break;
                case 5:
                    nonOrderingActions.Quit();
                    break;
                case 6:
                    nonOrderingActions.RestartOrder();
                    break;
                case 7:
                    nonOrderingActions.RemoveItem();
                    break;
                case 8:
                    nonOrderingActions.ChangeItemQuantity();
                    break;
            }
        }
    }
}
