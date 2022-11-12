using Newtonsoft.Json;
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

        public List<Panel> torns = new List<Panel>();

        public List<Panel> equis = new List<Panel>();

        public List<Panel> depora = new List<Panel>();

        public bool loged = false;
        public int rol = -1;
        public bool eliminar = false;

        public int cantDepo = 0;
        public int cantDepor = 0;
        public int cantTorn = 0;
        public int cantEqui = 0;

        public FormInicio()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            Program.Blank.torn = new Torneo();
            Program.Blank.Partido = new Partido();
            Program.Blank.Equipo = new Equipo();
            Program.Blank.Depor = new Deportista();

            Program.Blank.Depor.MdiParent = Program.Blank;
            Program.Blank.Depor.Show();
            Program.Blank.Depor.Visible = false;

            Program.Blank.Equipo.MdiParent = Program.Blank;
            Program.Blank.Equipo.Show();
            Program.Blank.Equipo.Visible = false;

            Program.Blank.Partido.MdiParent = Program.Blank;
            Program.Blank.Partido.Show();
            Program.Blank.Partido.Visible = false;

            Program.Blank.torn.MdiParent = Program.Blank;
            Program.Blank.torn.Show();
            Program.Blank.torn.Visible = false;
            
        }
        public void actualizar()
        {
            Idioma.controles(pnlInicio);
            Idioma.controles(pnlDeportes);
            Idioma.controles(pnlInicoArriba);
            Idioma.controles(pnlDirectorios);
            Idioma.controles(PanelLateral);
            Idioma.controles(SubPanelTor);
            Idioma.controles(SubPanelEqu);
            Idioma.controles(SubPanelDep);
            Idioma.controles(pnlDeportistasIni);
            Idioma.controles(pnlEventosIni);
            Idioma.controles(pnlEquiposIni);
            Idioma.controles(pnlTorneosIni);
        }

        public void clickDepo(Panel depo, PictureBox depoElim)
        {
            Program.Blank.Depo.deporte = depo.Name;
            Program.Blank.Depo.cargaTorn();
            string tipo;
            dynamic[,] depoInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from deporte WHERE nombreDep = '" + depo.Name + "'"));
            Program.Blank.Depo.pbDepoLogo.Image = Auxiliar.conByteImg(Convert.FromBase64String(depoInfo[5, 0]));
            if (depoInfo[3, 0] == 0) tipo = "Equipo";
            else tipo = "Individual";

            Program.Blank.Depo.lblInfoDepo.Text =
                "Deporte : " + depo.Name + "\n" +
                "Nombre Corto : " + depoInfo[2, 0] + "\n" +
                "Tipo de deporte : " + tipo + "\n" +
                "Numero de Titulares : " + depoInfo[4, 0];
            Program.Blank.Depo.lblDepoInfo.Text = depoInfo[6, 0] + "";
            Program.Blank.Depo.Show();
            Program.Blank.Depo.Location = new Point(0, 0);
        }

        public void cargaDepo()
        {

            pictureBox1.Image = Auxiliar.conByteImg(Convert.FromBase64String(apiPublicidad.randomSplit()));
            cantDepo = 0;

            for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from deporte"); i++)
            {
                dynamic[,] depoInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from deporte"));
                Panel depo = new Panel();
                depo.Visible = false;
                depo.Parent = Program.Blank.frmPrincipal.SubPanelDep;
                depo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                depo.Location = new System.Drawing.Point(17 + 78 * ((cantDepo) % 8), 7 + 93 * ((cantDepo) / 8));
                depo.Name = depoInfo[1,i];
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

                /* aqui se pone el logo del deporte */
                PictureBox imgDepo = new PictureBox();
                imgDepo.Name = depo.Name + "img";
                imgDepo.Parent = depo;
                imgDepo.Visible = true;
                imgDepo.Location = new System.Drawing.Point(0, 0);
                imgDepo.Size = new System.Drawing.Size(64, 64);
                imgDepo.SizeMode = PictureBoxSizeMode.StretchImage;
                imgDepo.Image = Auxiliar.conByteImg(Convert.FromBase64String(depoInfo[5,i]));

                Label nomCorto = new Label();
                nomCorto.Parent = depo;
                nomCorto.Text = depoInfo[2, i];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                depo.Visible = true;

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
            limpiar();
            Program.Blank.torn.torneo = torn.Name;
            dynamic[,] infoTorneo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from Torneo where nombreTorn = '" + torn.Name + "'"));
            Program.Blank.torn.lblInfoTorn.Text =
                "Nombre : " + infoTorneo[0, 0] + "\n" +
                "Cantidad de fases : " + apiResultados.consultaMaxIndex("Select idfase from fase where nombreTorn = '" + infoTorneo[0, 0] + "'") + "\n" +
                "Deporte : " + infoTorneo[5, 0] + "\n" +
                "Estado : " + infoTorneo[4, 0];
            Program.Blank.torn.pbDepoLogo.Image = Auxiliar.conByteImg(Convert.FromBase64String(infoTorneo[3, 0]));
            Program.Blank.torn.Show();
            Program.Blank.torn.deporte = infoTorneo[5, 0];
            Program.Blank.torn.estado = infoTorneo[4, 0];
            Program.Blank.torn.Location = new Point(0, 0);
            Program.Blank.torn.inicializar();
            Program.Blank.torn.arriba = true;
            for (int i = 0; i < Program.Blank.torn.Equipos.Count; i++)
            {
                Program.Blank.torn.Equipos[i].Enabled = false;
            }
        }

        public void cargaTorn()
        {
            cantTorn = 0;

            dynamic[,] tornInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from Torneo"));
            for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from Torneo"); i++)
            {
                Panel torn = new Panel();
                torn.Parent = Program.Blank.frmPrincipal.SubPanelTor;
                torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                torn.Location = new System.Drawing.Point(17 + 78 * ((cantTorn) % 8), 7 + 93 * ((cantTorn) / 8));
                torn.Name = tornInfo[0, i];
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

                /* aqui se pone el logo del torneo */
                PictureBox imgTorn = new PictureBox();
                imgTorn.Name = torn.Name + "img";
                imgTorn.Parent = torn;
                imgTorn.Visible = true;
                imgTorn.Location = new System.Drawing.Point(0, 0);
                imgTorn.Size = new System.Drawing.Size(64, 64);
                imgTorn.SizeMode = PictureBoxSizeMode.StretchImage;
                imgTorn.Image = Auxiliar.conByteImg(Convert.FromBase64String(tornInfo[3, i]));

                Label nomCorto = new Label();
                nomCorto.Parent = torn;
                nomCorto.Text = tornInfo[1, i];
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
                }
                else if (equiElim.Name.Equals(equi.Name + "1"))
                {
                    equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    equiElim.Name = equi.Name + "0";
                }
            }
            else
            {
                limpiar();
                Program.Blank.Equipo.equipo = equi.Name;
                Program.Blank.Equipo.cargarEquipo();
                Program.Blank.Equipo.Show();
                Program.Blank.Equipo.Location = new Point(0, 0);
            }
        }

        public void cargaEqui()
        {
            cantEqui = 0;

            for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from equipo"); i++)
            {
                dynamic[,] equiInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from equipo"));
                Panel equi = new Panel();
                equi.Parent = Program.Blank.frmPrincipal.SubPanelEqu;
                equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                 equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui) % 8), 7 + 93 * ((cantEqui) / 8));
                equi.Name = equiInfo[0, i];
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

                /* aqui se pone el logo del equipo */
                PictureBox imgEqui = new PictureBox();
                imgEqui.Name = equi.Name + "img";
                imgEqui.Parent = equi;
                imgEqui.Visible = true;
                imgEqui.Location = new System.Drawing.Point(0, 0);
                imgEqui.Size = new System.Drawing.Size(64, 64);
                imgEqui.SizeMode = PictureBoxSizeMode.StretchImage;
                imgEqui.Image = Auxiliar.conByteImg(Convert.FromBase64String(equiInfo[2, i]));

                Label nomCorto = new Label();
                nomCorto.Parent = equi;
                nomCorto.Text = equiInfo[1, i];
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

        public void clickDeport(Panel depor, PictureBox deporElim)
        {
            limpiar();
            Program.Blank.Depor.cedula = depor.Name;
            Program.Blank.Depor.cargarEquipo();
            Program.Blank.Depor.Show();
            Program.Blank.Depor.Location = new Point(0, 0);
        }

        public void cargaDeport()
        {
            cantDepor = 0;

            for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from deportista"); i++)
            {
                dynamic[,] deporInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from deportista"));
                
                Panel depor = new Panel();
                depor.Parent = Program.Blank.frmPrincipal.subPanelDeportistas;
                depor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                depor.Location = new System.Drawing.Point(17 + 78 * ((cantDepor) % 8), 7 + 93 * ((cantDepor) / 8));
                depor.Name = deporInfo[0, i]+"";
                depor.Size = new System.Drawing.Size(64, 80);
                cantDepor++;
                depora.Add(depor);

                PictureBox deporElim = new PictureBox();
                deporElim.Parent = depor;
                deporElim.Visible = false;
                deporElim.TabIndex = 1;
                deporElim.Location = new System.Drawing.Point(46, 0);
                deporElim.Size = new System.Drawing.Size(18, 18);
                deporElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                deporElim.Name = depor.Name + "0";

                /* aqui se pone el logo del deportista */
                PictureBox imgDepor = new PictureBox();
                imgDepor.Name = depor.Name + "img";
                imgDepor.Parent = depor;
                imgDepor.Visible = true;
                imgDepor.Location = new System.Drawing.Point(0, 0);
                imgDepor.Size = new System.Drawing.Size(64, 64);
                imgDepor.SizeMode = PictureBoxSizeMode.StretchImage;
                imgDepor.Image = Auxiliar.conByteImg(Convert.FromBase64String(deporInfo[4, i]));

                Label nomCorto = new Label();
                nomCorto.Parent = depor;
                nomCorto.Text = deporInfo[1, i];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDeport(depor, deporElim);
                });

                imgDepor.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDeport(depor, deporElim);
                });

                deporElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    clickDeport(depor, deporElim);
                });
            }
        }
        //************************************************FormInicio*************************************************************

        private void FormInicio_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            logoenter.Visible = false;
            panel6.Visible = false;
            Program.Blank.frmLogin.VerContra.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\ojoabierto.png"));
            cargaDepo();
            cargaTorn();
            cargaEqui();
            cargaDeport();
        }

        //*********************************************************************************************************************** 

        //****************************************************MENU***************************************************************

            private void panelInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
            }

            private void LblInicio_Click(object sender, EventArgs e)
            {
                pnlInicio.Visible = true;
                pnlDeportes.Visible = false;
                
        }
            private void panelInicio_MouseEnter(object sender, EventArgs e)
            {
                pnlInicoArriba.BackColor = Color.FromArgb(240, 172, 3);
                panel4.Visible = true;
            }

            private void panelInicio_MouseLeave(object sender, EventArgs e)
            {
                pnlInicoArriba.BackColor = Color.FromArgb(255, 183, 3);
                panel4.Visible = false;
            }

            private void LblInicio_MouseEnter(object sender, EventArgs e)
            {
                pnlInicoArriba.BackColor = Color.FromArgb(240, 172, 3);
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
                pnlDirectorios.BackColor = Color.FromArgb(240, 172, 3);
                panel6.Visible = true;
            }
        

            private void panelDeportes_MouseLeave(object sender, EventArgs e)
            {
                pnlDirectorios.BackColor = Color.FromArgb(255, 183, 3);
                panel6.Visible = false;
            }
        

            private void LblDeportes_MouseEnter(object sender, EventArgs e)
            {
                pnlDirectorios.BackColor = Color.FromArgb(240, 172, 3);
                panel6.Visible = true;
            }
        


            private void panelDeportes_MouseDown(object sender, MouseEventArgs e)
            {
                pnlDeportes.Visible = true;
                pnlInicio.Visible = false;
            }

            private void LblDeportes_MouseDown(object sender, MouseEventArgs e)
            {
                pnlDeportes.Visible = true;
                pnlInicio.Visible = false;
            }


        
            
        //***********************************************************************************************************************

        //************************************************TORNEOS****************************************************************

            private void btnTorneoTor_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneos", "Advertencia", MessageBoxButtons.OK);
            }
        
        //***********************************************************************************************************************

        //************************************************EQUIPOS****************************************************************
        
        
        private void btnEquipoEqu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Equipos", "Advertencia", MessageBoxButtons.OK);
        }
        



        //**********************************************************************************************************************

        //******************************************EQUIPOS - EQUIPOS***********************************************************

        
            
        
        private void loginleave_MouseEnter(object sender, EventArgs e)
        {
            if (!loged)
            {
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\loginenter.jpg"));
            }
        }
        private void loginleave_MouseLeave(object sender, EventArgs e)
        {
            if (!loged)
            {
                loginleave.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\login.png"));
            }
            
        }

        private void loginClick()
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
                dynamic[,] datosUsuario = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from usuario WHERE gmail = '" + Program.Blank.user.gmail[0] + "' AND dominio = '" + Program.Blank.user.gmail[1] + "'"));
                Program.Blank.user.label2.Text = datosUsuario[5, 0] + "";
                Program.Blank.user.label4.Text = datosUsuario[6, 0] + "";
                Program.Blank.user.label7.Text = datosUsuario[0, 0] + "@" + datosUsuario[1, 0];

                if ((datosUsuario[7, 0]+"").Equals("")) Program.Blank.user.label9.Text = "Indeterminado";
                else Program.Blank.user.label9.Text = datosUsuario[7, 0];
                Program.Blank.user.Visible = true;
                Program.Blank.user.Location = new Point(0, 0);
            }
        }

        private void loginleave_MouseDown(object sender, MouseEventArgs e)
        {
            loginClick();
        }

        private void panel23_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(58, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(166, 0);
            pnlEquiposIni.Location = new Point(296, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(166, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
            subPanelDeportistas.Visible = false;
        }

        private void panel24_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(60, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(296, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(166, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelTor.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelDep.Visible = false;
            subPanelDeportistas.Visible = false;

        }

        private void panel25_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(60, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(166, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));


            SubPanelTor.Visible = false;
            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = true;
            subPanelDeportistas.Visible = false;
        }

        private void panel26_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(60, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(390, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(166, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
            subPanelDeportistas.Visible = false;
        }

        private void panel27_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(53, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(390, 0);
            pnlDeportistasIni.Location = new Point(520, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(166, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));

            subPanelDeportistas.Visible = true;
            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(58, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(166, 0);
            pnlEquiposIni.Location = new Point(296, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(166, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
            subPanelDeportistas.Visible = false;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(60, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(296, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(166, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
        
            SubPanelTor.Visible = true;
            SubPanelEqu.Visible = false;
            SubPanelDep.Visible = false;
            subPanelDeportistas.Visible = false;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(60, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(426, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(166, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelEqu.Visible = true;
            SubPanelTor.Visible = false;
            SubPanelDep.Visible = false;
            subPanelDeportistas.Visible = false;

        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(60, 10);
            lblDeportistasInicio.Location = new Point(35, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(390, 0);
            pnlDeportistasIni.Location = new Point(556, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(166, 31);
            pnlDeportistasIni.Size = new Size(130, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));

            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
            subPanelDeportistas.Visible = false;
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            lblDeporteInicio.Location = new Point(40, 10);
            lblTorneosInicio.Location = new Point(42, 10);
            lblEquiposInicio.Location = new Point(42, 10);
            lblEventosInicio.Location = new Point(42, 10);
            lblDeportistasInicio.Location = new Point(53, 10);

            pnlTorneosIni.Location = new Point(130, 0);
            pnlEquiposIni.Location = new Point(260, 0);
            pnlEventosIni.Location = new Point(390, 0);
            pnlDeportistasIni.Location = new Point(520, 0);

            pnlDeportesIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlTorneosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEquiposIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlEventosIni.BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            pnlDeportistasIni.BackColor = Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));

            pnlDeportesIni.Size = new Size(130, 31);
            pnlTorneosIni.Size = new Size(130, 31);
            pnlEquiposIni.Size = new Size(130, 31);
            pnlEventosIni.Size = new Size(130, 31);
            pnlDeportistasIni.Size = new Size(166, 31);

            pnlDeportesIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlTorneosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEquiposIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlEventosIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnNo.png"));
            pnlDeportistasIni.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\btnSi.png"));

            subPanelDeportistas.Visible = true;
            SubPanelDep.Visible = false;
            SubPanelEqu.Visible = false;
            SubPanelTor.Visible = false;
        }
        
        private void FormInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.L)
            {
                loginClick();
            }
        }

        private void LblFav_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                if(rol > 0)
                {
                    Program.Blank.Favorito = new Favorito();

                    Program.Blank.Favorito.MdiParent = Program.Blank;
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Visible = false;
                    Program.Blank.Favorito.cargaEqui();
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Location = new Point(0, 0);
                }
                else
                {
                    MessageBox.Show("Suscripcion Necesaria");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                if (rol > 0)
                {
                    Program.Blank.Favorito = new Favorito();

                    Program.Blank.Favorito.MdiParent = Program.Blank;
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Visible = false;
                    Program.Blank.Favorito.cargaEqui();
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Location = new Point(0, 0);
                }
                else
                {
                    MessageBox.Show("Suscripcion Necesaria");
                }
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                if (rol > 0)
                {
                    Program.Blank.Favorito = new Favorito();

                    Program.Blank.Favorito.MdiParent = Program.Blank;
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Visible = false;
                    Program.Blank.Favorito.cargaEqui();
                    Program.Blank.Favorito.Show();
                    Program.Blank.Favorito.Location = new Point(0, 0);
                }
                else
                {
                    MessageBox.Show("Suscripcion Necesaria");
                }
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 172, 3);
            panel2.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 183, 3);
            panel2.Visible = false;
        }

        private void LblFav_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 172, 3);
            panel2.Visible = true;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 172, 3);
            panel2.Visible = true;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 172, 3);
            panel2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rol > 0)
            {
                pictureBox1.Visible = false;
                Program.Blank.user.pictureBox3.Visible = false;
                Program.Blank.user.pictureBox4.Visible = false;
                Program.Blank.user.pictureBox5.Visible = false;
                Program.Blank.user.pictureBox6.Visible = false;
            }

            pictureBox1.Image = Logica.conByteImg(Convert.FromBase64String(Logica.randomSplit()));
            Program.Blank.user.pictureBox3.Image = Logica.conByteImg(Convert.FromBase64String(Logica.randomSplit()));
            Program.Blank.user.pictureBox4.Image = Logica.conByteImg(Convert.FromBase64String(Logica.randomBanner()));
            Program.Blank.user.pictureBox5.Image = Logica.conByteImg(Convert.FromBase64String(Logica.randomBanner()));
            Program.Blank.user.pictureBox6.Image = Logica.conByteImg(Convert.FromBase64String(Logica.randomBanner()));
        }
    }



        //**********************************************************************************************************************
    
}