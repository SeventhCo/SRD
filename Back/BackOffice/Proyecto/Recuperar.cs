using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmRecuperar : Form
    {
        bool valid = true;
        public bool loged = false;
        int correos = 0;
        public frmRecuperar()
        {
            InitializeComponent();
        }

        private void lblGmail_Click(object sender, EventArgs e)
        {

        }
        public void actualizar()
        {
            Idioma.controles(pnlRecuperar);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte contador = 0;
            foreach (char c in txtGmail.Text)
            {
                if (c.Equals('@')) contador++;
            }
            string[] email = new string[2];
            for (int i = 0; i < txtGmail.Text.IndexOf('@'); i++) email[0] = "" + email[0] + txtGmail.Text[i];
            for (int i = txtGmail.Text.IndexOf('@') + 1; i < txtGmail.Text.Length; i++) email[1] = "" + email[1] + txtGmail.Text[i];
            string dominio = email[1];

            dynamic[,] datosUsuario = Logica.consulta("Select contra from usuario WHERE gmail = '" + email[0] + "' AND dominio = '" + email[1] + "'");
            if (btnSendEmail.Text == "Enviar Email")
            {
                if (datosUsuario != null)
                {
                    correos++;
                    string from = "seventh7community@gmail.com";
                    string displayName = "Seventh.co";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(txtGmail.Text);
                    string codigo = "";
                    for(int i = 0; i < datosUsuario[0, 0].Length; i++)
                    {
                        if(i == 6)
                        {
                            break;
                        }
                        codigo = codigo + datosUsuario[0, 0][i];
                    }
                    mail.Subject = "Recuperacion de contraseña";
                    mail.Priority = MailPriority.High;
                    mail.Body = "Usted ha solicitado el cambio de contraseña en nuestro servicio de sistema de resultados deportivos 7th, " +
                        "\nSi no ha sido usted el solicitante de este correo le avisamos que alguien posee su direccion de correo electronico" +
                        "\n\nEn caso contrario, deberia estar viendo en su pantalla la solicitud de su codigo de recuperacion " +
                        "\nsimplemente ingrese el mismo y presione Validar codigo" +
                        "\nCodigo: " + codigo;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25; //465; //587
                    smtp.Credentials = new NetworkCredential(from, "npmmyomepnntdoza");
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        smtp.Dispose();
                    }


                    txtCodigo.Visible = true;
                    lblCodigo.Visible = true;
                    panel1.Visible = true;
                    btnSendEmail.Text = "Validar Codigo";
                    pictureBox12.Visible = true;
                    label3.Visible = true;
                    label3.Text = correos + "";
                }
                else
                {
                    MessageBox.Show("Este gmail no fue registrado.");
                }
            }
            else if (btnSendEmail.Text == "Validar Codigo")
            {
                string codigo = "";
                for (int i = 0; i < datosUsuario[0, 0].Length; i++)
                {
                    if (i == 6)
                    {
                        break;
                    }
                    codigo = codigo + datosUsuario[0, 0][i];
                }
                if (txtCodigo.Text == codigo)
                {
                    txtCodigo.Visible = false;
                    lblCodigo.Visible = false;
                    panel1.Visible = false;
                    txtGmail.Visible = false;
                    lblGmail.Visible = false;
                    panel21.Visible = false;

                    txtContra.Visible = true;
                    lblContra.Visible = true;
                    panel2.Visible = true;
                    btnSendEmail.Text = "Modificar Contraseña";
                    valid = false;
                    pictureBox12.Visible = false;
                    label3.Visible = false;
                }
                else
                {
                    MessageBox.Show("Este codigo es incorrecto");
                }
            }
            else
            {
                Logica.comando("UPDATE usuario SET contra = md5('" + txtContra.Text + "')" + " WHERE gmail = '" + email[0] + "' and dominio = '" + email[1] + "'");
                this.Visible = false;
                Program.Blank.frmPrincipal.Enabled = true;
                MessageBox.Show("La base de datos de virus, ha sido actualizada");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmPrincipal.Enabled = true;


            Program.Blank.frmRecuperar = new frmRecuperar();
            Program.Blank.frmRecuperar.MdiParent = Program.Blank;
            Program.Blank.frmRecuperar.Show();
            Program.Blank.frmRecuperar.Visible = false;
        }

        private void lblforPass_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmLogin.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmRegister.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            do
            {
                if (valid)
                {
                    byte contador = 0;
                    foreach (char c in txtGmail.Text)
                    {
                        if (c.Equals('@')) contador++;
                    }
                    string[] email = new string[2];
                    for (int i = 0; i < txtGmail.Text.IndexOf('@'); i++) email[0] = "" + email[0] + txtGmail.Text[i];
                    for (int i = txtGmail.Text.IndexOf('@') + 1; i < txtGmail.Text.Length; i++) email[1] = "" + email[1] + txtGmail.Text[i];
                    string dominio = email[1];

                    dynamic[,] datosUsuario = Logica.consulta("Select contra from usuario WHERE gmail = '" + email[0] + "' AND dominio = '" + email[1] + "'");
                    correos++;
                    string from = "seventh7community@gmail.com";
                    string displayName = "Seventh.co";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(txtGmail.Text);
                    string codigo = "";
                    for (int i = 0; i < datosUsuario[0, 0].Length; i++)
                    {
                        if (i == 6)
                        {
                            break;
                        }
                        codigo = codigo + datosUsuario[0, 0][i];
                    }
                    mail.Subject = "Recuperacion de contraseña";
                    mail.Priority = MailPriority.High;
                    mail.Body = "Usted ha solicitado el cambio de contraseña en nuestro servicio de sistema de resultados deportivos 7th, " +
                        "\nSi no ha sido usted el solicitante de este correo le avisamos que alguien posee su direccion de correo electronico" +
                        "\n\nEn caso contrario, deberia estar viendo en su pantalla la solicitud de su codigo de recuperacion " +
                        "\nsimplemente ingrese el mismo y presione Validar codigo" +
                        "\nCodigo: " + codigo;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25; //465; //587
                    smtp.Credentials = new NetworkCredential(from, "npmmyomepnntdoza");
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        smtp.Dispose();
                    }


                    txtCodigo.Visible = true;
                    lblCodigo.Visible = true;
                    panel1.Visible = true;
                    btnSendEmail.Text = "Validar Codigo";
                    pictureBox12.Visible = true;
                    label3.Text = correos + "";
                }
                else
                {
                    pictureBox12.Visible = false;
                    label3.Visible = false;
                }
            } while (false);
        }
    }
}

