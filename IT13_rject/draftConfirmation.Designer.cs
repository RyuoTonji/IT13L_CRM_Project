namespace IT13_rject
{
    partial class Confirmation
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // confirmationLbl
            // 
            confirmationLbl.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmationLbl.Location = new Point(44, 55);
            confirmationLbl.Name = "confirmationLbl";
            confirmationLbl.Size = new Size(351, 68);
            confirmationLbl.TabIndex = 14;
            confirmationLbl.Text = "Confirming here will make your feedback as draft and can be edited later on.";
            confirmationLbl.TextAlign = ContentAlignment.MiddleCenter;
            confirmationLbl.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(129, 13);
            label1.Name = "label1";
            label1.Size = new Size(190, 37);
            label1.TabIndex = 13;
            label1.Text = "Are you sure?";
            // 
            // button1
            // 
            button1.Location = new Point(254, 137);
            button1.Name = "button1";
            button1.Size = new Size(141, 49);
            button1.TabIndex = 12;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(44, 137);
            button2.Name = "button2";
            button2.Size = new Size(141, 49);
            button2.TabIndex = 11;
            button2.Text = "Confirm as Draft";
            button2.UseVisualStyleBackColor = true;
            // 
            // Confirmation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 211);
            Controls.Add(confirmationLbl);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Confirmation";
            Text = "Confirmation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label confirmationLbl;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}