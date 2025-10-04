namespace IT13_rject
{
    partial class sendConfirmation
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
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            confirmationLbl = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(37, 137);
            button2.Name = "button2";
            button2.Size = new Size(141, 49);
            button2.TabIndex = 7;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(247, 137);
            button1.Name = "button1";
            button1.Size = new Size(141, 49);
            button1.TabIndex = 8;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 13);
            label1.Name = "label1";
            label1.Size = new Size(190, 37);
            label1.TabIndex = 9;
            label1.Text = "Are you sure?";
            label1.Click += label1_Click;
            // 
            // confirmationLbl
            // 
            confirmationLbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmationLbl.Location = new Point(37, 55);
            confirmationLbl.Name = "confirmationLbl";
            confirmationLbl.Size = new Size(351, 68);
            confirmationLbl.TabIndex = 10;
            confirmationLbl.Text = "Confirming here will send your feedback to the company.";
            confirmationLbl.TextAlign = ContentAlignment.MiddleCenter;
            confirmationLbl.UseWaitCursor = true;
            // 
            // sendConfirmation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 208);
            Controls.Add(confirmationLbl);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "sendConfirmation";
            Text = "Confirmation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label1;
        private Label confirmationLbl;
    }
}