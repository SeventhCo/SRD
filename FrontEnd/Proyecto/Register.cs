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
            int num1 = 0;
            string metodo = ApiAut.registrar(textBox1.Text, textBox5.Text, ApiAut.validGmail(textBox2.Text), textBox3.Text, fecha);
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
            }         
            switch (num1)
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
