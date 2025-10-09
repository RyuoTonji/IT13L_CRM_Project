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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.btnNavCustomerAdmin = new System.Windows.Forms.Button();
            this.btnNavAnalytics = new System.Windows.Forms.Button();
            this.btnNavFoodOrders = new System.Windows.Forms.Button();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.picDashboardLogo = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelCustomerAdmin = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();

            // 🟡 --- CUSTOMER FEEDBACK DASHBOARD INSERT ---
            this.panelFeedbackHeader = new System.Windows.Forms.Panel();
            this.lblFeedbackHeader = new System.Windows.Forms.Label();
            this.dgvCustomerFeedback = new System.Windows.Forms.DataGridView();
            // Add new controls into CustomerAdmin panel (inserted; label4 left intact)
            this.panelCustomerAdmin.Controls.Add(this.dgvCustomerFeedback);
            this.panelCustomerAdmin.Controls.Add(this.panelFeedbackHeader);

            // panelFeedbackHeader
            this.panelFeedbackHeader.BackColor = System.Drawing.Color.IndianRed;
            this.panelFeedbackHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFeedbackHeader.Height = 69;
            this.panelFeedbackHeader.Controls.Add(this.lblFeedbackHeader);

            // lblFeedbackHeader
            this.lblFeedbackHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFeedbackHeader.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblFeedbackHeader.Text = "Customer Feedback";
            this.lblFeedbackHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // dgvCustomerFeedback
            this.dgvCustomerFeedback.AllowUserToAddRows = false;
            this.dgvCustomerFeedback.AllowUserToDeleteRows = false;
            this.dgvCustomerFeedback.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerFeedback.ReadOnly = true;
            this.dgvCustomerFeedback.RowHeadersVisible = false;
            this.dgvCustomerFeedback.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerFeedback.Location = new System.Drawing.Point(0, 69);
            this.dgvCustomerFeedback.Name = "dgvCustomerFeedback";
            this.dgvCustomerFeedback.TabIndex = 2;
            // 🟡 --- END INSERT ---

            this.label3 = new System.Windows.Forms.Label();
            this.panelAnalytics = new System.Windows.Forms.Panel();
            this.tableLayoutAnalytics = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutStats = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTotalSales = new System.Windows.Forms.Panel();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalSalesTitle = new System.Windows.Forms.Label();
            this.panelAvgDailySales = new System.Windows.Forms.Panel();
            this.lblAvgDailyValue = new System.Windows.Forms.Label();
            this.lblAvgDailyTitle = new System.Windows.Forms.Label();
            this.panelAvgWeeklySales = new System.Windows.Forms.Panel();
            this.lblAvgWeeklyValue = new System.Windows.Forms.Label();
            this.lblAvgWeeklyTitle = new System.Windows.Forms.Label();
            this.panelAvgMonthlySales = new System.Windows.Forms.Panel();
            this.lblAvgMonthlyValue = new System.Windows.Forms.Label();
            this.lblAvgMonthlyTitle = new System.Windows.Forms.Label();
            this.tableLayoutCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartDailySales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCategorySales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAnalyticsHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFoodOrders = new System.Windows.Forms.Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panelOrdersHeader = new System.Windows.Forms.Panel();
            this.lblOrdersHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelCustomerAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerFeedback)).BeginInit();
            this.panelAnalytics.SuspendLayout();
            this.tableLayoutAnalytics.SuspendLayout();
            this.flowLayoutStats.SuspendLayout();
            this.panelTotalSales.SuspendLayout();
            this.panelAvgDailySales.SuspendLayout();
            this.panelAvgWeeklySales.SuspendLayout();
            this.panelAvgMonthlySales.SuspendLayout();
            this.tableLayoutCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailySales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorySales)).BeginInit();
            this.panelAnalyticsHeader.SuspendLayout();
            this.panelFoodOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelOrdersHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelNavigation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelContent, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1475, 841);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelNavigation.Controls.Add(this.btnNavCustomerAdmin);
            this.panelNavigation.Controls.Add(this.btnNavAnalytics);
            this.panelNavigation.Controls.Add(this.btnNavFoodOrders);
            this.panelNavigation.Controls.Add(this.lblDashboardTitle);
            this.panelNavigation.Controls.Add(this.picDashboardLogo);
            this.panelNavigation.Location = new System.Drawing.Point(4, 3);
            this.panelNavigation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(249, 811);
            this.panelNavigation.TabIndex = 0;
            // 
            // btnNavCustomerAdmin
            // 
            this.btnNavCustomerAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCustomerAdmin.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNavCustomerAdmin.Location = new System.Drawing.Point(0, 380);
            this.btnNavCustomerAdmin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNavCustomerAdmin.Name = "btnNavCustomerAdmin";
            this.btnNavCustomerAdmin.Size = new System.Drawing.Size(249, 69);
            this.btnNavCustomerAdmin.TabIndex = 5;
            this.btnNavCustomerAdmin.Text = "Customer Feedback";
            this.btnNavCustomerAdmin.UseVisualStyleBackColor = true;
            // 
            // btnNavAnalytics
            // 
            this.btnNavAnalytics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavAnalytics.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNavAnalytics.Location = new System.Drawing.Point(0, 242);
            this.btnNavAnalytics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNavAnalytics.Name = "btnNavAnalytics";
            this.btnNavAnalytics.Size = new System.Drawing.Size(249, 69);
            this.btnNavAnalytics.TabIndex = 3;
            this.btnNavAnalytics.Text = "Analytics";
            this.btnNavAnalytics.UseVisualStyleBackColor = true;
            // 
            // btnNavFoodOrders
            // 
            this.btnNavFoodOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavFoodOrders.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNavFoodOrders.Location = new System.Drawing.Point(0, 173);
            this.btnNavFoodOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNavFoodOrders.Name = "btnNavFoodOrders";
            this.btnNavFoodOrders.Size = new System.Drawing.Size(249, 69);
            this.btnNavFoodOrders.TabIndex = 2;
            this.btnNavFoodOrders.Text = "Food Orders";
            this.btnNavFoodOrders.UseVisualStyleBackColor = true;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDashboardTitle.Location = new System.Drawing.Point(0, 115);
            this.lblDashboardTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(249, 58);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "BBQ-Lagao";
            this.lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picDashboardLogo
            // 
            this.picDashboardLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picDashboardLogo.Location = new System.Drawing.Point(0, 0);
            this.picDashboardLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picDashboardLogo.Name = "picDashboardLogo";
            this.picDashboardLogo.Size = new System.Drawing.Size(249, 115);
            this.picDashboardLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDashboardLogo.TabIndex = 0;
            this.picDashboardLogo.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelCustomerAdmin);
            this.panelContent.Controls.Add(this.panelAnalytics);
            this.panelContent.Controls.Add(this.panelFoodOrders);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(261, 3);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1210, 835);
            this.panelContent.TabIndex = 1;
            // 
            // panelCustomerAdmin
            // 
            this.panelCustomerAdmin.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            //this.panelCustomerAdmin.Controls.Add(this.label4);
            this.panelCustomerAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomerAdmin.Location = new System.Drawing.Point(0, 0);
            this.panelCustomerAdmin.Name = "panelCustomerAdmin";
            this.panelCustomerAdmin.Size = new System.Drawing.Size(1210, 835);
            this.panelCustomerAdmin.TabIndex = 3;

            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1210, 69);
            this.label4.TabIndex = 1;
            
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1210, 69);
            this.label3.TabIndex = 1;
            this.label3.Text = "3rd Setting (Content Here)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAnalytics
            // 
            this.panelAnalytics.BackColor = System.Drawing.Color.LightGray;
            this.panelAnalytics.Controls.Add(this.tableLayoutAnalytics);
            this.panelAnalytics.Controls.Add(this.panelAnalyticsHeader);
            this.panelAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalytics.Location = new System.Drawing.Point(0, 0);
            this.panelAnalytics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelAnalytics.Name = "panelAnalytics";
            this.panelAnalytics.Size = new System.Drawing.Size(1210, 835);
            this.panelAnalytics.TabIndex = 1;
            // 
            // tableLayoutAnalytics
            // 
            this.tableLayoutAnalytics.ColumnCount = 2;
            this.tableLayoutAnalytics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutAnalytics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutAnalytics.Controls.Add(this.flowLayoutStats, 0, 0);
            this.tableLayoutAnalytics.Controls.Add(this.tableLayoutCharts, 1, 0);
            this.tableLayoutAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutAnalytics.Location = new System.Drawing.Point(0, 69);
            this.tableLayoutAnalytics.Name = "tableLayoutAnalytics";
            this.tableLayoutAnalytics.RowCount = 1;
            this.tableLayoutAnalytics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutAnalytics.Size = new System.Drawing.Size(1210, 766);
            this.tableLayoutAnalytics.TabIndex = 4;
            // 
            // flowLayoutStats
            // 
            this.flowLayoutStats.Controls.Add(this.panelTotalSales);
            this.flowLayoutStats.Controls.Add(this.panelAvgDailySales);
            this.flowLayoutStats.Controls.Add(this.panelAvgWeeklySales);
            this.flowLayoutStats.Controls.Add(this.panelAvgMonthlySales);
            this.flowLayoutStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutStats.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutStats.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutStats.Name = "flowLayoutStats";
            this.flowLayoutStats.Size = new System.Drawing.Size(294, 760);
            this.flowLayoutStats.TabIndex = 0;
            this.flowLayoutStats.WrapContents = false;
            // 
            // panelTotalSales
            // 
            this.panelTotalSales.BackColor = System.Drawing.Color.White;
            this.panelTotalSales.Controls.Add(this.lblTotalSalesValue);
            this.panelTotalSales.Controls.Add(this.lblTotalSalesTitle);
            this.panelTotalSales.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelTotalSales.Name = "panelTotalSales";
            this.panelTotalSales.Size = new System.Drawing.Size(280, 120);
            this.panelTotalSales.TabIndex = 0;
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSalesValue.Location = new System.Drawing.Point(0, 50);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(280, 70);
            this.lblTotalSalesValue.TabIndex = 1;
            this.lblTotalSalesValue.Text = "₱0.00";
            this.lblTotalSalesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalSalesTitle
            // 
            this.lblTotalSalesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalSalesTitle.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSalesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalSalesTitle.Name = "lblTotalSalesTitle";
            this.lblTotalSalesTitle.Size = new System.Drawing.Size(280, 50);
            this.lblTotalSalesTitle.TabIndex = 0;
            this.lblTotalSalesTitle.Text = "Total Sales";
            this.lblTotalSalesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAvgDailySales
            // 
            this.panelAvgDailySales.BackColor = System.Drawing.Color.White;
            this.panelAvgDailySales.Controls.Add(this.lblAvgDailyValue);
            this.panelAvgDailySales.Controls.Add(this.lblAvgDailyTitle);
            this.panelAvgDailySales.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelAvgDailySales.Name = "panelAvgDailySales";
            this.panelAvgDailySales.Size = new System.Drawing.Size(280, 120);
            this.panelAvgDailySales.TabIndex = 1;
            // 
            // lblAvgDailyValue
            // 
            this.lblAvgDailyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvgDailyValue.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgDailyValue.Location = new System.Drawing.Point(0, 50);
            this.lblAvgDailyValue.Name = "lblAvgDailyValue";
            this.lblAvgDailyValue.Size = new System.Drawing.Size(280, 70);
            this.lblAvgDailyValue.TabIndex = 1;
            this.lblAvgDailyValue.Text = "₱0.00";
            this.lblAvgDailyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgDailyTitle
            // 
            this.lblAvgDailyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvgDailyTitle.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgDailyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAvgDailyTitle.Name = "lblAvgDailyTitle";
            this.lblAvgDailyTitle.Size = new System.Drawing.Size(280, 50);
            this.lblAvgDailyTitle.TabIndex = 0;
            this.lblAvgDailyTitle.Text = "Average Daily Sales";
            this.lblAvgDailyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAvgWeeklySales
            // 
            this.panelAvgWeeklySales.BackColor = System.Drawing.Color.White;
            this.panelAvgWeeklySales.Controls.Add(this.lblAvgWeeklyValue);
            this.panelAvgWeeklySales.Controls.Add(this.lblAvgWeeklyTitle);
            this.panelAvgWeeklySales.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelAvgWeeklySales.Name = "panelAvgWeeklySales";
            this.panelAvgWeeklySales.Size = new System.Drawing.Size(280, 120);
            this.panelAvgWeeklySales.TabIndex = 2;
            // 
            // lblAvgWeeklyValue
            // 
            this.lblAvgWeeklyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvgWeeklyValue.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgWeeklyValue.Location = new System.Drawing.Point(0, 50);
            this.lblAvgWeeklyValue.Name = "lblAvgWeeklyValue";
            this.lblAvgWeeklyValue.Size = new System.Drawing.Size(280, 70);
            this.lblAvgWeeklyValue.TabIndex = 1;
            this.lblAvgWeeklyValue.Text = "₱0.00";
            this.lblAvgWeeklyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgWeeklyTitle
            // 
            this.lblAvgWeeklyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvgWeeklyTitle.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgWeeklyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAvgWeeklyTitle.Name = "lblAvgWeeklyTitle";
            this.lblAvgWeeklyTitle.Size = new System.Drawing.Size(280, 50);
            this.lblAvgWeeklyTitle.TabIndex = 0;
            this.lblAvgWeeklyTitle.Text = "Average Weekly Sales";
            this.lblAvgWeeklyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAvgMonthlySales
            // 
            this.panelAvgMonthlySales.BackColor = System.Drawing.Color.White;
            this.panelAvgMonthlySales.Controls.Add(this.lblAvgMonthlyValue);
            this.panelAvgMonthlySales.Controls.Add(this.lblAvgMonthlyTitle);
            this.panelAvgMonthlySales.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panelAvgMonthlySales.Name = "panelAvgMonthlySales";
            this.panelAvgMonthlySales.Size = new System.Drawing.Size(280, 120);
            this.panelAvgMonthlySales.TabIndex = 3;
            // 
            // lblAvgMonthlyValue
            // 
            this.lblAvgMonthlyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvgMonthlyValue.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgMonthlyValue.Location = new System.Drawing.Point(0, 50);
            this.lblAvgMonthlyValue.Name = "lblAvgMonthlyValue";
            this.lblAvgMonthlyValue.Size = new System.Drawing.Size(280, 70);
            this.lblAvgMonthlyValue.TabIndex = 1;
            this.lblAvgMonthlyValue.Text = "₱0.00";
            this.lblAvgMonthlyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvgMonthlyTitle
            // 
            this.lblAvgMonthlyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvgMonthlyTitle.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvgMonthlyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAvgMonthlyTitle.Name = "lblAvgMonthlyTitle";
            this.lblAvgMonthlyTitle.Size = new System.Drawing.Size(280, 50);
            this.lblAvgMonthlyTitle.TabIndex = 0;
            this.lblAvgMonthlyTitle.Text = "Average Monthly Sales";
            this.lblAvgMonthlyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutCharts
            // 
            this.tableLayoutCharts.ColumnCount = 1;
            this.tableLayoutCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCharts.Controls.Add(this.chartDailySales, 0, 0);
            this.tableLayoutCharts.Controls.Add(this.chartCategorySales, 0, 1);
            this.tableLayoutCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCharts.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutCharts.Name = "tableLayoutCharts";
            this.tableLayoutCharts.RowCount = 2;
            this.tableLayoutCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCharts.Size = new System.Drawing.Size(904, 760);
            this.tableLayoutCharts.TabIndex = 1;
            // 
            // chartDailySales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDailySales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDailySales.Legends.Add(legend1);
            this.chartDailySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDailySales.Location = new System.Drawing.Point(3, 3);
            this.chartDailySales.Name = "chartDailySales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDailySales.Series.Add(series1);
            this.chartDailySales.Size = new System.Drawing.Size(898, 374);
            this.chartDailySales.TabIndex = 2;
            this.chartDailySales.Text = "Daily Sales";
            // 
            // chartCategorySales
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCategorySales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCategorySales.Legends.Add(legend2);
            this.chartCategorySales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCategorySales.Location = new System.Drawing.Point(3, 383);
            this.chartCategorySales.Name = "chartCategorySales";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCategorySales.Series.Add(series2);
            this.chartCategorySales.Size = new System.Drawing.Size(898, 374);
            this.chartCategorySales.TabIndex = 3;
            this.chartCategorySales.Text = "Sales by Category";
            // 
            // panelAnalyticsHeader
            // 
            this.panelAnalyticsHeader.BackColor = System.Drawing.Color.IndianRed;
            this.panelAnalyticsHeader.Controls.Add(this.label2);
            this.panelAnalyticsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnalyticsHeader.Location = new System.Drawing.Point(0, 0);
            this.panelAnalyticsHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelAnalyticsHeader.Name = "panelAnalyticsHeader";
            this.panelAnalyticsHeader.Size = new System.Drawing.Size(1210, 69);
            this.panelAnalyticsHeader.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1210, 69);
            this.label2.TabIndex = 0;
            this.label2.Text = "Analytics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFoodOrders
            // 
            this.panelFoodOrders.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panelFoodOrders.Controls.Add(this.dgvOrders);
            this.panelFoodOrders.Controls.Add(this.panelOrdersHeader);
            this.panelFoodOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoodOrders.Location = new System.Drawing.Point(0, 0);
            this.panelFoodOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelFoodOrders.Name = "panelFoodOrders";
            this.panelFoodOrders.Size = new System.Drawing.Size(1210, 835);
            this.panelFoodOrders.TabIndex = 0;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(24, 104);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.Size = new System.Drawing.Size(1157, 707);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // panelOrdersHeader
            // 
            this.panelOrdersHeader.BackColor = System.Drawing.Color.IndianRed;
            this.panelOrdersHeader.Controls.Add(this.lblOrdersHeader);
            this.panelOrdersHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrdersHeader.Location = new System.Drawing.Point(0, 0);
            this.panelOrdersHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelOrdersHeader.Name = "panelOrdersHeader";
            this.panelOrdersHeader.Size = new System.Drawing.Size(1210, 69);
            this.panelOrdersHeader.TabIndex = 0;
            // 
            // lblOrdersHeader
            // 
            this.lblOrdersHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrdersHeader.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrdersHeader.Location = new System.Drawing.Point(0, 0);
            this.lblOrdersHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdersHeader.Name = "lblOrdersHeader";
            this.lblOrdersHeader.Size = new System.Drawing.Size(1210, 69);
            this.lblOrdersHeader.TabIndex = 0;
            this.lblOrdersHeader.Text = "Food Orders";
            this.lblOrdersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 841);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DashboardForm";
            this.Text = "Manager Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDashboardLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelCustomerAdmin.ResumeLayout(false);

            this.panelAnalytics.ResumeLayout(false);
            this.tableLayoutAnalytics.ResumeLayout(false);
            this.flowLayoutStats.ResumeLayout(false);
            this.panelTotalSales.ResumeLayout(false);
            this.panelAvgDailySales.ResumeLayout(false);
            this.panelAvgWeeklySales.ResumeLayout(false);
            this.panelAvgMonthlySales.ResumeLayout(false);
            this.tableLayoutCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDailySales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategorySales)).EndInit();
            this.panelAnalyticsHeader.ResumeLayout(false);
            this.panelFoodOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerFeedback)).EndInit();
            this.panelOrdersHeader.ResumeLayout(false);
            this.ResumeLayout(false);

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
