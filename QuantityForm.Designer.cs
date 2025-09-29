namespace MyKioski
{
    partial class QuantityForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnAddItemToCart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(0, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(384, 50);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblItemPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblItemPrice.Location = new System.Drawing.Point(0, 50);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(384, 30);
            this.lblItemPrice.TabIndex = 1;
            this.lblItemPrice.Text = "Price: ₱0.00";
            this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.btnIncrease);
            this.panel1.Controls.Add(this.btnDecrease);
            this.panel1.Location = new System.Drawing.Point(92, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 60);
            this.panel1.TabIndex = 2;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.Location = new System.Drawing.Point(70, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(60, 60);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "1";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnIncrease.Location = new System.Drawing.Point(130, 0);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(70, 60);
            this.btnIncrease.TabIndex = 1;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnDecrease.Location = new System.Drawing.Point(0, 0);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(70, 60);
            this.btnDecrease.TabIndex = 0;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnAddItemToCart
            // 
            this.btnAddItemToCart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddItemToCart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddItemToCart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnAddItemToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddItemToCart.Location = new System.Drawing.Point(0, 181);
            this.btnAddItemToCart.Name = "btnAddItemToCart";
            this.btnAddItemToCart.Size = new System.Drawing.Size(384, 60);
            this.btnAddItemToCart.TabIndex = 3;
            this.btnAddItemToCart.Text = "Add to Cart";
            this.btnAddItemToCart.UseVisualStyleBackColor = false;
            this.btnAddItemToCart.Click += new System.EventHandler(this.btnAddItemToCart_Click);
            // 
            // QuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.btnAddItemToCart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "QuantityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Quantity";
            this.Load += new System.EventHandler(this.QuantityForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnAddItemToCart;
    }
}