namespace MyKioski
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            panelBottom = new Panel();
            btnCheckout = new Button();
            btnBack = new Button();
            lblFinalTotal = new Label();
            dgvCart = new DataGridView();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.WhiteSmoke;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(915, 69);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(915, 69);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Review Your Order";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.WhiteSmoke;
            panelBottom.Controls.Add(btnCheckout);
            panelBottom.Controls.Add(btnBack);
            panelBottom.Controls.Add(lblFinalTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 555);
            panelBottom.Margin = new Padding(4, 3, 4, 3);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(915, 92);
            panelBottom.TabIndex = 1;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.ForestGreen;
            btnCheckout.Dock = DockStyle.Right;
            btnCheckout.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(541, 0);
            btnCheckout.Margin = new Padding(4, 3, 4, 3);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(187, 92);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Proceed to Payment";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DarkGray;
            btnBack.Dock = DockStyle.Right;
            btnBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(728, 0);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(187, 92);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.Dock = DockStyle.Left;
            lblFinalTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinalTotal.Location = new Point(0, 0);
            lblFinalTotal.Margin = new Padding(4, 0, 4, 0);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Padding = new Padding(23, 0, 0, 0);
            lblFinalTotal.Size = new Size(534, 92);
            lblFinalTotal.TabIndex = 0;
            lblFinalTotal.Text = "Final Total: ₱0.00";
            lblFinalTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 69);
            dgvCart.Margin = new Padding(4, 3, 4, 3);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 40;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(915, 486);
            dgvCart.TabIndex = 2;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 647);
            Controls.Add(dgvCart);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Order Summary";
            Load += CartForm_Load;
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFinalTotal;
        private System.Windows.Forms.DataGridView dgvCart;
    }
}