namespace veriYapi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEng = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.lblAdımBilgisi = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.progressSinav = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIpucu = new System.Windows.Forms.Button();
            this.lblIpucu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEng
            // 
            this.lblEng.AutoSize = true;
            this.lblEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEng.Location = new System.Drawing.Point(286, 140);
            this.lblEng.Name = "lblEng";
            this.lblEng.Size = new System.Drawing.Size(52, 18);
            this.lblEng.TabIndex = 0;
            this.lblEng.Text = "label1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(262, 174);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(103, 20);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(262, 200);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(103, 20);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(262, 235);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 20);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(262, 270);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(103, 20);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(170, 314);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(74, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Gonder";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Location = new System.Drawing.Point(388, 178);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(48, 16);
            this.lblSonuc.TabIndex = 6;
            this.lblSonuc.Text = "Sonuc:";
            // 
            // lblAdımBilgisi
            // 
            this.lblAdımBilgisi.AutoSize = true;
            this.lblAdımBilgisi.Location = new System.Drawing.Point(61, 321);
            this.lblAdımBilgisi.Name = "lblAdımBilgisi";
            this.lblAdımBilgisi.Size = new System.Drawing.Size(44, 16);
            this.lblAdımBilgisi.TabIndex = 7;
            this.lblAdımBilgisi.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(275, 314);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(77, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Sonraki";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // progressSinav
            // 
            this.progressSinav.Location = new System.Drawing.Point(554, 32);
            this.progressSinav.Name = "progressSinav";
            this.progressSinav.Size = new System.Drawing.Size(100, 23);
            this.progressSinav.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sınav modulüne HOŞ GELDİNİZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Aşağıdaki Kelimenin Türkçe Karşılığını Aşağıdan Seçiniz Lütfen: ";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(381, 309);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "rapor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIpucu
            // 
            this.btnIpucu.Location = new System.Drawing.Point(510, 188);
            this.btnIpucu.Name = "btnIpucu";
            this.btnIpucu.Size = new System.Drawing.Size(92, 32);
            this.btnIpucu.TabIndex = 14;
            this.btnIpucu.Text = "İpucu Cümle";
            this.btnIpucu.UseVisualStyleBackColor = true;
            this.btnIpucu.Click += new System.EventHandler(this.btnIpucu_Click);
            // 
            // lblIpucu
            // 
            this.lblIpucu.AutoSize = true;
            this.lblIpucu.Location = new System.Drawing.Point(25, 141);
            this.lblIpucu.Name = "lblIpucu";
            this.lblIpucu.Size = new System.Drawing.Size(44, 16);
            this.lblIpucu.TabIndex = 15;
            this.lblIpucu.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(662, 450);
            this.Controls.Add(this.lblIpucu);
            this.Controls.Add(this.btnIpucu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressSinav);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblAdımBilgisi);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lblEng);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEng;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.Label lblAdımBilgisi;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ProgressBar progressSinav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIpucu;
        private System.Windows.Forms.Label lblIpucu;
    }
}

