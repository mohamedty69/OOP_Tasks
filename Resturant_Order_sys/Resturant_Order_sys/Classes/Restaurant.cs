using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant_Order_sys.Classes
{
    public class Restaurant
    {
        public Restaurant(string restaurantName, decimal taxRate)
        {
            RestaurantName = restaurantName;
            Menu = new Menu(restaurantName, new List<MenuItem>()); 
            OrderList = new List<Order>(); 
            if (taxRate < 0) throw new ArgumentException("Tax Rate can not be negative");
            TaxRate = taxRate;
        }
        public string RestaurantName { get; set; }
        public Menu Menu { get; set; }
        public List<Order> OrderList { get; set; }
        public decimal TaxRate { get; set; }
        public Order CreateOrder(string orderId, int tableNumber)
        {
            var order = new Order(orderId, tableNumber);
            OrderList.Add(order);
            return order;

        }
        public Order GetOrder(string orderId)
        {
            var order = OrderList.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) throw new ArgumentNullException("The order is not exist");
            return order;
        }
        public List<Order> GetOrderByStatus(string status)
        {
            var order = OrderList.Where(o => o.Status == status).ToList();
            if (order == null) throw new ArgumentNullException("The order is not exist");
            return order;
        }
        public List<Order> GetActiveOrders()
        {
            var order = OrderList.Where(o => o.Status.ToLower() != "completed").ToList();
            if (order == null) throw new ArgumentNullException("The order is not exist");
            return order;
        }
        public void CompleteOrder(string orderId)
        {
            var order = OrderList.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) throw new ArgumentNullException("The order is not exist");
            order.Status = "Completed";
        }
        public decimal GetTotalRevenue()
        {
            var order = OrderList.Where(o => o.Status.ToLower() == "completed").ToList();
            if (order == null) throw new ArgumentNullException("The order is not exist");
            var sum = order.Select(o => o.GetSubTotalPlusTax()).Sum();
            return sum;
        }
        public void GetPopularItem(int count)
        {
            if (OrderList.Count == 0) throw new InvalidOperationException("The list is empty");
            //var popularOrder = OrderList.Select(o => o.OrderItem.Select(i => i.MenuItem.Name), o.OrderItem.GroupBy(i => i.MenuItem.ItemId).Count()).ToList();
            // Flatten all order items, group by MenuItem.ItemId, sum quantities, order by descending, take top 'count'
            var popularItems = OrderList
                .SelectMany(o => o.OrderItem)
                .GroupBy(i => i.MenuItem.ItemId)
                .Select(g => new { ItemId = g.Key, Name = g.First().MenuItem.Name, TotalQuantity = g.Sum(i => i.Quantity) })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(count)
                .ToList();
            // You can return or process popularItems as needed
            foreach (var p in popularItems)
            {
                Console.WriteLine($"{p.Name} - {p.TotalQuantity}");
            }
        }
    }
}
