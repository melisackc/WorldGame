namespace Yazilim_Yapimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load_1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ayarlar
            Settings AyarForm = new Settings();
            AyarForm.ShowDialog();
            TemaYöneticisi.TemaUygula(this); // Kullanýcý döndüðünde temayý uygula
            this.Invalidate();
            this.Refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Kelimelerim kelimelerimForm = new Kelimelerim();
            kelimelerimForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bulmaca bulmacaForm = new bulmaca();
            bulmacaForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wordle WordleForm = new Wordle();
            WordleForm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Sað panel
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Sol panel
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // sað panel labelý tarih için 
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Kelime Labelý
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Bugünün tarihini göster
            label2.Text = DateTime.Now.ToString("dd MMMM yyyy dddd");

            // Örnek kelime listesi
            string[] kelimeler = { "Plane=Uçak", "View=Manzara", "Ýnspire=Ýlham", "Future=Gelecek", "Gorgeous=Güzel" };
            int index = DateTime.Now.Day % kelimeler.Length;
            label3.Text = "Bugünün Kelimesi ==> " + kelimeler[index];

            // Günlük alýntýlar
            string[] alintilar = {
        "Azim, baþarýnýn anahtarýdýr.",
        "Bir kelime bir dünyadýr.",
        "Bugün bir adým daha ileri!",
        "Düþünmek kelimeyle baþlar.",
        "Tekrar, öðrenmenin anasýdýr."
    };
            label4.Text = alintilar[DateTime.Now.Day % alintilar.Length];

            // Tema uygulamasý
            TemaYöneticisi.TemaUygula(this);
        }


        private void label4_Click(object sender, EventArgs e)
        {
            //Günün sözü
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Geri butonu
            // Giriþ formuna dön
            LogIn girisFormu = new LogIn(); 
            girisFormu.Show();
            this.Hide(); 
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //Çýkýþ yap
            //Çýkýþ yap
            DialogResult result = MessageBox.Show("Uygulamadan çýkmak istediðinize emin misiniz?", "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
