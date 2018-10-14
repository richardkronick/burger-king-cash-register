using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class FinalDisplay
    {
        Menu menu = new Menu();
        Items items = new Items();
        GoodbyeMessages goodbyeMessages = new GoodbyeMessages();
        NonOrderingActions nonOrderingActions = new NonOrderingActions();

        public void DisplayFinalOrder()
        {
            int cb = Items.totalItemQuantity[1];
            int ck = Items.totalItemQuantity[3];
            int ff = Items.totalItemQuantity[2];
            int wp = Items.totalItemQuantity[0];

            // table displaying finalized order details
            Console.Clear();
            Console.WriteLine("\n                  Order Summary");
            Console.WriteLine("  ------------------------------------------");
            Console.WriteLine("       Item     |   Quantity   |    Cost");
            Console.WriteLine("  ______________ ______________ ____________\n");
            //sort items in alphabetical order
            menu.itemList.Sort();
            // HOW CAN I ASSOCIATE THE ITEM QUANTITY AND PRICE WITH THE MENU ITEM? One object?
            if (cb > 0) { Console.WriteLine("  {0}  |      {1}       |    {2}", menu.itemList.ElementAt(0), Items.totalItemQuantity[1], string.Format("${0:0.00}", Items.finalCheeseburgerPrice)); }
            if (ck > 0) { Console.WriteLine("  {0}  |      {1}       |    {2}", menu.itemList.ElementAt(1), Items.totalItemQuantity[3], string.Format("${0:0.00}", Items.finalCokePrice)); }
            if (ff > 0) { Console.WriteLine("  {0}  |      {1}       |    {2}", menu.itemList.ElementAt(2), Items.totalItemQuantity[2], string.Format("${0:0.00}", Items.finalFrenchFriesPrice)); }
            if (wp > 0) { Console.WriteLine("  {0}  |      {1}       |    {2}", menu.itemList.ElementAt(3), Items.totalItemQuantity[0], string.Format("${0:0.00}", Items.finalWhopperPrice)); }
            Console.WriteLine("  ------------------------------------------");
            Console.WriteLine("  Subtotal                          ${0}", string.Format("{0:0.00}", Items.subtotalPrice));
            Console.WriteLine("  Tax                               ${0}", string.Format("{0:0.00}", NonOrderingActions.totalTax));
            Console.WriteLine("  Total                             ${0}\n", string.Format("{0:0.00}", Items.totalPrice));

            // give the user an option to place another order
            Console.WriteLine("\nWould you like to place another order? If so, press 'Y'. Otherwise, press any key to quit.\n");
            Console.WriteLine("Does something look wrong? If so, press 'G' to go back.");
            string orderAgainOrQuit = Console.ReadLine();

            // if they would like to place another order, reset all amounts and quntities and re-display the menu and ordering options
            if (orderAgainOrQuit == "y")
            {
                items.ResetAllAmounts();
                menu.DisplayRepeatMenu();
            }
            else if (orderAgainOrQuit == "Y")
            {
                items.ResetAllAmounts();
                menu.DisplayRepeatMenu();
            }
            // if the user wants to go back to the ordering screen without changing anything
            else if (orderAgainOrQuit == "g")
            {
                Items.totalPrice = Items.finalWhopperPrice + Items.finalCheeseburgerPrice + Items.finalFrenchFriesPrice + Items.finalCokePrice;
                menu.DisplayRepeatMenu();
            }
            else if (orderAgainOrQuit == "G")
            {
                Items.totalPrice = Items.finalWhopperPrice + Items.finalCheeseburgerPrice + Items.finalFrenchFriesPrice + Items.finalCokePrice;
                menu.DisplayRepeatMenu();
            }
            // if they are finished, show them the thank you message
            else
            {
                goodbyeMessages.ThankYouMessage();
                goodbyeMessages.DisplayCrown();
            }
        }

    }
}
