using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Yazilim_Yapimi
{
    public partial class bulmaca : Form
    {
        List<string> foundWords = new List<string>();

        private bool isSelecting = false;
        private List<Label> selectedLabels = new List<Label>();
        private int selectingRow = -1;

        List<string> Words = new List<string>();

        public bulmaca()
        {
            InitializeComponent();
            this.button2.Click += new System.EventHandler(this.button2_Click);

        }

        private void bulmaca_Load(object sender, EventArgs e)
        {

        }

        private void bulmaca_Resize(object sender, EventArgs e)
        {
            int size = Math.Min(this.ClientSize.Width, this.ClientSize.Height) - 20;
            tableLayoutPanel1.Size = new Size(size, size);
        }



        string connStr = "Data Source=MELISA\\MSSQLSERVER01;Initial Catalog=yazilim_yapimi;Integrated Security=True";

        List<string> VeritabanindanKelimeleriGetir(int adet)
        {
            List<string> kelimeler = new List<string>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = $"SELECT TOP {adet} engWordName FROM Words ORDER BY NEWID()";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kelimeler.Add(reader["engWordName"].ToString().Trim().ToUpper());
                }
            }

            return kelimeler;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Words = VeritabanindanKelimeleriGetir(10);
            BulmacaOlustur();


        }

        Label[,] grid;

        void BulmacaOlustur()
        {



            int boyut = 10;

            if (grid == null)
            {
                grid = new Label[boyut, boyut];
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowCount = boyut;
                tableLayoutPanel1.ColumnCount = boyut;
                tableLayoutPanel1.ColumnStyles.Clear();
                tableLayoutPanel1.RowStyles.Clear();

                for (int i = 0; i < boyut; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / boyut));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / boyut));
                }

                for (int row = 0; row < boyut; row++)
                {
                    for (int col = 0; col < boyut; col++)
                    {
                        Label lbl = new Label();
                        /* lbl.MouseDown += Label_MouseDown;
                         lbl.MouseEnter += Label_MouseEnter;
                         lbl.MouseUp += Label_MouseUp;*/
                        lbl.Click += Label_Click;
                        lbl.Dock = DockStyle.Fill;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Font = new Font("Consolas", 14, FontStyle.Regular);
                        lbl.BorderStyle = BorderStyle.FixedSingle; // Daha belirgin kareler için
                        lbl.Text = "";
                        tableLayoutPanel1.Controls.Add(lbl, col, row);
                        grid[row, col] = lbl;
                    }
                }
            }
            else
            {
                // Var olan label kontrollerin textlerini temizle
                for (int row = 0; row < boyut; row++)
                {
                    for (int col = 0; col < boyut; col++)
                    {
                        grid[row, col].Text = "";
                    }
                }
            }

            Random rnd = new Random();

            // Kelimeleri yerleştir
            foreach (string word in Words)
            {
                string kelime = word.ToUpper();
                bool yerlestirildi = false;

                for (int attempt = 0; attempt < 100 && !yerlestirildi; attempt++)
                {
                    int row = rnd.Next(0, boyut);
                    int maxStartCol = boyut - kelime.Length;
                    if (maxStartCol < 0) continue;

                    int startCol = rnd.Next(0, maxStartCol + 1);

                    bool uygun = true;
                    for (int i = 0; i < kelime.Length; i++)
                    {
                        string mevcut = grid[row, startCol + i].Text;
                        if (!string.IsNullOrEmpty(mevcut) && mevcut != kelime[i].ToString())
                        {
                            uygun = false;
                            break;
                        }
                    }

                    if (uygun)
                    {
                        for (int i = 0; i < kelime.Length; i++)
                        {
                            grid[row, startCol + i].Text = kelime[i].ToString();
                        }
                        yerlestirildi = true;
                    }
                }
            }

            // Boş hücreleri doldur
            for (int row = 0; row < boyut; row++)
            {
                for (int col = 0; col < boyut; col++)
                {
                    if (string.IsNullOrWhiteSpace(grid[row, col].Text))
                    {
                        grid[row, col].Text = ((char)rnd.Next('A', 'Z' + 1)).ToString();
                    }
                }
            }
        }


        private void Label_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null)
                return;

            // Seçili değilse seç, seçili ise seçimi kaldır
            if (!selectedLabels.Contains(lbl))
            {
                // Eğer seçili harf yoksa ekle
                if (selectedLabels.Count == 0)
                {
                    selectedLabels.Add(lbl);
                    lbl.BackColor = Color.LightBlue;
                }
                else
                {
                    // Son seçilen harfin pozisyonu
                    var lastPos = tableLayoutPanel1.GetPositionFromControl(selectedLabels.Last());
                    var thisPos = tableLayoutPanel1.GetPositionFromControl(lbl);

                    // Harfler ya aynı satırda, ya da aynı sütunda ve bitişik olmalı
                    bool isAdjacent = false;
                    if (lastPos.Row == thisPos.Row &&
                        Math.Abs(lastPos.Column - thisPos.Column) == 1)
                        isAdjacent = true;
                    else if (lastPos.Column == thisPos.Column &&
                             Math.Abs(lastPos.Row - thisPos.Row) == 1)
                        isAdjacent = true;

                    if (isAdjacent)
                    {
                        selectedLabels.Add(lbl);
                        lbl.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        MessageBox.Show("Sadece bitişik harfleri seçebilirsiniz!");
                    }
                }
            }
            else
            {
                // Seçili ise iptal et ve sonrakileri temizle (örnek olarak)
                int index = selectedLabels.IndexOf(lbl);
                for (int i = selectedLabels.Count - 1; i >= index; i--)
                {
                    selectedLabels[i].BackColor = Color.White;
                    selectedLabels.RemoveAt(i);
                }
            }

            // Seçilen harflerin kelimesini göster (textBox1 veya başka)
            textBox1.Text = string.Concat(selectedLabels.Select(l => l.Text));
        }





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //oluşan kelimeyi göster
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // kelime
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //onayla butonu
            if (selectedLabels.Count == 0)
                return;

            string selectedWord = string.Concat(selectedLabels.Select(l => l.Text));
            string reversedWord = new string(selectedWord.Reverse().ToArray());

            // Kelimenin veritabanından gelen kelimeler listesinde olup olmadığını kontrol et
            bool isCorrect = Words.Contains(selectedWord) || Words.Contains(reversedWord);

            if (isCorrect)
            {
                foreach (var lbl in selectedLabels)
                {
                    lbl.BackColor = Color.LightGreen;
                    lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                    lbl.Enabled = false; // Bir daha seçilmesin
                }

                if (!foundWords.Contains(selectedWord) && !foundWords.Contains(reversedWord))
                {
                    foundWords.Add(selectedWord);
                    textBox2.AppendText(selectedWord + Environment.NewLine);
                }
            }
            else
            {
                foreach (var lbl in selectedLabels)
                {
                    lbl.BackColor = Color.White;
                    lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                }
                MessageBox.Show("Yanlış kelime seçildi!");
            }

            selectedLabels.Clear();
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
