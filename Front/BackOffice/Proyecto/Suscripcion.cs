using Newtonsoft.Json;
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
    public partial class Suscripcion : Form
    {
        public Suscripcion()
        {
            InitializeComponent();

        }

        public void actualizar()
        {
            Idioma.controles(pnlSuscripcion);
        }
        
        private void pnlSuscripcion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSuscribirse_Click(object sender, EventArgs e)
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
            dynamic[,] datosUsuario = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select rol from usuario WHERE gmail = '" + email[0] + "' AND dominio = '" + email[1] + "'"));

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtGmail.Text) || string.IsNullOrEmpty(txtDia.Text) || string.IsNullOrEmpty(txtMes.Text) || string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtNumTarjeta.Text) || string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Complete todos los campos");
            }
            else
            {
                if (datosUsuario != null)
                {
                    if ((datosUsuario[0, 0]) == 0)
                    {
                        JsonConvert.DeserializeObject<object>(apiResultados.comando("Update usuario set rol = 1 where gmail = '" + email[0] + "' and dominio = '" + email[1] + "'"));
                        MessageBox.Show("Usted fue registrado exitosamente,disfrute");
                        Program.Blank.frmPrincipal.rol = 1;
                        this.Visible = false;
                        Program.Blank.user.Enabled = true;
                    }
                    else if ((datosUsuario[0, 0]) == 1)
                    {
                        MessageBox.Show("Usted ya esta Suscripto");

                    }
                    else if ((datosUsuario[0, 0]) == 2)
                    {
                        MessageBox.Show("Usted es Administrador");

                    }
                }
                else
                {
                    MessageBox.Show("Este gmail no esta registrado");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.Blank.user.Enabled = true;
            Program.Blank.user.BringToFront();
        }

        private void txtDia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
