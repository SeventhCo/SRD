using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form4 : Form
    {
        int depos = 0;
        int equipos = 0;
        bool azulindividual = true;
        bool azulequipos = false;
        public Form4()
        {
            InitializeComponent();
            depos = Logica.consultaMaxIndex("select nombreDep from deporte");
            equipos = Logica.consultaMaxIndex("select nombreDep from equipo");
        }
        
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmPrincipal.Enabled = true;
            if (depos != Logica.consultaMaxIndex("select nombreDep from deporte"))
            {
                Program.Blank.frmPrincipal.cargaDepo();
            }
            if (equipos != Logica.consultaMaxIndex("select nombreDep from equipo"))
            {
                Program.Blank.frmPrincipal.cargaEqui();
            }
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
            if (azulequipos == false && azulindividual == true && textBox2.Text != "1")
            {
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposenterazul.png"));
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleavegris.png"));
                azulequipos = true; azulindividual = false;
                //grbCantidad.Visible = true;
            }    
        }

        private void btnindividual_Click(object sender, EventArgs e)
        {
            if (azulindividual == false && azulequipos == true && textBox2.Text == "1")
            {
                btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualenterazul.png"));
                btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleavegris.png"));
                azulequipos = false; azulindividual = true;
                //grbCantidad.Visible = false;
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            int titulares;
            int equipos;

            if (textBox1.Text.Equals("") || textBox3.Text.Equals("") || textBox2.Text.Equals("") || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos");
            }
            else if (Convert.ToBase64String(Logica.conImgByte(pictureBox3.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (pictureBox3.Image.Size.Width + pictureBox3.Image.Size.Height > 256)
            {
                MessageBox.Show("Su imagen es demasiado grande, puede causar inconvenientes tanto en memoria como red, por favor reduzca su altura y anchura en píxeles, tal que su suma sea 256px o menor, esto no disminuirá la calidad, debido a que la imagen que se muestra tendrá 64x64 px, mayores resoluciones serán imperceptibles");
            }
            else if (int.TryParse(textBox2.Text,out titulares))
            {
                if(textBox4.Text == "1" || textBox4.Text == "0")
                {
                    MessageBox.Show("El campo de Equipos/Enfrentamiento debe ser numerico y mayor a 1");
                }
                else if (int.TryParse(textBox4.Text, out equipos))
                {
                    if (Logica.addDepo(comboBox3.Text, textBox1.Text, textBox3.Text, azulindividual, titulares, pictureBox3.Image,equipos))
                    {
                        textBox3.Text = "";
                        textBox1.Text = "";
                        this.Visible = false;
                        Program.Blank.frmPrincipal.Enabled = true;
                        Program.Blank.frmPrincipal.cargaDepo();
                        if (equipos != Logica.consultaMaxIndex("select nombreDep from equipo"))
                        {
                            Program.Blank.frmPrincipal.cargaEqui();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un deporte llamado : " + textBox1.Text);
                    }
                }
            
                else
                {
                    MessageBox.Show("El campo de Equipos/Enfrentamiento debe ser numerico");
                }
            }
            else
            {
                MessageBox.Show("El campo Titulares debe ser numerico");
            }
            
        }

        public void actualizar()
        {
            Idioma.controles(pnlNomDep);
            Idioma.controles(pnlNombreCorto);
            Idioma.controles(pnlEquiposEnfr);
            Idioma.controles(pnlCantTit);
            Idioma.controles(pnlSistema);
            Idioma.controles(pnlLogo);
            Idioma.controles(pnlSubHerrDep);
            Idioma.controles(pnlDepHerr);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Program.Blank.frmPunt.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label8.Text = textBox1.Text.Length + " / 20";
            if (textBox1.Text.Length > 0 && textBox1.Text.Length < 21) label8.ForeColor = Color.Green;
            else label8.ForeColor = Color.Red;
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Equals(""))
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool seguro = true;

            int deportes = Logica.consultaMaxIndex("select sisPuntaje from deporte where sisPuntaje = '" + comboBox3.Text + "'");
            if (deportes > 1)
            {
                int equipos = Logica.consultaMaxIndex("select sisPuntaje from deporte, equipo where equipo.nombreDep = deporte.nombreDep and sisPuntaje = '" + comboBox3.Text + "'");
                if (equipos > 1)
                {
                    if (MessageBox.Show("Esta accion borrara " + deportes + " deportes y " + equipos + " equipos, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        seguro = false;
                    }
                }
                else if (equipos == 1)
                {
                    if (MessageBox.Show("Esta accion borrara " + deportes + " deportes y " + equipos + " equipo, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        seguro = false;
                    }
                }
                else
                {
                    if(MessageBox.Show("Esta accion borrara " + deportes + " deportes, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        MessageBox.Show("Cancelo");
                    }
                }
            }
            else if (deportes == 1)
            {
                int equipos = Logica.consultaMaxIndex("select sisPuntaje from deporte, equipo where equipo.nombreDep = deporte.nombreDep and sisPuntaje = '" + comboBox3.Text + "'");
                if (equipos > 1)
                {
                    if (MessageBox.Show("Esta accion borrara " + deportes + " deporte y " + equipos + " equipos, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        seguro = false;
                    }
                }
                else if (equipos == 1)
                {
                    if (MessageBox.Show("Esta accion borrara " + deportes + " deporte y " + equipos + " equipo, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        seguro = false;
                    }
                }
                else
                {
                    if (MessageBox.Show("Esta accion borrara " + deportes + " deporte, esta seguro que desea continuar?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        MessageBox.Show("Cancelo");
                    }
                }
            }

            if (seguro)
            {
                Logica.comando("DELETE FROM sistema WHERE (nombre = '" + comboBox3.Text + "')");
                comboBox3.Items.Remove(comboBox3.Text);
                comboBox3.SelectedIndex = -1;
            }
        }


        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "1")
            {
                if (azulequipos == false && azulindividual == true)
                {
                    btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposenterazul.png"));
                    btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualleavegris.png"));
                    azulequipos = true; azulindividual = false;
                    //grbCantidad.Visible = true;
                }
            }
            else
            {
                if (azulindividual == false && azulequipos == true)
                {
                    btnindividual.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\individualenterazul.png"));
                    btnenequipos.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\Enequiposoindividual\\equiposleavegris.png"));
                    azulequipos = false; azulindividual = true;
                    //grbCantidad.Visible = false;
                }
            }
        }
    }
}
