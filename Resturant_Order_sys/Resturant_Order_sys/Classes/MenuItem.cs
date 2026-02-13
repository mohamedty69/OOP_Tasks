using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant_Order_sys.Classes
{
    public class MenuItem
    {

        public string ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = true;
        public MenuItem(string itemId, string name, string description, decimal price, string category)
        {
            ItemId = itemId;
            Name = name;
            Description = description;
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            else Price = price;
            Category = category;
        }
        public string GetItemInfo() =>
            $"Item ID: {ItemId}\n"+
            $"Name: {Name}\n"+
            $"Description: {Description}\n"+
            $"Price: ${Price}\n"+
            $"Category: {Category}\n"+
            $"Available: {(IsAvailable ? "Yes" : "No")}";
        
    }
}
