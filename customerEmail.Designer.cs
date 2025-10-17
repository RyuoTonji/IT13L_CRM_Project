namespace MyKioski
{
    public partial class customerEmail : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            emailBox = new TextBox();
            label2 = new Label();
            feedbackBox = new TextBox();
            sendBtn = new Button();
            bindingSource1 = new BindingSource(components);
            label5 = new Label();
            othersBtn = new Button();
            complaintBtn = new Button();
            inquiryBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.Location = new Point(26, 51);
            emailBox.Multiline = true;
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter email address here";
            emailBox.Size = new Size(459, 33);
            emailBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 29);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "From:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // feedbackBox
            // 
            feedbackBox.Location = new Point(26, 108);
            feedbackBox.Multiline = true;
            feedbackBox.Name = "feedbackBox";
            feedbackBox.PlaceholderText = "Enter message here";
            feedbackBox.Size = new Size(459, 287);
            feedbackBox.TabIndex = 9;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(821, 390);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(141, 49);
            sendBtn.TabIndex = 11;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += Send_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(503, 200);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 19;
            label5.Text = "Type of Concern";
            // 
            // othersBtn
            // 
            othersBtn.Location = new Point(821, 226);
            othersBtn.Name = "othersBtn";
            othersBtn.Size = new Size(141, 49);
            othersBtn.TabIndex = 18;
            othersBtn.Text = "Others";
            othersBtn.UseVisualStyleBackColor = true;
            othersBtn.Click += othersBtn_Click;
            // 
            // complaintBtn
            // 
            complaintBtn.Location = new Point(664, 226);
            complaintBtn.Name = "complaintBtn";
            complaintBtn.Size = new Size(141, 49);
            complaintBtn.TabIndex = 17;
            complaintBtn.Text = "Complaint";
            complaintBtn.UseVisualStyleBackColor = true;
            complaintBtn.Click += complaintBtn_Click;
            // 
            // inquiryBtn
            // 
            inquiryBtn.Location = new Point(503, 226);
            inquiryBtn.Name = "inquiryBtn";
            inquiryBtn.Size = new Size(141, 49);
            inquiryBtn.TabIndex = 16;
            inquiryBtn.Text = "Inquiry";
            inquiryBtn.UseVisualStyleBackColor = true;
            inquiryBtn.Click += inquiryBtn_Click;
            // 
            // customerEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 463);
            Controls.Add(label5);
            Controls.Add(othersBtn);
            Controls.Add(complaintBtn);
            Controls.Add(inquiryBtn);
            Controls.Add(sendBtn);
            Controls.Add(feedbackBox);
            Controls.Add(label2);
            Controls.Add(emailBox);
            Name = "customerEmail";
            Text = "Feedback ";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox emailBox;
        private Label label2;
        private TextBox feedbackBox;
        private Button sendBtn;
        private BindingSource bindingSource1;

        private Label label5;
        private Button othersBtn;
        private Button complaintBtn;
        private Button inquiryBtn;
    }
}