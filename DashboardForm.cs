using MyKioski.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MyKioski
{
    public partial class DashboardForm : Form
    {
        private List<Panel> contentPanels = new List<Panel>();

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            string logoPath = "Assets/logo.png";
            if (File.Exists(logoPath))
                picDashboardLogo.Image = Image.FromFile(logoPath);

            contentPanels.Add(panelFoodOrders);
            contentPanels.Add(panelAnalytics);
            contentPanels.Add(panel3rdSetting);
            contentPanels.Add(panelCustomerAdmin);

            btnNavFoodOrders.Click += (s, ev) => ShowPanel(panelFoodOrders);
            btnNavAnalytics.Click += (s, ev) => { ShowPanel(panelAnalytics); LoadAnalytics(); };
            btnNav3rdSetting.Click += (s, ev) => ShowPanel(panel3rdSetting);
            btnNavCustomerAdmin.Click += (s, ev) => ShowPanel(panelCustomerAdmin);

            LoadOrders();
            LoadAnalytics();
            ShowPanel(panelFoodOrders);
        }

        private void ShowPanel(Panel panelToShow)
        {
            foreach (var panel in contentPanels)
                panel.Visible = (panel == panelToShow);
        }

        #region Food Orders
        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("colOrderId", "Order ID");
            dgvOrders.Columns.Add("colPaymentMethod", "Payment");
            dgvOrders.Columns.Add("colDate", "Date");
            dgvOrders.Columns.Add("colTotal", "Total");
            dgvOrders.Columns.Add("colStatus", "Status");

            DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn
            {
                Name = "colView",
                HeaderText = "Details",
                Text = "View",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            dgvOrders.Columns.Add(viewButton);
            dgvOrders.Columns.Add(deleteButton);

            List<Order> allOrders = OrderService.GetAllOrders();
            foreach (var order in allOrders.AsEnumerable().Reverse())
            {
                dgvOrders.Rows.Add(
                    order.OrderId,
                    order.PaymentMethod,
                    order.OrderDateTime.ToShortDateString(),
                    $"₱{order.TotalAmount:F2}",
                    order.OrderStatus
                );
            }

            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.Columns["colView"].Width = 80;
            dgvOrders.Columns["colDelete"].Width = 80;
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string orderId = dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value.ToString();

            if (dgvOrders.Columns[e.ColumnIndex].Name == "colView")
            {
                Order o = OrderService.GetAllOrders().FirstOrDefault(ord => ord.OrderId == orderId);
                if (o != null)
                {
                    string details = $"Order ID: {o.OrderId}\n\n";
                    foreach (var item in o.Items)
                        details += $"- {item.Item.Name} (x{item.Quantity})\n";
                    MessageBox.Show(details, "Order Details");
                }
            }

            if (dgvOrders.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete order {orderId}?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    OrderService.DeleteOrder(orderId);
                    LoadOrders();
                    LoadAnalytics();
                }
            }
        }
        #endregion

        #region Analytics
        private void LoadAnalytics()
        {
            lblTotalSalesValue.Text = $"₱{OrderService.GetTotalSales():F2}";
            lblAvgDailyValue.Text = $"₱{OrderService.GetAverageDailySales():F2}";
            lblAvgWeeklyValue.Text = $"₱{OrderService.GetAverageWeeklySales():F2}";
            lblAvgMonthlyValue.Text = $"₱{OrderService.GetAverageMonthlySales():F2}";

            PopulateDailySalesChart();
            PopulateItemsChart();
        }

        private void PopulateDailySalesChart()
        {
            chartDailySales.Series.Clear();
            chartDailySales.Titles.Clear();
            chartDailySales.Titles.Add("Daily Sales (Last 7 Days)");

            Series s = new Series("Daily Sales")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DodgerBlue,
                BorderWidth = 3
            };

            var data = OrderService.GetDailySalesForLastDays(7);
            foreach (var entry in data)
                s.Points.AddXY(entry.Key.ToString("ddd"), entry.Value);

            chartDailySales.Series.Add(s);
        }

        private void PopulateItemsChart()
        {
            chartCategorySales.Series.Clear();
            chartCategorySales.Titles.Clear();
            chartCategorySales.Titles.Add("Top Selling Items");

            Series s = new Series("Items Sold")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            var data = OrderService.GetSalesByItem()
                                   .OrderByDescending(kvp => kvp.Value)
                                   .Take(5);

            foreach (var entry in data)
                s.Points.AddXY(entry.Key, entry.Value);

            chartCategorySales.Series.Add(s);
        }
        #endregion

        // 🔐 Secret shortcut: Ctrl + D returns to MenuForm (no ESC, no exit)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                // Return to menu screen
                MenuForm menu = new MenuForm();
                menu.FormBorderStyle = FormBorderStyle.None;
                menu.WindowState = FormWindowState.Maximized;
                menu.TopMost = true;
                menu.Show();
                this.Hide(); // hide dashboard instead of closing app
                return true;
            }

            // No other keys allowed
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
