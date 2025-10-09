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

        // store mock feedback list (in-memory)
        private List<MockFeedback> mockFeedbackList = new List<MockFeedback>();

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
            contentPanels.Add(panelCustomerAdmin);
            //contentPanels.Add(panel3rdSetting);

            // nav button handlers - customer admin will load feedback when clicked
            btnNavFoodOrders.Click += (s, ev) => ShowPanel(panelFoodOrders);
            btnNavAnalytics.Click += (s, ev) => { ShowPanel(panelAnalytics); LoadAnalytics(); };
            btnNavCustomerAdmin.Click += (s, ev) => {
                ShowPanel(panelCustomerAdmin);
                LoadCustomerFeedback(); // load only when clicking Customer Feedback
            };

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

        #region Customer Feedback (mock data + grid)
        private void LoadCustomerFeedback()
        {
            // Prepare in-memory mock data (simple set each time)
            mockFeedbackList = new List<MockFeedback>
            {
                new MockFeedback { Email = "maria@gmail.com", Type = "Service Quality", Date = DateTime.Now.Date.AddDays(-0).ToShortDateString(), Time = "10:30 AM", Priority = "High", Status = "Pending" },
                new MockFeedback { Email = "john@yahoo.com", Type = "Food Taste", Date = DateTime.Now.Date.AddDays(-1).ToShortDateString(), Time = "12:00 PM", Priority = "Medium", Status = "Reviewed" },
                new MockFeedback { Email = "anne@gmail.com", Type = "Cleanliness", Date = DateTime.Now.Date.AddDays(-2).ToShortDateString(), Time = "09:45 AM", Priority = "Low", Status = "Resolved" }
            };

            // Clear existing
            dgvCustomerFeedback.Rows.Clear();
            dgvCustomerFeedback.Columns.Clear();

            // Add columns
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email ID Number" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Feedback Type" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "Time" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPriority", HeaderText = "Priority Level" });
            dgvCustomerFeedback.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Feedback Status" });

            // Image columns for edit & delete
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

            // Attempt to load icons from Assets
            try
            {
                string editPath = Path.Combine(Application.StartupPath, "Assets", "edit.png");
                string deletePath = Path.Combine(Application.StartupPath, "Assets", "delete.png");

                if (File.Exists(editPath))
                    editCol.Image = Image.FromFile(editPath);
                else
                    Console.WriteLine($"Edit icon not found: {editPath}");

                if (File.Exists(deletePath))
                    deleteCol.Image = Image.FromFile(deletePath);
                else
                    Console.WriteLine($"Delete icon not found: {deletePath}");
                    Console.WriteLine($"Delete icon not found: {deletePath}");
            }
            catch
            {
                // ignore image load issues — columns will still be there
            }

            dgvCustomerFeedback.Columns.Add(editCol);
            dgvCustomerFeedback.Columns.Add(deleteCol);

            // Add rows from mockFeedbackList
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

            // Appearance
            dgvCustomerFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerFeedback.RowTemplate.Height = 40;
            dgvCustomerFeedback.ClearSelection();

            // Wire the click event (remove previous to prevent multiple subscriptions)
            dgvCustomerFeedback.CellContentClick -= dgvCustomerFeedback_CellContentClick;
            dgvCustomerFeedback.CellContentClick += dgvCustomerFeedback_CellContentClick;
        }

        private void dgvCustomerFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Make sure column names exist
            var colName = dgvCustomerFeedback.Columns[e.ColumnIndex].Name;

            if (colName == "colEdit")
            {
                var email = dgvCustomerFeedback.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString();
                MessageBox.Show($"Edit feedback from {email}", "Edit Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Placeholder - you can open an edit form here
            }
            else if (colName == "colDelete")
            {
                var email = dgvCustomerFeedback.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString();
                var result = MessageBox.Show($"Are you sure you want to delete feedback from {email}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dgvCustomerFeedback.Rows.RemoveAt(e.RowIndex);
                    // If you'd persist to DB later, call deletion code here
                }
            }
        }
        #endregion

        // 🔐 Secret shortcut: Ctrl + D returns to MenuForm (no ESC, no exit)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                MenuForm menu = new MenuForm();
                menu.FormBorderStyle = FormBorderStyle.None;
                menu.WindowState = FormWindowState.Maximized;
                menu.TopMost = true;
                menu.Show();
                this.Hide();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // small mock DTO
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
