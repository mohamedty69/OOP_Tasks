using Resturant_Order_sys.Classes;
using System;

namespace Resturant_Order_sys
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
                Console.WriteLine(m.GetItemInfo());
                Console.WriteLine();
            }

            //// Create order for table 5
            //order1 = restaurant.createOrder(5)
            //order1.addItem(burger, 2, "No onions")
            //order1.addItem(fries, 2, "Extra crispy")
            //order1.addItem(soda, 2, "No ice")

            //// Display order summary
            //print(order1.getOrderSummary())

            //// Calculate with tip
            //subtotal = order1.getSubtotal()
            //tax = order1.getTax()
            //tip = order1.calculateTip(0.15)  // 15% tip
            //total = order1.getTotal() + tip

            //print("\nSubtotal: $" + subtotal)
            //print("Tax (8%): $" + tax)
            //print("Tip (15%): $" + tip)
            //print("Total: $" + total)

            //// Update order status
            //order1.updateStatus("Preparing")
            //print("\nOrder status: " + order1.status)

            //order1.updateStatus("Ready")
            //print("Order status: " + order1.status)

            //// Complete order
            //restaurant.completeOrder(order1.orderId)
            //print("Order status: " + order1.status)

            //// Get revenue
            //print("\nTotal Revenue: $" + restaurant.getTotalRevenue())
        }
    }
}
