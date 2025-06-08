namespace Yazilim_Yapimi
{
    partial class Wordle
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.Location = new Point(571, 134);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Kontrol Et";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Violet;
            button2.Location = new Point(529, 338);
            button2.Name = "button2";
            button2.Size = new Size(227, 29);
            button2.TabIndex = 1;
            button2.Text = "Tekrar denemek ister misin?";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(426, 134);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.PaleGreen;
            label1.Location = new Point(431, 82);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 3;
            label1.Text = "Kelimeyi gir ve kontrol et";
            // 
            // button3
            // 
            button3.BackColor = Color.Lavender;
            button3.Location = new Point(694, 12);
            button3.Name = "button3";
            button3.Size = new Size(73, 29);
            button3.TabIndex = 4;
            button3.Text = "Geri";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Wordle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Wordle";
            Text = "Wordle";
            Load += Wordle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Button button3;
    }
}