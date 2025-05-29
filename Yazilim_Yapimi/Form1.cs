namespace Yazilim_Yapimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //hafýza çivisi
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ayarlar
            Settings AyarForm = new Settings();
            AyarForm.ShowDialog();

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

            // Günü baz alarak döngüsel kelime seç (bugünün gününe göre deðiþir)
            int index = DateTime.Now.Day % kelimeler.Length;

            label3.Text = "Bugünün Kelimesi==> " + kelimeler[index];

            string[] alintilar = {
  "Azim, baþarýnýn anahtarýdýr.",
  "Bir kelime bir dünyadýr.",
  "Bugün bir adým daha ileri!",
  "Düþünmek kelimeyle baþlar.",
  "Tekrar, öðrenmenin anasýdýr."
};
            label4.Text = alintilar[DateTime.Now.Day % alintilar.Length];

            


        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Günün sözü
        }
    }
}
