using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FormHerramientas : Form
    {
        bool inter1 = true;
        bool inter2 = true;
        bool inter3 = true;
        public FormHerramientas()
        {
            InitializeComponent();
        }
        

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif" ;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
        }

        private void btnInternacional_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNacional_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNacional_Click_1(object sender, EventArgs e)
        {
            if (inter3)
            {
                btnNacional3.FlatAppearance.BorderSize = 2;
                btnNacional3.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnNacional3.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter3 = false;
                btnInternacional3.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnInternacional3.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnNacional1_Click(object sender, EventArgs e)
        {
            if (inter1)
            {
                btnNacional1.FlatAppearance.BorderSize = 2;
                btnNacional1.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnNacional1.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter1 = false;
                btnInternacional1.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnInternacional1.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnNacional2_Click(object sender, EventArgs e)
        {
            if (inter2)
            {
                btnNacional2.FlatAppearance.BorderSize = 2;
                btnNacional2.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnNacional2.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter2 = false;
                btnInternacional2.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnInternacional2.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnInternacional2_Click(object sender, EventArgs e)
        {
            if (!inter2)
            {
                btnInternacional2.FlatAppearance.BorderSize = 2;
                btnInternacional2.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnInternacional2.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter2 = true;
                btnNacional2.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnNacional2.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnInternacional3_Click(object sender, EventArgs e)
        {
            if (!inter3)
            {
                btnInternacional3.FlatAppearance.BorderSize = 2;
                btnInternacional3.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnInternacional3.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter3 = true;
                btnNacional3.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnNacional3.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnInternacional1_Click(object sender, EventArgs e)
        {
            if (!inter1)
            {
                btnInternacional1.FlatAppearance.BorderSize = 2;
                btnInternacional1.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnInternacional1.BackColor = Color.FromArgb(255, 1, 30, 44);
                inter1 = true;
                btnNacional1.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnNacional1.FlatAppearance.BorderSize = 0;
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == -1)
            {
                pnlCopa.Visible = false;
                pnlLiga.Visible = false;
                pnlDobleEliminacion.Visible = false;
            }
            else if (cboTipo.SelectedIndex == 0)
            {
                pnlLiga.Visible = true;
                pnlCopa.Visible = false;
                pnlDobleEliminacion.Visible = false;
            }
            else if (cboTipo.SelectedIndex == 1)
            {
                pnlCopa.Visible = true;
                pnlLiga.Visible = false;
                pnlDobleEliminacion.Visible = false;
            }
            else if (cboTipo.SelectedIndex == 2)
            {
                pnlDobleEliminacion.Visible = true;
                pnlCopa.Visible = false;
                pnlLiga.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /* if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (Logica.addTorn(txtNombreT.Text, textBox3.Text,inter,txtTrofeo.Text, pictureBox3.Image,0,comboBox1.Text))
            {
                textBox3.Text = "";
                txtNombreT.Text = "";
                this.Visible = false;
                Program.Blank.frmPrincipal.Enabled = true;
                Program.Blank.frmPrincipal.cargaTorn();
            }

            else
            {
                MessageBox.Show("Ya existe un Torneo llamado : " + txtNombreT.Text);
            } */
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }
    }
}
