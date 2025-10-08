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
            label3 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            bindingSource1 = new BindingSource(components);
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            label1.Location = new Point(503, 29);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Ticker Name";
            label1.Click += this.label1_Click;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(503, 192);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 8;
            label3.Text = "Priority";
            label3.Click += this.label3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(26, 108);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter message here";
            textBox2.Size = new Size(459, 287);
            textBox2.TabIndex = 9;
            // 
            // button4
            // 
            button4.Location = new Point(664, 390);
            button4.Name = "button4";
            button4.Size = new Size(141, 49);
            button4.TabIndex = 10;
            button4.Text = "Save as Draft";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(821, 390);
            button5.Name = "button5";
            button5.Size = new Size(141, 49);
            button5.TabIndex = 11;
            button5.Text = "Send";
            button5.UseVisualStyleBackColor = true;
            button5.Click += this.button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(503, 131);
            button6.Name = "button6";
            button6.Size = new Size(141, 49);
            button6.TabIndex = 12;
            button6.Text = "Dine In";
            button6.UseVisualStyleBackColor = true;
            button6.Click += this.button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(664, 131);
            button7.Name = "button7";
            button7.Size = new Size(141, 49);
            button7.TabIndex = 13;
            button7.Text = "Take Out";
            button7.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 108);
            label4.Name = "label4";
            label4.Size = new Size(158, 15);
            label4.TabIndex = 15;
            label4.Text = "Customer Service Experience";
            label4.Click += this.label4_Click;
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
            label5.Location = new Point(503, 281);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 19;
            label5.Text = "Type of Concern";
            // 
            // button8
            // 
            button8.Location = new Point(821, 308);
            button8.Name = "button8";
            button8.Size = new Size(141, 49);
            button8.TabIndex = 18;
            button8.Text = "Others";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(664, 308);
            button9.Name = "button9";
            button9.Size = new Size(141, 49);
            button9.TabIndex = 17;
            button9.Text = "Complaint";
            button9.UseVisualStyleBackColor = true;
            button9.Click += this.button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(503, 308);
            button10.Name = "button10";
            button10.Size = new Size(141, 49);
            button10.TabIndex = 16;
            button10.Text = "Inquiry";
            button10.UseVisualStyleBackColor = true;
            button10.Click += this.button10_Click;
            // 
            // button1
            // 
            button1.Location = new Point(821, 220);
            button1.Name = "button1";
            button1.Size = new Size(141, 49);
            button1.TabIndex = 22;
            button1.Text = "High";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(664, 220);
            button2.Name = "button2";
            button2.Size = new Size(141, 49);
            button2.TabIndex = 21;
            button2.Text = "Medium";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(503, 220);
            button3.Name = "button3";
            button3.Size = new Size(141, 49);
            button3.TabIndex = 20;
            button3.Text = "Low";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 463);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(label4);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(label3);
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
        private Label label3;
        private TextBox textBox2;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private BindingSource bindingSource1;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
