using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant_Order_sys.Classes
{
    public class Menu
    {
        public Menu(string resturantName, List<MenuItem> items)
        {
            ResturantName = resturantName;
            Items = items;
        }
        public string ResturantName { get; set; }
        public List<MenuItem> Items { get; set; }
        public void AddMenuItem(MenuItem item) {
            var Litem = Items.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (Litem != null)
            {
                throw new InvalidOperationException("Item is already excist");
            }
            Items.Add(item);
        }
        public void RemoveMenuItem(string itemId)
        {
            var item = Items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                Items.Remove(item);
            }
            else throw new InvalidOperationException("Item is not found");
        }
        public List<MenuItem> GetItemsByCategory(string category) =>
            Items.Where(i => i.Category == category).ToList();
        public List<MenuItem> SearchItems(string name) =>
             Items.Where(i => i.Name == name).ToList();
        public List<MenuItem> DisplayMenu() =>
            Items
                .Where(i => i.IsAvailable)
                .OrderBy(i => i.Category) 
                .ToList();
    }
}
