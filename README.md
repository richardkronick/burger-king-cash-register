# Burger King Cash Register
This is a food/menu ordering system. Burger King menu items were used as default examples, however, this can be used as an internal ordering system for not only food or restaruants but for nearly any menu ordering environment. 

The application is written in C#.

The application is designed with the user in mind and is intended to be very user-friendly.

## Features
It is a console app which includes the following features:

- Presents the menu and ordering options (including price, inventory quantity, amount ordered so far and subtotal for each item)
- There is an option to quit at any time
- There is an option to restart your order at any time
- You can remove an item
- You can change the item's quantity
- Once finished ordering you can see your order summary (including each item's quantity and subtotal, tax and total amount)
- The program calculates the tax owed
- Once an order is completed, the order is saved to a json file
- The user is given the option to view orders that were saved to a json file from a specific date

## How to Use
- To use this application, you can open it with [Visual Studio](https://visualstudio.microsoft.com/downloads/). If you are unsure which version to download, I recommend the free Community edition.
- To read and write orders to a json file, change the file location on line 267 of UserInterface.cs to something suitable for your computer.
- You can set inventory and change/add/remove item names at the top of the Order.cs file.

# License
The contents of this repository are covered under the [MIT License](https://github.com/udacity/ud777-writing-readmes/blob/master/LICENSE).
