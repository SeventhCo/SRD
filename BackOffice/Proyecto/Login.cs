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

                    switch (Logica.iniciarAdmin(mail[0], mail[1], txtPass.Text))
                    {
                        //0 usuario admin
                        //1 usuario no admin
                        //2 No usuario
                        case 0:
                            //inicio
                            Program.Blank.frmPrincipal.loged = true;
                            Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ajustes.png"));
                            Program.Blank.frmPrincipal.panelAgregarDep.Visible = true;
                            Program.Blank.frmPrincipal.panelEliminarDep.Visible = true;
                            Program.Blank.frmPrincipal.panel10.Visible = true;
                            Program.Blank.frmPrincipal.panel2.Visible = true;
                            Program.Blank.frmPrincipal.panel28.Visible = true;
                            Program.Blank.frmPrincipal.panel22.Visible = true;
                            Program.Blank.Depo.panel10.Visible = true;
                            Program.Blank.Depo.panel2.Visible = true;
                            this.Visible = false;
                            Program.Blank.user.gmail[0] = mail[0];
                            Program.Blank.user.gmail[1] = mail[1];
                            Program.Blank.frmPrincipal.Enabled = true;
                            Program.Blank.frmPrincipal.cargaDepo();
                            Program.Blank.frmPrincipal.cargaTorn();
                            Program.Blank.frmPrincipal.cargaEqui();
                            Program.Blank.Depo.lblDepoInfo.Cursor = Cursors.Hand;
                            MessageBox.Show("Sesion Iniciada Correctamente");
                            break;
                        case 1:
                            MessageBox.Show("Esta sesion no es Administrador");
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
    }
}
