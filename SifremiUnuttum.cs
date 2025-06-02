using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.ConstrainedExecution;


namespace Yazilim_Yapimi
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Kullanıcı ad girilir
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Lütfen kullanıcı adını giriniz.");
                return;
            }

            string yeniSifre = RastgeleSifreOlustur();
            string connectionString = "Server=MELISA\\MSSQLSERVER01;Database=yazilim_yapimi;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kullanıcı var mı kontrol et
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE userName = @userName", conn);
                cmd.Parameters.AddWithValue("@userName", kullaniciAdi);

                int kullaniciVarMi = (int)cmd.ExecuteScalar();

                if (kullaniciVarMi > 0)
                {
                    // Şifreyi güncelle
                    SqlCommand updateCmd = new SqlCommand("UPDATE Users SET password = @password WHERE userName = @userName", conn);
                    updateCmd.Parameters.AddWithValue("@password", yeniSifre);
                    updateCmd.Parameters.AddWithValue("@userName", kullaniciAdi);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Yeni şifreniz: " + yeniSifre, "Şifre Sıfırlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private string RastgeleSifreOlustur()
        {
            string karakterler = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            return new string(Enumerable.Repeat(karakterler, 8)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
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
