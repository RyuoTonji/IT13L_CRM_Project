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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.Location = new Point(19, 45);
            emailBox.Multiline = true;
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter email address here...";
            emailBox.Size = new Size(459, 33);
            emailBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(19, 20);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 4;
            label2.Text = "From:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // feedbackBox
            // 
            feedbackBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            feedbackBox.Location = new Point(19, 115);
            feedbackBox.Multiline = true;
            feedbackBox.Name = "feedbackBox";
            feedbackBox.PlaceholderText = "Enter message here...";
            feedbackBox.Size = new Size(459, 287);
            feedbackBox.TabIndex = 9;
            feedbackBox.TextChanged += feedbackBox_TextChanged;
            // 
            // sendBtn
            // 
            sendBtn.BackColor = Color.White;
            sendBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            sendBtn.Location = new Point(643, 353);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(141, 49);
            sendBtn.TabIndex = 11;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = false;
            sendBtn.Click += Send_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(496, 85);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 19;
            label5.Text = "Type of Concern";
            label5.Click += label5_Click;
            // 
            // othersBtn
            // 
            othersBtn.BackColor = Color.White;
            othersBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            othersBtn.Location = new Point(643, 170);
            othersBtn.Name = "othersBtn";
            othersBtn.Size = new Size(141, 49);
            othersBtn.TabIndex = 18;
            othersBtn.Text = "Others";
            othersBtn.UseVisualStyleBackColor = false;
            othersBtn.Click += othersBtn_Click;
            // 
            // complaintBtn
            // 
            complaintBtn.BackColor = Color.White;
            complaintBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            complaintBtn.Location = new Point(643, 115);
            complaintBtn.Name = "complaintBtn";
            complaintBtn.Size = new Size(141, 49);
            complaintBtn.TabIndex = 17;
            complaintBtn.Text = "Complaint";
            complaintBtn.UseVisualStyleBackColor = false;
            complaintBtn.Click += complaintBtn_Click;
            // 
            // inquiryBtn
            // 
            inquiryBtn.BackColor = Color.White;
            inquiryBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            inquiryBtn.Location = new Point(496, 115);
            inquiryBtn.Name = "inquiryBtn";
            inquiryBtn.Size = new Size(141, 49);
            inquiryBtn.TabIndex = 16;
            inquiryBtn.Text = "Inquiry";
            inquiryBtn.UseVisualStyleBackColor = false;
            inquiryBtn.Click += inquiryBtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(496, 170);
            button1.Name = "button1";
            button1.Size = new Size(141, 49);
            button1.TabIndex = 20;
            button1.Text = "Suggestion/s";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(496, 353);
            button2.Name = "button2";
            button2.Size = new Size(141, 49);
            button2.TabIndex = 21;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(496, 265);
            label1.Name = "label1";
            label1.Size = new Size(274, 34);
            label1.TabIndex = 22;
            label1.Text = "Please specify your concern in the message box \r\nif you selected \"Others\".";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(496, 236);
            label3.Name = "label3";
            label3.Size = new Size(108, 17);
            label3.TabIndex = 23;
            label3.Text = "Note/Reminder:";
            // 
            // customerEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(807, 436);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label3;
    }
}