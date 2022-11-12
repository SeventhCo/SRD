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
    public partial class HerramientasEquipos : Form
    {
        public HerramientasEquipos()
        {
            InitializeComponent();
        }
        public void actualizar()
        {
            Idioma.controles(pnlSubHerrEquipos);
            Idioma.controles(pnlNombreE);
            Idioma.controles(panel8);
            Idioma.controles(panel9);
            Idioma.controles(pnlHerrEquipos);
            Idioma.controles(pnlLogo);

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

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (pictureBox3.Image.Size.Width + pictureBox3.Image.Size.Height > 256)
            {
                MessageBox.Show("Su imagen es demasiado grande, puede causar inconvenientes tanto en memoria como red, por favor reduzca su altura y anchura en píxeles, tal que su suma sea 256px o menor, esto no disminuirá la calidad, debido a que la imagen que se muestra tendrá 64x64 px, mayores resoluciones serán imperceptibles");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Ingrese un deporte");
            }
            else if (Logica.addEqui(txtNombreE.Text, textBox3.Text,pictureBox3.Image,comboBox3.Text))
            {
                textBox3.Text = "";
                txtNombreE.Text = "";
                this.Visible = false;
                Program.Blank.frmPrincipal.Enabled = true;
                Program.Blank.frmPrincipal.cargaEqui();
            }
            else
            {
                MessageBox.Show("Ya existe un equipo llamado : " + txtNombreE.Text);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmPrincipal.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox3.Text.Length + " / 12";
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 13) label5.ForeColor = Color.Green;
            else label5.ForeColor = Color.Red;
        }

        private void pnlHerrEquipos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            dynamic[,] var = Logica.consulta("SELECT nombreDep FROM deporte");
            if (var != null)
            {
                for (int i = 0; i < Logica.consultaMaxIndex("SELECT nombreDep FROM deporte"); i++)
                {
                    comboBox3.Items.Add(var[0, i]);
                }
            }
        }
    }
}
