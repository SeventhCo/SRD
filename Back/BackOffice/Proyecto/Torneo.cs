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
        public Evento frmEvento;

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

        public void cargafase()
        {
            EquiposDisponibles = new List<dynamic[,]>();

            SeleccionadosPorEquipos = new List<Selected>();
            EquiposV44 = new List<Panel>();
            EquiposV44Selected = new List<PictureBox>();

            dynamic[,] fases = Logica.consulta("Select * from fase where nombreTorn = '" + torneo + "' order by idfase");

            int elementos = 0;

            formFases = new Equipos();
            formFases.cantEquipos = Logica.consulta("select cantEquipos from deporte where nombreDep = '" + deporte + "'")[0, 0];

            cargarEquipos();
            formFases.Visible = true;
            formFases.BringToFront();
            formFases.equiposEnDepo = Logica.consulta("select cantEquipos from deporte where nombreDep = '" + deporte + "'")[0, 0];


            fondos = new List<Panel>(); //Lista de fondos, lo necesito separado para desplazar
            vinculos = new List<dynamic[]>(); // Enlace entre el fondo de la fase y sus enfrentamientos

            //creacion de los paneles de fondo
            for (int i = 0; i < Logica.consultaMaxIndex("Select * from fase where nombreTorn = '" + torneo + "' order by idfase"); i++)
            {
                if (fases[0, i] > 0) finalDoble = true;
            }

            for (int i = 0; i < Logica.consultaMaxIndex("Select * from fase where nombreTorn = '" + torneo + "' order by idfase"); i++)
            {
                Panel fondo = new Panel();
                fondo.Parent = formFases;
                //fondo.Location = new Point(202 * (elementos++) * (formFases.cantEquipos/2), 0);
                fondo.Location = new Point(202 * (elementos++), 0);
                //fondo.BackColor = Color.Green;
                fondo.BackColor = Color.FromArgb(255, 135, 112, 81);
                fondo.Size = new Size(100, formFases.Size.Height);
                fondo.Name = fases[2, i];
                fondos.Add(fondo);
                fondo.SendToBack();

                Label ejemplo = new Label();
                ejemplo.Parent = fondo;
                ejemplo.Location = new Point(10, 10);
                ejemplo.Text = fases[2, i];
                ejemplo.Size = new Size(ejemplo.Size.Width, 80);

                ComboBox estado = new ComboBox();
                estado.Parent = ejemplo;
                estado.Size = new Size(90, 23);
                estado.Location = new Point(0, 20);
                estado.BackColor = Color.DarkGray;
                estado.DropDownStyle = ComboBoxStyle.DropDownList;
                estado.Items.Add("Pendiente");
                estado.Items.Add("En Proceso");
                estado.Items.Add("Finalizado");
                estado.SelectedIndex = fases[4, i];

                Label estadoFase = new Label();
                estadoFase.Visible = false;
                estadoFase.Parent = fondo;
                estadoFase.Text = estado.SelectedIndex + "";

                Label previous = new Label();
                previous.Parent = estado;
                previous.Visible = false;
                estado.Controls[0].Text = "" + estado.SelectedIndex;


                estado.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
                {
                    switch (estado.SelectedIndex)
                    {
                        case 0:
                            if (estado.Controls[0].Text == "" + 1)
                            {
                                MessageBox.Show("Esta fase ya ha Iniciado");
                                estado.SelectedIndex = 1;
                            }
                            else if (estado.Controls[0].Text == "" + 2)
                            {
                                MessageBox.Show("Esta fase ya ha Terminado");
                                estado.SelectedIndex = 2;
                            }
                            else
                            {
                                estadoFase.Text = "" + estado.SelectedIndex;
                                estado.Controls[0].Text = "" + estado.SelectedIndex;
                            }

                            break;
                        case 1:
                            if (estado.Controls[0].Text == "" + 2)
                            {
                                MessageBox.Show("Esta fase ya ha Terminado");
                                estado.SelectedIndex = 2;
                            }
                            else
                            {

                                for (int ind = 0; ind < vinculos.Count; ind++)
                                {
                                    if (vinculos[ind][0] == fondo)
                                    {
                                        int errores = 0;
                                        for (int q = 0; q < vinculos[ind][1].Count; q++)
                                        {
                                            if (vinculos[ind][1][q].Controls.Count != 3)
                                            {
                                                errores++;
                                            }
                                        }
                                        if (errores == 0)
                                        {
                                            estadoFase.Text = "" + estado.SelectedIndex;
                                            estado.Controls[0].Text = "" + estado.SelectedIndex;
                                        }
                                        else
                                        {
                                            estado.SelectedIndex = 0;
                                            MessageBox.Show("Compruebe que todos los enfrentamientos tengan un enfrentamiento creado o un equipo ganador");
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            for (int ind = 0; ind < vinculos.Count; ind++)
                            {
                                if (vinculos[ind][0] == fondo)
                                {
                                    int errores = 0;
                                    for (int q = 0; q < vinculos[ind][1].Count; q++)
                                    {
                                        if (vinculos[ind][1][q].Controls.Count != 3)
                                        {
                                            errores++;
                                        }
                                        else
                                        {
                                            bool encontrao = false;
                                            for (int hf = 0; hf < vinculos[ind][1][q].Controls.Count; hf++)
                                            {
                                                if (vinculos[ind][1][q].Controls[hf] is PictureBox)
                                                {
                                                    encontrao = true;
                                                }
                                            }
                                            if (!encontrao)
                                            {
                                                errores++;
                                            }
                                        }
                                    }
                                    if (errores == 0)
                                    {
                                        estadoFase.Text = "" + estado.SelectedIndex;
                                        estado.Controls[0].Text = "" + estado.SelectedIndex;
                                    }
                                    else
                                    {
                                        estado.SelectedIndex = 1;
                                        MessageBox.Show("Compruebe que todos los enfrentamientos tengan un equipo ganador");
                                    }
                                }
                            }
                            break;
                    }
                });

                int enfAnteriores = 0;

                if (vinculos.Count != 0)
                {
                    enfAnteriores = vinculos[vinculos.Count - 1][1].Count;
                }

                List<Panel> enfrentamientos = new List<Panel>();
                bool repetida = false;
                int cual = 0;
                for (int x = 0; x < i; x++)
                {
                    if (fases[1, x] == fases[1, i])
                    {
                        repetida = true;
                        cual = x;
                        break;
                    }
                }

                if (!repetida)
                {
                    for (int x = 0; x < fases[1, i]; x++)
                    {
                        Panel enfrentamiento = new Panel();
                        enfrentamiento.Parent = fondo;
                        enfrentamiento.Size = new Size(65, 65);
                        if (enfAnteriores == 0)
                        {
                            enfrentamiento.Location = new Point(17, 70 + 65 * x + 2 * x);
                        }
                        else
                        {
                            if (formFases.equiposEnDepo == 2)
                            {
                                enfrentamiento.Location = new Point(17, vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.Y - ((vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.Y - vinculos[vinculos.Count - 1][1][(formFases.equiposEnDepo * x + 1) - 1].Location.Y) / 2));
                                if (fases[1, i] != 1)
                                {
                                    PointF a = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x].Location.Y + 32.5f);
                                    PointF b = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                    PointF c = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.Y + 32.5f);
                                    PointF d = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                    formFases.Puntos.Add(a);
                                    formFases.Puntos.Add(b);
                                    formFases.Puntos.Add(c);
                                    formFases.Puntos.Add(d);
                                }
                                else
                                {
                                    if (!finalDoble)
                                    {
                                        PointF a = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x].Location.Y + 32.5f);
                                        PointF b = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                        PointF c = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + 1].Location.Y + 32.5f);
                                        PointF d = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                        formFases.Puntos.Add(a);
                                        formFases.Puntos.Add(b);
                                        formFases.Puntos.Add(c);
                                        formFases.Puntos.Add(d);
                                    }
                                }
                            }
                            else if (enfAnteriores % 2 == 0)
                            {
                                enfrentamiento.Location = new Point(17, vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * (x + 1) - (formFases.equiposEnDepo / 2)].Location.Y - ((vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * (x + 1) - (formFases.equiposEnDepo / 2) + 1].Location.Y - vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * (x + 1) - (formFases.equiposEnDepo / 2)].Location.Y) / 2));
                                for (int indice = 0; indice < formFases.equiposEnDepo; indice++)
                                {
                                    PointF a = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + indice].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + indice].Location.Y + 32.5f);
                                    PointF b = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                    formFases.Puntos.Add(a);
                                    formFases.Puntos.Add(b);
                                }
                            }
                            else
                            {
                                int a = 3;
                                for (int divisor = 3; enfAnteriores % divisor != 0; divisor = divisor + 2)
                                {
                                    a = divisor + 2;
                                }
                                enfrentamiento.Location = new Point(17, vinculos[vinculos.Count - 1][1][(a * (x + 1) - (a / 2)) - 1].Location.Y);
                                for (int indice = 0; indice < formFases.equiposEnDepo; indice++)
                                {
                                    PointF ab = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + indice].Location.X + 65, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][formFases.equiposEnDepo * x + indice].Location.Y + 32.5f);
                                    PointF b = new PointF(fondo.Location.X + enfrentamiento.Location.X, fondo.Location.Y + enfrentamiento.Location.Y + 32.5f);
                                    formFases.Puntos.Add(ab);
                                    formFases.Puntos.Add(b);
                                }
                            }
                        }
                        enfrentamiento.BackColor = Color.Wheat;
                        enfrentamientos.Add(enfrentamiento);
                    }
                }
                else
                {
                    for (int x = 0; x < fases[1, cual]; x++)
                    {
                        Panel enfrentamiento = new Panel();
                        enfrentamiento.Parent = fondo;
                        enfrentamiento.Size = new Size(65, 65);
                        enfrentamiento.Location = new Point(17, vinculos[cual][1][x].Location.Y);
                        enfrentamiento.BackColor = Color.Wheat;
                        enfrentamientos.Add(enfrentamiento);
                    }
                    if (fases[1, cual] == 2)
                    {
                        Panel enfrentamiento = new Panel();
                        enfrentamiento.Parent = vinculos[vinculos.Count - 2][0];
                        enfrentamiento.Size = new Size(65, 65);
                        enfrentamiento.Location = new Point(17, vinculos[vinculos.Count - 1][1][0].Location.Y);
                        enfrentamiento.BackColor = Color.Wheat;
                        vinculos[vinculos.Count - 2][1].Add(enfrentamiento);


                        Panel enfrentamientoExtra = new Panel();
                        enfrentamientoExtra.Parent = fondo;
                        enfrentamientoExtra.Size = new Size(65, 65);
                        enfrentamientoExtra.Location = new Point(17, vinculos[vinculos.Count - 1][1][0].Location.Y);
                        enfrentamientoExtra.BackColor = Color.Wheat;
                        enfrentamientos.Add(enfrentamientoExtra);

                        PointF a = new PointF(enfrentamiento.Parent.Location.X + enfrentamiento.Location.X + 32.5f, enfrentamiento.Parent.Location.Y + enfrentamiento.Location.Y);
                        PointF b = new PointF(vinculos[vinculos.Count - 2][0].Location.X + vinculos[vinculos.Count - 2][1][0].Location.X + 32.5f, vinculos[vinculos.Count - 2][0].Location.Y + vinculos[vinculos.Count - 2][1][0].Location.Y + 65);
                        PointF c = new PointF(enfrentamiento.Parent.Location.X + enfrentamiento.Location.X + 32.5f, enfrentamiento.Parent.Location.Y + enfrentamiento.Location.Y + 65);
                        PointF d = new PointF(vinculos[vinculos.Count - 2][0].Location.X + vinculos[vinculos.Count - 2][1][1].Location.X + 32.5f, vinculos[vinculos.Count - 2][0].Location.Y + vinculos[vinculos.Count - 2][1][1].Location.Y);
                        PointF e = new PointF(enfrentamiento.Parent.Location.X + enfrentamiento.Location.X + 65f, enfrentamiento.Parent.Location.Y + enfrentamiento.Location.Y + 32.5f);
                        PointF f = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][0].Location.X, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][0].Location.Y + 32.5f);

                        PointF g = new PointF(enfrentamientoExtra.Parent.Location.X + enfrentamientoExtra.Location.X + 32.5f, enfrentamientoExtra.Parent.Location.Y + enfrentamientoExtra.Location.Y);
                        PointF h = new PointF(enfrentamientos[0].Parent.Location.X + enfrentamientos[0].Location.X + 32.5f, enfrentamientos[0].Parent.Location.Y + enfrentamientos[0].Location.Y + 65f);
                        PointF u = new PointF(enfrentamientoExtra.Parent.Location.X + enfrentamientoExtra.Location.X + 32.5f, enfrentamientoExtra.Parent.Location.Y + enfrentamientoExtra.Location.Y + 65f);
                        PointF j = new PointF(enfrentamientos[1].Parent.Location.X + enfrentamientos[1].Location.X + 32.5f, enfrentamientos[1].Parent.Location.Y + enfrentamientos[1].Location.Y);
                        PointF k = new PointF(enfrentamientoExtra.Parent.Location.X + enfrentamientoExtra.Location.X, enfrentamientoExtra.Parent.Location.Y + enfrentamientoExtra.Location.Y + 32.5f);
                        PointF l = new PointF(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][1][0].Location.X + 65f, vinculos[vinculos.Count - 1][0].Location.Y + vinculos[vinculos.Count - 1][1][0].Location.Y + 32.5f);

                        formFases.Puntos.Add(a);
                        formFases.Puntos.Add(b);
                        formFases.Puntos.Add(c);
                        formFases.Puntos.Add(d);
                        formFases.Puntos.Add(e);
                        formFases.Puntos.Add(f);
                        formFases.Puntos.Add(g);
                        formFases.Puntos.Add(h);
                        formFases.Puntos.Add(u);
                        formFases.Puntos.Add(j);
                        formFases.Puntos.Add(k);
                        formFases.Puntos.Add(l);
                    }
                }
                if (i == 0)
                {
                    fondo.Size = new Size(fondo.Size.Width, enfrentamientos[enfrentamientos.Count - 1].Location.Y + 65 + 17);
                }
                else
                {
                    fondo.Size = new Size(fondo.Size.Width, fondos[0].Size.Height);
                }


                dynamic[] vinculo = new dynamic[2];
                vinculo[0] = fondo;
                vinculo[1] = enfrentamientos;

                vinculos.Add(vinculo);
            }

            formFases.altura = vinculos[vinculos.Count - 1][0].Height;
            formFases.localizacion = vinculos[vinculos.Count - 1][0].Location.X + 100;
            formFases.tm = new Size(vinculos[vinculos.Count - 1][0].Location.X + vinculos[vinculos.Count - 1][0].Size.Width, vinculos[0][0].Size.Height);
            formFases.ready = true;
            formFases.Pintar();

            for (int i = 0; i < vinculos.Count; i++)
            {
                vinculos[i][0].Controls[0].Location = new Point(vinculos[i][0].Location.X + vinculos[i][0].Controls[0].Location.X, vinculos[i][0].Location.Y + vinculos[i][0].Controls[0].Location.Y);
                vinculos[i][0].Controls[0].Parent = formFases.panel2;
            }

            //Momento eventos y cosas divertidas

            for (int i = 0; i < vinculos.Count; i++)
            {
                for (int x = 0; x < vinculos[i][1].Count; x++)
                {
                    if (vinculos[i][0].Controls[0].Text == "0")
                    {
                        if (i == 0)
                        {
                            Panel sender = vinculos[i][1][x];
                            vinculos[i][1][x].MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
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

                            vinculos[i][1][x].ControlAdded += new ControlEventHandler(delegate (Object s, ControlEventArgs exde)
                            {
                                if (sender.Controls.Count == 3)
                                {
                                    sender.Controls[1].MouseDown += new MouseEventHandler(delegate (Object sas, MouseEventArgs exdeas)
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

                                    sender.Controls[2].MouseDown += new MouseEventHandler(delegate (Object sas, MouseEventArgs exdeas)
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
                            });
                            Button config = new Button();
                            config.FlatAppearance.BorderSize = 1;
                            config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            config.Location = new System.Drawing.Point(0, 35);
                            config.Size = new System.Drawing.Size(65, 30);
                            config.Text = "Evento";
                            config.Parent = vinculos[i][1][x];
                            config.Visible = false;


                            Label a = new Label();
                            a.Text = "0/" + formFases.equiposEnDepo;
                            a.Parent = vinculos[i][1][x];
                            vinculos[i][1][x].Controls.SetChildIndex(a, 1);


                            a.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
                            {
                                if (a.Text == (formFases.equiposEnDepo + "/" + formFases.equiposEnDepo))
                                {
                                    config.Visible = true;
                                }
                                else
                                {
                                    config.Visible = false;
                                }
                            });

                            config.Click += new EventHandler(delegate (Object s, EventArgs exde)
                            {
                                Program.Blank.frmEvento = new Evento();
                                Program.Blank.frmEvento.MdiParent = Program.Blank;
                                Program.Blank.frmEvento.Show();
                                Program.Blank.frmEvento.cbDeporte.Text = deporte;
                                Program.Blank.frmEvento.cbDeporte.Enabled = false;
                                Program.Blank.frmEvento.comboBox1.Text = torneo;
                                Program.Blank.frmEvento.comboBox1.Enabled = false;
                                Program.Blank.torn.BringToFront();
                                Program.Blank.frmEvento.BringToFront();
                                this.frmEvento = Program.Blank.frmEvento;

                                Selected lista = new Selected(null, null);
                                for (int ixd = 0; ixd < SeleccionadosPorEquipos.Count; ixd++)
                                {
                                    if (SeleccionadosPorEquipos[ixd].enfrentamiento == sender)
                                    {
                                        lista = SeleccionadosPorEquipos[ixd];
                                        break;
                                    }
                                }

                                for (int o = 0; o < lista.Seleccionados.Count; o++)
                                {
                                    frmEvento.addEquipo();
                                    frmEvento.lista[frmEvento.lista.Count - 1].Text = lista.Seleccionados[o][0, 0] + "";
                                    frmEvento.lista[frmEvento.lista.Count - 1].Enabled = false;
                                }

                                frmEvento.caller = sender;

                                if (sender.Controls.Count == 3)
                                {
                                    frmEvento.textBox6.Text = sender.Controls[1].Controls[0].Text;
                                    frmEvento.textBox1.Text = sender.Controls[1].Controls[1].Text;
                                    frmEvento.textBox2.Text = sender.Controls[1].Controls[2].Text;
                                    frmEvento.textBox3.Text = sender.Controls[1].Controls[3].Text;
                                }

                            });
                        }
                        else
                        {
                            if (vinculos[i - 1][0].Controls[0].Text != "3")
                            {
                                Panel sender = vinculos[i][1][x];
                                vinculos[i][1][x].MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                                {
                                    MessageBox.Show("Compruebe que la fase anterior este finalizada para poder agregar equipos");
                                });

                                Button config = new Button();
                                config.FlatAppearance.BorderSize = 1;
                                config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                                config.Location = new System.Drawing.Point(0, 35);
                                config.Size = new System.Drawing.Size(65, 30);
                                config.Text = "Evento";
                                config.Parent = vinculos[i][1][x];
                                config.Visible = false;


                                Label a = new Label();
                                a.Text = "0/" + formFases.equiposEnDepo;
                                a.Parent = vinculos[i][1][x];
                                vinculos[i][1][x].Controls.SetChildIndex(a, 1);


                                a.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
                                {
                                    if (a.Text == (formFases.equiposEnDepo + "/" + formFases.equiposEnDepo))
                                    {
                                        config.Visible = true;
                                    }
                                    else
                                    {
                                        config.Visible = false;
                                    }
                                });

                                config.Click += new EventHandler(delegate (Object s, EventArgs exde)
                                {
                                    MessageBox.Show("Compruebe que la fase anterior este finalizada para poder agregar equipos");
                                });
                            }
                            else
                            {
                                Panel sender = vinculos[i][1][x];

                                Button config = new Button();
                                config.FlatAppearance.BorderSize = 1;
                                config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                                config.Location = new System.Drawing.Point(0, 35);
                                config.Size = new System.Drawing.Size(65, 30);
                                config.Text = "Evento";
                                config.Parent = vinculos[i][1][x];
                                config.Visible = false;


                                Label a = new Label();
                                a.Text = "0/" + formFases.equiposEnDepo;
                                a.Parent = vinculos[i][1][x];
                                vinculos[i][1][x].Controls.SetChildIndex(a, 1);


                                a.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
                                {
                                    if (a.Text == (formFases.equiposEnDepo + "/" + formFases.equiposEnDepo))
                                    {
                                        config.Visible = true;
                                    }
                                    else
                                    {
                                        config.Visible = false;
                                    }
                                });

                                config.Click += new EventHandler(delegate (Object s, EventArgs exde)
                                {
                                    Program.Blank.frmEvento = new Evento();
                                    Program.Blank.frmEvento.MdiParent = Program.Blank;
                                    Program.Blank.frmEvento.Show();
                                    Program.Blank.frmEvento.cbDeporte.Text = deporte;
                                    Program.Blank.frmEvento.cbDeporte.Enabled = false;
                                    Program.Blank.frmEvento.comboBox1.Text = torneo;
                                    Program.Blank.frmEvento.comboBox1.Enabled = false;
                                    Program.Blank.torn.BringToFront();
                                    Program.Blank.frmEvento.BringToFront();
                                    this.frmEvento = Program.Blank.frmEvento;

                                    Selected lista = new Selected(null, null);
                                    for (int ixd = 0; ixd < SeleccionadosPorEquipos.Count; ixd++)
                                    {
                                        if (SeleccionadosPorEquipos[ixd].enfrentamiento == sender)
                                        {
                                            lista = SeleccionadosPorEquipos[ixd];
                                            break;
                                        }
                                    }

                                    for (int o = 0; o < lista.Seleccionados.Count; o++)
                                    {
                                        frmEvento.addEquipo();
                                        frmEvento.lista[frmEvento.lista.Count - 1].Text = lista.Seleccionados[o][0, 0] + "";
                                        frmEvento.lista[frmEvento.lista.Count - 1].Enabled = false;
                                    }

                                    frmEvento.caller = sender;

                                    if (sender.Controls.Count == 3)
                                    {
                                        frmEvento.textBox6.Text = sender.Controls[1].Controls[0].Text;
                                        frmEvento.textBox1.Text = sender.Controls[1].Controls[1].Text;
                                        frmEvento.textBox2.Text = sender.Controls[1].Controls[2].Text;
                                        frmEvento.textBox3.Text = sender.Controls[1].Controls[3].Text;
                                    }

                                });
                            }
                        }
                    }
                    else
                    {
                        Panel sender = vinculos[i][1][x];
                        int id = x;
                        string nombrefase = vinculos[i][0].Name;
                        vinculos[i][1][x].MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                        {
                            int estado = int.Parse(sender.Parent.Controls[0].Text);
                            string actual = "";
                            switch (estado)
                            {
                                case 1:
                                    actual = "en proceso";
                                    break;
                                case 2:
                                    actual = "finalizada";
                                    break;
                            }
                            MessageBox.Show("Esta fase esta " + actual + ", no puede agregar ni modificar sus enfrentamientos y/o equipos");
                        });

                        vinculos[i][1][x].ControlAdded += new ControlEventHandler(delegate (Object s, ControlEventArgs exde)
                        {
                            if (sender.Controls.Count == 3)
                            {
                                sender.Controls[1].MouseDown += new MouseEventHandler(delegate (Object sas, MouseEventArgs exdeas)
                                {
                                    int estado = int.Parse(sender.Parent.Controls[0].Text);
                                    string actual = "";
                                    switch (estado)
                                    {
                                        case 1:
                                            actual = "en proceso";
                                            break;
                                        case 2:
                                            actual = "finalizada";
                                            break;
                                    }
                                    MessageBox.Show("Esta fase esta " + actual + ", no puede agregar ni modificar sus enfrentamientos y/o equipos");
                                });

                                sender.Controls[2].MouseDown += new MouseEventHandler(delegate (Object sas, MouseEventArgs exdeas)
                                {
                                    int estado = int.Parse(sender.Parent.Controls[0].Text);
                                    string actual = "";
                                    switch (estado)
                                    {
                                        case 1:
                                            actual = "en proceso";
                                            break;
                                        case 2:
                                            actual = "finalizada";
                                            break;
                                    }
                                    MessageBox.Show("Esta fase esta " + actual + ", no puede agregar ni modificar sus enfrentamientos y/o equipos");
                                });
                            }
                        });

                        Button config = new Button();
                        config.FlatAppearance.BorderSize = 1;
                        config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        config.Location = new System.Drawing.Point(0, 35);
                        config.Size = new System.Drawing.Size(65, 30);
                        config.Text = "Evento";
                        config.Parent = vinculos[i][1][x];
                        config.Visible = false;


                        Label a = new Label();
                        a.Text = "0/" + formFases.equiposEnDepo;
                        a.Parent = vinculos[i][1][x];
                        vinculos[i][1][x].Controls.SetChildIndex(a, 1);


                        a.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
                        {
                            if (a.Text == (formFases.equiposEnDepo + "/" + formFases.equiposEnDepo))
                            {
                                config.Visible = true;
                            }
                            else
                            {
                                config.Visible = false;
                            }
                        });

                        config.Click += new EventHandler(delegate (Object s, EventArgs exde)
                        {
                            int estado = int.Parse(sender.Parent.Controls[0].Text);
                            string actual = "";
                            switch (estado)
                            {
                                case 1:
                                    actual = "en proceso";
                                    break;
                                case 2:
                                    actual = "finalizada";
                                    break;
                            }
                            if (estado == 1)
                            {
                                Program.Blank.Partido = new Partido();

                                Program.Blank.Partido.MdiParent = Program.Blank;
                                Program.Blank.Partido.Show();
                                Program.Blank.Partido.Location = new Point(0, 0);
                                Program.Blank.Partido.id = id;
                                Program.Blank.Partido.nombreFase = nombrefase;
                                Program.Blank.Partido.nombreTorn = torneo;
                                Program.Blank.Partido.inicializar();
                            }
                            else
                            {
                                MessageBox.Show("Esta fase esta " + actual + ", no puede agregar ni modificar sus enfrentamientos y/o equipos");
                            }
                        });
                    }
                }
            }

            for (int ik = 0; ik < vinculos.Count; ik++)
            {
                for (int x = 0; x < vinculos[ik][1].Count; x++)
                {
                    Panel enfrentamiento = vinculos[ik][1][x];

                    List<dynamic[,]> Seleccionados = new List<dynamic[,]>();

                    Selected lista = new Selected(enfrentamiento, Seleccionados);
                    SeleccionadosPorEquipos.Add(lista);
                    List<dynamic[,]> equiposEliminar = new List<dynamic[,]>();
                    for (int i = 0; i < EquiposDisponibles.Count; i++)
                    {
                        equiposEliminar.Add(EquiposDisponibles[i]);
                    }
                    for (int i = 0; i < EquiposDisponibles.Count; i++)
                    {
                        dynamic equpDisp = EquiposDisponibles[i];

                        dynamic[,] info = Logica.consulta("Select * from equiposEvento where id = " + x + " and nombreFase = '" + vinculos[ik][0].Name + "' and nombreTorn = '" + torneo + "'");

                        for (int h = 0; h < Logica.consultaMaxIndex("Select * from equiposEvento where id = " + x + " and nombreFase = '" + vinculos[ik][0].Name + "' and nombreTorn = '" + torneo + "'"); h++)
                        {
                            if (info[1, h] == equpDisp[1, 0])
                            {
                                Seleccionados.Add(equpDisp);
                                equiposEliminar.Remove(equpDisp);
                            }
                        }
                    }
                    EquiposDisponibles = equiposEliminar;
                    if (enfrentamiento.Controls.Count > 0) enfrentamiento.Controls[enfrentamiento.Controls.Count - 1].Text = "" + Seleccionados.Count + "/" + formFases.equiposEnDepo;
                }
            }

            for (int i = 0; i < Program.Blank.torn.vinculos.Count; i++)
            {
                
                try
                {
                    for (int x = 0; x < Program.Blank.torn.vinculos[i][1].Count; x++)
                    {
                        if (Logica.consultaMaxIndex("Select * from Evento where nombreFase = '" + vinculos[i][0].Name + "' and nombreTorn = '" + torneo + "' and id = " + x + "") > 0)
                        {
                            dynamic[,] info = Logica.consulta("Select * from Evento where nombreFase = '" + vinculos[i][0].Name + "' and nombreTorn = '" + torneo + "' and id = " + x + "");
                            for (int z = 0; z < Logica.consultaMaxIndex("Select * from Evento where nombreFase = '" + vinculos[i][0].Name + "' and nombreTorn = '" + torneo + "' and id = " + x + ""); z++)
                            {
                                Label enf = new Label();
                                enf.Parent = Program.Blank.torn.vinculos[i][1][x];
                                enf.Location = new Point(0, 15);
                                enf.Text = info[3, z];
                                enf.AutoSize = false;
                                enf.BringToFront();
                                Program.Blank.torn.vinculos[i][1][x].Controls[1].BringToFront();


                                // *Indice de las putas cosas 
                                // * 0 = Boton de enfrentamiento
                                // * 1 = Label enf
                                // * 2 = Label cant Equipos



                                //.Controls.SetChildIndex();
                                Label titulo = new Label();
                                titulo.Parent = enf;
                                titulo.Visible = false;
                                titulo.Text = info[3, z];

                                DateTime fecha = info[0, z];

                                Label dia = new Label();
                                dia.Parent = enf;
                                dia.Visible = false;
                                dia.Text = fecha.Day + "";

                                Label mes = new Label();
                                mes.Parent = enf;
                                mes.Visible = false;
                                mes.Text = fecha.Month + "";

                                Label Ano = new Label();
                                Ano.Parent = enf;
                                Ano.Visible = false;
                                Ano.Text = fecha.Year + "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Esta funcion, ocasiona errores SOLO en la utu, por conflicto de drivers, que en caso de instalar el driver necesario para nosotros, borraria todas las anteriores versiones de odbc, saboteando al resto de equipos, sinceramente nos disculpamos por no poder brindar todas las funcionalidades del programa. En la defensa se mostraran capturas y videos de esta funcion y eventos en si, porque simplemente no funciona en la utu");
                    MessageBox.Show("Una vez ocurre este error, el funcionamiento del programa se deteriora gravemente, pudiendo crashear, le recomiendo reiniciar el programa");
                }
            }

        }


        void addEquipo()
        {
            cantEquipos++;
            label1.Location = new Point(12 + 182 * (cantEquipos % 3), 12 + (75 - 12) * (cantEquipos / 3) + cero.Location.Y);

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

            Button borrar = new Button();
            borrar.BackColor = System.Drawing.Color.DimGray;
            borrar.FlatAppearance.BorderSize = 0;
            borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            borrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            borrar.Location = new System.Drawing.Point(146, 11);
            borrar.Size = new System.Drawing.Size(23, 23);
            borrar.Text = "-";
            borrar.UseVisualStyleBackColor = false;
            borrar.Parent = equpo;

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

            borrar.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                if (this.formFases != null)
                {
                    MessageBox.Show("Cierre la configuracion de Eventos para poder realizar esta accion");
                }
                else
                {
                    if (estado == 0)
                    {
                        cantEquipos = 0;
                        Equipos.Remove(equpo);
                        for (int i = 0; i < Equipos.Count; i++)
                        {
                            cantEquipos++;
                            Equipos[i].Location = new Point(12 + 182 * ((cantEquipos - 1) % 3), cero.Location.Y + 12 + (75 - 12) * ((cantEquipos - 1) / 3));
                        }
                        label1.Location = new Point(12 + 182 * (cantEquipos % 3), 12 + (75 - 12) * (cantEquipos / 3) + cero.Location.Y);
                        equpo.Dispose();
                    }
                    else
                    {
                        if (estado == 1)
                        {
                            MessageBox.Show("Este torneo esta en proceso, no se pueden eliminar o agregar equipos");
                        }
                        else
                        {
                            MessageBox.Show("Este torneo esta finalizado, no se pueden eliminar o agregar equipos");
                        }
                    }
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

        private void label1_Click(object sender, EventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
            else if (this.formFases != null)
            {
                MessageBox.Show("Cierre la configuracion de Eventos para poder realizar esta accion");
            }
            else
            {
                if(estado == 0)
                {
                    addEquipo();
                }
                else
                {
                    if(estado == 1)
                    {
                        MessageBox.Show("Este torneo esta en proceso, no se pueden eliminar o agregar equipos");
                    }
                    else
                    {
                        MessageBox.Show("Este torneo esta finalizado, no se pueden eliminar o agregar equipos");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
            else if (this.formFases != null)
            {
                MessageBox.Show("Cierre la configuracion de Eventos para poder realizar esta accion");
            }
            else
            {
                for(int i = 0; i < Equipos.Count; i++)
                {
                    Equipos[i].Enabled = false;
                }
                if (estado == 0)
                {
                    Logica.comando("delete from EquipoTorneo where nombreTorn = '" + torneo + "'");
                    for (int i = 0; i < Equipos.Count; i++)
                    {
                        Logica.addEquipoTorneo(Equipos[i].Name, torneo);
                    }
                }
                cargafase();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
            else if (this.formFases != null)
            {
                MessageBox.Show("Cierre la configuracion de Eventos para poder realizar esta accion");
            }
            else
            {
                bool error = false;
                for (int i = 0; i < Equipos.Count; i++)
                {
                    if (Equipos[i].Name == "Indet")
                    {
                        error = true;
                        MessageBox.Show("Asegurese de completar todos los equipos");
                        break;
                    }
                }
                if (!error)
                {
                    if(estado == 0)
                    {
                        Logica.comando("delete from EquipoTorneo where nombreTorn = '" + torneo + "'");
                        for (int i = 0; i < Equipos.Count; i++)
                        {
                            Logica.addEquipoTorneo(Equipos[i].Name, torneo);
                        }
                    }
                    this.Visible = false;
                }
            }
        }

        private void pbDepoLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void Torneo_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void lblInfoTorn_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (frmEvento != null)
            {
                frmEvento.BringToFront();
            }
        }
    }
}
