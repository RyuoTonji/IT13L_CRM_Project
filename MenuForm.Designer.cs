// File: MenuForm.Designer.cs
namespace MyKioskApp
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.btnDesserts = new System.Windows.Forms.Button();
            this.btnPork = new System.Windows.Forms.Button();
            this.btnChicken = new System.Windows.Forms.Button();
            this.btnBBQ = new System.Windows.Forms.Button();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.panelCategories, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpMenu, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelCategories
            // 
            this.panelCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelCategories.Controls.Add(this.btnDesserts);
            this.panelCategories.Controls.Add(this.btnPork);
            this.panelCategories.Controls.Add(this.btnChicken);
            this.panelCategories.Controls.Add(this.btnBBQ);
            this.panelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCategories.Location = new System.Drawing.Point(3, 3);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(194, 444);
            this.panelCategories.TabIndex = 0;
            // 
            // btnDesserts
            // 
            this.btnDesserts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDesserts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDesserts.Location = new System.Drawing.Point(0, 180);
            this.btnDesserts.Name = "btnDesserts";
            this.btnDesserts.Size = new System.Drawing.Size(194, 60);
            this.btnDesserts.TabIndex = 3;
            this.btnDesserts.Text = "Desserts";
            this.btnDesserts.UseVisualStyleBackColor = true;
            // 
            // btnPork
            // 
            this.btnPork.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPork.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPork.Location = new System.Drawing.Point(0, 120);
            this.btnPork.Name = "btnPork";
            this.btnPork.Size = new System.Drawing.Size(194, 60);
            this.btnPork.TabIndex = 2;
            this.btnPork.Text = "Pork";
            this.btnPork.UseVisualStyleBackColor = true;
            // 
            // btnChicken
            // 
            this.btnChicken.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChicken.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnChicken.Location = new System.Drawing.Point(0, 60);
            this.btnChicken.Name = "btnChicken";
            this.btnChicken.Size = new System.Drawing.Size(194, 60);
            this.btnChicken.TabIndex = 1;
            this.btnChicken.Text = "Chicken";
            this.btnChicken.UseVisualStyleBackColor = true;
            // 
            // btnBBQ
            // 
            this.btnBBQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBBQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBBQ.Location = new System.Drawing.Point(0, 0);
            this.btnBBQ.Name = "btnBBQ";
            this.btnBBQ.Size = new System.Drawing.Size(194, 60);
            this.btnBBQ.TabIndex = 0;
            this.btnBBQ.Text = "BBQ";
            this.btnBBQ.UseVisualStyleBackColor = true;
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.BackColor = System.Drawing.Color.White;
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(203, 3);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(594, 444);
            this.flpMenu.TabIndex = 1;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelCategories.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Button btnDesserts;
        private System.Windows.Forms.Button btnPork;
        private System.Windows.Forms.Button btnChicken;
        private System.Windows.Forms.Button btnBBQ;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
    }
}