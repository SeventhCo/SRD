using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Torneo : Form
    {
        public string torneo;
        public string deporte;
        public int estado;
        public bool finalDoble;
        public List<dynamic[]> vinculos;
        public List<Panel> fondos;
        public bool arriba = false;

        public Equipos formFases;

        public int cantEquipos = 0;

        public List<Panel> Equipos = new List<Panel>();
        public List<dynamic[,]> EquiposDisponibles = new List<dynamic[,]>();

        private List<Selected> seleccionadosPorEquipos = new List<Selected>();
        public List<Panel> EquiposV44 = new List<Panel>();
        public List<PictureBox> EquiposV44Selected = new List<PictureBox>();

        internal List<Selected> SeleccionadosPorEquipos { get => seleccionadosPorEquipos; set => seleccionadosPorEquipos = value; }

        public Torneo()
        {
            InitializeComponent();
            cargarEquipos();
        }

        public void inicializar()
        {
            dynamic[,] infoEquipos = Logica.consulta("Select * from EquipoTorneo where nombreTorn = '" + torneo + "'");
            for (int i = 0; i < Logica.consultaMaxIndex("Select * from EquipoTorneo where nombreTorn = '" + torneo + "'"); i++)
            {
                addEquipo();
                fill((ComboBox)Equipos[i].Controls[0]);
                Equipos[i].Controls[0].Text = infoEquipos[0, i];
                if (estado > 0) Equipos[i].Enabled = false;
            }
        }
        void fill(ComboBox equipo)
        {
            equipo.Items.Clear();
            dynamic[,] var = Logica.consulta("Select * From equipo where nombreDep = '" + deporte + "'");
            if (var != null)
            {
                for (int i = 0; i < Logica.consultaMaxIndex("Select * From equipo where nombreDep = '" + deporte + "'"); i++)
                {
                    equipo.Items.Add(var[0, i]);
                }
            }

            for (int i = 0; i < Equipos.Count; i++)
            {
                equipo.Items.Remove(Equipos[i].Controls[0].Text);
            }
        }
        
        void addEquipo()
        {
            cantEquipos++;

            Panel equpo = new Panel();
            equpo.BackColor = Color.LightGray;
            equpo.Location = new Point(12 + 182 * ((cantEquipos - 1) % 3), cero.Location.Y + 12 + (75 - 12) * ((cantEquipos - 1) / 3));
            equpo.Size = new Size(170, 45);
            equpo.Parent = panel1;
            Equipos.Add(equpo);
            equpo.Name = "Indet";

            Label txtEquipo = new Label();
            txtEquipo.AutoSize = true;
            txtEquipo.ForeColor = System.Drawing.Color.Black;
            txtEquipo.Location = new System.Drawing.Point(61, 4);
            txtEquipo.Size = new System.Drawing.Size(44, 15);
            txtEquipo.Text = "Equipo";
            txtEquipo.Parent = equpo;

            ComboBox equipo = new ComboBox();
            equipo.Parent = equpo;
            equipo.BackColor = System.Drawing.Color.DarkGray;
            equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            equipo.FormattingEnabled = true;
            equipo.Location = new System.Drawing.Point(7, 19);
            equipo.Size = new System.Drawing.Size(133, 23);
            equpo.Controls.SetChildIndex(equipo, 0);

            equipo.GotFocus += new EventHandler(delegate (Object s, EventArgs exde)
            {
                equipo.Items.Clear();
                dynamic[,] var = Logica.consulta("Select * From equipo where nombreDep = '" + deporte + "'");
                if (var != null)
                {
                    for (int i = 0; i < Logica.consultaMaxIndex("Select * From equipo where nombreDep = '" + deporte + "'"); i++)
                    {
                        equipo.Items.Add(var[0, i]);
                    }
                }

                for (int i = 0; i < Equipos.Count; i++)
                {
                    equipo.Items.Remove(Equipos[i].Controls[0].Text);
                }
            });

            equipo.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                if (equipo.Text == "")
                {
                    equpo.Name = "Indet";
                }
                else
                {
                    equpo.Name = equipo.Text;
                }
            });
            
        }

        public void desplazarDerechaEquipos(List<Panel> TodasLasFases, int tamanioextra)
        {
            for (int i = 0; i < TodasLasFases.Count; i++)
            {
                TodasLasFases[i].Location = new Point(TodasLasFases[i].Location.X + tamanioextra, TodasLasFases[i].Location.Y);
            }
            formFases.panel2.Location = new Point(formFases.panel2.Location.X + tamanioextra, formFases.panel2.Location.Y);
            formFases.lineas.Location = new Point(formFases.lineas.Location.X + tamanioextra, formFases.lineas.Location.Y);
            formFases.lineas2.Location = new Point(formFases.lineas2.Location.X + tamanioextra, formFases.lineas2.Location.Y);
        }

        public void desplazarIzquierdaEquipos(List<Panel> TodasLasFases, int tamanioextra)
        {
            for (int i = 0; i < TodasLasFases.Count; i++)
            {
                TodasLasFases[i].Location = new Point(TodasLasFases[i].Location.X - tamanioextra, TodasLasFases[i].Location.Y);
            }
            formFases.panel2.Location = new Point(formFases.panel2.Location.X - tamanioextra, formFases.panel2.Location.Y);
            formFases.lineas.Location = new Point(formFases.lineas.Location.X - tamanioextra, formFases.lineas.Location.Y);
            formFases.lineas2.Location = new Point(formFases.lineas2.Location.X - tamanioextra, formFases.lineas2.Location.Y);
        }

        public void cargarEquipos()
        {
            for (int i = 0; i < Equipos.Count; i++)
            {
                EquiposDisponibles.Add(Logica.consulta("Select * from equipo where nombreEqu = '" + Equipos[i].Name + "'"));
            }
        }

        public void borrarEquipos()
        {
            for (int i = 0; i < EquiposV44.Count; i++)
            {
                EquiposV44[i].Dispose();
                EquiposV44Selected[i].Dispose();
            }
            EquiposV44.Clear();
            EquiposV44Selected.Clear();
        }

        public void mostrarEquipos(Panel equipos, int num, Panel enfrentamiento)
        {

            List<dynamic[,]> Seleccionados = new List<dynamic[,]>();

            bool encontrao = false;

            for (int a = 0; a < SeleccionadosPorEquipos.Count; a++)
            {
                if (SeleccionadosPorEquipos[a].enfrentamiento == enfrentamiento)
                {
                    Seleccionados = SeleccionadosPorEquipos[a].Seleccionados;
                    encontrao = true;
                    break;
                }
            }

            if (!encontrao)
            {
                Selected lista = new Selected(enfrentamiento, Seleccionados);
                SeleccionadosPorEquipos.Add(lista);
            }

            for (int i = 0; i < Seleccionados.Count; i++)
            {
                Panel equipo = new Panel();
                equipo.Visible = true;
                equipo.Parent = equipos;
                equipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                equipo.Location = new System.Drawing.Point(12, 12 + 86 * i);
                equipo.Name = Seleccionados[i][1, 0];
                equipo.Size = new System.Drawing.Size(64, 80);
                EquiposV44.Add(equipo);

                PictureBox equipoElim = new PictureBox();
                equipoElim.Parent = equipo;
                equipoElim.Name = "1";
                equipoElim.Location = new System.Drawing.Point(46, 0);
                equipoElim.Size = new System.Drawing.Size(18, 18);
                equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                EquiposV44Selected.Add(equipoElim);

                /* aqui se pone el logo del equipo */
                PictureBox imgequipo = new PictureBox();
                imgequipo.Parent = equipo;
                imgequipo.Visible = true;
                imgequipo.Location = new System.Drawing.Point(0, 0);
                imgequipo.Size = new System.Drawing.Size(64, 64);
                imgequipo.SizeMode = PictureBoxSizeMode.StretchImage;
                imgequipo.Image = Logica.conByteImg(Convert.FromBase64String(Seleccionados[i][2, 0]));

                Label nomCorto = new Label();
                nomCorto.Parent = equipo;
                nomCorto.Text = Seleccionados[i][1, 0];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                dynamic selecc = Seleccionados[i];

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {
                        EquiposDisponibles.Add(selecc);
                        Seleccionados.Remove(selecc);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {
                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(selecc);
                            EquiposDisponibles.Remove(selecc);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                            /*
                            if (Seleccionados.Count == 1)
                            {
                                PictureBox foto = new PictureBox();
                                foto.Size = new Size(65, 65);
                                foto.Location = new Point(0, 0 );
                                foto.Visible = true;
                                foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                                foto.BackgroundImageLayout = ImageLayout.Stretch;
                                Panel sender = enfrentamiento;
                                foto.Parent = enfrentamiento;
                                enfrentamiento.Controls.SetChildIndex(foto, 1);
                                enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                                foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                                {
                                    if (!formFases.panel1.Visible)
                                    {
                                        desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = true;
                                        mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                                    }
                                    else
                                    {
                                        desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = false;
                                        borrarEquipos();
                                    }
                                });
                            }
                            else
                            {
                                for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                                {
                                    if (enfrentamiento.Controls[h] is PictureBox)
                                    {
                                        enfrentamiento.Controls[h].Dispose();
                                    }
                                }
                            }
                            */
                });

                imgequipo.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {

                        EquiposDisponibles.Add(selecc);
                        Seleccionados.Remove(selecc);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {

                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(selecc);
                            EquiposDisponibles.Remove(selecc);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                            /*
                            if (Seleccionados.Count == 1)
                            {
                                PictureBox foto = new PictureBox();
                                foto.Size = new Size(65, 65);
                                foto.Location = new Point(0, 0 );
                                foto.Visible = true;
                                foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                                foto.BackgroundImageLayout = ImageLayout.Stretch;
                                Panel sender = enfrentamiento;
                                foto.Parent = enfrentamiento;
                                enfrentamiento.Controls.SetChildIndex(foto, 1);
                                enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                                foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                                {
                                    if (!formFases.panel1.Visible)
                                    {
                                        desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = true;
                                        mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                                    }
                                    else
                                    {
                                        desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = false;
                                        borrarEquipos();
                                    }
                                });
                            }
                            else
                            {
                                for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                                {
                                    if (enfrentamiento.Controls[h] is PictureBox)
                                    {
                                        enfrentamiento.Controls[h].Dispose();
                                    }
                                }
                            }
                            */
                });

                equipoElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {

                        EquiposDisponibles.Add(selecc);
                        Seleccionados.Remove(selecc);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {

                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(selecc);
                            EquiposDisponibles.Remove(selecc);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                            /*
                            if (Seleccionados.Count == 1)
                            {
                                PictureBox foto = new PictureBox();
                                foto.Size = new Size(65, 65);
                                foto.Location = new Point(0, 0);
                                foto.Visible = true;
                                foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                                foto.BackgroundImageLayout = ImageLayout.Stretch;
                                Panel sender = enfrentamiento;
                                foto.Parent = enfrentamiento;
                                enfrentamiento.Controls.SetChildIndex(foto, 1);
                                enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                                foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                                {
                                    if (!formFases.panel1.Visible)
                                    {
                                        desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = true;
                                        mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                                    }
                                    else
                                    {
                                        desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = false;
                                        borrarEquipos();
                                    }
                                });
                            }
                            else
                            {
                                for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                                {
                                    if (enfrentamiento.Controls[h] is PictureBox)
                                    {
                                        enfrentamiento.Controls[h].Dispose();
                                    }
                                }
                            }
                            */
                });
            }

            for (int i = 0; i < EquiposDisponibles.Count; i++)
            {
                Panel equipo = new Panel();
                equipo.Visible = true;
                equipo.Parent = equipos;
                equipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                equipo.Location = new System.Drawing.Point(12, 12 + 86 * (i + Seleccionados.Count));
                equipo.Name = EquiposDisponibles[i][1, 0];
                equipo.Size = new System.Drawing.Size(64, 80);
                EquiposV44.Add(equipo);

                PictureBox equipoElim = new PictureBox();
                equipoElim.Name = "0";
                equipoElim.Parent = equipo;
                equipoElim.Location = new System.Drawing.Point(46, 0);
                equipoElim.Size = new System.Drawing.Size(18, 18);
                equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                EquiposV44Selected.Add(equipoElim);

                // aqui se pone el logo del equipo 
                PictureBox imgequipo = new PictureBox();
                imgequipo.Parent = equipo;
                imgequipo.Visible = true;
                imgequipo.Location = new System.Drawing.Point(0, 0);
                imgequipo.Size = new System.Drawing.Size(64, 64);
                imgequipo.SizeMode = PictureBoxSizeMode.StretchImage;
                imgequipo.Image = Logica.conByteImg(Convert.FromBase64String(EquiposDisponibles[i][2, 0]));

                Label nomCorto = new Label();
                nomCorto.Parent = equipo;
                nomCorto.Text = EquiposDisponibles[i][1, 0];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                dynamic equpDisp = EquiposDisponibles[i];

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {
                        EquiposDisponibles.Add(equpDisp);
                        Seleccionados.Remove(equpDisp);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {
                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(equpDisp);
                            EquiposDisponibles.Remove(equpDisp);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                            /*
                            if (Seleccionados.Count == 1)
                            {
                                PictureBox foto = new PictureBox();
                                foto.Size = new Size(65, 65);
                                foto.Location = new Point(0, 0);
                                foto.Visible = true;
                                foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                                foto.BackgroundImageLayout = ImageLayout.Stretch;
                                Panel sender = enfrentamiento;
                                foto.Parent = enfrentamiento;
                                enfrentamiento.Controls.SetChildIndex(foto, 1);
                                enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                                foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                                {
                                    if (!formFases.panel1.Visible)
                                    {
                                        desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = true;
                                        mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                                    }
                                    else
                                    {
                                        desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = false;
                                        borrarEquipos();
                                    }
                                });
                            }
                            else
                            {
                                for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                                {
                                    if (enfrentamiento.Controls[h] is PictureBox)
                                    {
                                        enfrentamiento.Controls[h].Dispose();
                                    }
                                }
                            }
                            */
                });

                imgequipo.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {
                        EquiposDisponibles.Add(equpDisp);
                        Seleccionados.Remove(equpDisp);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {
                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(equpDisp);
                            EquiposDisponibles.Remove(equpDisp);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                            /*
                            if (Seleccionados.Count == 1)
                            {
                                PictureBox foto = new PictureBox();
                                foto.Size = new Size(65, 65);
                                foto.Location = new Point(0, 0);
                                foto.Visible = true;
                                foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                                foto.BackgroundImageLayout = ImageLayout.Stretch;
                                Panel sender = enfrentamiento;
                                foto.Parent = enfrentamiento;
                                enfrentamiento.Controls.SetChildIndex(foto, 1);
                                enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                                foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                                {
                                    if (!formFases.panel1.Visible)
                                    {
                                        desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = true;
                                        mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                                    }
                                    else
                                    {
                                        desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                        formFases.panel1.Visible = false;
                                        borrarEquipos();
                                    }
                                });
                            }
                            else
                            {
                                for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                                {
                                    if (enfrentamiento.Controls[h] is PictureBox)
                                    {
                                        enfrentamiento.Controls[h].Dispose();
                                    }
                                }
                            }
                            */
                });

                equipoElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    if (equipoElim.Name == "1")
                    {
                        EquiposDisponibles.Add(equpDisp);
                        Seleccionados.Remove(equpDisp);
                        equipoElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                        equipoElim.Name = "0";
                    }
                    else
                    {
                        if (Seleccionados.Count < num)
                        {
                            equipoElim.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                            equipoElim.Name = "1";
                            Seleccionados.Add(equpDisp);
                            EquiposDisponibles.Remove(equpDisp);
                        }
                    }
                    enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;

                    if (Seleccionados.Count == 1)
                    {
                        PictureBox foto = new PictureBox();
                        foto.Size = new Size(65, 65);
                        foto.Location = new Point(0, 0);
                        foto.Visible = true;
                        foto.BackgroundImage = Logica.conByteImg(Convert.FromBase64String(Seleccionados[0][2, 0]));
                        foto.BackgroundImageLayout = ImageLayout.Stretch;
                        Panel sender = enfrentamiento;
                        foto.Parent = enfrentamiento;
                        enfrentamiento.Controls.SetChildIndex(foto, 1);
                        enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].SendToBack();
                        foto.MouseDown += new MouseEventHandler(delegate (Object sa, MouseEventArgs exded)
                        {
                            if (!formFases.panel1.Visible)
                            {
                                desplazarDerechaEquipos(fondos, formFases.panel1.Size.Width);
                                formFases.panel1.Visible = true;
                                mostrarEquipos(formFases.panel1, formFases.cantEquipos, sender);
                            }
                            else
                            {
                                desplazarIzquierdaEquipos(fondos, formFases.panel1.Size.Width);
                                formFases.panel1.Visible = false;
                                borrarEquipos();
                            }
                        });
                    }
                    else
                    {
                        for (int h = 0; h < enfrentamiento.Controls.Count; h++)
                        {
                            if (enfrentamiento.Controls[h] is PictureBox)
                            {
                                enfrentamiento.Controls[h].Dispose();
                            }
                        }
                    }

                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
        }
    }
}
