using Resturant_Order_sys.Classes;
using System;
using System.Net.WebSockets;

namespace Restaurant_Order_sys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create restaurant
            var restaurant = new Restaurant("Tasty Bites", 0.08m);

            // Create menu items
            var burger = new MenuItem("M001", "Classic Burger",
    "Beef patty with lettuce, tomato, cheese", 12.99m, "Main Course");
            var fries = new MenuItem("M002", "French Fries",
    "Crispy golden fries", 4.99m, "Appetizer");
            var salad = new MenuItem("M003", "Caesar Salad",
    "Fresh romaine with caesar dressing", 8.99m, "Appetizer");
            var soda = new MenuItem("M004", "Soft Drink",
                "Coca-Cola, Sprite, or Fanta", 2.99m, "Beverage");
            var cake = new MenuItem("M005", "Chocolate Cake",
                "Rich chocolate layer cake", 6.99m, "Dessert");

            // Add items to menu
            restaurant.Menu.AddMenuItem(burger);
            restaurant.Menu.AddMenuItem(fries);
            restaurant.Menu.AddMenuItem(salad);
            restaurant.Menu.AddMenuItem(soda);
            restaurant.Menu.AddMenuItem(cake);

            // Display menu
            var menuList = restaurant.Menu.DisplayMenu();
            foreach(var m in menuList)
            {
                Console.WriteLine($" {m.Category}:");
                Console.WriteLine($"-{m.Name}: {m.Description} - {m.Price}");
                Console.WriteLine();
            }

            //// Create order for table 5
            var order1 = restaurant.CreateOrder("ORD001", 5);
            order1.AddItem(burger, 2, "No onions");
            order1.AddItem(fries, 2, "Extra crispy");
            order1.AddItem(soda, 2, "No ice");

            //// Display order summary
            order1.GetOrderSummary();

            //// Calculate with tip
            var subtotal = order1.GetSubTotal();
            var tax = order1.GetTax();
            var tip = order1.CalculateTip(0.15m);  // 15% tip
            var total = order1.GetTotal();
            
            Console.WriteLine($"\nSubtotal: ${subtotal}");
            Console.WriteLine($"Tax: ${tax}");
            Console.WriteLine($"Tip: ${tip}");
            Console.WriteLine($"Total: ${total}");

            //// Update order status
            order1.UpdateStatus("Preparing");
            Console.WriteLine("\nOrder status: " + order1.Status);

            order1.UpdateStatus("Ready");
            Console.WriteLine("Order status: " + order1.Status);

            //// Complete order
            restaurant.CompleteOrder(order1.OrderId);
            Console.WriteLine("Order status: " + order1.Status);

            //// Get revenue
            Console.WriteLine("\nTotal Revenue: $" + restaurant.GetTotalRevenue());
        }
    }
}
