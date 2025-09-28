namespace MyKioski
{
    partial class OrderTypeForm
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
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnTakeOut = new Button();
            btnDineIn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 58, 0, 0);
            lblTitle.Size = new Size(1475, 173);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "How would you like to enjoy your meal?";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(btnTakeOut, 1, 0);
            tableLayoutPanel1.Controls.Add(btnDineIn, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 173);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(58, 0, 58, 115);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1475, 668);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnTakeOut
            // 
            btnTakeOut.Dock = DockStyle.Fill;
            btnTakeOut.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTakeOut.Location = new Point(760, 23);
            btnTakeOut.Margin = new Padding(23, 23, 23, 23);
            btnTakeOut.Name = "btnTakeOut";
            btnTakeOut.Size = new Size(634, 507);
            btnTakeOut.TabIndex = 1;
            btnTakeOut.Text = "Take Out";
            btnTakeOut.UseVisualStyleBackColor = true;
            // 
            // btnDineIn
            // 
            btnDineIn.Dock = DockStyle.Fill;
            btnDineIn.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDineIn.Location = new Point(81, 23);
            btnDineIn.Margin = new Padding(23, 23, 23, 23);
            btnDineIn.Name = "btnDineIn";
            btnDineIn.Size = new Size(633, 507);
            btnDineIn.TabIndex = 0;
            btnDineIn.Text = "Dine In";
            btnDineIn.UseVisualStyleBackColor = true;
            // 
            // OrderTypeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1475, 841);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderTypeForm";
            Text = "OrderTypeForm";
            WindowState = FormWindowState.Maximized;
            Load += OrderTypeForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTakeOut;
        private System.Windows.Forms.Button btnDineIn;
    }
}