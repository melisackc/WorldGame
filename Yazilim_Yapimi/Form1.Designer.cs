namespace Yazilim_Yapimi
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
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 1;
            // 
            // button7
            // 
            button7.Location = new Point(8, 166);
            button7.Name = "button7";
            button7.Size = new Size(237, 29);
            button7.TabIndex = 7;
            button7.Text = "Hafıza Çivisi";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.Window;
            button6.Location = new Point(10, 28);
            button6.Name = "button6";
            button6.Size = new Size(235, 29);
            button6.TabIndex = 6;
            button6.Text = "Kelimlerim";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(8, 241);
            button5.Name = "button5";
            button5.Size = new Size(237, 29);
            button5.TabIndex = 5;
            button5.Text = "Ayarlar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(8, 206);
            button4.Name = "button4";
            button4.Size = new Size(237, 29);
            button4.TabIndex = 4;
            button4.Text = "Raporlarım";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(8, 131);
            button3.Name = "button3";
            button3.Size = new Size(237, 29);
            button3.TabIndex = 3;
            button3.Text = "Bulmaca";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(10, 63);
            button2.Name = "button2";
            button2.Size = new Size(235, 29);
            button2.TabIndex = 2;
            button2.Text = "Kelime Alıştırma";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(10, 96);
            button1.Name = "button1";
            button1.Size = new Size(237, 29);
            button1.TabIndex = 1;
            button1.Text = "Kelime Testi";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.BackColor = Color.LightSteelBlue;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 0;
            label1.Text = "    Menü";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Location = new Point(260, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(540, 450);
            panel2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Panel panel2;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
    }
}
