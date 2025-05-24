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
            //basýldýðýnda KelimeEkleme formunu aç

            KelimeEkleme kelimeEklemeForm = new KelimeEkleme();
            kelimeEklemeForm.ShowDialog();  // Modal þekilde açar, istersen Show() da kullanabilirsin


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
    }
}
