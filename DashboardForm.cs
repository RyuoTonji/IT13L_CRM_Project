using MyKioski.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyKioski
{
    public partial class DashboardForm : Form
    {
        private List<Panel> contentPanels;
        private List<MockFeedback> mockFeedbackList = new List<MockFeedback>();

        public DashboardForm()
        {
            InitializeComponent();
            contentPanels = new List<Panel>();
            this.KeyPreview = true;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            string logoPath = "Assets/logo.png";
            if (File.Exists(logoPath))
                picDashboardLogo.Image = Image.FromFile(logoPath);

            contentPanels.Clear();
            contentPanels.Add(panelFoodOrders);
            contentPanels.Add(panelAnalytics);
            contentPanels.Add(panelCustomerAdmin);

            foreach (var panel in contentPanels)
            {
                if (panel != null)
                {
                    panel.Dock = DockStyle.Fill;
                    panel.Visible = false;
                }
            }

            btnNavFoodOrders.Click += (s, ev) => ShowPanel(panelFoodOrders);
            btnNavAnalytics.Click += (s, ev) =>
            {
                ShowPanel(panelAnalytics);
                LoadAnalytics();
            };
            btnNavCustomerAdmin.Click += (s, ev) =>
            {
                ShowPanel(panelCustomerAdmin);
                LoadCustomerFeedback();
            };

            LoadOrders();
            ShowPanel(panelFoodOrders);
        }

        private void ShowPanel(Panel panelToShow)
        {
            foreach (var panel in contentPanels)
            {
                if (panel != null)
                    panel.Visible = false;
            }

            if (panelToShow != null)
            {
                panelToShow.Visible = true;
                panelToShow.BringToFront();
            }
        }

        #region Food Orders
        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("colOrderId", "Order ID");
            dgvOrders.Columns.Add("colpaymentMethod", "Payment");
            dgvOrders.Columns.Add("coldate", "Date");
            dgvOrders.Columns.Add("coltotal_price", "Total");
            dgvOrders.Columns.Add("colstatus", "Status");

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

            try
            {
                List<Order> allOrders = OrderService.GetAllOrders();

                if (allOrders.Count == 0)
                {
                    MessageBox.Show("No orders found in database. Please create some orders first.", "No Data");
                }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Database Error");
            }

            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                dgvOrders.Columns["colView"].Width = 80;
                dgvOrders.Columns["colDelete"].Width = 80;
            }
            catch { }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string orderId = dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value.ToString();

            if (dgvOrders.Columns[e.ColumnIndex].Name == "colView")
            {
                Order o = OrderService.GetOrderWithItems(orderId);
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
        private void InitializeChartsIfNeeded()
        {
            // Clear existing charts if any
            var existingCharts = panelAnalytics.Controls.OfType<Chart>().ToList();
            foreach (var chart in existingCharts)
            {
                panelAnalytics.Controls.Remove(chart);
                chart.Dispose();
            }

            // Create Daily Sales Chart
            chartDailySales = new Chart();
            chartDailySales.Name = "chartDailySales";
            chartDailySales.Size = new Size(600, 300);
            chartDailySales.Location = new Point(450, 70);
            chartDailySales.BackColor = Color.White;
            chartDailySales.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAnalytics.Controls.Add(chartDailySales);
            chartDailySales.BringToFront();

            // Create Category Sales Chart
            chartCategorySales = new Chart();
            chartCategorySales.Name = "chartCategorySales";
            chartCategorySales.Size = new Size(600, 300);
            chartCategorySales.Location = new Point(450, 390);
            chartCategorySales.BackColor = Color.White;
            chartCategorySales.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAnalytics.Controls.Add(chartCategorySales);
            chartCategorySales.BringToFront();
        }

        private void LoadAnalytics()
        {
            InitializeChartsIfNeeded();

            lblTotalSalesValue.Text = $"₱{OrderService.GetTotalSales():F2}";
            lblAvgDailyValue.Text = $"₱{OrderService.GetAverageDailySales():F2}";
            lblAvgWeeklyValue.Text = $"₱{OrderService.GetAverageWeeklySales():F2}";
            lblAvgMonthlyValue.Text = $"₱{OrderService.GetAverageMonthlySales():F2}";

            if (chartDailySales != null)
                PopulateDailySalesChart();

            if (chartCategorySales != null)
                PopulateItemsChart();

            panelAnalytics.Refresh();
        }

        private void PopulateDailySalesChart()
        {
            if (chartDailySales == null) return;

            chartDailySales.Series.Clear();
            chartDailySales.Titles.Clear();
            chartDailySales.ChartAreas.Clear();
            chartDailySales.Annotations.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.LabelStyle.Format = "₱{0}";
            chartArea.BackColor = Color.White;
            chartDailySales.ChartAreas.Add(chartArea);

            Title title = new Title("Daily Sales (Last 7 Days)");
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            chartDailySales.Titles.Add(title);

            Series series = new Series("Daily Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(54, 162, 235),
                BorderWidth = 2,
                IsValueShownAsLabel = true,
                ChartArea = "MainArea"
            };

            var salesData = OrderService.GetDailySalesForLastDays(7);
            bool hasData = false;

            if (salesData != null && salesData.Count > 0)
            {
                foreach (var entry in salesData.OrderBy(x => x.Key))
                {
                    series.Points.AddXY(entry.Key.ToString("MM/dd"), entry.Value);
                    if (entry.Value > 0) hasData = true;
                }
            }

            if (!hasData)
            {
                series.Points.AddXY("No Data", 0);

                TextAnnotation noDataAnnotation = new TextAnnotation
                {
                    Text = "No sales data for the last 7 days",
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    X = 50,
                    Y = 50,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartDailySales.Annotations.Add(noDataAnnotation);
            }

            chartDailySales.Series.Add(series);
            chartDailySales.Invalidate();
        }

        private void PopulateItemsChart()
        {
            if (chartCategorySales == null) return;

            chartCategorySales.Series.Clear();
            chartCategorySales.Titles.Clear();
            chartCategorySales.ChartAreas.Clear();
            chartCategorySales.Annotations.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;
            chartCategorySales.ChartAreas.Add(chartArea);

            Title title = new Title("Top Selling Items");
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            chartCategorySales.Titles.Add(title);

            Series series = new Series("Items Sold")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(75, 192, 192),
                IsValueShownAsLabel = true,
                ChartArea = "MainArea",
                BorderWidth = 2
            };

            var itemData = OrderService.GetSalesByItem()
                                       .OrderByDescending(kvp => kvp.Value)
                                       .Take(5)
                                       .ToList();
            bool hasData = false;

            if (itemData != null && itemData.Count > 0)
            {
                foreach (var entry in itemData)
                {
                    series.Points.AddXY(entry.Key, entry.Value);
                    if (entry.Value > 0) hasData = true;
                }
            }

            if (!hasData)
            {
                series.Points.AddXY("No Data", 0);

                TextAnnotation noDataAnnotation = new TextAnnotation
                {
                    Text = "No item sales data available",
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    X = 50,
                    Y = 50,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartCategorySales.Annotations.Add(noDataAnnotation);
            }

            chartCategorySales.Series.Add(series);
            chartCategorySales.Invalidate();
        }
        #endregion

        #region Customer Feedback
        private void LoadCustomerFeedback()
        {
            mockFeedbackList = new List<MockFeedback>
            {
                new MockFeedback { Email = "maria@gmail.com", Type = "Service Quality", Date = DateTime.Now.Date.AddDays(-0).ToShortDateString(), Time = "10:30 AM", Priority = "High", Status = "Pending" },
                new MockFeedback { Email = "john@yahoo.com", Type = "Food Taste", Date = DateTime.Now.Date.AddDays(-1).ToShortDateString(), Time = "12:00 PM", Priority = "Medium", Status = "Reviewed" },
                new MockFeedback { Email = "anne@gmail.com", Type = "Cleanliness", Date = DateTime.Now.Date.AddDays(-2).ToShortDateString(), Time = "09:45 AM", Priority = "Low", Status = "Resolved" }
            };

            dgvCustomerFeedback.Rows.Clear();
            dgvCustomerFeedback.Columns.Clear();

            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email ID Number" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Feedback Type" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "Time" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPriority", HeaderText = "Priority Level" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Feedback Status" });

            var editCol = new DataGridViewImageColumn()
            {
                Name = "colEdit",
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40
            };

            var deleteCol = new DataGridViewImageColumn()
            {
                Name = "colDelete",
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40
            };

            try
            {
                string editPath = Path.Combine(Application.StartupPath, "Assets", "edit.png");
                string deletePath = Path.Combine(Application.StartupPath, "Assets", "delete.png");

                if (File.Exists(editPath))
                    editCol.Image = Image.FromFile(editPath);

                if (File.Exists(deletePath))
                    deleteCol.Image = Image.FromFile(deletePath);
            }
            catch { }

            dgvCustomerFeedback.Columns.Add(editCol);
            dgvCustomerFeedback.Columns.Add(deleteCol);

            foreach (var f in mockFeedbackList)
            {
                dgvCustomerFeedback.Rows.Add(
                    f.Email,
                    f.Type,
                    f.Date,
                    f.Time,
                    f.Priority,
                    f.Status,
                    null,
                    null
                );
            }

            dgvCustomerFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerFeedback.RowTemplate.Height = 40;
            dgvCustomerFeedback.ClearSelection();

            dgvCustomerFeedback.CellContentClick -= dgvCustomerFeedback_CellContentClick;
            dgvCustomerFeedback.CellContentClick += dgvCustomerFeedback_CellContentClick;
        }

        private void dgvCustomerFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvCustomerFeedback.Columns[e.ColumnIndex].Name;

            if (colName == "colEdit")
            {
                var email = dgvCustomerFeedback.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString();
                MessageBox.Show($"Edit feedback from {email}", "Edit Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (colName == "colDelete")
            {
                var email = dgvCustomerFeedback.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString();
                var result = MessageBox.Show($"Are you sure you want to delete feedback from {email}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvCustomerFeedback.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                MenuForm existingMenu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();

                if (existingMenu != null)
                {
                    existingMenu.WindowState = FormWindowState.Maximized;
                    existingMenu.Show();
                    existingMenu.BringToFront();
                    this.Hide();
                }
                else
                {
                    MenuForm menu = new MenuForm();
                    menu.FormBorderStyle = FormBorderStyle.None;
                    menu.WindowState = FormWindowState.Maximized;
                    menu.TopMost = true;
                    menu.Show();
                    this.Hide();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNavFoodOrders_Click(object sender, EventArgs e)
        {
        }

        private class MockFeedback
        {
            public string Email { get; set; }
            public string Type { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Priority { get; set; }
            public string Status { get; set; }
        }
    }
}