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
            button8 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button8);
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
            panel1.Paint += panel1_Paint;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.Info;
            button7.Location = new Point(142, 399);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 9;
            button7.Text = "Çıkış Yap";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click_1;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.Info;
            button8.Location = new Point(23, 398);
            button8.Name = "button8";
            button8.Size = new Size(67, 29);
            button8.TabIndex = 8;
            button8.Text = "Geri";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
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
            button5.Location = new Point(8, 201);
            button5.Name = "button5";
            button5.Size = new Size(237, 29);
            button5.TabIndex = 5;
            button5.Text = "Ayarlar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(8, 166);
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
            button2.Text = "Wordle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(260, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(540, 450);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // label4
            // 
            label4.BackColor = Color.LightGray;
            label4.Location = new Point(31, 63);
            label4.Name = "label4";
            label4.Size = new Size(497, 25);
            label4.TabIndex = 3;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.pexels_anntarazevich_8051955;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(75, 255);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(397, 172);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.LightGray;
            label3.Location = new Point(243, 17);
            label3.Name = "label3";
            label3.Size = new Size(285, 25);
            label3.TabIndex = 1;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.LightGray;
            label2.Location = new Point(31, 14);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 0;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
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
            Load += Form1_Load_1;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Panel panel2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private Button button7;
        private Button button8;
    }
}
