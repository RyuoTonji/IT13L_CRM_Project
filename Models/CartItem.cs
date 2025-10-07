namespace MyKioski.Models
{
    public class CartItem
    {
        // The product itself (e.g., Pork BBQ)
        public MenuItem Item { get; set; } = null!;

        // How many of this product (e.g., 3)
        public int Quantity { get; set; }

        // A calculated property for the subtotal (Price * Quantity)
        public decimal Subtotal => Item.Price * Quantity;
    }
}