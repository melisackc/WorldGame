namespace veriYapi
{
    partial class ucRaporlama
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

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlKullaniciBilgileri = new System.Windows.Forms.Panel();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblToplamKelime = new System.Windows.Forms.Label();
            this.lblBilinenKelime = new System.Windows.Forms.Label();
            this.lblBasariOrani = new System.Windows.Forms.Label();
            this.dgvRapor = new System.Windows.Forms.DataGridView();
            this.cmbDurumFiltrele = new System.Windows.Forms.ComboBox();
            this.txtKrlimeAra = new System.Windows.Forms.TextBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.chartIstataistik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHataGrafik = new System.Windows.Forms.Button();
            this.btnDogruluk = new System.Windows.Forms.Button();
            this.pnlKullaniciBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIstataistik)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKullaniciBilgileri
            // 
            this.pnlKullaniciBilgileri.Controls.Add(this.lblBasariOrani);
            this.pnlKullaniciBilgileri.Controls.Add(this.lblBilinenKelime);
            this.pnlKullaniciBilgileri.Controls.Add(this.lblToplamKelime);
            this.pnlKullaniciBilgileri.Controls.Add(this.btnExcel);
            this.pnlKullaniciBilgileri.Controls.Add(this.lblAd);
            this.pnlKullaniciBilgileri.Controls.Add(this.btnYazdir);
            this.pnlKullaniciBilgileri.Controls.Add(this.btnPdf);
            this.pnlKullaniciBilgileri.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKullaniciBilgileri.Location = new System.Drawing.Point(0, 0);
            this.pnlKullaniciBilgileri.Name = "pnlKullaniciBilgileri";
            this.pnlKullaniciBilgileri.Size = new System.Drawing.Size(938, 59);
            this.pnlKullaniciBilgileri.TabIndex = 0;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(38, 23);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(44, 16);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "label1";
            // 
            // lblToplamKelime
            // 
            this.lblToplamKelime.AutoSize = true;
            this.lblToplamKelime.Location = new System.Drawing.Point(161, 23);
            this.lblToplamKelime.Name = "lblToplamKelime";
            this.lblToplamKelime.Size = new System.Drawing.Size(44, 16);
            this.lblToplamKelime.TabIndex = 1;
            this.lblToplamKelime.Text = "label1";
            // 
            // lblBilinenKelime
            // 
            this.lblBilinenKelime.AutoSize = true;
            this.lblBilinenKelime.Location = new System.Drawing.Point(290, 23);
            this.lblBilinenKelime.Name = "lblBilinenKelime";
            this.lblBilinenKelime.Size = new System.Drawing.Size(44, 16);
            this.lblBilinenKelime.TabIndex = 2;
            this.lblBilinenKelime.Text = "label1";
            // 
            // lblBasariOrani
            // 
            this.lblBasariOrani.AutoSize = true;
            this.lblBasariOrani.Location = new System.Drawing.Point(421, 23);
            this.lblBasariOrani.Name = "lblBasariOrani";
            this.lblBasariOrani.Size = new System.Drawing.Size(44, 16);
            this.lblBasariOrani.TabIndex = 3;
            this.lblBasariOrani.Text = "label1";
            // 
            // dgvRapor
            // 
            this.dgvRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapor.Location = new System.Drawing.Point(6, 65);
            this.dgvRapor.Name = "dgvRapor";
            this.dgvRapor.RowHeadersWidth = 51;
            this.dgvRapor.RowTemplate.Height = 24;
            this.dgvRapor.Size = new System.Drawing.Size(520, 222);
            this.dgvRapor.TabIndex = 1;
            this.dgvRapor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRapor_CellContentClick);
            // 
            // cmbDurumFiltrele
            // 
            this.cmbDurumFiltrele.FormattingEnabled = true;
            this.cmbDurumFiltrele.Items.AddRange(new object[] {
            "tümü",
            "bilinen",
            "bilinmeyen"});
            this.cmbDurumFiltrele.Location = new System.Drawing.Point(61, 308);
            this.cmbDurumFiltrele.Name = "cmbDurumFiltrele";
            this.cmbDurumFiltrele.Size = new System.Drawing.Size(121, 24);
            this.cmbDurumFiltrele.TabIndex = 2;
            // 
            // txtKrlimeAra
            // 
            this.txtKrlimeAra.Location = new System.Drawing.Point(212, 308);
            this.txtKrlimeAra.Name = "txtKrlimeAra";
            this.txtKrlimeAra.Size = new System.Drawing.Size(100, 22);
            this.txtKrlimeAra.TabIndex = 3;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(212, 349);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrele.TabIndex = 4;
            this.btnFiltrele.Text = "filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // chartIstataistik
            // 
            chartArea3.Name = "ChartArea1";
            this.chartIstataistik.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartIstataistik.Legends.Add(legend3);
            this.chartIstataistik.Location = new System.Drawing.Point(546, 65);
            this.chartIstataistik.Name = "chartIstataistik";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartIstataistik.Series.Add(series3);
            this.chartIstataistik.Size = new System.Drawing.Size(368, 288);
            this.chartIstataistik.TabIndex = 5;
            this.chartIstataistik.Text = "chart1";
            this.chartIstataistik.Click += new System.EventHandler(this.chartIstataistik_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.Location = new System.Drawing.Point(573, 23);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(106, 38);
            this.btnYazdir.TabIndex = 6;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = true;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(694, 21);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(106, 38);
            this.btnPdf.TabIndex = 7;
            this.btnPdf.Text = "PDF Kaydet";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(818, 18);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(106, 38);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Excel Kaydet";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Durum: ";
            // 
            // btnHataGrafik
            // 
            this.btnHataGrafik.Location = new System.Drawing.Point(414, 297);
            this.btnHataGrafik.Name = "btnHataGrafik";
            this.btnHataGrafik.Size = new System.Drawing.Size(106, 30);
            this.btnHataGrafik.TabIndex = 10;
            this.btnHataGrafik.Text = "Hata Grafiği";
            this.btnHataGrafik.UseVisualStyleBackColor = true;
            this.btnHataGrafik.Click += new System.EventHandler(this.btnHataGrafik_Click);
            // 
            // btnDogruluk
            // 
            this.btnDogruluk.Location = new System.Drawing.Point(414, 349);
            this.btnDogruluk.Name = "btnDogruluk";
            this.btnDogruluk.Size = new System.Drawing.Size(106, 29);
            this.btnDogruluk.TabIndex = 11;
            this.btnDogruluk.Text = "Dogruluk";
            this.btnDogruluk.UseVisualStyleBackColor = true;
            this.btnDogruluk.Click += new System.EventHandler(this.btnDogruluk_Click);
            // 
            // ucRaporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnDogruluk);
            this.Controls.Add(this.btnHataGrafik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartIstataistik);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.txtKrlimeAra);
            this.Controls.Add(this.cmbDurumFiltrele);
            this.Controls.Add(this.dgvRapor);
            this.Controls.Add(this.pnlKullaniciBilgileri);
            this.Name = "ucRaporlama";
            this.Size = new System.Drawing.Size(938, 566);
            this.Load += new System.EventHandler(this.ucRaporlama_Load);
            this.pnlKullaniciBilgileri.ResumeLayout(false);
            this.pnlKullaniciBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIstataistik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKullaniciBilgileri;
        private System.Windows.Forms.Label lblBasariOrani;
        private System.Windows.Forms.Label lblBilinenKelime;
        private System.Windows.Forms.Label lblToplamKelime;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.DataGridView dgvRapor;
        private System.Windows.Forms.ComboBox cmbDurumFiltrele;
        private System.Windows.Forms.TextBox txtKrlimeAra;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIstataistik;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHataGrafik;
        private System.Windows.Forms.Button btnDogruluk;
    }
}
