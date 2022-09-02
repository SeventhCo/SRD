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
            this.Visible = false;
            Program.Blank.frmLogin.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Para llamar al evento, todos los txtBox deben tener texto
            int dia, mes, ano;
            if ((int.TryParse(textBox4.Text, out dia) && dia > 0 && dia < 32 && int.TryParse(textBox6.Text, out mes) && mes > 0 && mes < 13 && int.TryParse(textBox7.Text, out ano) && ano >= 1900))
            {
                string fecha = ano + "-" + mes + "-" + dia;
                int rol;
                if (checkBox1.Checked)
                {
                    rol = 2;
                }
                else if (cbUsuarioSubscripto.Checked) rol = 1;
                else rol = 0;

                byte contador = 0;

                foreach (char c in textBox2.Text)
                {
                    if (c.Equals('@')) contador++;
                }

                string[] mail = new string[2];
                switch (contador)
                {
                    case 1:
                        for (int i = 0; i < textBox2.Text.IndexOf('@'); i++) mail[0] = "" + mail[0] + textBox2.Text[i];
                        for (int i = textBox2.Text.IndexOf('@') + 1; i < textBox2.Text.Length; i++) mail[1] = "" + mail[1] + textBox2.Text[i];
                        switch (Logica.registrar(mail[0], mail[1], textBox3.Text, rol, fecha, textBox1.Text, textBox5.Text, "", ""))
                        {
                            case 0:
                                MessageBox.Show("Registrado Exitosamente");
                                Program.Blank.frmRegister.Visible = false;
                                Program.Blank.frmLogin.Visible = true;
                                break;
                            case 1:
                                MessageBox.Show("El gmail ya esta registrado");
                                break;
                        }
                        break;
                    default:
                        MessageBox.Show("Gmail invalido");
                        break;
                }
            }
            else
                MessageBox.Show("Fecha Invalida");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cbUsuarioSubscripto.Checked = false;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("Día")) textBox4.Text = "";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("Mes")) textBox6.Text = "";
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals("Año")) textBox7.Text = "";
        }

        private void cbUsuarioSubscripto_Click(object sender, EventArgs e)
        {
            if (cbUsuarioSubscripto.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBox6.Size = new Size(55, 18);
            textBox7.Size = new Size(55, 18);
        }
    }
}
