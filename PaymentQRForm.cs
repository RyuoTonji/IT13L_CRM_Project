using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyKioski
{
    public partial class PaymentQRForm : Form
    {
        public PaymentQRForm()
        {
            InitializeComponent();

            // Center the form on screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Optional: clean popup look
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Center the QR code after load and on resize
            this.Load += (s, e) => CenterQRImage();
            this.Resize += (s, e) => CenterQRImage();
        }

        private void CenterQRImage()
        {
            if (pictureBoxQR != null)
            {
                pictureBoxQR.Left = (this.ClientSize.Width - pictureBoxQR.Width) / 2;
                pictureBoxQR.Top = (this.ClientSize.Height - pictureBoxQR.Height) / 2;
            }
        }
    }
}
