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
using System.IO;




namespace Yazilim_Yapimi
{



    public partial class Kelimelerim : Form
    {

        List<Word> words = new List<Word>();

        int currentIndex = 0;
        public Kelimelerim()
        {
            InitializeComponent();
        }

        private void LoadWordsFromDatabase()
        {
            string connStr = "Data Source=MELISA\\MSSQLSERVER01;Initial Catalog=yazilim_yapimi;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Tüm kelimeleri getir
                string wordQuery = "SELECT wordID, engWordName, turWordName, picturePath FROM Words";
                SqlCommand cmdWords = new SqlCommand(wordQuery, conn);
                SqlDataReader reader = cmdWords.ExecuteReader();

                Dictionary<int, Word> wordMap = new Dictionary<int, Word>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["wordID"]);
                    wordMap[id] = new Word
                    {
                        Eng = reader["engWordName"].ToString(),
                        Tr = reader["turWordName"].ToString(),
                        PicturePath = reader["picturePath"].ToString()
                    };
                }

                reader.Close();

                // Örnek cümleleri getir
                string sampleQuery = "SELECT wordID, samples FROM WordSamples ORDER BY wordSamplesID";
                SqlCommand cmdSamples = new SqlCommand(sampleQuery, conn);
                SqlDataReader reader2 = cmdSamples.ExecuteReader();

                Dictionary<int, List<string>> sampleMap = new Dictionary<int, List<string>>();

                while (reader2.Read())
                {
                    int wordID = Convert.ToInt32(reader2["wordID"]);
                    string sample = reader2["samples"].ToString();

                    if (!sampleMap.ContainsKey(wordID))
                        sampleMap[wordID] = new List<string>();

                    sampleMap[wordID].Add(sample);
                }

                reader2.Close();

                // Cümleleri word nesnesine yerleştir
                foreach (var pair in wordMap)
                {
                    int wordID = pair.Key;
                    Word word = pair.Value;

                    if (sampleMap.ContainsKey(wordID))
                    {
                        var samples = sampleMap[wordID];

                        word.EngSentence1 = samples.Count > 0 ? samples[0] : "";
                        word.TrSentence1 = samples.Count > 1 ? samples[1] : "";
                        word.EngSentence2 = samples.Count > 2 ? samples[2] : "";
                        word.TrSentence2 = samples.Count > 3 ? samples[3] : "";
                    }

                    words.Add(word);
                }
            }
        }



        private void Kelimelerim_Load(object sender, EventArgs e)
        {
            LoadWordsFromDatabase(); // Veritabanından kelimeleri çek
            if (words.Count > 0)
            {
                ShowWord(currentIndex); // İlk kelimeyi göster
            }
            else
            {
                MessageBox.Show("Henüz eklenmiş kelime bulunamadı.");
            }
        }

        private void ShowWord(int index)
        {
            if (index >= 0 && index < words.Count)
            {
                Word word = words[index];

                textBox1.Text = word.Eng;
                textBox2.Text = word.Tr;
                textBox3.Text = word.EngSentence1;
                textBox4.Text = word.TrSentence1;
                textBox5.Text = word.EngSentence2;
                textBox6.Text = word.TrSentence2;

                if (!string.IsNullOrEmpty(word.PicturePath) && File.Exists(word.PicturePath))
                {
                    pictureBox1.Image = Image.FromFile(word.PicturePath);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //picture box 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //kelimenin ingilizcesi
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //kelimenin türkçesi
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //ingilizce cümle
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Türkçe cümle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //önceki butonu
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowWord(currentIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sonraki butonu
            if (currentIndex < words.Count - 1)
            {
                currentIndex++;
                ShowWord(currentIndex);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //2. cümle
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Türkçesi
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }


    class Word
    {
        public string Eng { get; set; }
        public string Tr { get; set; }
        public string PicturePath { get; set; }

        public string EngSentence1 { get; set; }
        public string TrSentence1 { get; set; }
        public string EngSentence2 { get; set; }
        public string TrSentence2 { get; set; }
    }




}
