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
    public partial class Blank : Form
    {
        public FormInicio frmPrincipal = new FormInicio();
        public Login frmLogin = new Login();
        public Register frmRegister = new Register();
        public Deporte Depo = new Deporte();
        public Usuario user = new Usuario();

        public Blank()
        {
            InitializeComponent();
        }

        private void Blank_Load(object sender, EventArgs e)
        {
            frmLogin.MdiParent = this;
            frmLogin.Show();
            frmLogin.Visible = false;

            frmRegister.MdiParent = this;
            frmRegister.Show();
            frmRegister.Visible = false;

            Depo.MdiParent = this;
            Depo.Show();
            Depo.Visible = false;

            user.MdiParent = this;
            user.Show();
            user.Visible = false;

            frmPrincipal.MdiParent = this;
            frmPrincipal.Show();
        }
    }
}