using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FormInicio : Form
    {
        public Login frmLogin = new Login();
        public Register frmRegister = new Register();
        public Form4 frmHerramientas = new Form4();
        public FormHerramientas frmHerrTorneo = new FormHerramientas();
        public HerramientasEquipos frmHerrEquipos = new HerramientasEquipos();
        public bool loged = false;
        public FormInicio()
        {
            InitializeComponent();
        }
        //************************************************FormInicio*************************************************************

            private void FormInicio_Load(object sender, EventArgs e)
            {
                panel4.Visible = false;
                logoenter.Visible = false;
                panel6.Visible = false;
                panel8.Visible = false;
            }

        //***********************************************************************************************************************

        //****************************************************TIMERS*************************************************************

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
                    Application.Exit();
                }
                Opacity -= .2;
            }

        //*********************************************************************************************************************** 

        //****************************************************MENU***************************************************************

            private void panelInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                pnlTorneos.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlEquipos.Visible = false;
                pnlJuego.Visible = false;
                pnlLiga.Visible = false;
            }

            private void LblInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                pnlTorneos.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlEquipos.Visible = false;
                pnlJuego.Visible = false;
                pnlLiga.Visible = false;
        }
            private void panelInicio_MouseEnter(object sender, EventArgs e)
            {
                btnInicio.BackColor = Color.FromArgb(240, 172, 3);
                panel4.Visible = true;
            }

            private void panelInicio_MouseLeave(object sender, EventArgs e)
            {
                btnInicio.BackColor = Color.FromArgb(255, 183, 3);
                panel4.Visible = false;
            }

            private void LblInicio_MouseEnter(object sender, EventArgs e)
            {
                btnInicio.BackColor = Color.FromArgb(240, 172, 3);
                panel4.Visible = true;
            }

            private void exit_MouseClick(object sender, MouseEventArgs e)
            {
                timer2.Start();
                exit.BackColor = Color.FromArgb(126, 2, 2);
            }

            private void logoleave_MouseEnter(object sender, EventArgs e)
            {
                logoleave.Visible = false;
                logoenter.Visible = true;
            }

            private void logoenter_MouseLeave(object sender, EventArgs e)
            {
                logoleave.Visible = true;
                logoenter.Visible = false;
            }
   
            private void exit_MouseEnter(object sender, EventArgs e)
            {
                exit.BackColor = Color.FromArgb(142, 5, 5);
            }

            private void exit_MouseLeave(object sender, EventArgs e)
            {
                exit.BackColor = Color.Red;
            }

            private void panelDeportes_MouseEnter(object sender, EventArgs e)
            {
                btnDeportes.BackColor = Color.FromArgb(240, 172, 3);
                panel6.Visible = true;
            }

            private void panelAyuda_MouseEnter(object sender, EventArgs e)
            {
                btnAyuda.BackColor = Color.FromArgb(240, 172, 3);
                panel8.Visible = true;
            }

            private void panelDeportes_MouseLeave(object sender, EventArgs e)
            {
                btnDeportes.BackColor = Color.FromArgb(255, 183, 3);
                panel6.Visible = false;
            }

            private void panelAyuda_MouseLeave(object sender, EventArgs e)
            {
                btnAyuda.BackColor = Color.FromArgb(255, 183, 3);
                panel8.Visible = false;
            }

            private void LblDeportes_MouseEnter(object sender, EventArgs e)
            {
                btnDeportes.BackColor = Color.FromArgb(240, 172, 3);
                panel6.Visible = true;
            }

            private void LblAyuda_MouseEnter(object sender, EventArgs e)
            {
                btnAyuda.BackColor = Color.FromArgb(240, 172, 3);
                panel8.Visible = true;
            }


            private void panelDeportes_MouseDown(object sender, MouseEventArgs e)
            {
                pnlDeportes.Visible = true;
                pnlInicio.Visible = false;
                pnlEquipos.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlTorneos.Visible = false;
            }

            private void LblDeportes_MouseDown(object sender, MouseEventArgs e)
            {
                pnlDeportes.Visible = true;
                pnlInicio.Visible = false;
                pnlEquipos.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlTorneos.Visible = false;
            }



        //***********************************************************************************************************************

        //************************************************DEPORTES***************************************************************

            private void ImgBasketDep_Click(object sender, EventArgs e)
            {
                pnlEquipos.Visible = true;
                pnlDeportes.Visible = false;
            }

            private void ImgBasketDep_MouseEnter(object sender, EventArgs e)
            {
                panelBasketDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgBasketDep_MouseLeave(object sender, EventArgs e)
            {
                panelBasketDep.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarDep_MouseEnter(object sender, EventArgs e)
            {
                panelAgregarDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgAgregarDep_MouseLeave(object sender, EventArgs e)
            {
                panelAgregarDep.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarDep_Click(object sender, EventArgs e)
            {
                
                if (ChkEquisDep.Visible == true)
                {
                    MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                
                     Program.frmPrincipal.frmHerramientas.timer2.Stop();
                     Program.frmPrincipal.frmHerramientas.Visible = true;
                     Program.frmPrincipal.frmHerramientas.timer1.Start();
                }
            }


        private void ImgEliminarDep_MouseEnter(object sender, EventArgs e)
            {
                panelEliminarDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgEliminarDep_MouseLeave(object sender, EventArgs e)
            {
                panelEliminarDep.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void okDep_MouseEnter(object sender, EventArgs e)
            {
                panelEliminarDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void okDep_MouseLeave(object sender, EventArgs e)
            {
                panelEliminarDep.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void okDep_Click(object sender, EventArgs e)
            {
                TituloDep.Text = "       Deportes";
                TituloDep.BackColor = Color.FromArgb(1, 26, 37);
                okDep.Visible = false;
                ChkEquisDep.Visible = false;
                equisdep.Visible = false;
                ImgEliminarDep.Visible = true;
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este deporte?", "Eliminar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    panelBasketDep.Visible = false;
                    this.panelAgregarDep.Location = new System.Drawing.Point(20, 41);
                    this.panelEliminarDep.Location = new System.Drawing.Point(111, 41);
                }
            }

            private void ImgEliminarDep_Click(object sender, EventArgs e)
            {
                if (panelBasketDep.Visible == false && ChkEquisDep.Visible == false)
                {
                    DialogResult dialogResult2 = MessageBox.Show("No puede eliminar mas Deportes", "Advertencia", MessageBoxButtons.OK);
                }
                else if (panelBasketDep.Visible == true && ChkEquisDep.Visible == false)
                {
                    ChkEquisDep.Visible = true;
                    TituloDep.Text = "       Eliminar Deportes";
                    TituloDep.BackColor = Color.Maroon;
                }
                else if (ChkEquisDep.Visible == true)
                {
                    ChkEquisDep.Visible = false;
                    TituloDep.Text = "       Deportes";
                    TituloDep.BackColor = Color.FromArgb(1, 26, 37);
                }
            }

            private void ChkEquisDep_Click(object sender, EventArgs e)
            {
                if (equisdep.Visible)
                {
                    equisdep.Visible = false;
                    ImgEliminarDep.Visible = true;
                    okDep.Visible = false;
                }
                else
                {
                    equisdep.Visible = true;
                    ImgEliminarDep.Visible = false;
                    okDep.Visible = true;
                }
            }

            private void equisdep_Click(object sender, EventArgs e)
            {
                if (equisdep.Visible)
                {
                    equisdep.Visible = false;
                    ImgEliminarDep.Visible = true;
                    okDep.Visible = false;
                }
                else
                {
                    equisdep.Visible = true;
                    ImgEliminarDep.Visible = false;
                    okDep.Visible = true;
                }
            }
        //***********************************************************************************************************************

        //************************************************TORNEOS****************************************************************

            private void btnTorneoTor_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneos", "Advertencia", MessageBoxButtons.OK);
            }

            private void btnTorneoTor_MouseLeave(object sender, EventArgs e)
            {
                btnTorneoTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneosleaveazul.png"));
            }

            private void btnTorneoTor_MouseEnter(object sender, EventArgs e)
            {
                btnTorneoTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneosenterazul.png"));
            }

            private void btnEquiposTor_MouseEnter(object sender, EventArgs e)
            {
                btnEquiposTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Equiposentergris.png"));
                btnTorneoTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneosleaveazulentergris.png"));
            }

            private void btnEquiposTor_MouseLeave(object sender, EventArgs e)
            {
                btnEquiposTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Equiposleavegris.png"));
                btnTorneoTor.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneosleaveazul.png"));
            }

            private void btnEquiposTor_Click(object sender, EventArgs e)
            {
                pnlTorneos.Visible = false;
                pnlEquipos.Visible = true;
            }

            private void ImgTorneo_MouseEnter(object sender, EventArgs e)
            {
                panelTor.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgTorneo_MouseLeave(object sender, EventArgs e)
            {
                panelTor.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarTor_MouseEnter(object sender, EventArgs e)
            {
                panelAgregarTor.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgAgregarTor_MouseLeave(object sender, EventArgs e)
            {
                panelAgregarTor.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarTor_Click(object sender, EventArgs e)
            {
                if (ChkEquisTor.Visible == true)
                {
                    DialogResult dialogResult = MessageBox.Show("No puede agregar un torneo mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    Program.frmPrincipal.frmHerrTorneo.timer2.Stop();
                    Program.frmPrincipal.frmHerrTorneo.Visible = true;
                    Program.frmPrincipal.frmHerrTorneo.timer1.Start();
                }
            }

            private void ImgEliminarTor_MouseEnter(object sender, EventArgs e)
            {
                panelEliminarTor.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgEliminarTor_MouseLeave(object sender, EventArgs e)
            {
                panelEliminarTor.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgEliminarTor_Click(object sender, EventArgs e)
            {
                if (panelTor.Visible == false && ChkEquisTor.Visible == false)
                {
                    DialogResult dialogResult2 = MessageBox.Show("No puede eliminar mas Torneos", "Advertencia", MessageBoxButtons.OK);
                }
                else if (panelTor.Visible == true && ChkEquisTor.Visible == false)
                {
                    ChkEquisTor.Visible = true;
                    TituloTor.Text = "       Eliminar Torneos";
                    TituloTor.BackColor = Color.Maroon;
                }
                else if (ChkEquisTor.Visible == true)
                {
                    ChkEquisTor.Visible = false;
                    TituloTor.Text = "       Deportes - Torneos";
                    TituloTor.BackColor = Color.FromArgb(1, 26, 37);
                }
            }

            private void equisTor_Click(object sender, EventArgs e)
            {
                if (equisTor.Visible)
                {
                    equisTor.Visible = false;
                    ImgEliminarTor.Visible = true;
                    okTor.Visible = false;
                }
                else
                {
                    equisTor.Visible = true;
                    ImgEliminarTor.Visible = false;
                    okTor.Visible = true;
                }
            }

            private void ChkEquisTor_Click(object sender, EventArgs e)
            {
                if (equisTor.Visible)
                {
                    equisTor.Visible = false;
                    ImgEliminarTor.Visible = true;
                    okTor.Visible = false;
                }
                else
                {
                    equisTor.Visible = true;
                    ImgEliminarTor.Visible = false;
                    okTor.Visible = true;
                }
            }

            private void btnVolverTor_Click(object sender, EventArgs e)
            {
                pnlTorneos.Visible = false;
                pnlDeportes.Visible = true;
            }



        //***********************************************************************************************************************

        //************************************************EQUIPOS****************************************************************

            private void ImgEquipo_Click(object sender, EventArgs e)
            {
                pnlEquipos.Visible = false;
                pnlEquEquipos.Visible = true;
            }

            private void ImgEquipo_MouseEnter(object sender, EventArgs e)
            {
                panelEquipo.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgEquipo_MouseLeave(object sender, EventArgs e)
            {
                panelEquipo.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarEqu_MouseEnter(object sender, EventArgs e)
            {
                panelAgregarEqu.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgAgregarEqu_MouseLeave(object sender, EventArgs e)
            {
                panelAgregarEqu.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgAgregarEqu_Click(object sender, EventArgs e)
            {
                if (ChkequisEqu.Visible == true)
                {
                    DialogResult dialogResult = MessageBox.Show("No puede agregar un equipo mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    Program.frmPrincipal.frmHerrEquipos.timer2.Stop();
                    Program.frmPrincipal.frmHerrEquipos.Visible = true;
                    Program.frmPrincipal.frmHerrEquipos.timer1.Start();
                }
            }

            private void ImgEliminarEqu_MouseEnter(object sender, EventArgs e)
            {
                panelEliminarEqu.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgEliminarEqu_MouseLeave(object sender, EventArgs e)
            {
                panelEliminarEqu.BackColor = Color.FromArgb(2, 43, 63);
            }

            private void ImgEliminarEqu_Click(object sender, EventArgs e)
            {
                if (panelEquipo.Visible == false && ChkequisEqu.Visible == false)
                {
                    DialogResult dialogResult2 = MessageBox.Show("No puede eliminar mas Equipos", "Advertencia", MessageBoxButtons.OK);
                }
                else if (panelEquipo.Visible == true && ChkequisEqu.Visible == false)
                {
                    ChkequisEqu.Visible = true;
                    TituloEqu.Text = "       Eliminar Equipos";
                    TituloEqu.BackColor = Color.Maroon;
                }
                else if (ChkequisEqu.Visible == true)
                {
                    ChkequisEqu.Visible = false;
                    TituloEqu.Text = "       Deportes - Equipo";
                    TituloEqu.BackColor = Color.FromArgb(1, 26, 37);
                }
            }

            private void okEqu_Click(object sender, EventArgs e)
            {
                TituloEqu.Text = "       Deportes - Equipos";
                TituloEqu.BackColor = Color.FromArgb(1, 26, 37);
                okEqu.Visible = false;
                ChkequisEqu.Visible = false;
                equisEqu.Visible = false;
                ImgEliminarEqu.Visible = true;
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este deporte?", "Eliminar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    panelEquipo.Visible = false;
                    this.panelAgregarEqu.Location = new System.Drawing.Point(20, 41);
                    this.panelEliminarEqu.Location = new System.Drawing.Point(111, 41);
                }
            }

            private void okEqu_MouseEnter(object sender, EventArgs e)
            {
                panelEliminarEqu.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void okEqu_MouseLeave(object sender, EventArgs e)
            {
                panelEliminarEqu.BackColor = Color.FromArgb(2, 43, 63);
            }

        private void btnTorneoEqu_Click(object sender, EventArgs e)
        {
            pnlEquipos.Visible = false;
            pnlTorneos.Visible = true;
        }

        private void btnTorneoEqu_MouseEnter(object sender, EventArgs e)
        {
            btnTorneoEqu.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneosentergris.png"));
        }

        private void btnTorneoEqu_MouseLeave(object sender, EventArgs e)
        {
            btnTorneoEqu.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Torneoleavegris.png"));
        }

        private void btnEquipoEqu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Equipos", "Advertencia", MessageBoxButtons.OK);
        }

        private void btnEquipoEqu_MouseEnter(object sender, EventArgs e)
        {
            btnEquipoEqu.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Equiposenterazul.jpg"));
        }

        private void btnEquipoEqu_MouseLeave(object sender, EventArgs e)
        {
            btnEquipoEqu.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\Equiposleaveazul.jpg"));
        }

        private void btnVolverEqu_Click(object sender, EventArgs e)
        {
            pnlEquipos.Visible = false;
            pnlDeportes.Visible = true;
        }



        //**********************************************************************************************************************

        //******************************************EQUIPOS - EQUIPOS***********************************************************

        private void btnVolverEquipos_Click(object sender, EventArgs e)
        {
            pnlEquEquipos.Visible = false;
            pnlEquipos.Visible = true;
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 9, 14);
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 22, 33);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 9, 14);
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 9, 14);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 9, 14);
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(1, 9, 14);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            pnlEquEquipos.Visible = false;
            pnlJuego.Visible = true;
        }

        private void ImgTorneo_Click(object sender, EventArgs e)
        {
            pnlTorneos.Visible = false;
            pnlLiga.Visible = true;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            pnlLiga.Visible = false;
            pnlJuego.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pnlJuego.Visible = false;
            pnlLiga.Visible = true;
        }

        private void pnlEquEquipos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pnlLiga.Visible = false;
            pnlTorneos.Visible = true;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void loginleave_MouseEnter(object sender, EventArgs e)
        {
            if (loged == false)
            {
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\loginenter.jpg"));
            }
            else //loged == true
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\unloginenter.jpg"));
        }
        private void loginleave_MouseLeave(object sender, EventArgs e)
        {
            if (loged == false)
            {
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
            }
            else
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\unlogin.png"));
        }

        private void loginleave_MouseDown(object sender, MouseEventArgs e)
        {
            if (loged == false)
            {
                Program.frmPrincipal.frmLogin.Visible = true;
                Program.frmPrincipal.frmLogin.timer2.Stop();
                Program.frmPrincipal.frmLogin.timer1.Start();
            }
            if (loged)
            {
                MessageBox.Show("Sesion Cerrada Correctamente");
                Program.frmPrincipal.loged = false;
                Program.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
                Program.frmPrincipal.panelAgregarDep.Visible = false;
                Program.frmPrincipal.panelEliminarDep.Visible = false;
                Program.frmPrincipal.panelAgregarTor.Visible = false;
                Program.frmPrincipal.panelEliminarTor.Visible = false;
                Program.frmPrincipal.panelEliminarEqu.Visible = false;
                Program.frmPrincipal.panelAgregarEqu.Visible = false;
            }
        }

        //**********************************************************************************************************************
    }
}