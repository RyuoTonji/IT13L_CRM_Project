using System;
using System.Collections.Generic;

namespace MyKioski.Models
{
    public class Order
    {
        public string OrderId { get; set; } = "";
        public DateTime OrderDateTime { get; set; }
        public string PaymentMethod { get; set; } = "";
        public decimal TotalAmount { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public string OrderStatus { get; set; } = "Completed";
    }
}