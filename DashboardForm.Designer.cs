namespace MyKioski
{
    partial class DashboardForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panelNavigation = new Panel();
            btnNavCustomerAdmin = new Button();
            btnNavAnalytics = new Button();
            btnNavFoodOrders = new Button();
            lblDashboardTitle = new Label();
            picDashboardLogo = new PictureBox();
            panelContent = new Panel();
            panelCustomerAdmin = new Panel();
            dgvCustomerFeedback = new DataGridView();
            panelFeedbackHeader = new Panel();
            lblFeedbackHeader = new Label();
            panelAnalytics = new Panel();
            tableLayoutAnalytics = new TableLayoutPanel();
            flowLayoutStats = new FlowLayoutPanel();
            panelTotalSales = new Panel();
            lblTotalSalesValue = new Label();
            lblTotalSalesTitle = new Label();
            panelAvgDailySales = new Panel();
            lblAvgDailyValue = new Label();
            lblAvgDailyTitle = new Label();
            panelAvgWeeklySales = new Panel();
            lblAvgWeeklyValue = new Label();
            lblAvgWeeklyTitle = new Label();
            panelAvgMonthlySales = new Panel();
            lblAvgMonthlyValue = new Label();
            lblAvgMonthlyTitle = new Label();
            tableLayoutCharts = new TableLayoutPanel();
            panelAnalyticsHeader = new Panel();
            label2 = new Label();
            panelFoodOrders = new Panel();
            dgvOrders = new DataGridView();
            panelOrdersHeader = new Panel();
            lblOrdersHeader = new Label();
            label4 = new Label();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboardLogo).BeginInit();
            panelContent.SuspendLayout();
            panelCustomerAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerFeedback).BeginInit();
            panelFeedbackHeader.SuspendLayout();
            panelAnalytics.SuspendLayout();
            tableLayoutAnalytics.SuspendLayout();
            flowLayoutStats.SuspendLayout();
            panelTotalSales.SuspendLayout();
            panelAvgDailySales.SuspendLayout();
            panelAvgWeeklySales.SuspendLayout();
            panelAvgMonthlySales.SuspendLayout();
            panelAnalyticsHeader.SuspendLayout();
            panelFoodOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panelOrdersHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 257F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panelNavigation, 0, 0);
            tableLayoutPanel1.Controls.Add(panelContent, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1475, 841);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelNavigation
            // 
            panelNavigation.BackColor = Color.WhiteSmoke;
            panelNavigation.Controls.Add(btnNavCustomerAdmin);
            panelNavigation.Controls.Add(btnNavAnalytics);
            panelNavigation.Controls.Add(btnNavFoodOrders);
            panelNavigation.Controls.Add(lblDashboardTitle);
            panelNavigation.Controls.Add(picDashboardLogo);
            panelNavigation.Location = new Point(4, 3);
            panelNavigation.Margin = new Padding(4, 3, 4, 3);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(249, 811);
            panelNavigation.TabIndex = 0;
            // 
            // btnNavCustomerAdmin
            // 
            btnNavCustomerAdmin.Dock = DockStyle.Top;
            btnNavCustomerAdmin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNavCustomerAdmin.Location = new Point(0, 311);
            btnNavCustomerAdmin.Margin = new Padding(4, 3, 4, 3);
            btnNavCustomerAdmin.Name = "btnNavCustomerAdmin";
            btnNavCustomerAdmin.Size = new Size(249, 69);
            btnNavCustomerAdmin.TabIndex = 5;
            btnNavCustomerAdmin.Text = "Customer Feedback";
            btnNavCustomerAdmin.UseVisualStyleBackColor = true;
            // 
            // btnNavAnalytics
            // 
            btnNavAnalytics.Dock = DockStyle.Top;
            btnNavAnalytics.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNavAnalytics.Location = new Point(0, 242);
            btnNavAnalytics.Margin = new Padding(4, 3, 4, 3);
            btnNavAnalytics.Name = "btnNavAnalytics";
            btnNavAnalytics.Size = new Size(249, 69);
            btnNavAnalytics.TabIndex = 3;
            btnNavAnalytics.Text = "Analytics";
            btnNavAnalytics.UseVisualStyleBackColor = true;
            // 
            // btnNavFoodOrders
            // 
            btnNavFoodOrders.Dock = DockStyle.Top;
            btnNavFoodOrders.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNavFoodOrders.Location = new Point(0, 173);
            btnNavFoodOrders.Margin = new Padding(4, 3, 4, 3);
            btnNavFoodOrders.Name = "btnNavFoodOrders";
            btnNavFoodOrders.Size = new Size(249, 69);
            btnNavFoodOrders.TabIndex = 2;
            btnNavFoodOrders.Text = "Food Orders";
            btnNavFoodOrders.UseVisualStyleBackColor = true;
            btnNavFoodOrders.Click += btnNavFoodOrders_Click;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Dock = DockStyle.Top;
            lblDashboardTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblDashboardTitle.Location = new Point(0, 115);
            lblDashboardTitle.Margin = new Padding(4, 0, 4, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(249, 58);
            lblDashboardTitle.TabIndex = 1;
            lblDashboardTitle.Text = "BBQ-Lagao";
            lblDashboardTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picDashboardLogo
            // 
            picDashboardLogo.Dock = DockStyle.Top;
            picDashboardLogo.Location = new Point(0, 0);
            picDashboardLogo.Margin = new Padding(4, 3, 4, 3);
            picDashboardLogo.Name = "picDashboardLogo";
            picDashboardLogo.Size = new Size(249, 115);
            picDashboardLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picDashboardLogo.TabIndex = 0;
            picDashboardLogo.TabStop = false;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelCustomerAdmin);
            panelContent.Controls.Add(panelAnalytics);
            panelContent.Controls.Add(panelFoodOrders);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(261, 3);
            panelContent.Margin = new Padding(4, 3, 4, 3);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1210, 835);
            panelContent.TabIndex = 1;
            // 
            // panelCustomerAdmin
            // 
            panelCustomerAdmin.BackColor = Color.LightGoldenrodYellow;
            panelCustomerAdmin.Controls.Add(dgvCustomerFeedback);
            panelCustomerAdmin.Controls.Add(panelFeedbackHeader);
            panelCustomerAdmin.Dock = DockStyle.Fill;
            panelCustomerAdmin.Location = new Point(0, 0);
            panelCustomerAdmin.Name = "panelCustomerAdmin";
            panelCustomerAdmin.Size = new Size(1210, 835);
            panelCustomerAdmin.TabIndex = 3;
            // 
            // dgvCustomerFeedback
            // 
            dgvCustomerFeedback.AllowUserToAddRows = false;
            dgvCustomerFeedback.AllowUserToDeleteRows = false;
            dgvCustomerFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerFeedback.BackgroundColor = Color.White;
            dgvCustomerFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerFeedback.Dock = DockStyle.Fill;
            dgvCustomerFeedback.Location = new Point(0, 69);
            dgvCustomerFeedback.Name = "dgvCustomerFeedback";
            dgvCustomerFeedback.ReadOnly = true;
            dgvCustomerFeedback.RowHeadersVisible = false;
            dgvCustomerFeedback.Size = new Size(1210, 766);
            dgvCustomerFeedback.TabIndex = 2;
            // 
            // panelFeedbackHeader
            // 
            panelFeedbackHeader.BackColor = Color.IndianRed;
            panelFeedbackHeader.Controls.Add(lblFeedbackHeader);
            panelFeedbackHeader.Dock = DockStyle.Top;
            panelFeedbackHeader.Location = new Point(0, 0);
            panelFeedbackHeader.Name = "panelFeedbackHeader";
            panelFeedbackHeader.Size = new Size(1210, 69);
            panelFeedbackHeader.TabIndex = 3;
            // 
            // lblFeedbackHeader
            // 
            lblFeedbackHeader.Dock = DockStyle.Fill;
            lblFeedbackHeader.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFeedbackHeader.Location = new Point(0, 0);
            lblFeedbackHeader.Name = "lblFeedbackHeader";
            lblFeedbackHeader.Size = new Size(1210, 69);
            lblFeedbackHeader.TabIndex = 0;
            lblFeedbackHeader.Text = "Customer Feedback";
            lblFeedbackHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAnalytics
            // 
            panelAnalytics.BackColor = Color.LightGray;
            panelAnalytics.Controls.Add(tableLayoutAnalytics);
            panelAnalytics.Controls.Add(panelAnalyticsHeader);
            panelAnalytics.Dock = DockStyle.Fill;
            panelAnalytics.Location = new Point(0, 0);
            panelAnalytics.Margin = new Padding(4, 3, 4, 3);
            panelAnalytics.Name = "panelAnalytics";
            panelAnalytics.Size = new Size(1210, 835);
            panelAnalytics.TabIndex = 1;
            // 
            // tableLayoutAnalytics
            // 
            tableLayoutAnalytics.ColumnCount = 2;
            tableLayoutAnalytics.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutAnalytics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutAnalytics.Controls.Add(flowLayoutStats, 0, 0);
            tableLayoutAnalytics.Controls.Add(tableLayoutCharts, 1, 0);
            tableLayoutAnalytics.Dock = DockStyle.Fill;
            tableLayoutAnalytics.Location = new Point(0, 69);
            tableLayoutAnalytics.Name = "tableLayoutAnalytics";
            tableLayoutAnalytics.RowCount = 1;
            tableLayoutAnalytics.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutAnalytics.Size = new Size(1210, 766);
            tableLayoutAnalytics.TabIndex = 4;
            // 
            // flowLayoutStats
            // 
            flowLayoutStats.Controls.Add(panelTotalSales);
            flowLayoutStats.Controls.Add(panelAvgDailySales);
            flowLayoutStats.Controls.Add(panelAvgWeeklySales);
            flowLayoutStats.Controls.Add(panelAvgMonthlySales);
            flowLayoutStats.Dock = DockStyle.Fill;
            flowLayoutStats.FlowDirection = FlowDirection.TopDown;
            flowLayoutStats.Location = new Point(3, 3);
            flowLayoutStats.Name = "flowLayoutStats";
            flowLayoutStats.Size = new Size(294, 760);
            flowLayoutStats.TabIndex = 0;
            flowLayoutStats.WrapContents = false;
            // 
            // panelTotalSales
            // 
            panelTotalSales.BackColor = Color.White;
            panelTotalSales.Controls.Add(lblTotalSalesValue);
            panelTotalSales.Controls.Add(lblTotalSalesTitle);
            panelTotalSales.Location = new Point(3, 3);
            panelTotalSales.Margin = new Padding(3, 3, 3, 15);
            panelTotalSales.Name = "panelTotalSales";
            panelTotalSales.Size = new Size(280, 120);
            panelTotalSales.TabIndex = 0;
            // 
            // lblTotalSalesValue
            // 
            lblTotalSalesValue.Dock = DockStyle.Fill;
            lblTotalSalesValue.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalSalesValue.Location = new Point(0, 50);
            lblTotalSalesValue.Name = "lblTotalSalesValue";
            lblTotalSalesValue.Size = new Size(280, 70);
            lblTotalSalesValue.TabIndex = 1;
            lblTotalSalesValue.Text = "₱0.00";
            lblTotalSalesValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalSalesTitle
            // 
            lblTotalSalesTitle.Dock = DockStyle.Top;
            lblTotalSalesTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalSalesTitle.Location = new Point(0, 0);
            lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            lblTotalSalesTitle.Size = new Size(280, 50);
            lblTotalSalesTitle.TabIndex = 0;
            lblTotalSalesTitle.Text = "Total Sales";
            lblTotalSalesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAvgDailySales
            // 
            panelAvgDailySales.BackColor = Color.White;
            panelAvgDailySales.Controls.Add(lblAvgDailyValue);
            panelAvgDailySales.Controls.Add(lblAvgDailyTitle);
            panelAvgDailySales.Location = new Point(3, 141);
            panelAvgDailySales.Margin = new Padding(3, 3, 3, 15);
            panelAvgDailySales.Name = "panelAvgDailySales";
            panelAvgDailySales.Size = new Size(280, 120);
            panelAvgDailySales.TabIndex = 1;
            // 
            // lblAvgDailyValue
            // 
            lblAvgDailyValue.Dock = DockStyle.Fill;
            lblAvgDailyValue.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgDailyValue.Location = new Point(0, 50);
            lblAvgDailyValue.Name = "lblAvgDailyValue";
            lblAvgDailyValue.Size = new Size(280, 70);
            lblAvgDailyValue.TabIndex = 1;
            lblAvgDailyValue.Text = "₱0.00";
            lblAvgDailyValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvgDailyTitle
            // 
            lblAvgDailyTitle.Dock = DockStyle.Top;
            lblAvgDailyTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgDailyTitle.Location = new Point(0, 0);
            lblAvgDailyTitle.Name = "lblAvgDailyTitle";
            lblAvgDailyTitle.Size = new Size(280, 50);
            lblAvgDailyTitle.TabIndex = 0;
            lblAvgDailyTitle.Text = "Average Daily Sales";
            lblAvgDailyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAvgWeeklySales
            // 
            panelAvgWeeklySales.BackColor = Color.White;
            panelAvgWeeklySales.Controls.Add(lblAvgWeeklyValue);
            panelAvgWeeklySales.Controls.Add(lblAvgWeeklyTitle);
            panelAvgWeeklySales.Location = new Point(3, 279);
            panelAvgWeeklySales.Margin = new Padding(3, 3, 3, 15);
            panelAvgWeeklySales.Name = "panelAvgWeeklySales";
            panelAvgWeeklySales.Size = new Size(280, 120);
            panelAvgWeeklySales.TabIndex = 2;
            // 
            // lblAvgWeeklyValue
            // 
            lblAvgWeeklyValue.Dock = DockStyle.Fill;
            lblAvgWeeklyValue.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgWeeklyValue.Location = new Point(0, 50);
            lblAvgWeeklyValue.Name = "lblAvgWeeklyValue";
            lblAvgWeeklyValue.Size = new Size(280, 70);
            lblAvgWeeklyValue.TabIndex = 1;
            lblAvgWeeklyValue.Text = "₱0.00";
            lblAvgWeeklyValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvgWeeklyTitle
            // 
            lblAvgWeeklyTitle.Dock = DockStyle.Top;
            lblAvgWeeklyTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgWeeklyTitle.Location = new Point(0, 0);
            lblAvgWeeklyTitle.Name = "lblAvgWeeklyTitle";
            lblAvgWeeklyTitle.Size = new Size(280, 50);
            lblAvgWeeklyTitle.TabIndex = 0;
            lblAvgWeeklyTitle.Text = "Average Weekly Sales";
            lblAvgWeeklyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAvgMonthlySales
            // 
            panelAvgMonthlySales.BackColor = Color.White;
            panelAvgMonthlySales.Controls.Add(lblAvgMonthlyValue);
            panelAvgMonthlySales.Controls.Add(lblAvgMonthlyTitle);
            panelAvgMonthlySales.Location = new Point(3, 417);
            panelAvgMonthlySales.Margin = new Padding(3, 3, 3, 15);
            panelAvgMonthlySales.Name = "panelAvgMonthlySales";
            panelAvgMonthlySales.Size = new Size(280, 120);
            panelAvgMonthlySales.TabIndex = 3;
            // 
            // lblAvgMonthlyValue
            // 
            lblAvgMonthlyValue.Dock = DockStyle.Fill;
            lblAvgMonthlyValue.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgMonthlyValue.Location = new Point(0, 50);
            lblAvgMonthlyValue.Name = "lblAvgMonthlyValue";
            lblAvgMonthlyValue.Size = new Size(280, 70);
            lblAvgMonthlyValue.TabIndex = 1;
            lblAvgMonthlyValue.Text = "₱0.00";
            lblAvgMonthlyValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvgMonthlyTitle
            // 
            lblAvgMonthlyTitle.Dock = DockStyle.Top;
            lblAvgMonthlyTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAvgMonthlyTitle.Location = new Point(0, 0);
            lblAvgMonthlyTitle.Name = "lblAvgMonthlyTitle";
            lblAvgMonthlyTitle.Size = new Size(280, 50);
            lblAvgMonthlyTitle.TabIndex = 0;
            lblAvgMonthlyTitle.Text = "Average Monthly Sales";
            lblAvgMonthlyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutCharts
            // 
            tableLayoutCharts.ColumnCount = 1;
            tableLayoutCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutCharts.Dock = DockStyle.Fill;
            tableLayoutCharts.Location = new Point(303, 3);
            tableLayoutCharts.Name = "tableLayoutCharts";
            tableLayoutCharts.RowCount = 2;
            tableLayoutCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutCharts.Size = new Size(904, 760);
            tableLayoutCharts.TabIndex = 1;
            // 
            // panelAnalyticsHeader
            // 
            panelAnalyticsHeader.BackColor = Color.IndianRed;
            panelAnalyticsHeader.Controls.Add(label2);
            panelAnalyticsHeader.Dock = DockStyle.Top;
            panelAnalyticsHeader.Location = new Point(0, 0);
            panelAnalyticsHeader.Margin = new Padding(4, 3, 4, 3);
            panelAnalyticsHeader.Name = "panelAnalyticsHeader";
            panelAnalyticsHeader.Size = new Size(1210, 69);
            panelAnalyticsHeader.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(1210, 69);
            label2.TabIndex = 0;
            label2.Text = "Analytics";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFoodOrders
            // 
            panelFoodOrders.BackColor = Color.LightGoldenrodYellow;
            panelFoodOrders.Controls.Add(dgvOrders);
            panelFoodOrders.Controls.Add(panelOrdersHeader);
            panelFoodOrders.Dock = DockStyle.Fill;
            panelFoodOrders.Location = new Point(0, 0);
            panelFoodOrders.Margin = new Padding(4, 3, 4, 3);
            panelFoodOrders.Name = "panelFoodOrders";
            panelFoodOrders.Size = new Size(1210, 835);
            panelFoodOrders.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(24, 104);
            dgvOrders.Margin = new Padding(4, 3, 4, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1157, 707);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // panelOrdersHeader
            // 
            panelOrdersHeader.BackColor = Color.IndianRed;
            panelOrdersHeader.Controls.Add(lblOrdersHeader);
            panelOrdersHeader.Dock = DockStyle.Top;
            panelOrdersHeader.Location = new Point(0, 0);
            panelOrdersHeader.Margin = new Padding(4, 3, 4, 3);
            panelOrdersHeader.Name = "panelOrdersHeader";
            panelOrdersHeader.Size = new Size(1210, 69);
            panelOrdersHeader.TabIndex = 0;
            // 
            // lblOrdersHeader
            // 
            lblOrdersHeader.Dock = DockStyle.Fill;
            lblOrdersHeader.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrdersHeader.Location = new Point(0, 0);
            lblOrdersHeader.Margin = new Padding(4, 0, 4, 0);
            lblOrdersHeader.Name = "lblOrdersHeader";
            lblOrdersHeader.Size = new Size(1210, 69);
            lblOrdersHeader.TabIndex = 0;
            lblOrdersHeader.Text = "Food Orders";
            lblOrdersHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(1210, 69);
            label4.TabIndex = 1;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(1210, 69);
            label3.TabIndex = 1;
            label3.Text = "3rd Setting (Content Here)";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 841);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DashboardForm";
            Text = "Manager Dashboard";
            Load += DashboardForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panelNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDashboardLogo).EndInit();
            panelContent.ResumeLayout(false);
            panelCustomerAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomerFeedback).EndInit();
            panelFeedbackHeader.ResumeLayout(false);
            panelAnalytics.ResumeLayout(false);
            tableLayoutAnalytics.ResumeLayout(false);
            flowLayoutStats.ResumeLayout(false);
            panelTotalSales.ResumeLayout(false);
            panelAvgDailySales.ResumeLayout(false);
            panelAvgWeeklySales.ResumeLayout(false);
            panelAvgMonthlySales.ResumeLayout(false);
            panelAnalyticsHeader.ResumeLayout(false);
            panelFoodOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelOrdersHeader.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button btnNavCustomerAdmin;

        private System.Windows.Forms.Button btnNavAnalytics;
        private System.Windows.Forms.Button btnNavFoodOrders;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.PictureBox picDashboardLogo;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFoodOrders;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panelOrdersHeader;
        private System.Windows.Forms.Label lblOrdersHeader;
        private System.Windows.Forms.Panel panelAnalytics;
        private System.Windows.Forms.Panel panelAnalyticsHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelCustomerAdmin;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutAnalytics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutStats;
        private System.Windows.Forms.Panel panelTotalSales;
        private System.Windows.Forms.Label lblTotalSalesValue;
        private System.Windows.Forms.Label lblTotalSalesTitle;
        private System.Windows.Forms.Panel panelAvgDailySales;
        private System.Windows.Forms.Label lblAvgDailyValue;
        private System.Windows.Forms.Label lblAvgDailyTitle;
        private System.Windows.Forms.Panel panelAvgWeeklySales;
        private System.Windows.Forms.Label lblAvgWeeklyValue;
        private System.Windows.Forms.Label lblAvgWeeklyTitle;
        private System.Windows.Forms.Panel panelAvgMonthlySales;
        private System.Windows.Forms.Label lblAvgMonthlyValue;
        private System.Windows.Forms.Label lblAvgMonthlyTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailySales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategorySales;

        // 🟡 --- CUSTOMER FEEDBACK COMPONENT FIELDS ---
        private System.Windows.Forms.Panel panelFeedbackHeader;
        private System.Windows.Forms.Label lblFeedbackHeader;
        private System.Windows.Forms.DataGridView dgvCustomerFeedback;
    }
}
