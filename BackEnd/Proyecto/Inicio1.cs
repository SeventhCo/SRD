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
        public bool eliminar = false;
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
                ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                pictureBox12.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
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
                
                if (eliminar)
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
        
            private void ImgEliminarDep_Click(object sender, EventArgs e)
            {

            if (eliminar)
            {
                int deposSeleccionados = 0;
                for (int i = 0; i < Program.frmPrincipal.frmHerramientas.elimDepos.Count; i++)
                {
                    Program.frmPrincipal.frmHerramientas.Deposck[Program.frmPrincipal.frmHerramientas.depos.IndexOf(Program.frmPrincipal.frmHerramientas.elimDepos[i])].Dispose(); ;
                    Program.frmPrincipal.frmHerramientas.Deposck.Remove(Program.frmPrincipal.frmHerramientas.Deposck[Program.frmPrincipal.frmHerramientas.depos.IndexOf(Program.frmPrincipal.frmHerramientas.elimDepos[i])]);
                    Program.frmPrincipal.frmHerramientas.depos.Remove(Program.frmPrincipal.frmHerramientas.elimDepos[i]);
                    Program.frmPrincipal.frmHerramientas.elimDepos[i].Dispose();
                    Program.frmPrincipal.frmHerramientas.cantBotones--;
                    deposSeleccionados++;
                }
                Program.frmPrincipal.frmHerramientas.elimDepos.Clear();
                
                eliminar = false;
                Program.frmPrincipal.frmHerramientas.eliminar = false;
                for (int i = 0; i < Program.frmPrincipal.frmHerramientas.Deposck.Count; i++)
                {
                    Program.frmPrincipal.frmHerramientas.Deposck[i].Visible = false;
                }
                ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                if (deposSeleccionados == 0) MessageBox.Show("No selecciono ningun deporte");
                else MessageBox.Show("Deportes eliminados correctamente");

                for (int i = 1; i < Program.frmPrincipal.frmHerramientas.depos.Count; i++)
                {
                    int cantBotones = Program.frmPrincipal.frmHerramientas.cantBotones;
                    for (int b = 2; b < cantBotones; b++)
                    {
                        Program.frmPrincipal.frmHerramientas.depos[b-2].Location = new System.Drawing.Point(17 + 78 * (b % 8), 36 + 78 * (b / 8));
                    }
                    
                }
            }

            else
            {
                eliminar = true;
                Program.frmPrincipal.frmHerramientas.eliminar = true;
                ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < Program.frmPrincipal.frmHerramientas.Deposck.Count; i++) Program.frmPrincipal.frmHerramientas.Deposck[i].Visible = true;

            }
                
            }

            

            
        //***********************************************************************************************************************

        //************************************************TORNEOS****************************************************************

            private void btnTorneoTor_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneos", "Advertencia", MessageBoxButtons.OK);
            }
        
            private void btnEquiposTor_Click(object sender, EventArgs e)
            {
                pnlTorneos.Visible = false;
                pnlEquipos.Visible = true;
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
                if (eliminar)
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
                if (eliminar)
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
        
        private void btnEquipoEqu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Equipos", "Advertencia", MessageBoxButtons.OK);
        }
        private void btnVolverEqu_Click(object sender, EventArgs e)
        {
            pnlEquipos.Visible = false;
            pnlLiga.Visible = true;
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

        private void panelEliminarEqu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (eliminar)
            {
                int deposSeleccionados = 0;
                for (int i = 0; i < Program.frmPrincipal.frmHerrEquipos.elimEqui.Count; i++)
                {
                    Program.frmPrincipal.frmHerrEquipos.Equick[Program.frmPrincipal.frmHerrEquipos.equis.IndexOf(Program.frmPrincipal.frmHerrEquipos.elimEqui[i])].Dispose(); ;
                    Program.frmPrincipal.frmHerrEquipos.Equick.Remove(Program.frmPrincipal.frmHerrEquipos.Equick[Program.frmPrincipal.frmHerrEquipos.equis.IndexOf(Program.frmPrincipal.frmHerrEquipos.elimEqui[i])]);
                    Program.frmPrincipal.frmHerrEquipos.equis.Remove(Program.frmPrincipal.frmHerrEquipos.elimEqui[i]);
                    Program.frmPrincipal.frmHerrEquipos.elimEqui[i].Dispose();
                    Program.frmPrincipal.frmHerrEquipos.cantBotones--;
                    deposSeleccionados++;
                }
                Program.frmPrincipal.frmHerrEquipos.elimEqui.Clear();

                eliminar = false;
                Program.frmPrincipal.frmHerrEquipos.eliminar = false;
                for (int i = 0; i < Program.frmPrincipal.frmHerrEquipos.Equick.Count; i++)
                {
                    Program.frmPrincipal.frmHerrEquipos.Equick[i].Visible = false;
                }
                pictureBox12.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                if (deposSeleccionados == 0) MessageBox.Show("No selecciono ningun equipo");
                else MessageBox.Show("equipos eliminados correctamente");

                for (int i = 1; i < Program.frmPrincipal.frmHerrEquipos.equis.Count; i++)
                {
                    int cantBotones = Program.frmPrincipal.frmHerrEquipos.cantBotones;
                    for (int b = 2; b < cantBotones; b++)
                    {
                        Program.frmPrincipal.frmHerrEquipos.equis[b - 2].Location = new System.Drawing.Point(17 + 78 * (b % 8), 36 + 78 * (b / 8));
                    }

                }
            }

            else
            {
                eliminar = true;
                Program.frmPrincipal.frmHerrEquipos.eliminar= true;
                pictureBox12.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < Program.frmPrincipal.frmHerrEquipos.Equick.Count; i++) Program.frmPrincipal.frmHerrEquipos.Equick[i].Visible = true;

            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            
            if (eliminar)
            {
                int deposSeleccionados = 0;
                for (int i = 0; i < Program.frmPrincipal.frmHerrTorneo.elimtorn.Count; i++)
                {
                    Program.frmPrincipal.frmHerrTorneo.tornck[Program.frmPrincipal.frmHerrTorneo.torns.IndexOf(Program.frmPrincipal.frmHerrTorneo.elimtorn[i])].Dispose(); ;
                    Program.frmPrincipal.frmHerrTorneo.tornck.Remove(Program.frmPrincipal.frmHerrTorneo.tornck[Program.frmPrincipal.frmHerrTorneo.torns.IndexOf(Program.frmPrincipal.frmHerrTorneo.elimtorn[i])]);
                    Program.frmPrincipal.frmHerrTorneo.torns.Remove(Program.frmPrincipal.frmHerrTorneo.elimtorn[i]);
                    Program.frmPrincipal.frmHerrTorneo.elimtorn[i].Dispose();
                    Program.frmPrincipal.frmHerrTorneo.cantBotones--;
                    deposSeleccionados++;
                }
                Program.frmPrincipal.frmHerrTorneo.elimtorn.Clear();

                eliminar = false;
                Program.frmPrincipal.frmHerrTorneo.eliminar = false;
                for (int i = 0; i < Program.frmPrincipal.frmHerrTorneo.tornck.Count; i++)
                {
                    Program.frmPrincipal.frmHerrTorneo.tornck[i].Visible = false;
                }
                pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                if (deposSeleccionados == 0) MessageBox.Show("No selecciono ningun equipo");
                else MessageBox.Show("torneos eliminados correctamente");

                for (int i = 1; i < Program.frmPrincipal.frmHerrTorneo.torns.Count; i++)
                {
                    int cantBotones = Program.frmPrincipal.frmHerrTorneo.cantBotones;
                    for (int b = 2; b < cantBotones; b++)
                    {
                        Program.frmPrincipal.frmHerrTorneo.torns[b - 2].Location = new System.Drawing.Point(17 + 78 * (b % 8), 36 + 78 * (b / 8));
                    }

                }
            }

            else
            {
                eliminar = true;
                Program.frmPrincipal.frmHerrTorneo.eliminar = true;
                pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < Program.frmPrincipal.frmHerrTorneo.tornck.Count; i++) Program.frmPrincipal.frmHerrTorneo.tornck[i].Visible = true;

            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            pnlLiga.Visible = false;
            pnlEquipos.Visible = true;
        }

        //**********************************************************************************************************************
    }
}