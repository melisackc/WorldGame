using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace Yazilim_Yapimi
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Kullanıcı Adı 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Şifre
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Şifre tekrar
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kayıt ol butonu

            // Tüm alanların dolu olup olmadığını kontrol et
            if (
            string.IsNullOrWhiteSpace(textBox1.Text) ||  // Kullanıcı adı
            string.IsNullOrWhiteSpace(textBox2.Text) ||  // Şifre
            string.IsNullOrWhiteSpace(textBox3.Text))  // Şifre tekrar

            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kullanıcı adı uzunluğu kontrolü
            if (textBox1.Text.Length < 6 || textBox1.Text.Length > 15)
            {
                MessageBox.Show("Kullanıcı ad 6 ile 15 karakter arasında olmalıdır!", "Geçersiz İsim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifrelerin eşleşip eşleşmediğini kontrol et
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor! Lütfen aynı şifreyi iki kez giriniz.", "Şifre Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            // Bağlantı cümlesi: Sunucu ve veritabanı adını kendi ayarlarına göre düzenle
            string connectionString = "Server=MELISA\\MSSQLSERVER01;Database=yazilim_yapimi;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (userName, password) VALUES (@kullaniciAdi, @sifre)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@sifre", sifre); // Güvenlik için hash önerilir

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Geri butonu 
            // Giriş formuna dön
            LogIn girisFormu = new LogIn(); // Giriş formunun adı Giris ise
            girisFormu.Show();
            this.Hide(); // Kayıt formunu gizle
        }
    }
}