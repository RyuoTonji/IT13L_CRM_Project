using System.Drawing;

namespace MyKioski.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        // For file-based images (backward compatibility)
        public string ImagePath { get; set; }

        // NEW: For database-stored images
        public Image ProductImage { get; set; }
    }
}