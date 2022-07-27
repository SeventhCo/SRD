using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form4 : Form
    {
        
        bool azulindividual = true;
        bool azulequipos = false;
        public Form4()
        {
            InitializeComponent();
        }
        
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmPrincipal.Enabled = true;
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
                //grbCantidad.Visible = true;
            }    
        }

        private void btnindividual_Click(object sender, EventArgs e)
        {
            if (azulindividual == false && azulequipos == true)
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualenterazul.png"));
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleavegris.png"));
                azulequipos = false; azulindividual = true;
                //grbCantidad.Visible = false;
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if(Logica.addDepo(textBox1.Text,textBox3.Text, false, 10,pictureBox3.Image))
            {
                textBox3.Text = "";
                textBox1.Text = "";
                this.Visible = false;
                Program.Blank.frmPrincipal.Enabled = true;
                Program.Blank.frmPrincipal.cargaDepo();
            }
            else
            {
                MessageBox.Show("Ya existe un deporte llamado : "+textBox1.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox3.Text.Length + " / 12";
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 13) label5.ForeColor = Color.Green;
            else label5.ForeColor = Color.Red;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
        }
    }
}
