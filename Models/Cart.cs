using System.Collections.Generic;
using System.Linq;

namespace MyKioski.Models
{
    public static class Cart
    {
        public static List<CartItem> items = new List<CartItem>();

        // This is the old method, we'll keep it for now
        public static void AddItem(MenuItem itemToAdd)
        {
            var existingItem = items.FirstOrDefault(i => i.Item.Id == itemToAdd.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                items.Add(new CartItem { Item = itemToAdd, Quantity = 1 });
            }
        }

        // --- THIS IS THE NEW, MORE POWERFUL METHOD ---
        public static void AddItemWithQuantity(MenuItem itemToAdd, int quantity)
        {
            var existingItem = items.FirstOrDefault(i => i.Item.Id == itemToAdd.Id);
            if (existingItem != null)
            {
                // If item is already in cart, just add the new quantity to the old one
                existingItem.Quantity += quantity;
            }
            else
            {
                // If it's a new item, add it with the selected quantity
                items.Add(new CartItem { Item = itemToAdd, Quantity = quantity });
            }
        }

        public static void IncreaseQuantity(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Item.Id == itemId);
            if (item != null) { item.Quantity++; }
        }

        public static void DecreaseQuantity(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Item.Id == itemId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0) { items.Remove(item); }
            }
        }

        public static void ClearCart() { items.Clear(); }
        public static decimal GetTotal() { return items.Sum(item => item.Subtotal); }
        public static int GetItemCount() { return items.Sum(item => item.Quantity); }
    }
}