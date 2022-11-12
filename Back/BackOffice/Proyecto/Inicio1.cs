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

        public List<Panel> depora = new List<Panel>();
        public List<Panel> elimDepor = new List<Panel>();
        public List<PictureBox> deporImg = new List<PictureBox>();

        public bool loged = false;
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
            Program.Blank.frmHerramientas = new Form4();
            Program.Blank.frmHerrTorneo = new FormHerramientas();
            Program.Blank.frmHerrEquipos = new HerramientasEquipos();
            Program.Blank.frmPunt = new SisPunt();
            Program.Blank.frmEvento = new Evento();
            Program.Blank.torn = new Torneo();
            Program.Blank.Partido = new Partido();
            Program.Blank.Deportista = new Deportistas();
            Program.Blank.Equipo = new Equipo();
            Program.Blank.Depor = new Deportista();

            Program.Blank.Depor.MdiParent = Program.Blank;
            Program.Blank.Depor.Show();
            Program.Blank.Depor.Visible = false;

            Program.Blank.Equipo.MdiParent = Program.Blank;
            Program.Blank.Equipo.Show();
            Program.Blank.Equipo.Visible = false;

            Program.Blank.Deportista.MdiParent = Program.Blank;
            Program.Blank.Deportista.Show();
            Program.Blank.Deportista.Visible = false;

            Program.Blank.Partido.MdiParent = Program.Blank;
            Program.Blank.Partido.Show();
            Program.Blank.Partido.Visible = false;

            Program.Blank.torn.MdiParent = Program.Blank;
            Program.Blank.torn.Show();
            Program.Blank.torn.Visible = false;

            Program.Blank.frmHerramientas.MdiParent = Program.Blank;
            Program.Blank.frmHerramientas.Show();
            Program.Blank.frmHerramientas.Visible = false;

            Program.Blank.frmHerrTorneo.MdiParent = Program.Blank;
            Program.Blank.frmHerrTorneo.Show();
            Program.Blank.frmHerrTorneo.Visible = false;

            Program.Blank.frmHerrEquipos.MdiParent = Program.Blank;
            Program.Blank.frmHerrEquipos.Show();
            Program.Blank.frmHerrEquipos.Visible = false;

            Program.Blank.frmEvento.MdiParent = Program.Blank;
            Program.Blank.frmEvento.Show();
            Program.Blank.frmEvento.Visible = false;

            Program.Blank.frmPunt.MdiParent = Program.Blank;
            Program.Blank.frmPunt.Show();
            Program.Blank.frmPunt.Visible = false;

        }
        public void actualizar()
        {
            Idioma.controles(pnlInicio);
            Idioma.controles(pnlDeportes);
            Idioma.controles(pnlInicoArriba);
            Idioma.controles(pnlDirectorios);
            Idioma.controles(pnlAyuda);
            Idioma.controles(PanelLateral);
            Idioma.controles(SubPanelTor);
            Idioma.controles(SubPanelEqu);
            Idioma.controles(SubPanelDep);
            Idioma.controles(pnlDeportistasIni);
            Idioma.controles(pnlEventosIni);
            Idioma.controles(pnlEquiposIni);
            Idioma.controles(pnlTorneosIni);
            Idioma.controles(pnlEliminarTorn2);
            Idioma.controles(pnlAgregarTornDep);
            Idioma.controles(pnlEliminarEqs);
            Idioma.controles(pnlAgregarEq);
            Idioma.controles(panelAgregarDep);
            Idioma.controles(panelEliminarDep);
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
                Program.Blank.Depo.deporte = depo.Name;
                Program.Blank.Depo.cargaTorn();
                string tipo;
                dynamic[,] depoInfo = Logica.consulta("Select * from deporte WHERE nombreDep = '" + depo.Name + "'");
                Program.Blank.Depo.pbDepoLogo.Image = Logica.conByteImg(Convert.FromBase64String(depoInfo[5, 0]));
                if (depoInfo[3, 0] == 0) tipo = "Equipo";
                else tipo = "Individual";

                Program.Blank.Depo.lblInfoDepo.Text =
                    "Deporte : " + depo.Name + "\n" +
                    "Nombre Corto : " + depoInfo[2, 0] + "\n" +
                    "Tipo de deporte : " + tipo + "\n" +
                    "Numero de Titulares : " + depoInfo[4, 0];
                Program.Blank.Depo.lblDepoInfo.Text = depoInfo[6, 0] + "";
                if (Program.Blank.Depo.lblDepoInfo.Text.Equals("") && loged) Program.Blank.Depo.lblDepoInfo.Text = "Agregar Texto";
                Program.Blank.Depo.Show();
                Program.Blank.Depo.Location = new Point(0, 0);
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
                dynamic[,] depoInfo = Logica.consulta("Select * from deporte");
                Panel depo = new Panel();
                depo.Visible = false;
                depo.Parent = Program.Blank.frmPrincipal.SubPanelDep;
                depo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) depo.Location = new System.Drawing.Point(17 + 78 * ((cantDepo + 2) % 8), 7 + 93 * ((cantDepo + 2) / 8));
                else depo.Location = new System.Drawing.Point(17 + 78 * ((cantDepo) % 8), 7 + 93 * ((cantDepo) / 8));
                depo.Name = depoInfo[1, i];
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
                imgDepo.Image = Logica.conByteImg(Convert.FromBase64String(depoInfo[5, i]));

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
                limpiar();
                Program.Blank.torn.torneo = torn.Name;
                dynamic[,] infoTorneo = Logica.consulta("Select * from Torneo where nombreTorn = '" + torn.Name + "'");
                Program.Blank.torn.lblInfoTorn.Text =
                    "Nombre : " + infoTorneo[0, 0] + "\n" +
                    "Cantidad de fases : " + Logica.consultaMaxIndex("Select idfase from fase where nombreTorn = '" + infoTorneo[0, 0] + "'") + "\n" +
                    "Deporte : " + infoTorneo[5, 0] + "\n" +
                    "Estado : " + infoTorneo[4, 0];
                Program.Blank.torn.pbDepoLogo.Image = Logica.conByteImg(Convert.FromBase64String(infoTorneo[3, 0]));
                Program.Blank.torn.Show();
                Program.Blank.torn.deporte = infoTorneo[5, 0];
                Program.Blank.torn.estado = infoTorneo[4, 0];
                Program.Blank.torn.Location = new Point(0, 0);
                Program.Blank.torn.inicializar();
                Program.Blank.torn.arriba = true;
                if (!loged)
                {
                    Program.Blank.torn.button3.Visible = false;
                    Program.Blank.torn.label1.Visible = false;
                    for (int i = 0; i < Program.Blank.torn.Equipos.Count; i++)
                    {
                        Program.Blank.torn.Equipos[i].Enabled = false;
                    }
                }
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

            dynamic[,] tornInfo = Logica.consulta("Select * from Torneo");
            for (int i = 0; i < Logica.consultaMaxIndex("Select * from Torneo"); i++)
            {
                Panel torn = new Panel();
                torn.Parent = Program.Blank.frmPrincipal.SubPanelTor;
                torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) torn.Location = new System.Drawing.Point(17 + 78 * ((cantTorn + 2) % 8), 7 + 93 * ((cantTorn + 2) / 8));
                else torn.Location = new System.Drawing.Point(17 + 78 * ((cantTorn) % 8), 7 + 93 * ((cantTorn) / 8));
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
                tornsImg.Add(tornElim);

                /* aqui se pone el logo del torneo */
                PictureBox imgTorn = new PictureBox();
                imgTorn.Name = torn.Name + "img";
                imgTorn.Parent = torn;
                imgTorn.Visible = true;
                imgTorn.Location = new System.Drawing.Point(0, 0);
                imgTorn.Size = new System.Drawing.Size(64, 64);
                imgTorn.SizeMode = PictureBoxSizeMode.StretchImage;
                imgTorn.Image = Logica.conByteImg(Convert.FromBase64String(tornInfo[3, i]));

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
                limpiar();
                Program.Blank.Equipo.equipo = equi.Name;
                Program.Blank.Equipo.cargarEquipo();
                Program.Blank.Equipo.Show();
                Program.Blank.Equipo.Location = new Point(0, 0);
            }
        }

        public void cargaEqui()
        {
            for (int i = equisImg.Count - 1; i >= 0; i--)
            {
                equisImg[i].Dispose();
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
                dynamic[,] equiInfo = Logica.consulta("Select * from equipo");
                Panel equi = new Panel();
                equi.Parent = Program.Blank.frmPrincipal.SubPanelEqu;
                equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui + 2) % 8), 7 + 93 * ((cantEqui + 2) / 8));
                else equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui) % 8), 7 + 93 * ((cantEqui) / 8));
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
                equisImg.Add(equiElim);

                /* aqui se pone el logo del equipo */
                PictureBox imgEqui = new PictureBox();
                imgEqui.Name = equi.Name + "img";
                imgEqui.Parent = equi;
                imgEqui.Visible = true;
                imgEqui.Location = new System.Drawing.Point(0, 0);
                imgEqui.Size = new System.Drawing.Size(64, 64);
                imgEqui.SizeMode = PictureBoxSizeMode.StretchImage;
                imgEqui.Image = Logica.conByteImg(Convert.FromBase64String(equiInfo[2, i]));

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
            if (eliminar)
            {
                if (deporElim.Name.Equals(depor.Name + "0"))
                {
                    deporElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                    deporElim.Name = depor.Name + "1";
                    elimDepor.Add(depor);
                }
                else if (deporElim.Name.Equals(depor.Name + "1"))
                {
                    deporElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    deporElim.Name = depor.Name + "0";
                    elimDepor.Remove(depor);
                }
            }
            else
            {
                limpiar();
                Program.Blank.Depor.cedula = depor.Name;
                Program.Blank.Depor.cargarEquipo();
                Program.Blank.Depor.Show();
                Program.Blank.Depor.Location = new Point(0, 0);
            }
        }

        public void cargaDeport()
        {
            for (int i = deporImg.Count - 1; i >= 0; i--)
            {
                deporImg[i].Dispose();
                deporImg.Remove(deporImg[i]);
            }
            for (int i = depora.Count - 1; i >= 0; i--)
            {
                depora[i].Dispose();
                depora.Remove(depora[i]);
            }
            for (int i = elimDepor.Count - 1; i >= 0; i--)
            {
                elimDepor[i].Dispose();
                elimDepor.Remove(elimDepor[i]);
            }
            cantDepor = 0;

            for (int i = 0; i < Logica.consultaMaxIndex("Select * from deportista"); i++)
            {
                dynamic[,] deporInfo = Logica.consulta("Select * from deportista");

                Panel depor = new Panel();
                depor.Parent = Program.Blank.frmPrincipal.subPanelDeportistas;
                depor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) depor.Location = new System.Drawing.Point(17 + 78 * ((cantDepor + 2) % 8), 7 + 93 * ((cantDepor + 2) / 8));
                else depor.Location = new System.Drawing.Point(17 + 78 * ((cantDepor) % 8), 7 + 93 * ((cantDepor) / 8));
                depor.Name = deporInfo[0, i] + "";
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
                deporImg.Add(deporElim);

                /* aqui se pone el logo del deportista */
                PictureBox imgDepor = new PictureBox();
                imgDepor.Name = depor.Name + "img";
                imgDepor.Parent = depor;
                imgDepor.Visible = true;
                imgDepor.Location = new System.Drawing.Point(0, 0);
                imgDepor.Size = new System.Drawing.Size(64, 64);
                imgDepor.SizeMode = PictureBoxSizeMode.StretchImage;
                imgDepor.Image = Logica.conByteImg(Convert.FromBase64String(deporInfo[4, i]));

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
            panel8.Visible = false;
            ImgEliminarDep.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
            pictureBox13.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
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

        private void panelAyuda_MouseEnter(object sender, EventArgs e)
        {
            pnlAyuda.BackColor = Color.FromArgb(240, 172, 3);
            panel8.Visible = true;
        }

        private void panelDeportes_MouseLeave(object sender, EventArgs e)
        {
            pnlDirectorios.BackColor = Color.FromArgb(255, 183, 3);
            panel6.Visible = false;
        }

        private void panelAyuda_MouseLeave(object sender, EventArgs e)
        {
            pnlAyuda.BackColor = Color.FromArgb(255, 183, 3);
            panel8.Visible = false;
        }

        private void LblDeportes_MouseEnter(object sender, EventArgs e)
        {
            pnlDirectorios.BackColor = Color.FromArgb(240, 172, 3);
            panel6.Visible = true;
        }

        private void LblAyuda_MouseEnter(object sender, EventArgs e)
        {
            pnlAyuda.BackColor = Color.FromArgb(240, 172, 3);
            panel8.Visible = true;
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
                cargaTorn();
                cargaEqui();
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
                limpiar();
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
                dynamic[,] datosUsuario = Logica.consulta("Select * from usuario WHERE gmail = '" + Program.Blank.user.gmail[0] + "' AND dominio = '" + Program.Blank.user.gmail[1] + "'");
                Program.Blank.user.label2.Text = datosUsuario[5, 0] + "";
                Program.Blank.user.label4.Text = datosUsuario[6, 0] + "";
                Program.Blank.user.label7.Text = datosUsuario[0, 0] + "@" + datosUsuario[1, 0];

                if ((datosUsuario[7, 0] + "").Equals("")) Program.Blank.user.label9.Text = "Indeterminado";
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



        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (eliminar)
                {
                    MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
                }
                else
                {
                    limpiar();
                    Program.Blank.frmHerramientas.pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                    Program.Blank.frmHerramientas.comboBox3.Items.Clear();
                    dynamic[,] sist = Logica.consulta("Select * from sistema");
                    if (!(sist == null))
                    {
                        for (int i = 0; i < sist.Length; i++)
                        {
                            Program.Blank.frmHerramientas.comboBox3.Items.Add(sist[0, i]);
                        }
                    }
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
                limpiar();
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
                Program.Blank.frmHerrTorneo.pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                Program.Blank.frmHerrTorneo.comboBox5.Items.Clear();
                dynamic[,] sist = Logica.consulta("Select * from deporte");
                if (!(sist == null))
                {
                    for (int i = 0; i < Logica.consultaMaxIndex("Select * from deporte"); i++)
                    {
                        Program.Blank.frmHerrTorneo.comboBox5.Items.Add(sist[1, i]);
                    }
                }
                limpiar();
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
                limpiar();
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
                    limpiar();
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

        private void FormInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.L)
            {
                loginClick();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            limpiar();
            Program.Blank.frmEvento.Visible = true;
            this.Enabled = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            limpiar();
            Program.Blank.frmEvento.Visible = true;
            this.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (eliminar)
            {
                MessageBox.Show("No puede agregar un Deportista mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                limpiar();
                Program.Blank.Deportista.Visible = true;
                this.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (eliminar)
            {
                int deporSeleccionados = elimDepor.Count;
                for (int i = elimDepor.Count - 1; i >= 0; i--) Logica.comando("delete from deportista where cedula = " + elimDepor[i].Name + "");
                cargaDeport();
                eliminar = false;
                pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn.png"));
                if (deporSeleccionados == 0) MessageBox.Show("No selecciono ningun deportista");
                else if (deporSeleccionados == 1) MessageBox.Show("Deportista eliminado correctamente");
                else MessageBox.Show("Deportistas eliminados correctamente");
            }
            else
            {
                eliminar = true;
                pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\depoElimbtn2.png"));
                for (int i = 0; i < deporImg.Count; i++) deporImg[i].Visible = true;
            }
        }

        private void pnlAyuda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                Program.Blank.Favorito = new Favorito();

                Program.Blank.Favorito.MdiParent = Program.Blank;
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Visible = false;
                Program.Blank.Favorito.cargaEqui();
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Location = new Point(0,0);

            }
            
        }
        private void LblAyudaInicio_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                Program.Blank.Favorito = new Favorito();

                Program.Blank.Favorito.MdiParent = Program.Blank;
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Visible = false;
                Program.Blank.Favorito.cargaEqui();
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Location = new Point(0, 0);
            }
        }
        private void pnlAyuda_Click(object sender, EventArgs e)
        {
            if (!loged)
            {
                MessageBox.Show("Inicie sesion para acceder a esta ventana");
            }
            else
            {
                Program.Blank.Favorito = new Favorito();

                Program.Blank.Favorito.MdiParent = Program.Blank;
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Visible = false;
                Program.Blank.Favorito.cargaEqui();
                Program.Blank.Favorito.Show();
                Program.Blank.Favorito.Location = new Point(0, 0);

            }
        }
    }
}