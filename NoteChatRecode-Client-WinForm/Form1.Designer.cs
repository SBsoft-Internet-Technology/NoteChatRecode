namespace NoteChatRecode_Client_WinForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(150, 9);
            label1.Name = "label1";
            label1.Size = new Size(399, 52);
            label1.TabIndex = 0;
            label1.Text = "NoteChat-WinForm";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "localhost";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(150, 113);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(414, 27);
            textBox2.TabIndex = 2;
            textBox2.Text = "8080";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(150, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(414, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(150, 179);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(414, 27);
            textBox4.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(12, 291);
            button1.Name = "button1";
            button1.Size = new Size(222, 58);
            button1.TabIndex = 5;
            button1.Text = "社交的手腕";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_ClickAsync;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 370);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // button2
            // 
            button2.Location = new Point(240, 291);
            button2.Name = "button2";
            button2.Size = new Size(222, 58);
            button2.TabIndex = 7;
            button2.Text = "登录";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(468, 291);
            button3.Name = "button3";
            button3.Size = new Size(222, 58);
            button3.TabIndex = 8;
            button3.Text = "发送消息";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(240, 227);
            button4.Name = "button4";
            button4.Size = new Size(222, 58);
            button4.TabIndex = 9;
            button4.Text = "PING";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 408);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
