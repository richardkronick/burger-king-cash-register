using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class Order
    {
        public List<MenuItemDetails> items;
        public decimal totalPrice;
        public decimal totalTax;

        public Order()
        {
            items = new List<MenuItemDetails>();

            items.Add(new MenuItemDetails() { ItemName = "Cheeseburger", Price = 2.50m, Tax = 0.07m, Quantity = 0, Subtotal = 0m });
            items.Add(new MenuItemDetails() { ItemName = "Coke", Price = 1.35m, Tax = 0.09m, Quantity = 0, Subtotal = 0m });
            items.Add(new MenuItemDetails() { ItemName = "French Fries", Price = 0.99m, Tax = 0.07m, Quantity = 0, Subtotal = 0m });
            items.Add(new MenuItemDetails() { ItemName = "Whopper", Price = 3.99m, Tax = 0.07m, Quantity = 0, Subtotal = 0m });
        }

        internal void OrderMenuItems(int inputAsIntIndex)
        {
            // Prompt user for item amount, confirm as int and add to item quantity
            Console.Write($"You selected: {items[inputAsIntIndex].ItemName}.\nHow many would you like?  ");
            items[inputAsIntIndex].Quantity += ConfirmIntegerInRange(1, 999);

            // calculate the subtotal for item
            items[inputAsIntIndex].Subtotal = items[inputAsIntIndex].Quantity * items[inputAsIntIndex].Price;

            //calculate total price so far
            decimal totalAmount = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalAmount += items[i].Subtotal;
            };
            totalPrice = totalAmount;
        }

        internal void RestartOrder()
        {
            // Allow user to restart order and ask if they are sure they want to
            Console.WriteLine("Are you sure you want to restart your order? Press 'Y' to confirm or 'N' to continue your current order.\n");
            string restartInput = Console.ReadLine();

            // if they indicate they are sure, then reset all amounts and quantities and return to the menu
            if (restartInput == "y" || restartInput == "Y")
                ResetAllAmounts();
        }

        internal void RemoveItem()
        {
            //get input as a string within the range of the number of available items
            int itemToDelete = (ConfirmIntegerInRange(1, items.Count)) - 1;

            // subtract the cost of the deleted item from the total price; reset quantity and item subtotal to zero
            totalPrice -= items[itemToDelete].Subtotal;
            items[itemToDelete].Quantity = 0;
            items[itemToDelete].Subtotal = 0;
        }

        internal void ChangeItemQuantity()
        {
            // reset quantity and subtotal to zero; subtract the cost of the delted item from the total price
            // get input as a string within the range of the number of available items
            int itemToChange = (ConfirmIntegerInRange(1, items.Count)) - 1;

            // subtract the cost of the deleted item from the total price; reset quantity and item subtotal to zero
            totalPrice -= items[itemToChange].Subtotal;
            items[itemToChange].Quantity = 0;
            items[itemToChange].Subtotal = 0;
            // then add back in how many they want
            // Prompt user for item amount, confirm as int and add to item quantity
            Console.Write($"You selected: {items[itemToChange].ItemName}.\nHow many would you like?  ");
            items[itemToChange].Quantity += ConfirmIntegerInRange(1, 999);

            // calculate the subtotal for item
            items[itemToChange].Subtotal = items[itemToChange].Quantity * items[itemToChange].Price;

            //calculate total price so far
            decimal totalAmount = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalAmount += items[i].Subtotal;
            };
            totalPrice = totalAmount;
        }

        internal void ResetAllAmounts()
        {
            //reset item quantities, subtotals and total price
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Quantity = 0;
                items[i].Subtotal = 0;
            }
            totalPrice = 0;
            totalTax = 0;
        }

        public int ConfirmIntegerInRange(int minValue, int maxValue)
        {
            int result = 0;
            bool isValidInput = false;
            string inputAsString;

            while (isValidInput == false)
            {
                inputAsString = Console.ReadLine();

                isValidInput = int.TryParse(inputAsString, out result);

                if ((isValidInput == false) || result < minValue || result > maxValue)
                {
                    Console.WriteLine($"Please enter a number between {minValue} and {maxValue}.");
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }
            return result;
        }
    }
}
