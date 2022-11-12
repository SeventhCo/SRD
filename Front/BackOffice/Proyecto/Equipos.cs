using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Equipos : Form
    {
        public int cantEquipos = 0;
        public int equiposEnDepo = 0;
        public Label lineas;
        public Label lineas2;
        public Size tm;
        public int localizacion;
        public int altura;

        public bool ready = false;
        Pen Pen = new Pen(Color.Black, 8);

        public List<PointF> Puntos = new List<PointF>();
        public List<PointF> FinalDoble = new List<PointF>();

        public Equipos()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(delegate (object s, EventArgs exde)
            {
                if (this.Width > localizacion)
                {
                    if (altura > this.Height)
                    {
                        panel2.Size = new Size(this.Size.Width - 33, panel2.Size.Height);
                    }
                    else
                    {
                        panel2.Size = new Size(this.Size.Width - 16, panel2.Size.Height);
                    }
                }
                else
                {
                    panel2.Size = new Size(localizacion, panel2.Size.Height);
                }
                panel1.Size = new Size(panel1.Width, this.Height - 1);
                button1.Location = new Point(this.Width - 136, this.Height - 109);
            });
        }
        public void Pintar()
        {
            if (ready)
            {
                lineas = new Label();
                lineas.Text = "";
                lineas.AutoSize = false;
                lineas.Parent = this;
                lineas.Location = new Point(0, 0);
                lineas.BackColor = Color.FromArgb(255, 238, 215, 174);
                lineas.BringToFront();
                lineas.Visible = true;
                lineas.Paint += new PaintEventHandler(delegate (object s, PaintEventArgs exde)
                {

                    GraphicsPath myGraphicsPath = new GraphicsPath();

                    for (int i = 0; i < Puntos.Count; i = i + 4)
                    {
                        if (Puntos[i].X != Puntos[i + 1].X)
                        {
                            PointF[] poligono = {
                            new PointF(Puntos[i].X, Puntos[i].Y+2.5f),
                            new PointF(Puntos[i+1].X, Puntos[i+1].Y+2.5f),
                            new PointF(Puntos[i+1].X, Puntos[i+1].Y-2.5f),
                            new PointF(Puntos[i].X, Puntos[i].Y-2.5f),
                        };
                            myGraphicsPath.AddPolygon(poligono);
                        }
                        else
                        {
                            PointF[] poligono = {
                        new PointF(Puntos[i].X-2.5f, Puntos[i].Y),
                        new PointF(Puntos[i].X+2.5f, Puntos[i].Y),
                        new PointF(Puntos[i+1].X+2.5f, Puntos[i+1].Y),
                        new PointF(Puntos[i+1].X-2.5f, Puntos[i+1].Y),
                        };
                            myGraphicsPath.AddPolygon(poligono);
                        }
                    }
                    lineas.Region = new Region(myGraphicsPath);
                });
                lineas2 = new Label();
                lineas2.Text = "";
                lineas2.AutoSize = false;
                lineas2.Parent = this;
                lineas2.Location = new Point(0, 0);
                lineas2.BackColor = Color.FromArgb(255, 238, 215, 174);
                lineas2.BringToFront();
                lineas2.Visible = true;
                lineas2.Paint += new PaintEventHandler(delegate (object s, PaintEventArgs exde)
                {

                    GraphicsPath myGraphicsPath = new GraphicsPath();

                    for (int i = 2; i < Puntos.Count; i = i + 4)
                    {
                        if (Puntos[i].X != Puntos[i + 1].X)
                        {
                            PointF[] poligono = {
                            new PointF(Puntos[i].X, Puntos[i].Y+2.5f),
                            new PointF(Puntos[i+1].X, Puntos[i+1].Y+2.5f),
                            new PointF(Puntos[i+1].X, Puntos[i+1].Y-2.5f),
                            new PointF(Puntos[i].X, Puntos[i].Y-2.5f),
                        };
                            myGraphicsPath.AddPolygon(poligono);
                        }
                        else
                        {
                            PointF[] poligono = {
                        new PointF(Puntos[i].X-2.5f, Puntos[i].Y),
                        new PointF(Puntos[i].X+2.5f, Puntos[i].Y),
                        new PointF(Puntos[i+1].X+2.5f, Puntos[i+1].Y),
                        new PointF(Puntos[i+1].X-2.5f, Puntos[i+1].Y),
                        };
                            myGraphicsPath.AddPolygon(poligono);
                        }
                    }
                    lineas2.Region = new Region(myGraphicsPath);
                });
                lineas.Size = tm;
                lineas2.Size = tm;

            }
        }

        private void Equipos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_LocationChanged(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width - 136, this.Height - 109);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (this.Width > localizacion)
            {
                if (altura > this.Height)
                {
                    panel2.Size = new Size(this.Size.Width - 33, panel2.Size.Height);
                }
                else
                {
                    panel2.Size = new Size(this.Size.Width - 16, panel2.Size.Height);
                }
            }
            else
            {
                panel2.Size = new Size(localizacion, panel2.Size.Height);
            }
        }

        private void Equipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < Program.Blank.torn.Equipos.Count; i++)
            {
                Program.Blank.torn.Equipos[i].Enabled = true;
            }
            Program.Blank.torn.formFases = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int errores = 0;
            for (int i = 0; i < Program.Blank.torn.vinculos.Count; i++)
            {
                /*
                if (Program.Blank.torn.vinculos[i][0].Controls[0].Text == "0")
                {
                    for (int x = 0; x < Program.Blank.torn.vinculos[i][1].Count; x++)
                    {
                        if(Program.Blank.torn.vinculos[i][1][x].Controls.Count <= 2)
                        {
                            MessageBox.Show("Asegurese de ingresar Equipos y Enfrentamientos en cada fase");
                            errores++;
                        }
                    }
                }
                else */if (Program.Blank.torn.vinculos[i][0].Controls[0].Text == "1")
                {
                    for (int x = 0; x < Program.Blank.torn.vinculos[i][1].Count; x++)
                    {
                        if (Program.Blank.torn.vinculos[i][1][x].Controls.Count <= 2)
                        {
                            MessageBox.Show("Asegurese de ingresar Equipos y Enfrentamientos en todos los enfrentamientos de la fase : '"+ Program.Blank.torn.vinculos[i][0].Name + "'");
                            errores++;
                        }
                    }
                }
                if(errores > 0)
                {
                    break;
                }
            }
            if(errores == 0)
            {
                for (int i = 0; i < Program.Blank.torn.vinculos.Count; i++)
                {
                    if (Program.Blank.torn.vinculos[i][0].Controls[0].Text == "1")
                    {
                        for (int x = 0; x < Program.Blank.torn.vinculos[i][1].Count; x++)
                        {
                            for(int p = 0; p < Program.Blank.torn.SeleccionadosPorEquipos.Count; p++)
                            {
                                if (Program.Blank.torn.SeleccionadosPorEquipos[p].enfrentamiento == Program.Blank.torn.vinculos[i][1][x])
                                {
                                    for(int u = 0; u < Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados.Count; u++)
                                    {
                                        if (Logica.consultaMaxIndex("Select * from EquipoFase where nombreEqu = '" + Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados[u][1, 0] + "' and nombreTorn = '" + Program.Blank.torn.torneo + "' and nombreFase = '" + Program.Blank.torn.vinculos[i][0].Name + "'") == 0)
                                        {
                                            Logica.comando("Insert into EquipoFase values('" + Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados[u][1, 0] + "','" + Program.Blank.torn.torneo + "','" + Program.Blank.torn.vinculos[i][0].Name + "')");
                                        }
                                    }
                                }
                            }
                            
                            if (Logica.consultaMaxIndex("Select * from Evento where id = " + x + " and nombreFase = '" + Program.Blank.torn.vinculos[i][0].Name + "' and nombreTorn = '" + Program.Blank.torn.torneo + "'") == 0)
                            {
                                Logica.comando("Insert into Evento values('" + Program.Blank.torn.vinculos[i][1][x].Controls[1].Controls[3].Text + "-" + Program.Blank.torn.vinculos[i][1][x].Controls[1].Controls[2].Text + "-" + Program.Blank.torn.vinculos[i][1][x].Controls[1].Controls[1].Text + "',0," + x + ",'" + Program.Blank.torn.vinculos[i][1][x].Controls[1].Controls[0].Text + "',null,'" + Program.Blank.torn.vinculos[i][0].Name + "','" + Program.Blank.torn.torneo + "')");
                            }

                            for (int p = 0; p < Program.Blank.torn.SeleccionadosPorEquipos.Count; p++)
                            {
                                if (Program.Blank.torn.SeleccionadosPorEquipos[p].enfrentamiento == Program.Blank.torn.vinculos[i][1][x])
                                {
                                    for (int u = 0; u < Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados.Count; u++)
                                    {
                                        if (Logica.consultaMaxIndex("Select * from equiposEvento where id = "+x+" and nombreEqu = '" + Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados[u][1, 0] + "' and nombreTorn = '" + Program.Blank.torn.torneo + "' and nombreFase = '" + Program.Blank.torn.vinculos[i][0].Name + "'") == 0)
                                        {
                                            Logica.comando("Insert into equiposEvento values("+x+",'" + Program.Blank.torn.SeleccionadosPorEquipos[p].Seleccionados[u][1, 0] + "','" + Program.Blank.torn.vinculos[i][0].Name + "','" + Program.Blank.torn.torneo + "')");
                                        }
                                    }
                                }
                            }
                            //El error esta en que se elimina EquipoTorneo borrando en cascada equiposEvento
                            //Solucion: updatear el estado de la fase, y por lo tanto del torneo, impidiendo agregar o borrar equipos
                        }
                        Console.WriteLine(" update Torneo set estado = " + Program.Blank.torn.vinculos[i][0].Controls[0].Text + " where nombreTorn = '" + Program.Blank.torn.torneo + "'");
                        Logica.comando(" update Torneo set estado = "+ Program.Blank.torn.vinculos[i][0].Controls[0].Text + " where nombreTorn = '"+ Program.Blank.torn.torneo + "'");
                        Program.Blank.torn.estado = int.Parse(Program.Blank.torn.vinculos[i][0].Controls[0].Text);
                        Logica.comando("update fase set estado = "+ Program.Blank.torn.vinculos[i][0].Controls[0].Text + " where nombreFase = '"+ Program.Blank.torn.vinculos[i][0].Name+ "' and nombreTorn = '" + Program.Blank.torn.torneo + "'");
                    }
                }
            }
        }
    }
}
