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
        public List<Panel> depos = new List<Panel>();
        public List<Panel> elimDepos = new List<Panel>();
        public List<PictureBox> Deposck = new List<PictureBox>();
        public bool eliminar = false;
        public int cantBotones = 2;
        bool azulindividual = true;
        bool azulequipos = false;
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

        private void btnindividual_MouseEnter(object sender, EventArgs e)
        {
            if (azulindividual == false && azulequipos == true)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualentergris.png"));
            }
            else if (azulindividual == true && azulequipos == false)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualenterazul.png"));
            }
        }

        private void btnindividual_MouseLeave(object sender, EventArgs e)
        {
            if (azulindividual == false && azulequipos == true)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleavegris.png"));
            }
            else if (azulindividual == true && azulequipos == false)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleaveazul.png"));
            }
        }

        private void btnenequipos_MouseEnter(object sender, EventArgs e)
        {
            if (azulindividual == true && azulequipos == false)
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposentergris.png"));
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleaveazulentergris.png"));
            }
            else if (azulequipos == true && azulindividual == false)
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposenterazul.png"));
            } 
        }

        private void btnenequipos_MouseLeave(object sender, EventArgs e)
        {
            if (azulequipos == true && azulindividual == false)
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleaveazul.png"));
            }
            else if (azulindividual == true && azulequipos == false)
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleavegris.png"));
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleaveazul.png"));
            }
        }

        private void btnenequipos_Click(object sender, EventArgs e)
        {
            if (azulequipos == false && azulindividual == true)
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposenterazul.png"));
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleavegris.png"));
                azulequipos = true; azulindividual = false;
                grbCantidad.Visible = true;
            }    
        }

        private void btnindividual_Click(object sender, EventArgs e)
        {
            if (azulindividual == false && azulequipos == true)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualenterazul.png"));
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleavegris.png"));
                azulequipos = false; azulindividual = true;
                grbCantidad.Visible = false;
            }
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelSisPuntaje.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelSisPuntaje.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelSisPuntaje.Visible = false;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Logica.addDepo(textBox1.Text, false, 10))
            {
                Panel depo = new Panel();
                depo.Parent = Program.frmPrincipal.SubPanelDep;
                depo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                depo.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
                depo.Name = textBox1.Text;
                depo.Size = new System.Drawing.Size(64, 65);
                cantBotones++;
                depo.TabIndex = cantBotones;
                depos.Add(depo);

                PictureBox depoElim = new PictureBox();
                depoElim.Parent = depo;
                depoElim.Visible = false;
                depoElim.TabIndex = 1;
                depoElim.Location = new System.Drawing.Point(46, 0);
                depoElim.Size = new System.Drawing.Size(18, 18);
                depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                depoElim.Name = depo.Name + "0";
                Deposck.Add(depoElim);

                /* aqui se pone el logo del deporte */
                PictureBox imgDepo = new PictureBox();
                imgDepo.Name = depo.Name + "img";
                imgDepo.Parent = depo;
                imgDepo.Visible = true;
                imgDepo.Location = new System.Drawing.Point(0, 0);
                imgDepo.Size = new System.Drawing.Size(64, 65);
                imgDepo.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\ejemplo.png"));

                imgDepo.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (eliminar)
                    {
                        if (depoElim.Name.Equals(depo.Name + "0"))
                        {
                            depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            depoElim.Name = depo.Name + "1";
                            elimDepos.Add(depo);
                        }
                        else if (depoElim.Name.Equals(depo.Name + "1"))
                        {
                            depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                            depoElim.Name = depo.Name + "0";
                            elimDepos.Remove(depo);
                        }
                    }
                    else
                    {
                        Program.frmPrincipal.pnlDeportes.Visible = false;
                        Program.frmPrincipal.pnlTorneos.Visible = true;
                        Program.frmPrincipal.TituloTor.Text = "       " + depo.Name + " - Torneos";
                    }

                });
                textBox1.Text = "";
                timer2.Start();
            }
            else
            {
                MessageBox.Show("Ya existe un deporte llamado : "+textBox1.Text);
            }
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
