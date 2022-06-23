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
            Program.frmPrincipal.frmRegister.timer2.Stop();
            Program.frmPrincipal.frmRegister.Visible = true;
            Program.frmPrincipal.frmRegister.timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                Program.cm.Open("bd7sdco", txtUser.Text, txtContra.Text, -1);
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
                return;
            }
            Program.cm.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
            //doypermisos
            Program.frmPrincipal.frmLogin.Visible = false;
            */
                if (txtUser.Text.Equals("admin") && txtPass.Text.Equals("admin"))
                {
                    Program.frmPrincipal.frmLogin.Visible = false;

                    //inicio
                    Program.frmPrincipal.loginleave.Visible = false;
                    Program.frmPrincipal.unloginenter.Visible = true;
                    Program.frmPrincipal.pnlAnuncioInicio.Visible = false;

                    //deportes
                    Program.frmPrincipal.panelAgregarDep.Visible = true;
                    Program.frmPrincipal.panelEliminarDep.Visible = true;
                    Program.frmPrincipal.panelPublicidadDep.Visible = false;

                    //deportes torneos
                    Program.frmPrincipal.panelAgregarTor.Visible = true;
                    Program.frmPrincipal.panelEliminarTor.Visible = true;
                    Program.frmPrincipal.AnuncioTor.Visible = false;

                    //deportes equipos
                    Program.frmPrincipal.panelAgregarEqu.Visible = true;
                    Program.frmPrincipal.PublicidadEqu.Visible = false;
                    Program.frmPrincipal.panelEliminarEqu.Visible = true;
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

