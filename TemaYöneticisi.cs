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
    public partial class TemaYöneticisi : Form
    {
        public TemaYöneticisi()
        {
            InitializeComponent();
            this.Load += TemaYöneticisi_Load;
        }

        private void TemaYöneticisi_Load(object sender, EventArgs e)
        {
            TemaUygula(this);  // Form açılırken temayı uygula
        }


        public static string SeciliTema { get; set; } = "Açık Tema";

        public static void TemaUygula(Control parent)
        {
            Color backColor, foreColor;

            if (SeciliTema == "Koyu Tema")
            {
                backColor = Color.FromArgb(30, 30, 30);
                foreColor = Color.White;
            }
            else
            {
                backColor = SystemColors.Control;
                foreColor = Color.Black;
            }

            // Sadece formun arka planını değiştir
            if (parent is Form)
            {
                parent.BackColor = backColor;
            }

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Label || ctrl is Button || ctrl is RadioButton || ctrl is CheckBox)
                {
                    ctrl.ForeColor = foreColor;
                    ctrl.BackColor = backColor == SystemColors.Control ? SystemColors.Control : Color.FromArgb(50, 50, 50);
                }
                else if (ctrl is Panel || ctrl is GroupBox)
                {
                    ctrl.BackColor = backColor; // Panel ve GroupBox arka planını tema rengine göre ayarla
                }

                // Recursive çağrı ile iç kontrolleri de tema uygula
                TemaUygula(ctrl);
            }
        }


    }

}
