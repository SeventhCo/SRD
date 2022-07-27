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
        public Form4 frmHerramientas = new Form4();
        public FormHerramientas frmHerrTorneo = new FormHerramientas();
        public HerramientasEquipos frmHerrEquipos = new HerramientasEquipos();
        public SisPunt frmPunt = new SisPunt();

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

            frmHerramientas.MdiParent = this;
            frmHerramientas.Show();
            frmHerramientas.Visible = false;

            frmHerrTorneo.MdiParent = this;
            frmHerrTorneo.Show();
            frmHerrTorneo.Visible = false;

            frmHerrEquipos.MdiParent = this;
            frmHerrEquipos.Show();
            frmHerrEquipos.Visible = false;

            frmPunt.MdiParent = this;
            frmPunt.Show();
            frmPunt.Visible = false;

            frmPrincipal.MdiParent = this;
            frmPrincipal.Show();
        }
    }
}