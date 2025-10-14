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
            UpdateCartButton();
            Cart.CartUpdated += OnCartUpdated;
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
                 new MenuItem { Id = 9, Name = "G.S.M Blue", Price = 50.00m, ImagePath = "96f6a7f7fffb782bf0e31a95e82acdfa.jpg", Category = "Drinks"},
                 new MenuItem { Id = 10,Name = "Mountain Dew (Glass Bottle)", Price = 20.00m, ImagePath = "281-2811643_mountain-dew-glass-bottle-250-ml-beer-bottle.png", Category = "Drinks"},
                 new MenuItem { Id = 11,Name = "Mountain Dew (Plastic)", Price = 25.00m, ImagePath = "mountain_dew_plastic.jpg", Category = "Drinks"},
                 new MenuItem { Id = 12,Name = "Red Horse Beer", Price = 120.00m, ImagePath = "1790523662.jpg", Category = "Drinks"},
                 new MenuItem { Id = 13,Name = "San Miguel Beer", Price = 110.00m, ImagePath = "bt-sanmig-palepilsen_e6e7beea-5e80-420d-8769-0b2caaf2bc7c_1024x1024.png", Category = "Drinks"},
                 new MenuItem { Id = 14,Name = "Coke Mismo", Price = 20.00m, ImagePath = "Coke_mismo.jpg", Category = "Drinks"},
                 new MenuItem { Id = 15,Name = "Pork Belly", Price = 120.00m, ImagePath = "belly.jpeg", Category = "BBQ"},
                 new MenuItem { Id = 16,Name = "Chicharon Bulaklak", Price = 100.00m, ImagePath = "ChicharonBulaklak-640-1.jpg", Category = "Sides"},
                 new MenuItem { Id = 17,Name = "Chicken Skin", Price = 80.00m, ImagePath = "chicken_skin.jpeg", Category = "Sides"},
                 new MenuItem { Id = 18,Name = "Chicken Wings", Price = 150.00m, ImagePath = "chicken_wings.jpg", Category = "Chicken"},
                 new MenuItem { Id = 19,Name = "Grilled Bangus", Price = 160.00m, ImagePath = "Grilled-Stuffed-Milkfish-Recipe (1).jpg", Category = "BBQ"},
                 new MenuItem { Id = 20,Name = "Isaw (5 sticks)", Price = 50.00m, ImagePath = "isaw.jpg", Category = "BBQ"},
                 new MenuItem { Id = 21,Name = "Lechon Kawali", Price = 140.00m, ImagePath = "lechon-kawali-recipe.jpg", Category = "Pares"},
                 new MenuItem { Id = 22,Name = "Halo Halo", Price = 70.00m, ImagePath = "Mang-Inasal-Halo-Halo-1024x1024.jpg", Category = "Desserts"},
                 new MenuItem { Id = 23,Name = "Manglo Float", Price = 60.00m, ImagePath = "mangofloatrecipe.png", Category = "Desserts"},
                 new MenuItem { Id = 24,Name = "Pork Chop", Price = 130.00m, ImagePath = "Pork-Chop.jpg", Category = "Pares"},
                 new MenuItem { Id = 25,Name = "Grilled Liempo", Price = 130.00m, ImagePath = "th (1).jpg", Category = "BBQ"},
                 new MenuItem { Id = 26,Name = "Rice", Price = 10.00m, ImagePath = "rice.jpg", Category = "Sides"},
            };
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Handle Esc for exiting the app
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }

            // Handle Ctrl+A for admin dashboard
            if (keyData == (Keys.Control | Keys.A))
            {
                DashboardForm dashboard = new DashboardForm();
                dashboard.FormBorderStyle = FormBorderStyle.None;
                dashboard.WindowState = FormWindowState.Maximized;
                dashboard.TopMost = true;
                dashboard.Show();
                this.Hide();
                return true;
            }

            // Normal key handling for other keys
            return base.ProcessCmdKey(ref msg, keyData);
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
                    PictureBox pic = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 140 };
                    string imagePath = Path.Combine(Application.StartupPath, "Assets", item.ImagePath);

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            {
                                pic.Image = Image.FromStream(fs);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Image load failed: {item.ImagePath} - {ex.Message}");
                            pic.Image = null;
                        }
                    }
                    else
                    {
                        pic.Image = null;
                    }

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
                    UpdateCartButton();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();

            // Make it completely borderless and full screen
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.WindowState = FormWindowState.Maximized;
            dashboard.TopMost = true;  // keeps it above other windows

            dashboard.Show();
            this.Hide();
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.ShowDialog(); // Or Show() if you want non-modal
            UpdateOrderSummary(); // Refresh the summary when cart form closes
        }

        private void UpdateCartButton()
        {
            // Calculate total items in the cart
            int totalItems = Cart.items.Count;

            // Update the button text
            btnMyCart.Text = $"🛒 My Cart ({totalItems})";
        }

        private void OnCartUpdated()
        {
            // This ensures the UI updates safely even if the event fires from another thread
            if (InvokeRequired)
            {
                Invoke(new Action(OnCartUpdated));
                return;
            }

            UpdateOrderSummary();
            UpdateCartButton();
        }

        private void Feedbackbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Are you a member?",
        "Membership Check",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Show feedback form centered on screen
                customerEmail feedbackForm = new customerEmail();
                feedbackForm.StartPosition = FormStartPosition.CenterScreen;
                feedbackForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must be a member to access feedback.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

    }
}
