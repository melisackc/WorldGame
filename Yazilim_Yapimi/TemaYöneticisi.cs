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
        }

        
            public static string SeciliTema { get; set; } = "Açık Tema";

        public static void TemaUygula(Form form)
        {
            if (SeciliTema == "Koyu Tema")
            {
                form.BackColor = Color.FromArgb(30, 30, 30);
                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Label || ctrl is Button || ctrl is RadioButton)
                    {
                        ctrl.ForeColor = Color.White;
                        ctrl.BackColor = Color.FromArgb(50, 50, 50);
                    }
                    else
                    {
                        ctrl.ForeColor = Color.White;
                        ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    }
                }
            }
            else // Açık Tema
            {
                form.BackColor = SystemColors.Control;
                foreach (Control ctrl in form.Controls)
                {
                    ctrl.ForeColor = Color.Black;
                    ctrl.BackColor = SystemColors.Control;
                }
            }
        }
    }

}
