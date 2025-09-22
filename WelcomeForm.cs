// File: WelcomeForm.cs
using System;
using System.Windows.Forms;

// Make sure this namespace matches your project name
namespace MyKioski
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void OnFormClick(object sender, EventArgs e)
        {
            OrderTypeForm orderTypeForm = new OrderTypeForm();
            orderTypeForm.Show();
            this.Hide();
        }
    }
}