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
        public List<Panel> torns = new List<Panel>();
        public List<Panel> elimtorn = new List<Panel>();
        public List<PictureBox> tornck = new List<PictureBox>();
        public int cantBotones = 2;
        public bool eliminar = false;
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
            btnAceptar.BackColor = Color.FromArgb(1, 110, 1);
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.Green;
        }

        private void Cancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(161,2,2);
        }

        private void Cancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Logica.addTorn(txtNombreT.Text))//, Program.frmPrincipal.frmHerrTorneo.torns.Count))
            {
                Panel torn = new Panel();
                torn.Parent = Program.frmPrincipal.SubPanelTor;
                torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                torn.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
                torn.Name = txtNombreT.Text;
                torn.Size = new System.Drawing.Size(64, 65);
                cantBotones++;
                torn.TabIndex = cantBotones;
                torns.Add(torn);

                PictureBox tornElim = new PictureBox();
                tornElim.Parent = torn;
                tornElim.Visible = false;
                tornElim.TabIndex = 1;
                tornElim.Location = new System.Drawing.Point(46, 0);
                tornElim.Size = new System.Drawing.Size(18, 18);
                tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                tornElim.Name = torn.Name + "0";
                tornck.Add(tornElim);

                /* aqui se pone el logo del deporte */
                PictureBox imgtorn = new PictureBox();
                imgtorn.Name = torn.Name + "img";
                imgtorn.Parent = torn;
                imgtorn.Visible = true;
                imgtorn.Location = new System.Drawing.Point(0, 0);
                imgtorn.Size = new System.Drawing.Size(64, 65);
                imgtorn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\ejemplo.png"));

                imgtorn.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (eliminar)
                    {
                        if (tornElim.Name.Equals(torn.Name + "0"))
                        {
                            tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            tornElim.Name = torn.Name + "1";
                            elimtorn.Add(torn);
                        }
                        else if (tornElim.Name.Equals(torn.Name + "1"))
                        {
                            tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                            tornElim.Name = torn.Name + "0";
                            elimtorn.Remove(torn);
                        }
                    }
                    else
                    {
                        Program.frmPrincipal.pnlTorneos.Visible = false;
                        Program.frmPrincipal.pnlLiga.Visible = true;
                        Program.frmPrincipal.label23.Text = "       " + torn.Name;
                        Program.frmPrincipal.TituloEqu.Text = torn.Name + " - Equipos";
                    }

                });
                txtNombreT.Text = "";
                timer2.Start();
            }
            else
            {
                MessageBox.Show("Ya existe un torneo llamado : " + txtNombreT.Text);
            }
        }
    }
}
