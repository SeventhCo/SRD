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
        public Torneo torn = new Torneo();
        public Usuario user = new Usuario();
        public frmRecuperar frmRecuperar = new frmRecuperar();
        public Partido Partido = new Partido();
        public Equipo Equipo = new Equipo();
        public Deportista Depor = new Deportista();
        public Suscripcion Suscripcion = new Suscripcion();
        public Favorito Favorito = new Favorito();

        public Blank()
        {
            InitializeComponent();
        }

        private void Blank_Load(object sender, EventArgs e)
        {
            Favorito.MdiParent = this;
            Favorito.Show();
            Favorito.Visible = false;

            Suscripcion.MdiParent = this;
            Suscripcion.Show();
            Suscripcion.Visible = false;

            Depor.MdiParent = this;
            Depor.Show();
            Depor.Visible = false;

            Equipo.MdiParent = this;
            Equipo.Show();
            Equipo.Visible = false;

            Partido.MdiParent = this;
            Partido.Show();
            Partido.Visible = false;

            frmLogin.MdiParent = this;
            frmLogin.Show();
            frmLogin.Visible = false;

            frmRegister.MdiParent = this;
            frmRegister.Show();
            frmRegister.Visible = false;

            torn.MdiParent = this;
            torn.Show();
            torn.Visible = false;

            Depo.MdiParent = this;
            Depo.Show();
            Depo.Visible = false;

            user.MdiParent = this;
            user.Show();
            user.Visible = false;

            frmRecuperar.MdiParent = this;
            frmRecuperar.Show();
            frmRecuperar.Visible = false;
            
            frmPrincipal.MdiParent = this;
            frmPrincipal.Show();
            
        }
        
    }
}