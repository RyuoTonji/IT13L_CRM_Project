using System.Collections.Generic;
using System.Linq;

namespace MyKioski.Models
{
    public static class Cart
    {
        // The list now holds CartItems
        public static List<CartItem> items = new List<CartItem>();

        // This method is now smarter. If an item exists, it increases the quantity.
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

        public static void IncreaseQuantity(int itemId)
        {
            var item = items.FirstOrDefault(i => i.Item.Id == itemId);
            if (item != null)
            {
                item.Quantity++;
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
            }
        }

        public static void ClearCart() { items.Clear(); }
        public static decimal GetTotal() { return items.Sum(item => item.Subtotal); }
        public static int GetItemCount() { return items.Sum(item => item.Quantity); }
    }
}