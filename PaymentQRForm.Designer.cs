namespace MyKioski
{
    partial class PaymentQRForm
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
            pictureBoxQR = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(380, 289);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom; // Make QR auto-fit nicely
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // PaymentQRForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxQR);
            Name = "PaymentQRForm";
            Text = "Scan to Pay";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pictureBoxQR;
    }
}
