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
    public partial class Usuario : Form
    {
        public string[] gmail = new string[2];

        public Usuario()
        {
            InitializeComponent();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Blank.frmPrincipal.loged = false;
            Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
            Program.Blank.frmPrincipal.panelAgregarDep.Visible = false;
            Program.Blank.frmPrincipal.panelEliminarDep.Visible = false;
            Program.Blank.frmPrincipal.pnlAgregarTornDep.Visible = false;
            Program.Blank.frmPrincipal.pnlEliminarTorn2.Visible = false;
            Program.Blank.frmPrincipal.pnlAgregarEq.Visible = false;
            Program.Blank.frmPrincipal.pnlEliminarEqs.Visible = false;
            Program.Blank.frmPrincipal.panel9.Visible = false;
            Program.Blank.frmPrincipal.panel7.Visible = false;
            Program.Blank.Depo.pnlAgregar.Visible = false;
            Program.Blank.Depo.pnlEliminar.Visible = false;
            Program.Blank.frmPrincipal.cargaDepo();
            Program.Blank.frmPrincipal.cargaTorn();
            Program.Blank.frmPrincipal.cargaEqui();
            Program.Blank.Depo.lblDepoInfo.Cursor = Cursors.Default;
            this.Visible = false;
            MessageBox.Show("Sesion Cerrada Correctamente");
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            pnlAjustes.Visible = true;
            pnlIngles.Visible = false;
            pnlSub.Visible = true;
            pnlPubli.Visible = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            pnlSub.Visible = true;
            pnlIngles.Visible = false;
            pnlAjustes.Visible = false;
            pnlPubli.Visible = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            pnlIngles.Visible = true;
            pnlAjustes.Visible = false;
            pnlSub.Visible = false;
            pnlPubli.Visible = false;
        }
        
        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (rdbIngles.Checked)
            {
                rdbEspañol.Checked = true;
                rdbIngles.Checked = false;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            if (rdbEspañol.Checked)
            {
                rdbIngles.Checked = true;
                rdbEspañol.Checked = false;
            }

            Idioma.cambiarIdioma("eng.txt");
            actualizar();
            Program.Blank.frmPrincipal.actualizar();
            Program.Blank.frmEvento.actualizar();
            Program.Blank.frmHerrEquipos.actualizar();
            Program.Blank.frmHerramientas.actualizar();
            Program.Blank.frmHerrTorneo.actualizar();
            Program.Blank.frmLogin.actualizar();
            Program.Blank.frmRegister.actualizar();
            Program.Blank.frmPunt.actualizar();
            Program.Blank.Suscripcion.actualizar();
            Program.Blank.frmRecuperar.actualizar();
            Program.Blank.Depo.actualizar();
            Program.Blank.Deportista.actualizar();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            pnl1Usuario.Visible = true;
            textBox1.Text = label2.Text;
            textBox2.Text = label4.Text;
            pnlMenu1Usu.Enabled = false;
            pnlAjustes.Enabled = false;
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            pnlMenu1Usu.Enabled = true;
            pnlAjustes.Enabled = true;
            pnl1Usuario.Visible = false;
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            Logica.comando("UPDATE usuario SET nombre = '" + textBox1.Text + "' , apellido = '"+textBox2.Text+"'WHERE (gmail = '" + gmail[0]+"') and (dominio = '"+gmail[1]+"')");
            label2.Text = textBox1.Text;
            label4.Text = textBox2.Text;
            pnlMenu1Usu.Enabled = true;
            pnlMenu1Usu.BringToFront();
            pnlAjustes.Enabled = true;
            pnl1Usuario.Visible = false;
        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            
            byte contador = 0;

            foreach (char c in textBox4.Text)
            {
                if (c.Equals('@')) contador++;
            }

            string[] mail = new string[2];
            switch (contador)
            {
                case 1:

                    for (int i = 0; i < textBox4.Text.IndexOf('@'); i++) mail[0] = "" + mail[0] + textBox4.Text[i];
                    for (int i = textBox4.Text.IndexOf('@') + 1; i < textBox4.Text.Length; i++) mail[1] = "" + mail[1] + textBox4.Text[i];

                    if (Logica.comando("Select * from usuario WHERE gmail = '" + mail[0] + "' and dominio = '" + mail[1] + "'").ToString().Equals("0"))
                    {
                        Logica.comando("UPDATE usuario SET gmail = '" + mail[0] + "', dominio = '" + mail[1] + "' WHERE (gmail = '" + gmail[0] + "') and (dominio = '" + gmail[1] + "')");
                        label7.Text = textBox4.Text;
                        pnl2Usuario.Visible = false;
                        pnlAjustes.Enabled = true;
                        pnlMenu1Usu.Enabled = true;
                        gmail[0] = mail[0];
                        gmail[1] = mail[1];
                    }
                    else MessageBox.Show("Gmail en uso");
                    break;
                default:
                    MessageBox.Show("Gmail Invalido");
                        break;
            }
                    
            }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            pnl2Usuario.Visible = true;
            pnl2Usuario.BringToFront();
            pnlAjustes.Enabled = false;
            pnlMenu1Usu.Enabled = false;
            textBox4.Text = label7.Text;
        }

        private void button16_MouseDown(object sender, MouseEventArgs e)
        {
            pnl2Usuario.Visible = false;
            pnlAjustes.Enabled = true;
            pnlMenu1Usu.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("EFECTIVAMENTE"))
            {
                btnAceptar4Usu.Enabled = true;
            }
            else btnAceptar4Usu.Enabled = false;
        }

        private void button21_MouseDown(object sender, MouseEventArgs e)
        {
            Logica.comando("DELETE FROM usuario WHERE (gmail = '"+gmail[0]+"') and (dominio = '"+gmail[1]+"');");
            Program.Blank.frmPrincipal.loged = false;
            Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
            Program.Blank.frmPrincipal.panelAgregarDep.Visible = false;
            Program.Blank.frmPrincipal.panelEliminarDep.Visible = false;
            Program.Blank.frmPrincipal.pnlAgregarTornDep.Visible = false;
            Program.Blank.frmPrincipal.pnlEliminarTorn2.Visible = false;
            Program.Blank.frmPrincipal.pnlAgregarEq.Visible = false;
            Program.Blank.frmPrincipal.panel9.Visible = false;
            Program.Blank.frmPrincipal.panel7.Visible = false;
            Program.Blank.frmPrincipal.pnlEliminarEqs.Visible = false;
            Program.Blank.Depo.pnlAgregar.Visible = false;
            Program.Blank.Depo.pnlEliminar.Visible = false;
            Program.Blank.frmPrincipal.cargaDepo();
            Program.Blank.frmPrincipal.cargaTorn();
            Program.Blank.frmPrincipal.cargaEqui();
            Program.Blank.Depo.lblDepoInfo.Cursor = Cursors.Default;
            this.Visible = false;
        }

        void actualizar()
        {
            Idioma.controles(pnlNom1);
            Idioma.controles(pnl1Usuario);
            Idioma.controles(pnl2Usuario);
            Idioma.controles(pnl3Usuario);
            Idioma.controles(pnl4Usu);
            Idioma.controles(pnlSub3Usu);
            Idioma.controles(pnl5Usu);
            Idioma.controles(pnlSub5Usu);
            Idioma.controles(pnlMenu1Usu);
            Idioma.controles(pnlAjuste1Usu);
            Idioma.controles(pnlAjuste2Usu);
            Idioma.controles(pnlAjuste3Usu);
            Idioma.controles(pnlAjuste4Usu);
            Idioma.controles(pnlAjustes);
            Idioma.controles(pnlPlan1);
            Idioma.controles(pnlPlan2);
            Idioma.controles(pnlPlan3);
            Idioma.controles(pnlSubPublicidadUsu);
            Idioma.controles(pnlPublicidadUsu);
            Idioma.controles(pnlIdentificador);
            Idioma.controles(pnlTipoPublicidad);
            Idioma.controles(pnlPaisPublicidad);
            Idioma.controles(pnlPubli);
        }

        private void button13_MouseDown(object sender, MouseEventArgs e)
        {
            pnl5Usu.Visible = true;
            pnl5Usu.BringToFront();
            pnlAjustes.Enabled = false;
            pnlMenu1Usu.Enabled = false;
        }

        private void button20_MouseDown(object sender, MouseEventArgs e)
        {
            pnl5Usu.Visible = false;
            pnlAjustes.Enabled = true;
            pnlMenu1Usu.Enabled = true;
        }

        private void button22_MouseDown(object sender, MouseEventArgs e)
        {
            pnlPubli.Visible = true;
            pnlIngles.Visible = false;
            pnlAjustes.Visible = false;
            pnlSub.Visible = false;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pcbPublicidad.Image = new Bitmap(open.FileName);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbTipo.Text.Equals("Banner"))
            {

            }
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcbPublicidad_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pcbPublicidad.Image = new Bitmap(open.FileName);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {

            if (txtIdent.Text.Equals("") || cbTipo.Text.Equals("") || txtPais.Text.Equals(""))
            {
                MessageBox.Show("Complete todos los campos");
            }
            else if (Convert.ToBase64String(Logica.conImgByte(pcbPublicidad.Image)).Equals(Convert.ToBase64String(Logica.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"))))))
            {
                MessageBox.Show("Ingrese una imagen");
            }
                if (Logica.addPublicidad(txtIdent.Text, cbTipo.SelectedIndex, txtPais.Text, pcbPublicidad.Image))
                {
                    txtIdent.Text = "";
                    txtPais.Text = "";
                    cbTipo.Text = "";
                    pcbPublicidad.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                    this.Visible = false;
                    Program.Blank.frmPrincipal.Enabled = true;
                    Program.Blank.frmPrincipal.cargaDepo();
                }
                else
                {
                    MessageBox.Show("Ya existe una publicidad con identificador : " + txtIdent.Text);
                }
            }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.Blank.Suscripcion.Visible = true;
            this.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Program.Blank.Suscripcion.Visible = true;
            this.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Program.Blank.Suscripcion.Visible = true;
            this.Enabled = false;
        }
    }
}

