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
            try
            {
                if (txtUser.Text.Equals("admin") && txtContra.Text.Equals("admin"))
                {
                    Program.frmPrincipal.frmLogin.Visible = false;

                    //inicio
                    Program.frmPrincipal.loginleave.Visible = false;
                    Program.frmPrincipal.unloginenter.Visible = true;
                    Program.frmPrincipal.PanelAnuncio.Visible = false;

                    //deportes
                    Program.frmPrincipal.a.panelAgregar.Visible = true;
                    Program.frmPrincipal.a.panelEliminar.Visible = true;
                    Program.frmPrincipal.a.loginenter.Visible = false;
                    Program.frmPrincipal.a.unloginenter.Visible = true;
                    Program.frmPrincipal.a.panelPublicidad.Visible = false;

                    //deportes torneos
                    Program.frmPrincipal.frmTorneos.loginleave.Visible = false;
                    Program.frmPrincipal.frmTorneos.panelAgregar.Visible = true;
                    Program.frmPrincipal.frmTorneos.panelEliminar.Visible = true;
                    Program.frmPrincipal.frmTorneos.unloginleave.Visible = true;
                    Program.frmPrincipal.frmTorneos.Anuncio.Visible = false;

                    //deportes equipos
                    Program.frmPrincipal.frmEquipo.loginleave.Visible = false;
                    Program.frmPrincipal.frmEquipo.panelAgregar.Visible = true;
                    Program.frmPrincipal.frmEquipo.panelAnuncio.Visible = false;
                    Program.frmPrincipal.frmEquipo.panelEliminar.Visible = true;
                    Program.frmPrincipal.frmEquipo.unloginleave.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
                return;
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
            if (txtContra.PasswordChar.Equals('*'))
            {
                txtContra.PasswordChar = '\0';


            }
            else
            {
                txtContra.PasswordChar = '*';
            }
        }
    }
}

