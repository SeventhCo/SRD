using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FormInicio : Form
    {
        public List<Panel> depos = new List<Panel>();
        public List<Panel> elimDepos = new List<Panel>();
        public List<PictureBox> deposImg = new List<PictureBox>();

        public List<Panel> torns = new List<Panel>();
        public List<Panel> elimTorns = new List<Panel>();
        public List<PictureBox> tornsImg = new List<PictureBox>();

        public List<Panel> equis = new List<Panel>();
        public List<Panel> elimEquis = new List<Panel>();
        public List<PictureBox> equisImg = new List<PictureBox>();

        public bool loged = false;
        public bool eliminar = false;

        public int cantDepo = 0;
        public int cantTorn = 0;
        public int cantEqui = 0;

        public FormInicio()
        {
            InitializeComponent();
        }

        public void clickDepo(Panel depo, PictureBox depoElim)
        {
            if (eliminar)
            {
                if (depoElim.Name.Equals(depo.Name + "0"))
                {
                    depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                    depoElim.Name = depo.Name + "1";
                    elimDepos.Add(depo);
                }
                else if (depoElim.Name.Equals(depo.Name + "1"))
                {
                    depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    depoElim.Name = depo.Name + "0";
                    elimDepos.Remove(depo);
                }
            }
            else
            {
                Program.Blank.frmPrincipal.pnlDeportes.Visible = false;
            }
        }

        public void cargaDepo()
        {
            for (int i = deposImg.Count - 1; i >= 0; i--)
            {
                deposImg[i].Dispose();
                deposImg.Remove(deposImg[i]);
            }
            for (int i = depos.Count - 1; i >= 0; i--)
            {
                depos[i].Dispose();
                depos.Remove(depos[i]);
            }
            for (int i = elimDepos.Count - 1; i >= 0; i--)
            {
                elimDepos[i].Dispose();
                elimDepos.Remove(elimDepos[i]);
            }
            cantDepo = 0;

            for (int i = 0; i < Logica.consultaMaxIndex("Select * from deporte"); i++)
            {
                Panel depo = new Panel();
                depo.Parent = Program.Blank.frmPrincipal.SubPanelDep;
                depo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) depo.Location = new System.Drawing.Point(17 + 78 * ((cantDepo + 2) % 8), 36 + 93 * ((cantDepo + 2) / 8));
                else depo.Location = new System.Drawing.Point(17 + 78 * ((cantDepo) % 8), 36 + 93 * ((cantDepo) / 8));
                depo.Name = Logica.consulta("Select * from deporte", 0, i);
                depo.Size = new System.Drawing.Size(64, 80);
                depo.TabIndex = cantDepo;
                cantDepo++;
                depos.Add(depo);

                PictureBox depoElim = new PictureBox();
                depoElim.Parent = depo;
                depoElim.Visible = false;
                depoElim.TabIndex = 1;
                depoElim.Location = new System.Drawing.Point(46, 0);
                depoElim.Size = new System.Drawing.Size(18, 18);
                depoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                depoElim.Name = depo.Name + "0";
                deposImg.Add(depoElim);

                /* aqui se pone el logo del deporte */
                PictureBox imgDepo = new PictureBox();
                imgDepo.Name = depo.Name + "img";
                imgDepo.Parent = depo;
                imgDepo.Visible = true;
                imgDepo.Location = new System.Drawing.Point(0, 0);
                imgDepo.Size = new System.Drawing.Size(64, 64);
                imgDepo.SizeMode = PictureBoxSizeMode.StretchImage;
                imgDepo.Image = Logica.conByteImg(Convert.FromBase64String(Logica.consulta("Select * from deporte", 4, i)));

                Label nomCorto = new Label();
                nomCorto.Parent = depo;
                nomCorto.Text = Logica.consulta("Select * from deporte", 1, i);
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDepo(depo, depoElim);
                });

                imgDepo.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDepo(depo, depoElim);
                });

                depoElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDepo(depo, depoElim);
                });
            }
        }

        public void clickTorn(Panel torn, PictureBox tornElim)
        {
            if (eliminar)
            {
                if (tornElim.Name.Equals(torn.Name + "0"))
                {
                    tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                    tornElim.Name = torn.Name + "1";
                    elimTorns.Add(torn);
                }
                else if (tornElim.Name.Equals(torn.Name + "1"))
                {
                    tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    tornElim.Name = torn.Name + "0";
                    elimTorns.Remove(torn);
                }
            }
            else
            {
                Program.Blank.frmPrincipal.pnlDeportes.Visible = false;
            }
        }

        

        public void cargaTorn()
        {
            for (int i = tornsImg.Count - 1; i >= 0; i--)
            {
                tornsImg[i].Dispose();
                tornsImg.Remove(tornsImg[i]);
            }
            for (int i = torns.Count - 1; i >= 0; i--)
            {
                torns[i].Dispose();
                torns.Remove(torns[i]);
            }
            for (int i = elimTorns.Count - 1; i >= 0; i--)
            {
                elimTorns[i].Dispose();
                elimTorns.Remove(elimTorns[i]);
            }
            cantTorn = 0;

            for (int i = 0; i < Logica.consultaMaxIndex("Select * from torneo"); i++)
            {
                Panel torn = new Panel();
                torn.Parent = Program.Blank.frmPrincipal.SubPanelTor;
                torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) torn.Location = new System.Drawing.Point(17 + 78 * ((cantTorn + 2) % 8), 36 + 93 * ((cantTorn + 2) / 8));
                else torn.Location = new System.Drawing.Point(17 + 78 * ((cantTorn) % 8), 36 + 93 * ((cantTorn) / 8));
                torn.Name = Logica.consulta("Select * from torneo", 0, i);
                torn.Size = new System.Drawing.Size(64, 80);
                cantTorn++;
                torns.Add(torn);

                PictureBox tornElim = new PictureBox();
                tornElim.Parent = torn;
                tornElim.Visible = false;
                tornElim.TabIndex = 1;
                tornElim.Location = new System.Drawing.Point(46, 0);
                tornElim.Size = new System.Drawing.Size(18, 18);
                tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                tornElim.Name = torn.Name + "0";
                tornsImg.Add(tornElim);

                /* aqui se pone el logo del torneo */
                PictureBox imgTorn = new PictureBox();
                imgTorn.Name = torn.Name + "img";
                imgTorn.Parent = torn;
                imgTorn.Visible = true;
                imgTorn.Location = new System.Drawing.Point(0, 0);
                imgTorn.Size = new System.Drawing.Size(64, 64);
                imgTorn.SizeMode = PictureBoxSizeMode.StretchImage;
                imgTorn.Image = Logica.conByteImg(Convert.FromBase64String(Logica.consulta("Select * from torneo", 5, i)));

                Label nomCorto = new Label();
                nomCorto.Parent = torn;
                nomCorto.Text = Logica.consulta("Select * from torneo", 1, i);
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickTorn(torn, tornElim);
                });

                imgTorn.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickTorn(torn, tornElim);
                });

                tornElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickTorn(torn, tornElim);
                });
            }
        }

        public void clickEqui(Panel equi, PictureBox equiElim)
        {
            if (eliminar)
            {
                if (equiElim.Name.Equals(equi.Name + "0"))
                {
                    equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                    equiElim.Name = equi.Name + "1";
                    elimEquis.Add(equi);
                }
                else if (equiElim.Name.Equals(equi.Name + "1"))
                {
                    equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    equiElim.Name = equi.Name + "0";
                    elimEquis.Remove(equi);
                }
            }
            else
            {
                Program.Blank.frmPrincipal.pnlDeportes.Visible = false;
            }
        }

        public void cargaEqui()
        {
            for (int i = equisImg.Count - 1; i >= 0; i--)
            {
                tornsImg[i].Dispose();
                equisImg.Remove(equisImg[i]);
            }
            for (int i = equis.Count - 1; i >= 0; i--)
            {
                equis[i].Dispose();
                equis.Remove(equis[i]);
            }
            for (int i = elimEquis.Count - 1; i >= 0; i--)
            {
                elimEquis[i].Dispose();
                elimEquis.Remove(elimEquis[i]);
            }
            cantEqui = 0;

            for (int i = 0; i < Logica.consultaMaxIndex("Select * from equipo"); i++)
            {
                Panel equi = new Panel();
                equi.Parent = Program.Blank.frmPrincipal.SubPanelEqu;
                equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui + 2) % 8), 36 + 93 * ((cantEqui + 2) / 8));
                else equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui) % 8), 36 + 93 * ((cantEqui) / 8));
                equi.Name = Logica.consulta("Select * from equipo", 0, i);
                equi.Size = new System.Drawing.Size(64, 80);
                cantEqui++;
                equis.Add(equi);

                PictureBox equiElim = new PictureBox();
                equiElim.Parent = equi;
                equiElim.Visible = false;
                equiElim.TabIndex = 1;
                equiElim.Location = new System.Drawing.Point(46, 0);
                equiElim.Size = new System.Drawing.Size(18, 18);
                equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                equiElim.Name = equi.Name + "0";
                equisImg.Add(equiElim);

                /* aqui se pone el logo del equipo */
                PictureBox imgEqui = new PictureBox();
                imgEqui.Name = equi.Name + "img";
                imgEqui.Parent = equi;
                imgEqui.Visible = true;
                imgEqui.Location = new System.Drawing.Point(0, 0);
                imgEqui.Size = new System.Drawing.Size(64, 64);
                imgEqui.SizeMode = PictureBoxSizeMode.StretchImage;
                imgEqui.Image = Logica.conByteImg(Convert.FromBase64String(Logica.consulta("Select * from equipo", 2, i)));

                Label nomCorto = new Label();
                nomCorto.Parent = equi;
                nomCorto.Text = Logica.consulta("Select * from equipo", 1, i);
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickEqui(equi, equiElim);
                });

                imgEqui.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickEqui(equi, equiElim);
                });

                equiElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickEqui(equi, equiElim);
                });
            }
        }
        //************************************************FormInicio*************************************************************

        private void FormInicio_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            logoenter.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
            pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
            Program.Blank.frmLogin.VerContra.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ojoabierto.png"));
            cargaDepo();
            cargaTorn();
            cargaEqui();
        }

        //*********************************************************************************************************************** 

        //****************************************************MENU***************************************************************

            private void panelInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                pnlEquEquipos.Visible = false;
                pnlJuego.Visible = false;
                pnlLiga.Visible = false;
            }

            private void LblInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                pnlEquEquipos.Visible = false;
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
            Program.Blank.Close();
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
                pnlEquEquipos.Visible = false;
            }

            private void LblDeportes_MouseDown(object sender, MouseEventArgs e)
            {
                pnlDeportes.Visible = true;
                pnlInicio.Visible = false;
                pnlEquEquipos.Visible = false;
            }



        //***********************************************************************************************************************

        //************************************************DEPORTES***************************************************************

            

            private void ImgAgregarDep_MouseEnter(object sender, EventArgs e)
            {
                panelAgregarDep.BackColor = Color.FromArgb(2, 39, 57);
            }

            private void ImgAgregarDep_MouseLeave(object sender, EventArgs e)
            {
                panelAgregarDep.BackColor = Color.FromArgb(2, 43, 63);
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
                int deposSeleccionados = elimDepos.Count;
                for (int i = elimDepos.Count - 1; i >= 0; i--) Logica.rmDepo(elimDepos[i].Name);
                cargaDepo();
                eliminar = false;

                ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                cargaDepo();
                if (deposSeleccionados == 0) MessageBox.Show("No selecciono ningun deporte");
                else if (deposSeleccionados == 1) MessageBox.Show("Deporte eliminado correctamente");
                else MessageBox.Show("Deportes eliminados correctamente");
            }
            else
            {
                eliminar = true;
                ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < deposImg.Count; i++) deposImg[i].Visible = true;
            }
                
            }

            

            
        //***********************************************************************************************************************

        //************************************************TORNEOS****************************************************************

            private void btnTorneoTor_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneos", "Advertencia", MessageBoxButtons.OK);
            }

            private void ImgAgregarTor_Click(object sender, EventArgs e)
            {
                if (eliminar)
                {
                    DialogResult dialogResult = MessageBox.Show("No puede agregar un torneo mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    Program.Blank.frmHerrTorneo.Visible = true;
                }
            }
        //***********************************************************************************************************************

        //************************************************EQUIPOS****************************************************************
        
        
        private void btnEquipoEqu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Equipos", "Advertencia", MessageBoxButtons.OK);
        }
        



        //**********************************************************************************************************************

        //******************************************EQUIPOS - EQUIPOS***********************************************************

        

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
        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pnlLiga.Visible = false;
            pnlDeportes.Visible = true;
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
                Program.Blank.frmLogin.BringToFront();
                Program.Blank.frmLogin.Opacity = 1;
                Program.Blank.frmLogin.Visible = true;
                Program.Blank.frmPrincipal.Enabled = false;
            }
            if (loged)
            {
                Program.Blank.frmPrincipal.loged = false;
                Program.Blank.frmPrincipal.loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
                Program.Blank.frmPrincipal.panelAgregarDep.Visible = false;
                Program.Blank.frmPrincipal.panelEliminarDep.Visible = false;
                Program.Blank.frmPrincipal.panel7.Visible = false;
                Program.Blank.frmPrincipal.panel2.Visible = false;
                Program.Blank.frmPrincipal.panel28.Visible = false;
                Program.Blank.frmPrincipal.panel22.Visible = false;
                Program.Blank.frmPrincipal.cargaDepo();
                Program.Blank.frmPrincipal.cargaTorn();
                Program.Blank.frmPrincipal.cargaEqui();
                MessageBox.Show("Sesion Cerrada Correctamente");
            }
        }

        

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            pnlLiga.Visible = false;
            pnlDeportes.Visible = true;
        }

        private void panel23_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(58, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(166, 0);
            panel25.Location = new Point(296, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(166, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void panel24_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(60, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(296, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(166, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelTor.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelDep.Visible = false;
            
        }

        private void panel25_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(60, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(166, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));


            SubPanelTor.Visible = false;
            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = true;
        }

        private void panel26_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(60, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(390, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(166, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void panel27_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(53, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(390, 0);
            panel27.Location = new Point(520, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(166, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(58, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(166, 0);
            panel25.Location = new Point(296, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(166, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(60, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(296, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(166, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
        
            SubPanelTor.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelDep.Visible = false;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(60, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(426, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(166, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelEqu.Visible = true;
            SubPanelTor.Visible = false;
            SubPanelDep.Visible = false;
            
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(60, 10);
            label5.Location = new Point(35, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(390, 0);
            panel27.Location = new Point(556, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(166, 31);
            panel27.Size = new Size(130, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Location = new Point(40, 10);
            label2.Location = new Point(42, 10);
            label3.Location = new Point(42, 10);
            label4.Location = new Point(42, 10);
            label5.Location = new Point(53, 10);

            panel24.Location = new Point(130, 0);
            panel25.Location = new Point(260, 0);
            panel26.Location = new Point(390, 0);
            panel27.Location = new Point(520, 0);

            panel23.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel24.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel25.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel26.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            panel27.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));

            panel23.Size = new Size(130, 31);
            panel24.Size = new Size(130, 31);
            panel25.Size = new Size(130, 31);
            panel26.Size = new Size(130, 31);
            panel27.Size = new Size(166, 31);

            panel23.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel24.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel25.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel26.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            panel27.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (eliminar)
                {
                    MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    Program.Blank.frmHerramientas.pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                    Program.Blank.frmHerramientas.Visible = true;
                    this.Enabled = false;
                }
            }
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            if (eliminar)
            {
                MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                Program.Blank.frmHerramientas.Visible = true;
                this.Enabled = false;
            }
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            if (eliminar)
            {
                MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                Program.Blank.frmHerrTorneo.pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                Program.Blank.frmHerrTorneo.Visible = true;
                this.Enabled = false;
            }
        }

        private void label35_MouseDown(object sender, MouseEventArgs e)
        {
            if (eliminar)
            {
                MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                Program.Blank.frmHerrTorneo.Visible = true;
                this.Enabled = false;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (eliminar)
            {
                int tornsSeleccionados = elimTorns.Count;
                for (int i = elimTorns.Count - 1; i >= 0; i--) Logica.rmTorn(elimTorns[i].Name);
                eliminar = false;
                pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                cargaTorn();
                if (tornsSeleccionados == 0) MessageBox.Show("No selecciono ningun Torneo");
                else if (tornsSeleccionados == 1) MessageBox.Show("Torneo eliminado correctamente");
                else MessageBox.Show("Torneos eliminados correctamente");
            }
            else
            {
                eliminar = true;
                pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < tornsImg.Count; i++) tornsImg[i].Visible = true;
            }
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (eliminar)
                {
                    MessageBox.Show("No puede agregar un Equipo mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    Program.Blank.frmHerrEquipos.pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                    Program.Blank.frmHerrEquipos.Visible = true;
                    this.Enabled = false;
                }
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (eliminar)
            {
                int equisSeleccionados = elimEquis.Count;
                for (int i = elimEquis.Count - 1; i >= 0; i--) Logica.rmEqui(elimEquis[i].Name);
                eliminar = false;
                pictureBox16.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                cargaEqui();
                if (equisSeleccionados == 0) MessageBox.Show("No selecciono ningun Equipo");
                else if (equisSeleccionados == 1) MessageBox.Show("Equipo eliminado correctamente");
                else MessageBox.Show("Equipos eliminados correctamente");
            }
            else
            {
                eliminar = true;
                pictureBox16.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < equisImg.Count; i++) equisImg[i].Visible = true;
            }
        }



        //**********************************************************************************************************************
    }
}