// File: Models/Cart.cs
using System.Collections.Generic;
using System.Linq;

namespace MyKioskApp.Models
{
    public static class Cart
    {
        public static List<MenuItem> items = new List<MenuItem>();
        public static void AddItem(MenuItem item) { items.Add(item); }
        public static decimal GetTotal() { return items.Sum(item => item.Price); }
        public static int GetItemCount() { return items.Count; }
    }
}