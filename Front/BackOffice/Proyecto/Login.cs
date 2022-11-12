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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void iniciarSesion()
        {
            byte contador = 0;

            foreach (char c in txtGmail.Text)
            {
                if (c.Equals('@')) contador++;
            }

            string[] mail = new string[2];
            switch (contador)
            {
                case 1:
                    for (int i = 0; i < txtGmail.Text.IndexOf('@'); i++) mail[0] = "" + mail[0] + txtGmail.Text[i];
                    for (int i = txtGmail.Text.IndexOf('@') + 1; i < txtGmail.Text.Length; i++) mail[1] = "" + mail[1] + txtGmail.Text[i];

                    switch (apiAutenticacion.iniciar(mail[0], mail[1], txtPass.Text))
                    {
                        //0 rol > 0
                        //1 rol == 0
                        //2 no
                        case 0:
                            //inicio
                            Program.Blank.frmPrincipal.loged = true;
                            Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ajustes.png"));
                            this.Visible = false;
                            Program.Blank.user.gmail[0] = mail[0];
                            Program.Blank.user.gmail[1] = mail[1];
                            Program.Blank.frmPrincipal.Enabled = true;
                            Program.Blank.frmPrincipal.cargaDepo();
                            Program.Blank.frmPrincipal.cargaTorn();
                            Program.Blank.frmPrincipal.cargaEqui();
                            Program.Blank.frmPrincipal.cargaDeport();
                            Program.Blank.Depo.lblDepoInfo.Cursor = Cursors.Hand;
                            MessageBox.Show("Sesion Iniciada Correctamente");
                            apiAutenticacion.close();
                            apiAutenticacion.openAsPaidUser();
                            Program.Blank.frmPrincipal.rol = 1;
                            Program.Blank.Equipo.pictureBox4.Visible = true;
                            break;
                        case 1:
                            Program.Blank.frmPrincipal.loged = true;
                            Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ajustes.png"));
                            this.Visible = false;
                            Program.Blank.user.gmail[0] = mail[0];
                            Program.Blank.user.gmail[1] = mail[1];
                            Program.Blank.frmPrincipal.Enabled = true;
                            Program.Blank.frmPrincipal.cargaDepo();
                            Program.Blank.frmPrincipal.cargaTorn();
                            Program.Blank.frmPrincipal.cargaEqui();
                            Program.Blank.frmPrincipal.cargaDeport();
                            Program.Blank.Depo.lblDepoInfo.Cursor = Cursors.Hand;
                            MessageBox.Show("Sesion Iniciada Correctamente");
                            apiAutenticacion.close();
                            apiAutenticacion.openAsUser();
                            Program.Blank.frmPrincipal.rol = 0;
                            Program.Blank.Equipo.pictureBox4.Visible = false;
                            break;
                        case 2:
                            MessageBox.Show("Gmail o Contrasenia incorrecta");
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Gmail o Contrasenia incorrecta");
                    break;
            }


        }

        public void actualizar()
        {
            Idioma.controles(pnlLogin);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void VerContra_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtPass.PasswordChar.Equals('*'))
            {
                VerContra.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ojocerrao.png"));
                txtPass.PasswordChar = '\0';
            }
            else
            {
                VerContra.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ojoabierto.png"));
                txtPass.PasswordChar = '*';
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Blank.frmLogin.Visible = false;
            Program.Blank.frmRegister.Visible = true;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                iniciarSesion();
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            iniciarSesion();
        }

        private void lblforPass_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmRecuperar.Visible = true;
        }
    }
}
