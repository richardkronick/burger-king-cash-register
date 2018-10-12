using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class Menu
    {
        // declare global variables
        int inputAsInt = 0;
        double whopperSubtotal = 0;
        double cheeseburgerSubtotal = 0;
        double frenchFriesSubtotal = 0;
        double cokeSubtotal = 0;
        double totalPrice = 0;

        int totalWhopperQuantity = 0;
        int totalCheeseburgerQuantity = 0;
        int totalFrenchFriesQuantity = 0;
        int totalCokeQuantity = 0;

        double finalWhopperPrice = 0;
        double finalCheeseburgerPrice = 0;
        double finalFrenchFriesPrice = 0;
        double finalCokePrice = 0;

        public void DisplayMenu()
        {
            //Display initial menu
            Console.WriteLine("  1. Whopper - 3.99");
            Console.WriteLine("  2. Cheeseburger - 2.50");
            Console.WriteLine("  3. French Fries - .99");
            Console.WriteLine("  4. Coke - 1.35\n");
            Console.WriteLine("Please enter the number, 1-4, of the first item you would like to order. \nPress '5' to Quit.\n");

            //confirm that input is an integer and that it is within the correct range
            ConfirmIntegerInRange();

            // determine what action to take based on the user's input
            ItemChoice();
        }

        public void DisplayRepeatMenu()
        {
            Console.Clear();

            // display non-initial menu
            Console.WriteLine($"\n------Your total so far is { totalPrice }------\n");
            Console.WriteLine("  1. Whopper - 3.99");
            Console.WriteLine("  2. Cheeseburger - 2.50");
            Console.WriteLine("  3. French Fries - .99");
            Console.WriteLine("  4. Coke - 1.35\n");
            Console.WriteLine("Please enter the number, 1-4, of the next item you would like to order.");
            Console.WriteLine("Press '5' to quit.");
            Console.WriteLine("Press '6' to restart your order.");
            Console.WriteLine("Press '0' to complete your order and see your final order details.\n");
            ConfirmIntegerInRange();
            ItemChoice();
        }

        // confirm that an input is an integer and within the accepted range
        public int ConfirmIntegerInRange()
        {
            int result;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                // get input from the user and store as a string
                string inputAsString = Console.ReadLine();

                // if input is an int then parse it into an int and store whether or not it was successful as a bool
                isValidInput = int.TryParse(inputAsString, out result);

                // if parsable as an int
                if (isValidInput == true)
                {
                    // ensure int is between 0 and 6
                    inputAsInt = result;
                    if(inputAsInt < 0 || inputAsInt > 6)
                    {
                        isValidInput = false;
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                // if not parsable as int produce error message and prompt user to repeat
                if (isValidInput == false)
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
            }
            // return user input as an int
            return inputAsInt;
        }

        // determine what action to take based on the user's input
        public void ItemChoice()
        {
            // determine which path to take based off of the user's 0 - 6 int input
            switch (inputAsInt)
            {
                case 0:
                    ShowFinalOrder();
                    break;
                case 1:
                    Whopper();
                    break;
                case 2:
                    Cheeseburger();
                    break;
                case 3:
                    FrenchFries();
                    break;
                case 4:
                    Coke();
                    break;
                case 5:
                    Quit();
                    break;
                case 6:
                    RestartOrder();
                    break;
            }
        }

        public void Whopper()
        {
            // Prompt user for item amount, confirm as int and store as int
            Console.WriteLine("How many mouth-watering Whoppers would you like?");
            int whopperQuantity = ConfirmInteger();

            // calculate the sub total for item
            whopperSubtotal = 3.99 * whopperQuantity;

            // calculate total quantity of item, total price of this particular item and total price overall so far
            totalWhopperQuantity += whopperQuantity;
            finalWhopperPrice += whopperSubtotal;
            totalPrice += whopperSubtotal;

            // return to menu display to allow user to continue order
            DisplayRepeatMenu();
        }

        public void Cheeseburger()
        {
            Console.WriteLine("How many delicious cheeseburgers would you like?");
            int cheeseburgerQuantity = ConfirmInteger();

            cheeseburgerSubtotal = 2.5 * cheeseburgerQuantity;

            totalCheeseburgerQuantity += cheeseburgerQuantity;
            finalCheeseburgerPrice += cheeseburgerSubtotal;
            totalPrice += cheeseburgerSubtotal;

            DisplayRepeatMenu();
        }

        public void FrenchFries()
        {
            Console.WriteLine("How many orders of tasty french fries you would like?");
            int frenchFriesQuantity = ConfirmInteger();

            frenchFriesSubtotal = 0.99 * frenchFriesQuantity;

            totalFrenchFriesQuantity += frenchFriesQuantity;
            finalFrenchFriesPrice += frenchFriesSubtotal;
            totalPrice += frenchFriesSubtotal;

            DisplayRepeatMenu();
        }

        public void Coke()
        {
            Console.WriteLine("How many thirst-quenching Cokes you would like?");
            int cokeQuantity = ConfirmInteger();

            cokeSubtotal = 1.35 * cokeQuantity;

            totalCokeQuantity += cokeQuantity;
            finalCokePrice += cokeSubtotal;
            totalPrice += cokeSubtotal;

            DisplayRepeatMenu();
        }

        public void RestartOrder()
        {
            // Allow user to restart order and ask if they are sure they want to
            Console.WriteLine("Are you sure you want to restart your order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string restartInput = Console.ReadLine();

            // if they indicate they are sure, then reset all amounts and quantities and return to the menu
            if (restartInput == "y")
            {
                ResetAllAmounts();
                DisplayRepeatMenu();
            }
            else if(restartInput == "Y")
            {
                ResetAllAmounts();
                DisplayRepeatMenu();
            }
            // if not, then keep amounts and quantities and allow user to continue
            else
            {
                DisplayRepeatMenu();
            }
        }

        // reset all amounts and quantities back to zero
        public void ResetAllAmounts()
        {
            whopperSubtotal = 0;
            cheeseburgerSubtotal = 0;
            frenchFriesSubtotal = 0;
            cokeSubtotal = 0;
            totalPrice = 0;

            totalWhopperQuantity = 0;
            totalCheeseburgerQuantity = 0;
            totalFrenchFriesQuantity = 0;
            totalCokeQuantity = 0;

            finalWhopperPrice = 0;
            finalCheeseburgerPrice = 0;
            finalFrenchFriesPrice = 0;
            finalCokePrice = 0;
        }

        public void ShowFinalOrder()
        {
            // allow user to view their final order, by first asking them to confirm they are finished
            Console.WriteLine("Are you sure you want to complete this order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string finalOrContinue = Console.ReadLine();

            // if they confirm they are finished, show their final order
            if (finalOrContinue == "y")
            {
                DisplayFinalOrder();
            }
            else if (finalOrContinue == "Y")
            {
                DisplayFinalOrder();
            }
            // if they are not finished, allow them to continue to order
            else
            {
                DisplayRepeatMenu();
            }
        }

        public void DisplayFinalOrder()
        {
            // table displaying finalized order details
            Console.Clear();
            Console.WriteLine("\n            Order Summary");
            Console.WriteLine("  --------------------------------------");
            Console.WriteLine("    Item    |    Quantity   |    Cost");
            Console.WriteLine("  _________     __________    _________\n");
            Console.WriteLine("  Whopper           {0}          {1}", totalWhopperQuantity, string.Format("${0:0.00}", finalWhopperPrice));
            Console.WriteLine("  Cheeseburger      {0}          {1}", totalCheeseburgerQuantity, string.Format("${0:0.00}", finalCheeseburgerPrice));
            Console.WriteLine("  French fries      {0}          {1}", totalFrenchFriesQuantity, string.Format("${0:0.00}", finalFrenchFriesPrice));
            Console.WriteLine("  Coke              {0}          {1}", totalCokeQuantity, string.Format("${0:0.00}", finalCokePrice));
            Console.WriteLine("  --------------------------------------");
            Console.WriteLine($"  Total                        ${totalPrice}\n");

            // give the user an option to place another order
            Console.WriteLine("\nWould you like to place another order? If so, press 'Y'. Otherwise, press any key to quit.");
            string orderAgainOrQuit = Console.ReadLine();

            // if they would like to place another order, reset all amounts and quntities and re-display the menu and ordering options
            if (orderAgainOrQuit == "y")
            {
                ResetAllAmounts();
                DisplayRepeatMenu();
            }
            else if (orderAgainOrQuit == "Y")
            {
                ResetAllAmounts();
                DisplayRepeatMenu();
            }
            // if they are finished, show them the thank you message
            else
            {
                Console.Clear();
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("Thank you for choosing Burger King. Sorry in advance for the bathroom issues!");
                Console.WriteLine("-----------------------------------------------------------------------------");
                DisplayCrown();
            }
        }

        // confirm that input is an integer, but not cofirming id it is within a range
        public int ConfirmInteger()
        {
            int result;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                // get user input and store as string
                string inputAsString = Console.ReadLine();

                // attempt to parse input into an int and store the result as a bool
                isValidInput = int.TryParse(inputAsString, out result);

                // if successfully parsed as int, return as int, otherwise prompt user to re-enter a number
                if (isValidInput == true)
                {
                    inputAsInt = result;
                }
                if (isValidInput == false)
                {
                    Console.WriteLine("Please enter a number only");
                }
            }
            return inputAsInt;
        }

        public void Quit()
        {
            // allow the user to exit the program and provide them with a chance to go back to ordering
            Console.WriteLine("Are you sure? Press 'R' to return to ordering, otherwise press any other key to confirm quit.");
            string goBack = Console.ReadLine();

            // if the choose to return to ordering, re-display the menu
            if (goBack == "r")
            {
                DisplayRepeatMenu();
            }
            else if (goBack == "R")
            {
                DisplayRepeatMenu();
            }
            // if they confirm quit, display the quit message
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Burger King's delicious food is now closed to you! I bet you wish you wouldn't have quit!\n" +
                    "The king shall now dine alone!\nYour mother was a hamster and your father smelt of elderberries.\nBYE...");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                DisplayCrown();
            }
        }

        public void DisplayCrown()
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
