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

namespace Yazilim_Yapimi
{
    public partial class Wordle : Form
    {
        public Wordle()
        {
            InitializeComponent();
        }

        private Label[,] labels = new Label[6, 5];
        private string secretWord = "";
        private int currentTry = 0;
        private void Wordle_Load(object sender, EventArgs e)
        {
            int kutuBoyutu = 50;
            int aralik = 5;
            int baslangicX = 50;
            int baslangicY = 50;

            for (int satir = 0; satir < 6; satir++)
            {
                for (int sutun = 0; sutun < 5; sutun++)
                {
                    Label lbl = new Label();
                    lbl.Width = kutuBoyutu;
                    lbl.Height = kutuBoyutu;
                    lbl.Left = baslangicX + sutun * (kutuBoyutu + aralik);
                    lbl.Top = baslangicY + satir * (kutuBoyutu + aralik);
                    lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BackColor = Color.LightGray;
                    this.Controls.Add(lbl);

                    labels[satir, sutun] = lbl; // 2 boyutlu diziye kaydet
                }
            }

            LoadNewWord(); // Veritabanından rastgele kelimeyi çek
        }

        private void LoadNewWord()
        {
            currentTry = 0;
            textBox1.Enabled = true;
            button1.Enabled = true;
            textBox1.Clear();

            // Kutuları sıfırla
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    labels[i, j].Text = "";
                    labels[i, j].BackColor = Color.LightGray;
                }
            }

            // Veritabanından rastgele 5 harfli kelime al
            string connectionString = "Server=MELISA\\MSSQLSERVER01;Database=yazilim_yapimi;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 engWordName FROM Words WHERE LEN(engWordName) = 5 ORDER BY NEWID()", conn);
                var result = cmd.ExecuteScalar();
                secretWord = result != null ? result.ToString().ToUpper() : "APPLE"; // yedek kelime
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kontrol et
            string guess = textBox1.Text.Trim().ToUpper();

            if (guess.Length != 5)
            {
                MessageBox.Show("Lütfen 5 harfli bir kelime girin.");
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                labels[currentTry, i].Text = guess[i].ToString();

                if (guess[i] == secretWord[i])
                    labels[currentTry, i].BackColor = Color.Green;
                else if (secretWord.Contains(guess[i]))
                    labels[currentTry, i].BackColor = Color.Goldenrod;
                else
                    labels[currentTry, i].BackColor = Color.Gray;
            }

            if (guess == secretWord)
            {
                MessageBox.Show("🎉 Tebrikler! Doğru tahmin.");
                textBox1.Enabled = false;
                button1.Enabled = false;
                return;
            }

            currentTry++;

            if (currentTry >= 6)
            {
                MessageBox.Show("❌ Oyun bitti. Doğru kelime: " + secretWord);
                textBox1.Enabled = false;
                button1.Enabled = false;
            }

            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tekrar dene
            LoadNewWord();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
