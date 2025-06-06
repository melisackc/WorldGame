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


namespace veriYapi
{
    public partial class Form2 : Form
    {
        string baglantiCumlesi = "Server=DESKTOP-7VKKIA1\\SQLEXPRESS;Database=veriYapi;Trusted_Connection=True;";
        public int CurrentUserID { get; set; }

        public Form2(int gelenUserID)
        {
            InitializeComponent();
            this.CurrentUserID = gelenUserID;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ucRaporlama ucRaporlama = new ucRaporlama(CurrentUserID);
            ucRaporlama.Dock = DockStyle.Fill; // UserControl'ün formu doldurmasını sağlar
            this.Controls.Add(ucRaporlama); // UserControl'ü formun Controls koleksiyonuna ekler

        }


    }
}
