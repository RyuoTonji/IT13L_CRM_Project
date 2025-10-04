namespace IT13_rject
{
    partial class notificationOfSentFeedback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            confirmationLbl = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // confirmationLbl
            // 
            confirmationLbl.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmationLbl.Location = new Point(107, 196);
            confirmationLbl.Name = "confirmationLbl";
            confirmationLbl.Size = new Size(351, 68);
            confirmationLbl.TabIndex = 15;
            confirmationLbl.Text = "Something about thanking the user about providing feedback.\r\n\r\n";
            confirmationLbl.TextAlign = ContentAlignment.MiddleCenter;
            confirmationLbl.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(107, 128);
            label1.Name = "label1";
            label1.Size = new Size(351, 68);
            label1.TabIndex = 16;
            label1.Text = "Feedback Sent!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseWaitCursor = true;
            // 
            // notificationOfSentFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 326);
            Controls.Add(label1);
            Controls.Add(confirmationLbl);
            Name = "notificationOfSentFeedback";
            Load += notificationOfSentFeedback_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label confirmationLbl;
        private Label label1;
    }
}