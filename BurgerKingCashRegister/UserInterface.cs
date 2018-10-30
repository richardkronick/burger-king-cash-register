using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class UserInterface
    {
        Order order = new Order();
        GoodbyeMessage bye = new GoodbyeMessage();

        public int inputAsInt;
        public int inputAsIntIndex;

        public void DisplayMenu()
        {
            Console.WriteLine("\nWelcome to Burger King! Here is the menu:\n");
            MenuItems();
            Console.WriteLine($"\nSelect the item 1 - {order.items.Count} that you would like to order. \nPress '{order.items.Count + 1}' to Quit.\n");
            inputAsInt = order.ConfirmIntegerInRange(1, (order.items.Count + 1));
            inputAsIntIndex = inputAsInt - 1;
            MenuChoice();
        }

        private void MenuItems()
        {
            for (int i = 0; i < order.items.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {order.items[i].ItemName} - {(order.items[i].Price.ToString("C", CultureInfo.CurrentCulture))} " +
                    $"--- Quantity: {order.items[i].Quantity}, Item Subtotal: {order.items[i].Subtotal}");
            }
        }

        private void MenuChoice()
        {
            if (inputAsInt >= 1 && inputAsInt <= order.items.Count)
            {
                order.OrderMenuItems(inputAsIntIndex);
                DisplayRepeatMenu();
            }
            else if (inputAsInt == (order.items.Count + 2))
            {
                order.RestartOrder();
                DisplayRepeatMenu();
            }
            else if (inputAsInt == (order.items.Count + 3))
            {
                Console.WriteLine("Enter the number preceding the item you would like to remove and reset to zero. Press enter to confirm removal.");
                PrintModifyMenuList();
                order.RemoveItem();
                DisplayRepeatMenu();
            }
            else if (inputAsInt == (order.items.Count + 4))
            {
                Console.WriteLine("Enter the number preceding the item would you like to change the quantity of. Press enter to confirm removal.");
                PrintModifyMenuList();
                order.ChangeItemQuantity();
                DisplayRepeatMenu();
            }
            else if (inputAsInt == (order.items.Count + 5))
            {
                // View previous orders from a specific date
            }
            else if (inputAsInt == 0)
            {
                ShowFinalOrder();
                PlaceAnotherOrder();
            }
            else if (inputAsInt == (order.items.Count + 1))
            {
                Quit();
            }
        }

        public void DisplayRepeatMenu()
        {
            Console.Clear();

            Console.WriteLine($"\n------Your total so far is { (order.totalPrice.ToString("C", CultureInfo.CurrentCulture)) }------\n");
            MenuItems();
            Console.WriteLine($"\nPlease enter the item 1 - {order.items.Count} of the next item you would like to order.");
            Console.WriteLine($"  Press '{order.items.Count + 1}' to quit.");
            Console.WriteLine($"  Press '{order.items.Count + 2}' to restart your order.");
            Console.WriteLine($"  Press '{order.items.Count + 3}' to remove an item.");
            Console.WriteLine($"  Press '{order.items.Count + 4}' to change an item's quantity");
            Console.WriteLine("  Press '0' to complete your order and see your final order details.\n");
            inputAsInt = order.ConfirmIntegerInRange(0, (order.items.Count + 4));
            inputAsIntIndex = inputAsInt - 1;
            MenuChoice();
        }

        private void PrintModifyMenuList()
        {
            // prompt user to choose which item to change/delete
            Console.WriteLine($"Press '{order.items.Count + 1}' to go back.");
            for (int i = 0; i < order.items.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {order.items[i].ItemName}");
            }
        }

        private void ShowFinalOrder()
        {
            // allow user to view their final order, by first asking them to confirm they are finished
            Console.WriteLine("Are you sure you want to complete this order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string finalOrContinue = Console.ReadLine();

            // if they confirm they are finished, show their final order
            if (finalOrContinue == "y" || finalOrContinue == "Y")
            {
                CalculateTax();
                FinalOrderDisplay();
            }
            // if they are not finished, allow them to continue to order
            else
            {
                DisplayRepeatMenu();
            }
        }

        private void CalculateTax()
        {
            // get a subtotal cost for all the food in order to calculate food taxes
            for (int i = 0; i < order.items.Count; i++)
            {
                order.totalTax += (order.items[i].Subtotal * order.items[i].Tax);
            }
        }

        private void FinalOrderDisplay()
        {
            // table displaying finalized order details
            Console.Clear();
            Console.WriteLine("\n                  Order Summary");
            Console.WriteLine("  ------------------------------------------");
            Console.WriteLine("       Item     |   Quantity   |    Cost");
            Console.WriteLine("  ______________ ______________ ____________\n");

            //sort items in alphabetical order
            order.items.Sort((x, y) => x.ItemName.CompareTo(y.ItemName));

            for (int i = 0; i < order.items.Count; i++)
            {
                if (order.items[i].Quantity != 0)
                {
                    {
                        Console.WriteLine("  {0}  |      {1}       |    {2}", order.items[i].ItemName.PadRight(12), order.items[i].Quantity,
                          string.Format("${0:0.00}", order.items[i].Subtotal));
                    }
                }
            }
            Console.WriteLine("  ------------------------------------------");
            Console.WriteLine("  Subtotal                          ${0}", string.Format("{0:0.00}", order.totalPrice));
            Console.WriteLine("  Tax                               ${0}", string.Format("{0:0.00}", order.totalTax));
            Console.WriteLine("  Total                             ${0}\n", string.Format("{0:0.00}", order.totalPrice + order.totalTax));
        }

        private void WriteOrderToTextFile()
        {
            List<string> orderAsList = new List<string>();

            orderAsList.Add($"Order Date & Time: {DateTime.Now}");

            for (int i = 0; i < order.items.Count; i++)
            {
                string itemInfo = (($"Item: {order.items[i].ItemName.ToString()}") + ($", Quantity: {order.items[i].Quantity.ToString()}")
                    + ($", Item Subtotal: {order.items[i].Subtotal.ToString()}"));
                orderAsList.Add(itemInfo);
            }

            orderAsList.Add($"Subtotal: {order.totalPrice.ToString()}");
            orderAsList.Add($"Tax: {string.Format("{0:0.00}", order.totalTax)}");
            orderAsList.Add($"Total: {string.Format("{0:0.00}", order.totalPrice + order.totalTax)}");

            string filePathDateTime = DateTime.Now.ToString("yyyyMMdd_hhmmss");

            File.WriteAllLines(@"C:\Users\rckro\Desktop\VS\order" + filePathDateTime + ".txt", orderAsList);
        }

        private void PlaceAnotherOrder()
        {
            // give the user an option to place another order
            Console.WriteLine("\nWould you like to place another order? If so, press 'Y'. Otherwise, press any key to quit.\n");
            Console.WriteLine("Does something look wrong? If so, press 'G' to go back.");
            string orderAgainOrQuit = Console.ReadLine();

            // if they would like to place another order, reset all amounts and quntities and re-display the menu and ordering options
            if (orderAgainOrQuit == "y" || orderAgainOrQuit == "Y")
            {
                WriteOrderToTextFile();
                order.ResetAllAmounts();
                DisplayRepeatMenu();
            }

            // if the user wants to go back to the ordering screen without changing anything
            else if (orderAgainOrQuit == "g" || orderAgainOrQuit == "G")
            {
                order.totalPrice -= order.totalTax;
                DisplayRepeatMenu();
            }

            // if they are finished, show them the thank you message
            else
            {
                WriteOrderToTextFile();
                bye.ThankYouMessage();
                bye.DisplayCrown();
                Console.ReadKey();
            }
        }

        public void Quit()
        {
            Console.WriteLine("Are you sure? Press 'R' to return to ordering, otherwise press any other key to confirm quit.");
            string goBack = Console.ReadLine();

            // if the choose to return to ordering, re-display the menu
            if (goBack == "r" || goBack == "R")
            {
                DisplayRepeatMenu();
            }
            // if they confirm quit, display the quit message
            else
            {
                bye.QuitMessage();
                bye.DisplayCrown();
                Console.ReadKey();
            }
        }
    }
}
