using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FormHerramientas : Form
    {
        public FormHerramientas()
        {
            InitializeComponent();
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmHerrTorneo.Visible = false;
            }
            Opacity -= .2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Aceptar_MouseEnter(object sender, EventArgs e)
        {
            Aceptar.BackColor = Color.FromArgb(1, 110, 1);
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            Aceptar.BackColor = Color.Green;
        }

        private void Cancelar_MouseEnter(object sender, EventArgs e)
        {
            Cancelar.BackColor = Color.FromArgb(161,2,2);
        }

        private void Cancelar_MouseLeave(object sender, EventArgs e)
        {
            Cancelar.BackColor = Color.FromArgb(192, 0, 0);
        }
    }
}
