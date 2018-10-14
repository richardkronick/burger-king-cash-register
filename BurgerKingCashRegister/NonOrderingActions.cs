using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class NonOrderingActions
    {
        static Items items = new Items();
        static Menu menu = new Menu();
        static GoodbyeMessages goodByeMessages = new GoodbyeMessages();
        static ConfirmInput confirmInput = new ConfirmInput();
        static FinalDisplay finalDisplay = new FinalDisplay();

        public double foodTax = 0;
        public double drinkTax = 0;
        public static double totalTax = 0;

        public void ShowFinalOrder()
        {
            // allow user to view their final order, by first asking them to confirm they are finished
            Console.WriteLine("Are you sure you want to complete this order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string finalOrContinue = Console.ReadLine();

            // if they confirm they are finished, show their final order
            if (finalOrContinue == "y")
            {
                CalculateTax();
                finalDisplay.DisplayFinalOrder();
            }
            else if (finalOrContinue == "Y")
            {
                CalculateTax();
                finalDisplay.DisplayFinalOrder();
            }
            // if they are not finished, allow them to continue to order
            else
            {
                menu.DisplayRepeatMenu();
            }
        }

        public void Quit()
        {
            // allow the user to exit the program and provide them with a chance to go back to ordering
            Console.WriteLine("Are you sure? Press 'R' to return to ordering, otherwise press any other key to confirm quit.");
            string goBack = Console.ReadLine();

            // if the choose to return to ordering, re-display the menu
            if (goBack == "r")
            {
                menu.DisplayRepeatMenu();
            }
            else if (goBack == "R")
            {
                menu.DisplayRepeatMenu();
            }
            // if they confirm quit, display the quit message
            else
            {
                goodByeMessages.QuitMessage();
                goodByeMessages.DisplayCrown();
            }
        }

        public void RestartOrder()
        {
            // Allow user to restart order and ask if they are sure they want to
            Console.WriteLine("Are you sure you want to restart your order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string restartInput = Console.ReadLine();

            // if they indicate they are sure, then reset all amounts and quantities and return to the menu
            if (restartInput == "y")
            {
                items.ResetAllAmounts();
                menu.DisplayRepeatMenu();
            }
            else if (restartInput == "Y")
            {
                items.ResetAllAmounts();
                menu.DisplayRepeatMenu();
            }
            // if not, then keep amounts and quantities and allow user to continue
            else
            {
                menu.DisplayRepeatMenu();
            }
        }

        public void RemoveItem()
        {
            // prompt user to choose which item to remove
            Console.WriteLine("Enter the number preceding the item would you like to remove and reset to zero. Press enter to confirm removal.");
            Console.WriteLine("Press '5' to go back.");
            Console.WriteLine($"    1. {menu.itemList.ElementAt(0)}");
            Console.WriteLine($"    2. {menu.itemList.ElementAt(1)}");
            Console.WriteLine($"    3. {menu.itemList.ElementAt(2)}");
            Console.WriteLine($"    4. {menu.itemList.ElementAt(3)}");
            //get input as a string within the range of 1 - 5
            int itemToRemove = confirmInput.ConfirmInteger1to5();

            switch (itemToRemove)
            {
                // reset quantity and item price to zero; subtract the cost of the delted item from the total price
                case 1:
                    Items.totalItemQuantity[0] = 0;
                    Items.whopperSubtotal = 0;
                    Items.totalPrice -= Items.finalWhopperPrice;
                    Items.finalWhopperPrice = 0;
                    menu.DisplayRepeatMenu();
                    break;
                case 2:
                    Items.totalItemQuantity[1] = 0;
                    Items.cheeseburgerSubtotal = 0;
                    Items.totalPrice -= Items.finalCheeseburgerPrice;
                    Items.finalCheeseburgerPrice = 0;
                    menu.DisplayRepeatMenu();
                    break;
                case 3:
                    Items.totalItemQuantity[2] = 0;
                    Items.frenchFriesSubtotal = 0;
                    Items.totalPrice -= Items.finalFrenchFriesPrice;
                    Items.finalFrenchFriesPrice = 0;
                    menu.DisplayRepeatMenu();
                    break;
                case 4:
                    Items.totalItemQuantity[3] = 0;
                    Items.cokeSubtotal = 0;
                    Items.totalPrice -= Items.finalCokePrice;
                    Items.finalCokePrice = 0;
                    menu.DisplayRepeatMenu();
                    break;
                case 5:
                    menu.DisplayRepeatMenu();
                    break;
            }
        }

        public void CalculateTax()
        {
            // get a subtotal cost for all the food in order to calculate food taxes
            double foodSubtotal = Items.finalWhopperPrice + Items.finalCheeseburgerPrice + Items.finalFrenchFriesPrice;
            //calculate food tax
            foodTax = foodSubtotal * 0.07;
            // calculate drink tax
            drinkTax = Items.finalCokePrice * 0.09;
            // add to get total tax
            totalTax = foodTax + drinkTax;
            // calculate subtotal price before taxes
            Items.subtotalPrice = foodSubtotal + Items.finalCokePrice;
            // calculate final price inclusing taxes
            Items.totalPrice = foodSubtotal + foodTax + Items.finalCokePrice + drinkTax;
        }

        public void ChangeItemQuantity()
        {
            // prompt user to choose which item to change
            Console.WriteLine("Enter the number preceding the item would you like to change the quantity of. Press enter to confirm removal.");
            Console.WriteLine("Press '5' to go back.");
            Console.WriteLine($"    1. {menu.itemList.ElementAt(0)}");
            Console.WriteLine($"    2. {menu.itemList.ElementAt(1)}");
            Console.WriteLine($"    3. {menu.itemList.ElementAt(2)}");
            Console.WriteLine($"    4. {menu.itemList.ElementAt(3)}");
            //get input as a string within the range of 1 - 5
            int itemToChange = confirmInput.ConfirmInteger1to5();

            switch (itemToChange)
            {
                // reset quantity and item price to zero; subtract the cost of the delted item from the total price, then add back in how many they want
                case 1:
                    Items.totalItemQuantity[0] = 0;
                    Items.whopperSubtotal = 0;
                    Items.totalPrice -= Items.finalWhopperPrice;
                    Items.finalWhopperPrice = 0;
                    // Add back in the new quantity
                    items.Whopper();
                    break;
                case 2:
                    Items.totalItemQuantity[1] = 0;
                    Items.cheeseburgerSubtotal = 0;
                    Items.totalPrice -= Items.finalCheeseburgerPrice;
                    Items.finalCheeseburgerPrice = 0;
                    items.Cheeseburger();               
                    break;
                case 3:
                    Items.totalItemQuantity[2] = 0;
                    Items.frenchFriesSubtotal = 0;
                    Items.totalPrice -= Items.finalFrenchFriesPrice;
                    Items.finalFrenchFriesPrice = 0;
                    items.FrenchFries();
                    break;
                case 4:
                    Items.totalItemQuantity[3] = 0;
                    Items.cokeSubtotal = 0;
                    Items.totalPrice -= Items.finalCokePrice;
                    Items.finalCokePrice = 0;
                    items.Coke();
                    break;
                case 5:
                    menu.DisplayRepeatMenu();
                    break;
            }

        }

    }
}
