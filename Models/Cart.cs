using System;
using System.Collections.Generic;
using System.Linq;

namespace MyKioski.Models
{
    public static class Cart
    {
        public static List<CartItem> items = new List<CartItem>();

        public static event Action CartUpdated;

        private static void OnCartUpdated()
        {
            CartUpdated?.Invoke();
        }

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
            OnCartUpdated(); // ✅ added
        }

        // --- THIS IS THE NEW, MORE POWERFUL METHOD ---
        public static void AddItemWithQuantity(MenuItem itemToAdd, int quantity)
        {
            var existingItem = items.FirstOrDefault(i => i.Item.Id == itemToAdd.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem { Item = itemToAdd, Quantity = quantity });
            }
            OnCartUpdated(); // ✅ added
        }

        public static void IncreaseQuantity(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Item.Id == itemId);
            if (item != null)
            {
                item.Quantity++;
                OnCartUpdated(); // ✅ added
            }
        }

        public static void DecreaseQuantity(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Item.Id == itemId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    items.Remove(item);
                }
                OnCartUpdated(); // ✅ moved outside so it always fires
            }
        }

        public static void ClearCart()
        {
            items.Clear();
            OnCartUpdated();
        }

        public static decimal GetTotal() => items.Sum(item => item.Subtotal);
        public static int GetItemCount() => items.Sum(item => item.Quantity);
    }
}
