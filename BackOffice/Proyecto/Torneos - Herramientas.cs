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
        public FormHerramientas()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
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
            if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (Logica.addTorn(txtNombreT.Text, textBox3.Text,3,true,"a", pictureBox3.Image, "asa",true))
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
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox3.Text.Length+" / 12";
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 13) label5.ForeColor = Color.Green;
            else label5.ForeColor = Color.Red;
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
    }
}
