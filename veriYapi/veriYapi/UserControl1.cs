using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Drawing;
using DocumentFormat.OpenXml.Office.Word;
using System.Windows.Forms.DataVisualization.Charting;


namespace veriYapi
{

    public partial class ucRaporlama : UserControl
    {
        public int CurrentUserID { get; set; }

        string baglantiCumlesi = "Server=DESKTOP-7VKKIA1\\SQLEXPRESS;Database=veriYapi;Trusted_Connection=True;";
        PrintDocument printDocument = new PrintDocument();
        int currentRow = 0;

        public ucRaporlama(int gelenUserID)
        {
            InitializeComponent();
            this.CurrentUserID = gelenUserID;
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF Dosyası|*.pdf",
                FileName = "Rapor.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToPDF(dgvRapor, sfd.FileName);
                    MessageBox.Show("PDF başarıyla oluşturuldu! 🧾✅", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int rowHeight = 30;

            System.Drawing.Font font = new System.Drawing.Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            // Sütun başlıkları
            int x = left;
            foreach (DataGridViewColumn col in dgvRapor.Columns)
            {
                e.Graphics.DrawString(col.HeaderText, font, brush, x, top);
                e.Graphics.DrawRectangle(pen, x, top, col.Width, rowHeight);
                x += col.Width;
            }

            top += rowHeight;

            // Satırlar
            while (currentRow < dgvRapor.Rows.Count)
            {
                DataGridViewRow row = dgvRapor.Rows[currentRow];
                x = left;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string text = cell.Value?.ToString() ?? "";
                    e.Graphics.DrawString(text, font, brush, x, top);
                    e.Graphics.DrawRectangle(pen, x, top, cell.OwningColumn.Width, rowHeight);
                    x += cell.OwningColumn.Width;
                }

                top += rowHeight;
                currentRow++;

                if (top + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            currentRow = 0;
            e.HasMorePages = false;
        }
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void ucRaporlama_Load(object sender, EventArgs e)
        {
            KullaniciBilgiYukle();
            cmbDurumFiltrele.Items.Clear();
            cmbDurumFiltrele.Items.AddRange(new string[] { "Tümü", "Bilinenler", "Bilinmeyenler" });
            cmbDurumFiltrele.SelectedIndex = 0;
            KelimeleriGetir();

            GrafikleriYukle();
            var veriler = GetirGunlukVeri(CurrentUserID); 
                        CizGrafik(veriler);

            btnFiltrele_Click(null, null); 
        }
        private void KullaniciBilgiYukle()
        {
            int toplamKelime = dgvRapor.Rows.Count;
            int bilinenKelime = dgvRapor.Rows.Cast<DataGridViewRow>()
                               .Count(row => Convert.ToBoolean(row.Cells["IsKnown"].Value) == true);

            lblToplamKelime.Text = $"Toplam Kelime: {toplamKelime}";
            lblBilinenKelime.Text = $"Bilinen Kelime: {bilinenKelime}";

            double oran = toplamKelime == 0 ? 0 : (bilinenKelime * 100.0) / toplamKelime;
            lblBasariOrani.Text = $"Başarı Oranı: %{oran:F2}";
        }

        public DataTable KelimeleriGetir()
        {
            DataTable dt = new DataTable();
                        string query = @"
                        SELECT
                        w.English,
                        w.Turkish,
                        u.LastAnsweredDate,
                        u.IsKnown
                        FROM
                        WordProgress u
                        INNER JOIN
                        Words w ON u.WordID = w.WordID
                        "; 

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", CurrentUserID); 

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable KelimeleriGetir(string durumFilter, string aramaKelime)
        {
            DataTable dt = new DataTable();

            string query = @"
                        SELECT
                        w.English,
                        w.Turkish,
                        u.LastAnsweredDate,
                        u.IsKnown
                        FROM
                        WordProgress u
                        INNER JOIN
                        Words w ON u.WordID = w.WordID
                        WHERE
                        UserID = @UserID";

            if (durumFilter == "Bilinenler")
                query += " AND IsKnown = 1 ";
            else if (durumFilter == "Bilinmeyenler")
                query += " AND IsKnown = 0 ";

            if (!string.IsNullOrEmpty(aramaKelime))
                query += " AND (English LIKE @Arama OR Turkish LIKE @Arama) ";

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", CurrentUserID);

                    if (!string.IsNullOrEmpty(aramaKelime))
                        cmd.Parameters.AddWithValue("@Arama", $"%{aramaKelime}%");

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            string durum = cmbDurumFiltrele.SelectedItem?.ToString() ?? "Tümü";
            string araKelime = txtKrlimeAra.Text.Trim();

            DataTable dt = KelimeleriGetir(durum, araKelime);
            dgvRapor.DataSource = dt;

            KullaniciBilgiYukle();
        }

        private void GrafikleriYukle()
        {
            // Günlük öğrenme verisi
            DataTable dtGunluk = new DataTable();
            string sqlGunluk = @"
                SELECT 
                CAST(LastAnsweredDate AS DATE) AS Tarih, 
                COUNT(*) AS DogruSayisi
                FROM 
                WordProgress
                WHERE 
                UserID = @UserID AND IsKnown = 1
                GROUP BY 
                CAST(LastAnsweredDate AS DATE)
                ORDER BY 
                Tarih;";

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            using (SqlCommand cmd = new SqlCommand(sqlGunluk, con))
            {
                cmd.Parameters.AddWithValue("@UserID", CurrentUserID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtGunluk);
            }

            chartIstataistik.Series.Clear();
            chartIstataistik.ChartAreas.Clear();

            chartIstataistik.ChartAreas.Add("ChartArea1");

            // Günlük Öğrenme Serisi
            var seriesGunluk = new System.Windows.Forms.DataVisualization.Charting.Series("Günlük Öğrenme");
            seriesGunluk.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chartIstataistik.Series.Add(seriesGunluk);

            foreach (DataRow row in dtGunluk.Rows)
            {
                DateTime tarih = (DateTime)row["Tarih"];
                int sayi = Convert.ToInt32(row["DogruSayisi"]);
                seriesGunluk.XValueType = ChartValueType.DateTime;
                seriesGunluk.Points.AddXY(tarih, sayi);
            }

            // En Çok Hata Yapılan Kelimeler
            DataTable dtHata = new DataTable();
            string sqlHata = @"
                SELECT TOP 10 
                w.English, 
                COUNT(*) AS HataSayisi
                FROM 
                WordProgress uwp
                INNER JOIN 
                Words w ON uwp.WordID = w.WordID
                WHERE 
                uwp.UserID = @UserID AND IsKnown = 0
                GROUP BY 
                w.English
                ORDER BY 
                HataSayisi DESC;";

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            using (SqlCommand cmd = new SqlCommand(sqlHata, con))
            {
                cmd.Parameters.AddWithValue("@UserID", CurrentUserID);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtHata);
            }

            var seriesHata = new System.Windows.Forms.DataVisualization.Charting.Series("En Çok Hata Yapılan Kelimeler");
            seriesHata.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chartIstataistik.Series.Add(seriesHata);

            foreach (DataRow row in dtHata.Rows)
            {
                string kelime = row["English"].ToString();
                int hataSayisi = Convert.ToInt32(row["HataSayisi"]);
                seriesHata.Points.AddXY(kelime, hataSayisi);
            }
        }

        private void ExportToPDF(DataGridView dgv, string filePath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            table.WidthPercentage = 100;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new BaseColor(240, 240, 240); /
                table.AddCell(cell);
            }

            // Veriler
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(cell.Value?.ToString() ?? "");
                }
            }

            document.Add(table);
            document.Close();
        }

        private void ExportToExcel(DataGridView dgv, string dosyaYolu)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Rapor");

                // Başlıklar
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                }

                // Satırlar
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                workbook.SaveAs(dosyaYolu);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Dosyası|*.xlsx", FileName = "Rapor.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dgvRapor, sfd.FileName);
                    MessageBox.Show("Excel dosyası başarıyla oluşturuldu! 🎉");
                }
            }
        }

        public class GunlukVeri
        {
            public DateTime Tarih { get; set; }
            public int KelimeSayisi { get; set; }
        }

        List<GunlukVeri> GetirGunlukVeri(int kullaniciID)
        {
            List<GunlukVeri> liste = new List<GunlukVeri>();

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand(@"
            select 
            cast (LastAnsweredDate as DATE) as Tarih,
            count(*) as kelimeSayisi
            from WordProgress
            where UserID =@id and IsKnown=1
            group by cast (LastAnsweredDate as DATE)
            order by Tarih", con);

                cmd.Parameters.AddWithValue("@id", kullaniciID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    liste.Add(new GunlukVeri
                    {
                        Tarih = Convert.ToDateTime(dr["Tarih"]),
                        KelimeSayisi = Convert.ToInt32(dr["kelimeSayisi"])
                    });
                }
            }

            return liste;
        }
        void CizGrafik(List<GunlukVeri> veriler)
        {
            chartIstataistik.Series.Clear();

            Series seri = new Series("Günlük Kelime");
            seri.ChartType = SeriesChartType.Column;
            seri.Color = Color.SteelBlue;

            foreach (var veri in veriler)
            {
                seri.Points.AddXY(veri.Tarih.ToString("dd MMM"), veri.KelimeSayisi);
            }

            chartIstataistik.Series.Add(seri);
            chartIstataistik.ChartAreas[0].AxisX.Title = "Tarih";
            chartIstataistik.ChartAreas[0].AxisY.Title = "Öğrenilen Kelime Sayısı";
            chartIstataistik.Titles.Clear();
            chartIstataistik.Titles.Add("Günlük Öğrenme Grafiği");
        }

        private void chartIstataistik_Click(object sender, EventArgs e)
        {

        }

        public class HataVerisi
        {
            public string Kelime { get; set; }
            public int HataSayisi { get; set; }
        }

        List<HataVerisi> GetirEnCokHatalar(int kullaniciID)
        {
            List<HataVerisi> liste = new List<HataVerisi>();

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand(@"
            select top 10 w.English,count(*) as HataSayisi
            from WordProgress u join Words w on w.WordID=u.WordID
            where u.UserID=@id and u.IsKnown=0
            group by w.English
            order by HataSayisi desc", con);

                cmd.Parameters.AddWithValue("@id", kullaniciID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    liste.Add(new HataVerisi
                    {
                        Kelime = dr["English"].ToString(),
                        HataSayisi = Convert.ToInt32(dr["HataSayisi"])
                    });
                }
            }
            return liste;
        }
        void CizHataGrafik(List<HataVerisi> veriler)
        {
            chartIstataistik.Series.Clear(); // Aynı Chart'ı kullanabilir
            Series seri = new Series("Hatalı Kelimeler");
            seri.ChartType = SeriesChartType.Bar;
            seri.Color = Color.IndianRed;

            foreach (var veri in veriler)
            {
                seri.Points.AddXY(veri.Kelime, veri.HataSayisi);
            }

            chartIstataistik.Series.Add(seri);
            chartIstataistik.ChartAreas[0].AxisX.Title = "Kelime";
            chartIstataistik.ChartAreas[0].AxisY.Title = "Hata Sayısı";
            chartIstataistik.Titles.Clear();
            chartIstataistik.Titles.Add("En Çok Hata Yapılan Kelimeler");
        }

        private void btnHataGrafik_Click(object sender, EventArgs e)
        {
            var veriler = GetirEnCokHatalar(CurrentUserID);
            CizHataGrafik(veriler);
        }

        public class DogrulukOrani
        {
            public int Dogru { get; set; }
            public int Yanlis { get; set; }
        }

        DogrulukOrani GetirDogrulukOrani(int kullaniciID)
        {
            var oran = new DogrulukOrani();

            using (SqlConnection con = new SqlConnection(baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
            SUM(CASE WHEN IsKnown = 1 THEN 1 ELSE 0 END) AS DogruSayisi,
            SUM(CASE WHEN IsKnown = 0 THEN 1 ELSE 0 END) AS YanlisSayisi
            FROM WordProgress
            WHERE UserID = @id", con);

                cmd.Parameters.AddWithValue("@id", kullaniciID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    oran.Dogru = dr["DogruSayisi"] != DBNull.Value ? Convert.ToInt32(dr["DogruSayisi"]) : 0;
                    oran.Yanlis = dr["YanlisSayisi"] != DBNull.Value ? Convert.ToInt32(dr["YanlisSayisi"]) : 0;
                }

            }

            return oran;
        }

        void CizDogrulukGrafik(DogrulukOrani oran)
        {
            chartIstataistik.Series.Clear(); 
            chartIstataistik.Titles.Clear();
            chartIstataistik.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartIstataistik.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            Series pieSeri = new Series("Doğruluk");
            pieSeri.ChartType = SeriesChartType.Pie;

            pieSeri.Points.AddXY("Doğru", oran.Dogru);
            pieSeri.Points.AddXY("Yanlış", oran.Yanlis);

            pieSeri.Points[0].Color = Color.SeaGreen;
            pieSeri.Points[1].Color = Color.IndianRed;

            pieSeri.IsValueShownAsLabel = true;

            chartIstataistik.Series.Add(pieSeri);
            chartIstataistik.Titles.Add("Genel Doğruluk Oranı");
        }

        private void btnDogruluk_Click(object sender, EventArgs e)
        {
            var oran = GetirDogrulukOrani(CurrentUserID); 
            CizDogrulukGrafik(oran);
        }

        private void dgvRapor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
