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
        public List<Panel> equis = new List<Panel>();
        public List<Panel> elimEqui = new List<Panel>();
        public List<PictureBox> Equick = new List<PictureBox>();
        public int cantBotones = 2;
        public bool eliminar = false;
        public HerramientasEquipos()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(161, 2, 2);
        }

        private void Cancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void Aceptar_MouseEnter(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(1, 110, 1);
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.Green;
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
            if (Logica.addEqui(txtNombreE.Text, false, 10))
            {
                Panel equi = new Panel();
                equi.Parent = Program.frmPrincipal.SubPanelEqu;
                equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                equi.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
                equi.Name = txtNombreE.Text;
                equi.Size = new System.Drawing.Size(64, 65);
                cantBotones++;
                equi.TabIndex = cantBotones;
                equis.Add(equi);

                PictureBox equiElim = new PictureBox();
                equiElim.Parent = equi;
                equiElim.Visible = false;
                equiElim.TabIndex = 1;
                equiElim.Location = new System.Drawing.Point(46, 0);
                equiElim.Size = new System.Drawing.Size(18, 18);
                equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                equiElim.Name = equi.Name + "0";
                Equick.Add(equiElim);

                /* aqui se pone el logo del deporte */
                PictureBox imgequi = new PictureBox();
                imgequi.Name = equi.Name + "img";
                imgequi.Parent = equi;
                imgequi.Visible = true;
                imgequi.Location = new System.Drawing.Point(0, 0);
                imgequi.Size = new System.Drawing.Size(64, 65);
                imgequi.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\ejemplo.png"));

                imgequi.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (eliminar)
                    {
                        if (equiElim.Name.Equals(equi.Name + "0"))
                        {
                            equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equiElim.Name = equi.Name + "1";
                            elimEqui.Add(equi);
                        }
                        else if (equiElim.Name.Equals(equi.Name + "1"))
                        {
                            equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                            equiElim.Name = equi.Name + "0";
                            elimEqui.Remove(equi);
                        }
                    }
                    else
                    {
                        Program.frmPrincipal.pnlEquipos.Visible = false;
                        Program.frmPrincipal.pnlEquEquipos.Visible = true;
                        Program.frmPrincipal.label13.Text = "       " + equi.Name + " - Equipo";
                    }

                });
                txtNombreE.Text = "";
                timer2.Start();
            }
            else
            {
                MessageBox.Show("Ya existe un equipo llamado : " + txtNombreE.Text);
            }
        }
    }
}
