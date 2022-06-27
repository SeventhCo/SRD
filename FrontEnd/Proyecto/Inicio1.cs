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
        public FormHerramientas frmHerrTorneo = new FormHerramientas();
        public Register frmRegister = new Register();
        public FormInicio()
        {
            InitializeComponent();
        }


        //************************************************FormInicio*************************************************************

            private void FormInicio_Load(object sender, EventArgs e)
            {
                panel4.Visible = false;
                logoenter.Visible = false;
                loginenter.Visible = false;
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
            }

            private void LblInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                pnlTorneos.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlEquipos.Visible = false;
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

            private void loginleave_MouseEnter(object sender, EventArgs e)
            {
                loginenter.Visible = true;
                loginleave.Visible = false;
            }

            private void loginenter_MouseLeave(object sender, EventArgs e)
            {
                loginleave.Visible = true;
                loginenter.Visible = false;
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

            private void loginenter_MouseDown(object sender, MouseEventArgs e)
            {
                Program.frmPrincipal.frmLogin.Visible = true;
                Program.frmPrincipal.frmLogin.timer2.Stop();
                Program.frmPrincipal.frmLogin.timer1.Start();
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

            private void unloginleave_MouseEnter(object sender, EventArgs e)
            {
                unloginenter.Visible = false;
                unloginleave.Visible = true;
            }

            private void unloginenter_MouseLeave(object sender, EventArgs e)
            {
                unloginleave.Visible = false;
                unloginenter.Visible = true;
            }

        //***********************************************************************************************************************

        //************************************************DEPORTES***************************************************************

            private void ImgBasketDep_Click(object sender, EventArgs e)
            {
                pnlDeportes.Visible = false;
                pnlTorneos.Visible = true;
            }

            private void ImgBasketDep_MouseEnter(object sender, EventArgs e)
            {
                panelBasketDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgBasketDep_MouseLeave(object sender, EventArgs e)
            {
                panelBasketDep.BackColor = Color.FromArgb(2, 43, 63);
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

        //**********************************************************************************************************************
    }
}