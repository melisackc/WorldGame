using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazilim_Yapimi
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kelime Ekleme
            KelimeEkleme EkleForm = new KelimeEkleme();
            EkleForm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tema Ayarları

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kelime Sıklığı
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TemaYöneticisi.SeciliTema = "Açık Tema";
                TemaYöneticisi.TemaUygula(this); // Temayı anında uygula
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                TemaYöneticisi.SeciliTema = "Koyu Tema";
                TemaYöneticisi.TemaUygula(this); // Temayı anında uygula
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Geri butonu
            this.Close(); // Ayarlar formunu kapatır
        }
    }
}
