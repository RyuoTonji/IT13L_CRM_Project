// File: MenuForm.cs
using MyKioskApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyKioskApp
{
    public partial class MenuForm : Form
    {
        private List<MenuItem> allMenuItems;

        public MenuForm() { InitializeComponent(); }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoadFullProductCatalog();
            DisplayMenuItems(allMenuItems);
            this.btnBBQ.Click += new System.EventHandler(this.CategoryButton_Click);
            this.btnChicken.Click += new System.EventHandler(this.CategoryButton_Click);
            this.btnPork.Click += new System.EventHandler(this.CategoryButton_Click);
            this.btnDesserts.Click += new System.EventHandler(this.CategoryButton_Click);
        }

        private void LoadFullProductCatalog()
        {
            allMenuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Special Beef Pares", Price = 120.00m, ImagePath = "pares.jpg", Category = "Pork" },
                new MenuItem { Id = 2, Name = "Pork BBQ (3 sticks)", Price = 90.00m, ImagePath = "pork_bbq.jpg", Category = "BBQ" },
                new MenuItem { Id = 3, Name = "Lava Chicken", Price = 110.00m, ImagePath = "lava_chicken.jpg", Category = "Chicken" },
                new MenuItem { Id = 4, Name = "Leche Flan", Price = 50.00m, ImagePath = "leche_flan.jpg", Category = "Desserts" },
            };
        }

        private void DisplayMenuItems(List<MenuItem> itemsToShow)
        {
            flpMenu.Controls.Clear();
            foreach (var item in itemsToShow)
            {
                Panel card = new Panel { Width = 180, Height = 220, Margin = new Padding(10), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
                PictureBox pic = new PictureBox { Image = Image.FromFile("Assets/" + item.ImagePath), SizeMode = PictureBoxSizeMode.StretchImage, Dock = DockStyle.Top, Height = 120 };
                Label nameLabel = new Label { Text = item.Name, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 10, FontStyle.Bold), Height = 40 };
                Label priceLabel = new Label { Text = $"₱{item.Price:F2}", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DarkRed };

                card.Controls.Add(priceLabel);
                card.Controls.Add(nameLabel);
                card.Controls.Add(pic);

                flpMenu.Controls.Add(card);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string category = clickedButton.Text;
            var filteredItems = allMenuItems.Where(item => item.Category == category).ToList();
            DisplayMenuItems(filteredItems);
        }
    }
}