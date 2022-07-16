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
        List<Panel> depos = new List<Panel>();
        int cantBotones = 3;
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
            Panel depo = new Panel();
            depo.Parent = Program.frmPrincipal.SubPanelDep;
            depo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            depo.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
            depo.Name = textBox1.Text;
            depo.Size = new System.Drawing.Size(64, 65);
            cantBotones++;
            depo.TabIndex = cantBotones;
            depos.Add(depo);
            Label txt = new Label();
            txt.Parent = depo;
            txt.Visible = true;
            txt.Text = depo.Name;
            depo.Click += new EventHandler(delegate (Object s, EventArgs exde) {
                Program.frmPrincipal.pnlDeportes.Visible = false;
                Program.frmPrincipal.pnlTorneos.Visible = true;
                Program.frmPrincipal.TituloEqu.Text = "       "+depo.Name+ " - Equipo";
                Program.frmPrincipal.TituloTor.Text = "       " + depo.Name + " - Torneos";
            });
            textBox1.Text = "";
            timer2.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
