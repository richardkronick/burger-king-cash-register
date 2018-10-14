using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class ConfirmInput
    {
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
                    // ensure int is between 0 and 8
                    Menu.inputAsInt = result;
                    if (Menu.inputAsInt < 0 || Menu.inputAsInt > 8)
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
            return Menu.inputAsInt;
        }

        public int ConfirmInteger1to5()
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
                    // ensure int is between 1 and 4
                    Menu.inputAsInt = result;
                    if (Menu.inputAsInt < 1 || Menu.inputAsInt > 5)
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
                    Console.WriteLine("Please enter a number between 1 and 5 only.");
                }
            }
            // return user input as an int
            return Menu.inputAsInt;
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
                    Menu.inputAsInt = result;
                }
                if (isValidInput == false)
                {
                    Console.WriteLine("Please enter a number only");
                }
            }
            return Menu.inputAsInt;
        }

    }
}
