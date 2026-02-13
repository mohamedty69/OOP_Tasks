using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Resturant_Order_sys.Classes
{
    public class Order
    {
        private decimal _tipResult;
        public Order(string orderId, int tableNumber)
        {
            OrderId = orderId;
            if (TableNumber < 0) throw new ArgumentException("The TableNumber can not be negative");
            else TableNumber = tableNumber;
            OrderItem = new List<OrderItem>();
            OrderTime = DateTime.UtcNow;
        }

        public string OrderId { get; set; }
        public int TableNumber { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; } = "Pending";
        public void AddItem(MenuItem menuItem, int quantity, string specialInstructions)
        {
            var item = OrderItem.FirstOrDefault(o => o.MenuItem.ItemId == menuItem.ItemId);
            if (item == null)
            {
                var orderitem = new OrderItem(menuItem, quantity, specialInstructions);
                OrderItem.Add(orderitem);
            }
            else throw new InvalidOperationException("Item is already add");
        }
        public void RemoveItem (string ItemId)
        {
            var item = OrderItem.FirstOrDefault( i => i.MenuItem.ItemId == ItemId);
            if ( item == null)
            {
                throw new InvalidOperationException("The Item is already removed");
            }
            OrderItem.Remove(item);
        }
        public decimal GetSubTotal () => OrderItem.Select(o => o.GetSubTotal()).Sum();
        public decimal GetTax() => GetSubTotal() * 0.08m;
        public decimal GetSubTotalPlusTax() => GetSubTotal() + GetTax();
        public decimal CalculateTip(decimal tip)
        {
            _tipResult = GetSubTotal() * tip;
            return _tipResult;
        }
        public decimal GetToal() => GetSubTotal() + GetTax() + _tipResult;
        public void UpdateStatus (string ordersStatus) => Status = ordersStatus;
        public void GetOrderSummary()
        {
            Console.WriteLine($"Order ID: {OrderId}\n"+
                $"Table: {TableNumber}\n"+
                $"Time: {OrderTime}\n"+
                $"Status: {Status}\n");
            Console.WriteLine("Items");
            foreach (var orders in OrderItem)
            {
                Console.WriteLine($"- {orders.MenuItem.Name} x{orders.Quantity} - {orders.GetSubTotal()}\n"+
                    $"Special: {orders.SpecialInstructions}");
            }
        }

    }
}
