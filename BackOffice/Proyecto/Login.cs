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

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            string mail = txtGmail.Text;
            if (mail.Contains('@'))
            {
                for (int i = 0; i < mail.Length; i++)
                {
                    if (mail[i] != '@')
                    {
                        mail = mail + mail[i];
                    }
                    else break;
                }
            }
            switch (Logica.iniciarAdmin(mail, txtPass.Text))
            {
                //0 usuario admin
                //1 usuario no admin
                //2 No usuario
                case 0:
                    //inicio
                    Program.Blank.frmPrincipal.loged = true;
                    Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\unlogin.png"));
                    Program.Blank.frmPrincipal.panelAgregarDep.Visible = true;
                    Program.Blank.frmPrincipal.panelEliminarDep.Visible = true;
                    Program.Blank.frmPrincipal.panel10.Visible = true;
                    Program.Blank.frmPrincipal.panel2.Visible = true;
                    Program.Blank.frmPrincipal.panel28.Visible = true;
                    Program.Blank.frmPrincipal.panel22.Visible = true;
                    this.Visible = false;
                    Program.Blank.frmPrincipal.Enabled = true;
                    Program.Blank.frmPrincipal.cargaDepo();
                    Program.Blank.frmPrincipal.cargaTorn();
                    Program.Blank.frmPrincipal.cargaEqui();
                    MessageBox.Show("Sesion Iniciada Correctamente");
                    break;
                case 1:
                    MessageBox.Show("Esta sesion no es Administrador");
                    break;
                case 2:
                    MessageBox.Show("Usuario o Contrasenia incorrecta");
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

        private void lblCrearCuenta_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Blank.frmLogin.Visible = false;
            Program.Blank.frmRegister.Visible = true;
        }
    }
}
