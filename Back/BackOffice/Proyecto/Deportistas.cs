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
    public partial class Deportistas : Form
    {
        public Deportistas()
        {
            InitializeComponent();
            Deportes();
            pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));

        }
        public void Deportes()
        {
            cbDeporte.Items.Clear();
            dynamic[,] variable = Logica.consulta("Select nombreDep from deporte ");
            if (variable != null)
            {
                for (int i = 0; i < variable.Length; i++)
                {
                    cbDeporte.Items.Add(variable[0, i]);
                }
            }
        }

        private void pnlHerrEquipos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEquipo.Items.Clear();
            dynamic[,] datosDeporte = Logica.consulta("Select nombreEqu from equipo WHERE NombreDep = '" + cbDeporte.SelectedItem.ToString() + "'");
            if (datosDeporte != null)
            {
                for (int j = 0; j < datosDeporte.Length; j++)
                {
                    cbEquipo.Items.Add(datosDeporte[0, j]);
                }
            }

        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmPrincipal.Enabled = true;
        }
        public void actualizar()
        {
            Idioma.controles(pnlNombreE);
            Idioma.controles(panel8);
            Idioma.controles(panel12);
            Idioma.controles(panel7);
            Idioma.controles(panel16);
            Idioma.controles(panel2);
            Idioma.controles(panel9);
            Idioma.controles(pnlLogo);
            Idioma.controles(pnlHerrEquipos);
            Idioma.controles(pnlSubHerrEquipos);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (pictureBox3.Image.Size.Width + pictureBox3.Image.Size.Height > 256)
            {
                MessageBox.Show("Su imagen es demasiado grande, puede causar inconvenientes tanto en memoria como red, por favor reduzca su altura y anchura en píxeles, tal que su suma sea 256px o menor, esto no disminuirá la calidad, debido a que la imagen que se muestra tendrá 64x64 px, mayores resoluciones serán imperceptibles");
            }
            else if (cbDeporte.Text == "")
            {
                MessageBox.Show("Ingrese un Deporte");
            }
            else if (cbEquipo.Text == "")
            {
                MessageBox.Show("Ingrese un Equipo");
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el Nombre");
            }
            else if (txtEdad.Text == "")
            {
                MessageBox.Show("Ingrese la Edad");
            }
            else if (txtCi.Text == "")
            {
                MessageBox.Show("Ingrese el Documento de Identidad");
            }
            else if (numero.Text == "")
            {
                MessageBox.Show("Ingrese el Numero");
            }
            else if (txtAltura.Text == "")
            {
                MessageBox.Show("Ingrese la Altura");
            }
            else if (txtCi.ForeColor == Color.Red)
            {
                MessageBox.Show("Ingrese un documento Numerico");
            }
            else if (txtEdad.ForeColor == Color.Red)
            {
                MessageBox.Show("Ingrese una Edad Numerica");
            }
            else if (Logica.addDeportista(txtCi.Text,txtNombre.Text,txtEdad.Text,txtAltura.Text,numero.Text,cbEquipo.Text,pictureBox3.Image))
            {
                this.Visible = false;
                Program.Blank.frmPrincipal.Enabled = true;
                Program.Blank.frmPrincipal.cargaDeport();
            }
            else
            {
                MessageBox.Show("Ya existe este deportista o numero dentro del equipo");
            }
        }
        
        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtEdad.Text, out int a))
            {
                txtEdad.ForeColor = SystemColors.Menu;
            }
            else
            {
                txtEdad.ForeColor = Color.Red;
            }
        }

        private void txtCi_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtCi.Text,out int a))
            {
                txtCi.ForeColor = SystemColors.Menu;
            }
            else
            {
                txtCi.ForeColor = Color.Red;
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
    }

}
