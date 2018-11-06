using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerKingCashRegister
{
    class SavedOrder
    {
        public DateTime TimeStamp { get; set; }
        //public List<string> OrderInfo {get; set;}
        public List<int> ItemQuantity { get; set; }
        public List<decimal> ItemSubtotal { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
