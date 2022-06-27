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
    public partial class HerramientasEquipos : Form
    {
        List<Panel> equis = new List<Panel>();
        int cantBotones = 3;
        public HerramientasEquipos()
        {
            InitializeComponent();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmHerrEquipos.Visible = false;
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

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Panel equi = new Panel();
            equi.Parent = Program.frmPrincipal.SubPanelEqu;
            equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            equi.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
            equi.Name = textBox1.Text;
            equi.Size = new System.Drawing.Size(64, 65);
            cantBotones++;
            equi.TabIndex = cantBotones;
            equis.Add(equi);
            Label txt = new Label();
            txt.Parent = equi;
            txt.Visible = true;
            txt.Text = equi.Name;
            equi.Click += new EventHandler(delegate (Object s, EventArgs exde) {
                Program.frmPrincipal.pnlEquipos.Visible = false;
                Program.frmPrincipal.pnlEquEquipos.Visible = true;
                Program.frmPrincipal.label13.Text = equi.Name;
            });
            textBox1.Text = "";
            timer2.Start();
        }
    }
}
