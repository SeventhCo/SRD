using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            timer2.Start();
            Program.frmPrincipal.frmLogin.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmRegister.Visible = false;
            }
            Opacity -= .2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Para llamar al evento, todos los txtBox deben tener texto
            string fecha = textBox4.Text + textBox6.Text + textBox7.Text;
            //MySQL no soporta las @ asi que me quedo con lo que este antes
            string mail = textBox2.Text;
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
            int rol;
            if (checkBox1.Checked)
            {
                rol = 2;
            }
            else rol = 1;
            switch (Logica.registrar(textBox1.Text,textBox5.Text,textBox2.Text,textBox3.Text,fecha,rol))
            {
                case 0:
                    MessageBox.Show("Registrado Exitosamente");
                    Program.frmPrincipal.frmRegister.Visible = false;
                    break;
                case 1:
                    MessageBox.Show("El gmail ya esta registrado");
                    break;
            }
        }
    }
}
