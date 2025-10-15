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
        private List<Panel> contentPanels; // Remove = new List<Panel>() from here

        // store mock feedback list (in-memory)
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

            // Clear and re-add to be safe
            contentPanels.Clear();
            contentPanels.Add(panelFoodOrders);
            contentPanels.Add(panelAnalytics);
            contentPanels.Add(panelCustomerAdmin);

            // Set up all panels
            foreach (var panel in contentPanels)
            {
                if (panel != null)
                {
                    panel.Dock = DockStyle.Fill;
                    panel.Visible = false;
                }
            }

            // nav button handlers
            btnNavFoodOrders.Click += (s, ev) => ShowPanel(panelFoodOrders);
            btnNavAnalytics.Click += (s, ev) =>
            {
                ShowPanel(panelAnalytics);
                LoadAnalytics(); // Load analytics only when viewing the panel
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
            // Hide all panels
            foreach (var panel in contentPanels)
            {
                if (panel != null)
                    panel.Visible = false;
            }

            // Show the selected panel
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

            // Only populate charts if they exist
            if (chartDailySales != null)
                PopulateDailySalesChart();

            if (chartCategorySales != null)
                PopulateItemsChart();
        }

        private void PopulateDailySalesChart()
        {
            // Check if chart exists
            if (chartDailySales == null)
            {
                MessageBox.Show("Daily Sales Chart control not found in the form!");
                return;
            }

            // Clear everything
            chartDailySales.Series.Clear();
            chartDailySales.Titles.Clear();
            chartDailySales.ChartAreas.Clear();

            // Add ChartArea (CRITICAL - charts need this to display)
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;
            chartDailySales.ChartAreas.Add(chartArea);

            // Add title
            Title title = new Title("Daily Sales (Last 7 Days)");
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            chartDailySales.Titles.Add(title);

            // Create series
            Series s = new Series("Daily Sales")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DodgerBlue,
                BorderWidth = 3,
                ChartArea = "MainArea",
                IsValueShownAsLabel = true
            };

            // Get data
            var data = OrderService.GetDailySalesForLastDays(7);

            // Check if we have data
            if (data == null || data.Count == 0)
            {
                // Add sample data to show the chart is working
                s.Points.AddXY("Mon", 0);
                s.Points.AddXY("Tue", 0);
                s.Points.AddXY("Wed", 0);
                s.Points.AddXY("Thu", 0);
                s.Points.AddXY("Fri", 0);
                s.Points.AddXY("Sat", 0);
                s.Points.AddXY("Sun", 0);
            }
            else
            {
                foreach (var entry in data)
                    s.Points.AddXY(entry.Key.ToString("ddd"), entry.Value);
            }

            chartDailySales.Series.Add(s);

            // Force refresh
            chartDailySales.Invalidate();
            chartDailySales.Update();
        }

        private void PopulateItemsChart()
        {
            // Check if chart exists
            if (chartCategorySales == null)
            {
                MessageBox.Show("Category Sales Chart control not found in the form!");
                return;
            }

            // Clear everything
            chartCategorySales.Series.Clear();
            chartCategorySales.Titles.Clear();
            chartCategorySales.ChartAreas.Clear();

            // Add ChartArea (CRITICAL - charts need this to display)
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartCategorySales.ChartAreas.Add(chartArea);

            // Add title
            chartCategorySales.Titles.Add("Top Selling Items");

            // Create series
            Series s = new Series("Items Sold")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                ChartArea = "MainArea",
                Color = Color.Green
            };

            // Get data
            var data = OrderService.GetSalesByItem()
                                   .OrderByDescending(kvp => kvp.Value)
                                   .Take(5)
                                   .ToList();

            // Check if we have data
            if (data == null || data.Count == 0)
            {
                // Add dummy point to show empty chart
                s.Points.AddXY("No Data", 0);
            }
            else
            {
                foreach (var entry in data)
                    s.Points.AddXY(entry.Key, entry.Value);
            }

            chartCategorySales.Series.Add(s);

            // Force refresh
            chartCategorySales.Invalidate();
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
                // Find if MenuForm is already open and hidden
                MenuForm existingMenu = Application.OpenForms.OfType<MenuForm>().FirstOrDefault();

                if (existingMenu != null)
                {
                    // If MenuForm exists, just show it
                    existingMenu.WindowState = FormWindowState.Maximized;
                    existingMenu.Show();
                    existingMenu.BringToFront();
                    this.Hide();
                }
                else
                {
                    // Create new MenuForm if it doesn't exist
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

        private void btnNavFoodOrders_Click(object sender, EventArgs e)
        {

        }
    }
}
