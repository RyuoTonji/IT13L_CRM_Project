namespace MyKioski
{
    partial class Form1
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
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            bindingSource1 = new BindingSource(components);
            textBox1 = new TextBox();
            label5 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            textBox4 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 51);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Enter email address here";
            textBox3.Size = new Size(459, 33);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(503, 22);
            label1.Name = "label1";
            label1.Size = new Size(85, 17);
            label1.TabIndex = 3;
            label1.Text = "Ticker Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(26, 22);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 4;
            label2.Text = "From:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(26, 101);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter message here";
            textBox2.Size = new Size(459, 287);
            textBox2.TabIndex = 9;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonHighlight;
            button4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(664, 398);
            button4.Name = "button4";
            button4.Size = new Size(141, 49);
            button4.TabIndex = 10;
            button4.Text = "Save as Draft";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ButtonHighlight;
            button5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(821, 398);
            button5.Name = "button5";
            button5.Size = new Size(141, 49);
            button5.TabIndex = 11;
            button5.Text = "Send Reply";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(503, 51);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter the concern here";
            textBox1.Size = new Size(459, 33);
            textBox1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(503, 98);
            label5.Name = "label5";
            label5.Size = new Size(108, 17);
            label5.TabIndex = 19;
            label5.Text = "Type of Concern";
            // 
            // button8
            // 
            button8.Location = new Point(821, 124);
            button8.Name = "button8";
            button8.Size = new Size(141, 49);
            button8.TabIndex = 18;
            button8.Text = "Others";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(664, 124);
            button9.Name = "button9";
            button9.Size = new Size(141, 49);
            button9.TabIndex = 17;
            button9.Text = "Complaint";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(503, 124);
            button10.Name = "button10";
            button10.Size = new Size(141, 49);
            button10.TabIndex = 16;
            button10.Text = "Inquiry";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(503, 221);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Enter message here";
            textBox4.Size = new Size(459, 167);
            textBox4.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(503, 190);
            label3.Name = "label3";
            label3.Size = new Size(140, 17);
            label3.TabIndex = 21;
            label3.Text = "Manager Note/Reply:";
            label3.Click += label3_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(983, 463);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Feedback ";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button button4;
        private Button button5;
        private BindingSource bindingSource1;
        private TextBox textBox1;
        private Label label5;
        private Button button8;
        private Button button9;
        private Button button10;
        private TextBox textBox4;
        private Label label3;
    }
}
