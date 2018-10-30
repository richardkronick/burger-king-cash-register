﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class MenuItemDetails
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
