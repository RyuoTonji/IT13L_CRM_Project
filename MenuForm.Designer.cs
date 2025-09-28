// File: MenuForm.Designer.cs
namespace MyKioski
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panelCategories = new Panel();
            btnDesserts = new Button();
            btnDrinks = new Button();
            btnSides = new Button();
            btnPares = new Button();
            btnChicken = new Button();
            btnBBQ = new Button();
            btnAll = new Button();
            flpMenu = new FlowLayoutPanel();
            panelOrderSummary = new Panel();
            lblTotal = new Label();
            lblItemCount = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            picLogo = new PictureBox();
            btnMyCart = new Button();
            tableLayoutPanel1.SuspendLayout();
            panelCategories.SuspendLayout();
            panelOrderSummary.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelCategories, 0, 1);
            tableLayoutPanel1.Controls.Add(flpMenu, 1, 1);
            tableLayoutPanel1.Controls.Add(panelOrderSummary, 0, 2);
            tableLayoutPanel1.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 104F));
            tableLayoutPanel1.Size = new Size(1475, 841);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelCategories
            // 
            panelCategories.BackColor = Color.WhiteSmoke;
            panelCategories.Controls.Add(btnDesserts);
            panelCategories.Controls.Add(btnDrinks);
            panelCategories.Controls.Add(btnSides);
            panelCategories.Controls.Add(btnPares);
            panelCategories.Controls.Add(btnChicken);
            panelCategories.Controls.Add(btnBBQ);
            panelCategories.Controls.Add(btnAll);
            panelCategories.Dock = DockStyle.Fill;
            panelCategories.Location = new Point(4, 118);
            panelCategories.Margin = new Padding(4, 3, 4, 3);
            panelCategories.Name = "panelCategories";
            panelCategories.Size = new Size(249, 616);
            panelCategories.TabIndex = 0;
            // 
            // btnDesserts
            // 
            btnDesserts.Dock = DockStyle.Top;
            btnDesserts.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnDesserts.Location = new Point(0, 414);
            btnDesserts.Margin = new Padding(4, 3, 4, 3);
            btnDesserts.Name = "btnDesserts";
            btnDesserts.Size = new Size(249, 69);
            btnDesserts.TabIndex = 6;
            btnDesserts.Text = "Desserts";
            btnDesserts.UseVisualStyleBackColor = true;
            btnDesserts.Click += CategoryButton_Click;
            // 
            // btnDrinks
            // 
            btnDrinks.Dock = DockStyle.Top;
            btnDrinks.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnDrinks.Location = new Point(0, 345);
            btnDrinks.Margin = new Padding(4, 3, 4, 3);
            btnDrinks.Name = "btnDrinks";
            btnDrinks.Size = new Size(249, 69);
            btnDrinks.TabIndex = 5;
            btnDrinks.Text = "Drinks";
            btnDrinks.UseVisualStyleBackColor = true;
            btnDrinks.Click += CategoryButton_Click;
            // 
            // btnSides
            // 
            btnSides.Dock = DockStyle.Top;
            btnSides.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnSides.Location = new Point(0, 276);
            btnSides.Margin = new Padding(4, 3, 4, 3);
            btnSides.Name = "btnSides";
            btnSides.Size = new Size(249, 69);
            btnSides.TabIndex = 4;
            btnSides.Text = "Sides";
            btnSides.UseVisualStyleBackColor = true;
            btnSides.Click += CategoryButton_Click;
            // 
            // btnPares
            // 
            btnPares.Dock = DockStyle.Top;
            btnPares.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnPares.Location = new Point(0, 207);
            btnPares.Margin = new Padding(4, 3, 4, 3);
            btnPares.Name = "btnPares";
            btnPares.Size = new Size(249, 69);
            btnPares.TabIndex = 3;
            btnPares.Text = "Pares";
            btnPares.UseVisualStyleBackColor = true;
            btnPares.Click += CategoryButton_Click;
            // 
            // btnChicken
            // 
            btnChicken.Dock = DockStyle.Top;
            btnChicken.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnChicken.Location = new Point(0, 138);
            btnChicken.Margin = new Padding(4, 3, 4, 3);
            btnChicken.Name = "btnChicken";
            btnChicken.Size = new Size(249, 69);
            btnChicken.TabIndex = 2;
            btnChicken.Text = "Chicken";
            btnChicken.UseVisualStyleBackColor = true;
            btnChicken.Click += CategoryButton_Click;
            // 
            // btnBBQ
            // 
            btnBBQ.Dock = DockStyle.Top;
            btnBBQ.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnBBQ.Location = new Point(0, 69);
            btnBBQ.Margin = new Padding(4, 3, 4, 3);
            btnBBQ.Name = "btnBBQ";
            btnBBQ.Size = new Size(249, 69);
            btnBBQ.TabIndex = 1;
            btnBBQ.Text = "BBQ";
            btnBBQ.UseVisualStyleBackColor = true;
            btnBBQ.Click += CategoryButton_Click;
            // 
            // btnAll
            // 
            btnAll.Dock = DockStyle.Top;
            btnAll.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnAll.Location = new Point(0, 0);
            btnAll.Margin = new Padding(4, 3, 4, 3);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(249, 69);
            btnAll.TabIndex = 0;
            btnAll.Text = "All";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += CategoryButton_Click;
            // 
            // flpMenu
            // 
            flpMenu.AutoScroll = true;
            flpMenu.BackColor = Color.Gainsboro;
            flpMenu.Dock = DockStyle.Fill;
            flpMenu.Location = new Point(261, 118);
            flpMenu.Margin = new Padding(4, 3, 4, 3);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(12);
            flpMenu.Size = new Size(1210, 616);
            flpMenu.TabIndex = 1;
            // 
            // panelOrderSummary
            // 
            panelOrderSummary.BackColor = Color.White;
            tableLayoutPanel1.SetColumnSpan(panelOrderSummary, 2);
            panelOrderSummary.Controls.Add(lblTotal);
            panelOrderSummary.Controls.Add(lblItemCount);
            panelOrderSummary.Dock = DockStyle.Fill;
            panelOrderSummary.Location = new Point(4, 740);
            panelOrderSummary.Margin = new Padding(4, 3, 4, 3);
            panelOrderSummary.Name = "panelOrderSummary";
            panelOrderSummary.Size = new Size(1467, 98);
            panelOrderSummary.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTotal.Location = new Point(1278, 27);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(168, 37);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // lblItemCount
            // 
            lblItemCount.AutoSize = true;
            lblItemCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblItemCount.Location = new Point(27, 27);
            lblItemCount.Margin = new Padding(4, 0, 4, 0);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(191, 37);
            lblItemCount.TabIndex = 0;
            lblItemCount.Text = "Item Count: 0";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.DarkRed;
            tableLayoutPanel1.SetColumnSpan(panelHeader, 2);
            panelHeader.Controls.Add(btnMyCart);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(4, 3);
            panelHeader.Margin = new Padding(4, 3, 4, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1467, 109);
            panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.RosyBrown;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(250, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1217, 109);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "BBQ-Lagao at Beef Pares";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.RosyBrown;
            picLogo.Dock = DockStyle.Left;
            picLogo.Location = new Point(0, 0);
            picLogo.Margin = new Padding(4, 3, 4, 3);
            picLogo.Name = "picLogo";
            picLogo.Padding = new Padding(12);
            picLogo.Size = new Size(250, 109);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // btnMyCart
            // 
            btnMyCart.BackColor = Color.ForestGreen;
            btnMyCart.Dock = DockStyle.Right;
            btnMyCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMyCart.ForeColor = Color.White;
            btnMyCart.Location = new Point(1287, 0);
            btnMyCart.Name = "btnMyCart";
            btnMyCart.Size = new Size(180, 109);
            btnMyCart.TabIndex = 2;
            btnMyCart.Text = "\U0001f6d2 My Cart (0)";
            btnMyCart.UseVisualStyleBackColor = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 841);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuForm";
            Text = "MenuForm";
            WindowState = FormWindowState.Maximized;
            Load += MenuForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panelCategories.ResumeLayout(false);
            panelOrderSummary.ResumeLayout(false);
            panelOrderSummary.PerformLayout();
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Panel panelOrderSummary;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnBBQ;
        private System.Windows.Forms.Button btnChicken;
        private System.Windows.Forms.Button btnPares;
        private System.Windows.Forms.Button btnSides;
        private System.Windows.Forms.Button btnDrinks;
        private System.Windows.Forms.Button btnDesserts;
        private Button btnMyCart;
    }
}