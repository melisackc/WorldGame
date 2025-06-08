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
    public partial class KelimeEkleme : Form
    {

        private string savedImagePath = null;

        // Resimlerin kaydedileceği klasör (İstersen değiştirebilirsin)
        private string imageFolder = @"C:\\Users\\kinay\\OneDrive\\Desktop\\Y.YapımıFoto";
        public KelimeEkleme()
        {
            InitializeComponent();
        }

        private void KelimeEkleme_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kelime ekleme butonu

            string eng = textBox1.Text.Trim();
            string tr = textBox2.Text.Trim();
            string engSample = textBox3.Text.Trim();
            string trSample = textBox4.Text.Trim();
            string engSample2 = textBox5.Text.Trim();
            string trSample2 = textBox6.Text.Trim();


            if (string.IsNullOrEmpty(eng) || string.IsNullOrEmpty(tr))
            {
                MessageBox.Show("İngilizce ve Türkçe kelime boş olamaz.");
                return;
            }



            string connectionString = "Data Source=MELISA\\MSSQLSERVER01;Initial Catalog=yazilim_yapimi;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Words tablosuna ekle, picturePath olarak klasördeki yolu gönder
                    string insertWordQuery = @"
                        INSERT INTO Words (engWordName, turWordName, picturePath) 
                        VALUES (@eng, @tr, @pic);
                        SELECT SCOPE_IDENTITY();
                    ";
                    SqlCommand cmdWord = new SqlCommand(insertWordQuery, connection, transaction);
                    cmdWord.Parameters.AddWithValue("@eng", eng);
                    cmdWord.Parameters.AddWithValue("@tr", tr);
                    cmdWord.Parameters.AddWithValue("@pic", savedImagePath ?? (object)DBNull.Value);

                    int newWordID = Convert.ToInt32(cmdWord.ExecuteScalar());

                    // WordSamples tablosuna örnekler ekle
                    string insertSampleQuery = "INSERT INTO WordSamples (wordID, samples) VALUES (@wordID, @sample)";

                    SqlCommand cmdSample1 = new SqlCommand(insertSampleQuery, connection, transaction);
                    cmdSample1.Parameters.AddWithValue("@wordID", newWordID);
                    cmdSample1.Parameters.AddWithValue("@sample", engSample);
                    cmdSample1.ExecuteNonQuery();

                    SqlCommand cmdSample2 = new SqlCommand(insertSampleQuery, connection, transaction);
                    cmdSample2.Parameters.AddWithValue("@wordID", newWordID);
                    cmdSample2.Parameters.AddWithValue("@sample", trSample);
                    cmdSample2.ExecuteNonQuery();

                    // 2. örnek cümleleri ekle
                    if (!string.IsNullOrEmpty(engSample2))
                    {
                        SqlCommand cmdSample3 = new SqlCommand(insertSampleQuery, connection, transaction);
                        cmdSample3.Parameters.AddWithValue("@wordID", newWordID);
                        cmdSample3.Parameters.AddWithValue("@sample", engSample2);
                        cmdSample3.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(trSample2))
                    {
                        SqlCommand cmdSample4 = new SqlCommand(insertSampleQuery, connection, transaction);
                        cmdSample4.Parameters.AddWithValue("@wordID", newWordID);
                        cmdSample4.Parameters.AddWithValue("@sample", trSample2);
                        cmdSample4.ExecuteNonQuery();
                    }


                    transaction.Commit();
                    MessageBox.Show("Kelime ve örnekler başarıyla eklendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
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
            //cümlenin türkçesi
        }

        string selectedImagePath = "";
        private void button1_Click(object sender, EventArgs e)
        {

            // Fotoğraf seçme butonu
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Bir fotoğraf seçiniz";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Klasör yoksa oluştur
                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }
                    selectedImagePath = ofd.FileName;

                    string fileName = Path.GetFileName(selectedImagePath);
                    string targetPath = Path.Combine(imageFolder, fileName);




                    // Aynı isimde dosya varsa benzersiz isim oluştur
                    if (File.Exists(targetPath))
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath);
                        targetPath = Path.Combine(imageFolder, uniqueFileName);
                    }

                    // Dosyayı klasöre kopyala
                    File.Copy(selectedImagePath, targetPath);

                    // PictureBox'a göster
                    pictureBox1.Image = Image.FromFile(targetPath);

                    // Veritabanına kaydetmek için yolu sakla
                    savedImagePath = targetPath;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // 2. ingilizce cümle
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
}
