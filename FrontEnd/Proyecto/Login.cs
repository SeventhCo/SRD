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
            Program.frmPrincipal.frmLogin.Visible = false;
            Program.frmPrincipal.frmRegister.timer2.Stop();
            Program.frmPrincipal.frmRegister.Visible = true;
            Program.frmPrincipal.frmRegister.timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            string metodo = ApiAut.login(ApiAut.validGmail(txtGmail.Text), txtPass.Text);
            for (int i = 0; i < metodo.Length; i++)
            {
                if (metodo[i].Equals('0'))
                {
                    num1 = 0;
                }
                else if (metodo[i].Equals('1'))
                {
                    num1 = 1;
                }
                if (metodo[i].Equals('2'))
                {
                    num1 = 2;
                }
            }
            switch (num1)
            {
                //0 usuario Suscrito
                //1 usuario Registrado
                //2 No usuario
                case 0:
                    //inicio
                    Program.frmPrincipal.loginleave.Visible = false;
                    Program.frmPrincipal.unloginenter.Visible = true;
                    Program.frmPrincipal.pnlAnuncioInicio.Visible = false;
                    
                    Program.frmPrincipal.panelPublicidadDep.Visible = false;
                    
                    Program.frmPrincipal.AnuncioTor.Visible = false;

                    //deportes equipos
                    Program.frmPrincipal.PublicidadEqu.Visible = false;

                    MessageBox.Show("Sesion Iniciada Correctamente");
                    Program.frmPrincipal.frmLogin.Visible = false;
                    break;
                case 1:
                    //inicio
                    Program.frmPrincipal.loginleave.Visible = false;
                    Program.frmPrincipal.unloginenter.Visible = true;

                    //deportes

                    MessageBox.Show("Sesion Iniciada Correctamente");
                    Program.frmPrincipal.frmLogin.Visible = false;
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

