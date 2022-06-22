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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmHerramientas.Visible = false;
            }
            Opacity -= .2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void individualeavegris_MouseEnter(object sender, EventArgs e)
        {
            individualeavegris.Visible = false;
            individualentergris.Visible = true;
        }

        private void individualentergris_Click(object sender, EventArgs e)
        {
            Cantidad.Visible = false;
            equiposleavegris.Visible = true;
            individualenterazul.Visible = true;
            individualentergris.Visible = false;
            equiposleaveazul.Visible = false;
        }

        private void individualentergris_MouseLeave(object sender, EventArgs e)
        {
            if (individualenterazul.Visible == true)
            {
                individualenterazul.Visible = true;
                individualeavegris.Visible = false;
            }
            else if (individualenterazul.Visible == false)
            {
                individualentergris.Visible = false;
                individualeavegris.Visible = true;
            }
        }

        private void individualeaveazul_MouseEnter(object sender, EventArgs e)
        {
            individualenterazul.Visible = true;
            individualeaveazul.Visible = false;
        }

        private void individualenterazul_MouseLeave(object sender, EventArgs e)
        {
            individualeaveazul.Visible = true;
            individualenterazul.Visible = false;
        }
        private void equiposleavegris_MouseEnter(object sender, EventArgs e)
        {
            equiposentergris.Visible = true;
            equiposleavegris.Visible = false;
        }

        private void equiposentergris_MouseLeave(object sender, EventArgs e)
        {
            if (equiposenterazul.Visible == true)
            {
                equiposenterazul.Visible = true;
                equiposleavegris.Visible = false;
            }
            else if (equiposenterazul.Visible == false)
            {
                equiposentergris.Visible = false;
                equiposleavegris.Visible = true;
            }
        }

        private void equiposentergris_Click(object sender, EventArgs e)
        {
            individualeaveazul.Visible = false;
            equiposenterazul.Visible = true;
            individualeavegris.Visible = true;
            equiposentergris.Visible = false;
            Cantidad.Visible = true;
        }

        private void equiposleaveazul_MouseEnter(object sender, EventArgs e)
        {
            equiposenterazul.Visible = true;
            equiposleaveazul.Visible = false;
        }

        private void equiposenterazul_MouseLeave(object sender, EventArgs e)
        {
            equiposleaveazul.Visible = true;
            equiposenterazul.Visible = false;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Cancelar_MouseEnter(object sender, EventArgs e)
        {
            Cancelar.BackColor = Color.FromArgb(161, 2, 2);
        }

        private void Cancelar_MouseLeave(object sender, EventArgs e)
        {
            Cancelar.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void Aceptar_MouseEnter(object sender, EventArgs e)
        {
            Aceptar.BackColor = Color.FromArgb(1, 110, 1);
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            Aceptar.BackColor = Color.Green;
        }
    }
}
