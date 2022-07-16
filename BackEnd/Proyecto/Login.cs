using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;

namespace Proyecto
{
    public partial class Login : Form
    {
        private Color borderColor = Color.Silver;
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
            button2.BackColor = Color.FromArgb(126, 2, 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmLogin.Visible = false;
            }
            Opacity -= .2;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Program.frmPrincipal.frmLogin.Visible = false;
            Program.frmPrincipal.frmRegister.timer2.Stop();
            Program.frmPrincipal.frmRegister.Visible = true;
            Program.frmPrincipal.frmRegister.timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
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
            switch (Logica.iniciarAdmin(mail,txtPass.Text))
            {
                //0 usuario admin
                //1 usuario no admin
                //2 No usuario
                case 0:
                    //inicio
                    Program.frmPrincipal.loged = true;
                    Program.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\unlogin.png"));
                    Program.frmPrincipal.panelAgregarDep.Visible = true;
                    Program.frmPrincipal.panelEliminarDep.Visible = true;
                    Program.frmPrincipal.panelAgregarTor.Visible = true;
                    Program.frmPrincipal.panelEliminarTor.Visible = true;
                    Program.frmPrincipal.panelEliminarEqu.Visible = true;
                    Program.frmPrincipal.panelAgregarEqu.Visible = true;
                    MessageBox.Show("Sesion Iniciada Correctamente");
                    Program.frmPrincipal.frmLogin.Visible = false;
                    break;
                case 1:
                    MessageBox.Show("Esta sesion no es Administrador");
                    break;
                case 2:
                    MessageBox.Show("Usuario o Contrasenia incorrecta");
                    break;
            }
        }          
        private void VerContra_MouseEnter(object sender, EventArgs e)
        {
            VerContra.BackColor = Color.FromArgb(148, 148, 148);
        }

        private void VerContra_MouseLeave(object sender, EventArgs e)
        {
            VerContra.BackColor = Color.DarkGray;
        }

        private void VerContra_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar.Equals('*'))
            {
                txtPass.PasswordChar = '\0';


            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }
    }
}
