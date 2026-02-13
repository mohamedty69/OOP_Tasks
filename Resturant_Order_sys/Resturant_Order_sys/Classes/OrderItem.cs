using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Resturant_Order_sys.Classes
{
    public class OrderItem
    {
        public OrderItem(MenuItem menuItem, int quantity, string specialInstructions)
        {
            MenuItem = menuItem;
            if (Quantity < 0)
            {
                throw new ArgumentException("The Quantity can not be negative");
            }
            else Quantity = quantity;
            SpecialInstructions = specialInstructions;
        }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public string SpecialInstructions { get; set; }
        public decimal GetSubTotal() => MenuItem.Price * Quantity;
        public String GetOrderItemDetails() => $"{MenuItem.GetItemInfo()}\n" + $"SubTotal: {GetSubTotal()}";
    }
}
