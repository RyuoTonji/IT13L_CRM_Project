// File: WelcomeForm.cs
using System;
using System.Windows.Forms;

namespace MyKioskApp
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm() { InitializeComponent(); }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            CenterControlHorizontally(this.label1);
            CenterControlHorizontally(this.label2);
            CenterControlHorizontally(this.label3);

            int spacing1 = 20;
            int spacing2 = 40;
            int totalHeight = this.label1.Height + spacing1 + this.label2.Height + spacing2 + this.label3.Height;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            this.label1.Top = startY;
            this.label2.Top = this.label1.Bottom + spacing1;
            this.label3.Top = this.label2.Bottom + spacing2;

            this.Click += new EventHandler(OnFormClick);
            this.label1.Click += new EventHandler(OnFormClick);
            this.label2.Click += new EventHandler(OnFormClick);
            this.label3.Click += new EventHandler(OnFormClick);
        }

        private void OnFormClick(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }

        private void CenterControlHorizontally(Control control)
        {
            control.Left = (this.ClientSize.Width - control.Width) / 2;
        }
    }
}