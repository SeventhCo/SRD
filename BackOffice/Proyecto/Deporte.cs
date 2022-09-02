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
    public partial class Deporte : Form
    {
        public string deporte;
        public Deporte()
        {
            InitializeComponent();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            Logica.consultaMaxIndex("UPDATE `mysqlbdsdco`.`deporte` SET `descripcion` = '" + desc.Text + "' WHERE (`nombreDep` = '" + deporte + "');");
            lblDepoInfo.Text = desc.Text;
            if (desc.Text.Equals("")) lblDepoInfo.Text = "Agregar Texto";
            desc.Visible = false;
        }

        private void lblDepoInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (Program.Blank.frmPrincipal.loged)
            {
                desc.Visible = true;
                desc.BringToFront();
                if (desc.Text.Equals("Agregar Texto")) desc.Text = "";
                desc.Focus();
                
            }
        }

        private void desc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Logica.consultaMaxIndex("UPDATE `mysqlbdsdco`.`deporte` SET `descripcion` = '" + desc.Text + "' WHERE (`nombreDep` = '" + deporte + "');");
                lblDepoInfo.Text = desc.Text;
                if (desc.Text.Equals("")) lblDepoInfo.Text = "Agregar Texto";
                desc.Visible = false;
            }
        }

        private void Deporte_Load(object sender, EventArgs e)
        {
            desc.Size = new Size(2,2);
        }
    }
}
