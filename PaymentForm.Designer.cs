namespace MyKioski
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPayGCash = new System.Windows.Forms.Button();
            this.btnPayCash = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(584, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Please Select Your Payment Method";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAmountDue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAmountDue.Location = new System.Drawing.Point(0, 80);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(584, 60);
            this.lblAmountDue.TabIndex = 1;
            this.lblAmountDue.Text = "Amount Due: ₱0.00";
            this.lblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPayGCash);
            this.panel1.Controls.Add(this.btnPayCash);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(40, 20, 40, 40);
            this.panel1.Size = new System.Drawing.Size(584, 221);
            this.panel1.TabIndex = 2;
            // 
            // btnPayGCash
            // 
            this.btnPayGCash.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPayGCash.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPayGCash.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnPayGCash.ForeColor = System.Drawing.Color.White;
            this.btnPayGCash.Location = new System.Drawing.Point(304, 20);
            this.btnPayGCash.Name = "btnPayGCash";
            this.btnPayGCash.Size = new System.Drawing.Size(240, 161);
            this.btnPayGCash.TabIndex = 1;
            this.btnPayGCash.Text = "Pay with GCash";
            this.btnPayGCash.UseVisualStyleBackColor = false;
            this.btnPayGCash.Click += new System.EventHandler(this.btnPayGCash_Click);
            // 
            // btnPayCash
            // 
            this.btnPayCash.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPayCash.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPayCash.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnPayCash.ForeColor = System.Drawing.Color.White;
            this.btnPayCash.Location = new System.Drawing.Point(40, 20);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(240, 161);
            this.btnPayCash.TabIndex = 0;
            this.btnPayCash.Text = "Pay with Cash";
            this.btnPayCash.UseVisualStyleBackColor = false;
            this.btnPayCash.Click += new System.EventHandler(this.btnPayCash_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAmountDue);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPayGCash;
        private System.Windows.Forms.Button btnPayCash;
    }
}