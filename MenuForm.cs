using MyKioski.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class MenuForm : Form
    {
        private List<MenuItem> allMenuItems;

        public MenuForm() { InitializeComponent(); }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("Assets/logo.png");
            LoadFullProductCatalog();
            DisplayMenuItems(allMenuItems); // Display all items in groups initially
            UpdateOrderSummary();
        }

        private void UpdateOrderSummary()
        {
            lblItemCount.Text = $"Item Count: {Cart.GetItemCount()}";
            lblTotal.Text = $"Total: ₱{Cart.GetTotal():F2}";
        }

        private void LoadFullProductCatalog()
        {
            allMenuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Special Beef Pares", Price = 120.00m, ImagePath = "pares.jpg", Category = "Pares" },
                new MenuItem { Id = 2, Name = "Pork BBQ (3 sticks)", Price = 90.00m, ImagePath = "pork_bbq.jpg", Category = "BBQ" },
                new MenuItem { Id = 3, Name = "Lava Chicken", Price = 110.00m, ImagePath = "lava_chicken.jpg", Category = "Chicken" },
                new MenuItem { Id = 4, Name = "pusit", Price = 25.00m, ImagePath = "pusit.png", Category = "Sides" },
                new MenuItem { Id = 5, Name = "Leche Flan", Price = 50.00m, ImagePath = "leche_flan.jpg", Category = "Desserts" },
                new MenuItem { Id = 6, Name = "Coke", Price = 30.00m, ImagePath = "coke.png", Category = "Drinks" },
                new MenuItem { Id = 7, Name = "Royal", Price = 30.00m, ImagePath = "royal.jpg", Category = "Drinks" },
                new MenuItem { Id = 8, Name = "Sprite", Price = 50.00m, ImagePath = "sprite.jpeg", Category = "Drinks" },
            };
        }

        // --- THIS IS THE NEW, UPGRADED DISPLAY METHOD ---
        private void DisplayMenuItems(List<MenuItem> itemsToShow)
        {
            flpMenu.Controls.Clear();

            // First, group the items by their category using LINQ.
            // This creates groups like: "BBQ" -> {Pork BBQ, Extra Hot BBQ}, "Sides" -> {Garlic Rice, Chicken Skin}
            var groupedItems = itemsToShow.GroupBy(item => item.Category).ToList();

            // Now, loop through each GROUP (e.g., the "BBQ" group, then the "Sides" group)
            foreach (var group in groupedItems)
            {
                // 1. Create a big, bold label for the category name (e.g., "BBQ")
                Label categoryLabel = new Label
                {
                    Text = group.Key.ToUpper(), // The category name, e.g., "BBQ"
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.DarkSlateGray,
                    BackColor = Color.LightGray,
                    Width = flpMenu.ClientSize.Width - 40, // Make it almost as wide as the panel
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(10, 20, 10, 10) // Add some space around it
                };
                flpMenu.Controls.Add(categoryLabel);

                // 2. Now, loop through all the ITEMS within this one group
                foreach (var item in group)
                {
                    // This is the same card-building code as before
                    Panel card = new Panel { Width = 200, Height = 250, Margin = new Padding(15), BackColor = Color.White };
                    PictureBox pic = new PictureBox { Image = Image.FromFile("Assets/" + item.ImagePath), SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 140 };
                    Label nameLabel = new Label { Text = item.Name, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 11, FontStyle.Bold), Height = 50 };
                    Button addButton = new Button { Text = $"ADD - ₱{item.Price:F2}", Dock = DockStyle.Bottom, Height = 60, BackColor = Color.DarkOrange, ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Bold), Tag = item };

                    addButton.Click += AddButton_Click;
                    card.Controls.Add(nameLabel);
                    card.Controls.Add(pic);
                    card.Controls.Add(addButton);

                    flpMenu.Controls.Add(card);
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Get the MenuItem from the button that was clicked
            Button clickedButton = sender as Button;
            MenuItem itemToAdd = clickedButton.Tag as MenuItem;

            // Create our new pop-up form, passing the selected item to it
            using (QuantityForm quantityDialog = new QuantityForm(itemToAdd))
            {
                // Show the pop-up and wait for the user to close it
                // The code will pause here until the user clicks "Add to Cart" or closes the window
                DialogResult result = quantityDialog.ShowDialog();

                // Check if the user clicked the "Add to Cart" button
                if (result == DialogResult.OK)
                {
                    // Get the quantity the user selected from the public property
                    int quantity = quantityDialog.SelectedQuantity;

                    // Use our new, powerful cart method to add the item with its quantity
                    Cart.AddItemWithQuantity(itemToAdd, quantity);

                    // Update the summary display on the main menu
                    UpdateOrderSummary();
                }
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Text == "All")
            {
                DisplayMenuItems(allMenuItems); // The "All" button shows the new grouped view
            }
            else
            {
                // The other category buttons will filter to show only that group
                string category = clickedButton.Text;
                var filteredItems = allMenuItems.Where(item => item.Category == category).ToList();
                DisplayMenuItems(filteredItems);
            }
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.ShowDialog(); // Or Show() if you want non-modal
            UpdateOrderSummary(); // Refresh the summary when cart form closes
        }
    }


}