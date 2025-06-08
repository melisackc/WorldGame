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
    public partial class LogIn : Form
    {
        public LogIn()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sifre = textBox2.Text.Trim();
            string kullaniciAdi = textBox1.Text.Trim();

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi doldurun.");
                return;
            }

            if (kullaniciAdi.Length < 6 || kullaniciAdi.Length > 15)
            {
                MessageBox.Show("Kullanıcı adı 6 ile 15 karakter arasında olmalıdır.");
                return;
            }

            if (sifre.Length < 6 || sifre.Length > 10)
            {
                MessageBox.Show("Şifre 6 ile 10 karakter arasında olmalıdır.");
                return;
            }

            string connectionString = "Data Source=MELISA\\MSSQLSERVER01;Initial Catalog=yazilim_yapimi;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE userName = @userName AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userName", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@password", sifre);

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        Form1 anaForm = new Form1();
                        anaForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }




        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Şifremi unuttum linki
            SifremiUnuttum sifirlaFormu = new SifremiUnuttum();
            sifirlaFormu.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kayıt ol butonu
            Kayıt kayitOlFormu = new Kayıt();
            kayitOlFormu.Show(); // veya ShowDialog() kullanabilirsin

            // İstersen Form1'i gizleyebilirsin:
            this.Hide();
        }
    }
}
