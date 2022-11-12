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
    public partial class Partido : Form
    {
        public int id;
        public string nombreFase, nombreTorn;
        public dynamic[,] info;
        int arbitros = 0;
        int cantEquipos = 0;
        public List<Panel> Sucesos = new List<Panel>();
        public List<Panel> Equipos = new List<Panel>();
        public List<Panel> EquiposVertical = new List<Panel>();
        public List<Panel> Arbitros = new List<Panel>();

        public Partido()
        {
            InitializeComponent();
        }

        public void inicializar()
        {
            info = Logica.consulta("Select * from Evento where id = "+id+" and nombreFase = '"+nombreFase+"' and nombreTorn = '"+nombreTorn+"'");
            label1.Text = info[3,0];
            addEquipo();
            equiposAlineaciones();
            label2.Text = "Torneo: " + nombreTorn + "\n"+
                          "Fase : "+nombreFase+"\n"+
                          "Cantidad de Equipos : "+ Logica.consultaMaxIndex("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlEquipos.Visible = true;
            pnlAlineaciones.Visible = false;
            pnlArbitros.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlAlineaciones.Visible = true;
            pnlEquipos.Visible = false;
            pnlArbitros.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlArbitros.Visible = true;
            pnlAlineaciones.Visible = false;
            pnlEquipos.Visible = false;
        }

        void addEquipo()
        {
            dynamic[,] infoEquipos = Logica.consulta("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
            int indice = Logica.consultaMaxIndex("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
            for (int i = 0; i < indice; i++)
            {
                dynamic[,] infoPorEquipo = Logica.consulta("Select * from equipo where nombreEqu = '" + infoEquipos[1,i]+"'");

                Panel equi = new Panel();
                equi.Parent = pnlEquipos;
                equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                equi.Location = new System.Drawing.Point(17 + 78 * ((cantEquipos) % 8), 7 + 93 * ((cantEquipos) / 8));
                equi.Name = infoPorEquipo[0, 0];
                equi.Size = new System.Drawing.Size(64, 80);
                cantEquipos++;
                Equipos.Add(equi);

                /* aqui se pone el logo del equipo */
                PictureBox imgEqui = new PictureBox();
                imgEqui.Name = equi.Name + "img";
                imgEqui.Parent = equi;
                imgEqui.Visible = true;
                imgEqui.Location = new System.Drawing.Point(0, 0);
                imgEqui.Size = new System.Drawing.Size(64, 64);
                imgEqui.SizeMode = PictureBoxSizeMode.StretchImage;
                imgEqui.Image = Logica.conByteImg(Convert.FromBase64String(infoPorEquipo[2, 0]));

                Label nomCorto = new Label();
                nomCorto.Parent = equi;
                nomCorto.Text = infoPorEquipo[1, 0];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    //
                });

                imgEqui.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    //
                });
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {

        }
        
        public void equiposAlineaciones()
        {
            dynamic[,] infoEquipos = Logica.consulta("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
            int indice = Logica.consultaMaxIndex("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");

            List<dynamic[]> vinculos = new List<dynamic[]>();
            for (int i = 0; i < indice; i++)
            {
                dynamic[,] infoPorEquipo = Logica.consulta("Select * from equipo where nombreEqu = '" + infoEquipos[1, i] + "'");

                Panel equipo = new Panel();
                equipo.Visible = true;
                equipo.Parent = pnlEquipoAlineacion;
                equipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                equipo.Location = new System.Drawing.Point(12, 12 + 86 * (i));
                equipo.Name = infoPorEquipo[1, 0];
                equipo.Size = new System.Drawing.Size(64, 80);
                EquiposVertical.Add(equipo);

                // aqui se pone el logo del equipo 
                PictureBox imgequipo = new PictureBox();
                imgequipo.Parent = equipo;
                imgequipo.Visible = true;
                imgequipo.Location = new System.Drawing.Point(0, 0);
                imgequipo.Size = new System.Drawing.Size(64, 64);
                imgequipo.SizeMode = PictureBoxSizeMode.StretchImage;
                imgequipo.Image = Logica.conByteImg(Convert.FromBase64String(infoPorEquipo[2, 0]));

                Label nomCorto = new Label();
                nomCorto.Parent = equipo;
                nomCorto.Text = infoPorEquipo[1, 0];
                nomCorto.Visible = true;
                nomCorto.AutoSize = false;
                nomCorto.Size = new Size(64, 13);
                nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                nomCorto.Location = new Point(0, 65);

                Panel deportistas = new Panel();
                deportistas.Parent = pnlAlineaciones;
                deportistas.Location = new Point(94, 3);
                deportistas.Size = new Size(447, 295);
                deportistas.Visible = false;
                deportistas.AutoScroll = true;

                ComboBox jugadoresDisponibles = new ComboBox();
                jugadoresDisponibles.Visible = false;
                dynamic[,] infoDeportistas = Logica.consulta("Select nombreEqu,numero from deportistaEquipo where nombreEqu = '" + infoEquipos[1, i] + "'");
                for (int h = 0; h < Logica.consultaMaxIndex("Select nombreEqu,numero from deportistaEquipo where nombreEqu = '"+ infoEquipos[1, i] + "'"); h++)
                {
                    jugadoresDisponibles.Items.Add(infoDeportistas[1,h]+"");
                }

                dynamic[,] infoDepo = Logica.consulta("Select * from deporte where nombreDep = '" + Logica.consulta("Select nombreDep from Torneo where nombreTorn = '" + nombreTorn + "'")[0, 0] + "'");

                List<ComboBox> depos = new List<ComboBox>();

                for(int u = 0; u < infoDepo[4,0]; u++)
                {
                    ComboBox deportista = new ComboBox();
                    deportista.BackColor = Color.DarkGray;
                    deportista.DropDownStyle = ComboBoxStyle.DropDownList;
                    deportista.Location = new Point(9, 8 + 27 * u);
                    deportista.Size = new Size(162, 21);
                    deportista.Parent = deportistas;
                    depos.Add(deportista);

                    Label previo = new Label();
                    previo.Parent = deportista;
                    previo.Text = "";
                    previo.Visible = false;

                    for(int o = 0; o < jugadoresDisponibles.Items.Count; o++)
                    {
                        deportista.Items.Add(jugadoresDisponibles.Items[o]);
                    }
                    deportista.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
                    {
                        if(previo.Text == "")
                        {
                            jugadoresDisponibles.Items.Remove(deportista.Text);
                            previo.Text = deportista.Text;
                        }
                        else
                        {
                            jugadoresDisponibles.Items.Add(previo.Text);
                            jugadoresDisponibles.Items.Remove(deportista.Text);
                            previo.Text = deportista.Text;
                        }
                        for(int f = 0; f < depos.Count; f++)
                        {
                            depos[f].Items.Clear();
                            for (int o = 0; o < jugadoresDisponibles.Items.Count; o++)
                            {
                                depos[f].Items.Add(jugadoresDisponibles.Items[o]);
                            }
                        }
                    });

                    Label txt = new Label();
                    txt.Text = "Posicion :";
                    txt.AutoSize = false;
                    txt.Size = new Size(84, 21);
                    txt.TextAlign = ContentAlignment.MiddleCenter;
                    txt.Location = new Point(177, 8 + 27 * u);
                    txt.Font = new Font("Microsoft Sans Serif", 11.25F);
                    txt.Parent = deportistas;
                    
                    TextBox posicion = new TextBox();
                    posicion.Parent = deportistas;
                    posicion.Size = new Size(155, 20);
                    posicion.Location = new Point(265, 8 + 27*u);
                }

                Button guardar = new Button();
                guardar.FlatAppearance.BorderColor = Color.Lime;
                guardar.FlatStyle = FlatStyle.Flat;
                guardar.ForeColor = SystemColors.Control;
                guardar.Location = new Point(9, deportistas.Controls[deportistas.Controls.Count-1].Location.Y+27);
                guardar.Size = new Size(411, 23);
                guardar.Text = "Guardar";
                guardar.Parent = deportistas;


                dynamic[] vinculo = new dynamic[2];
                vinculo[0] = equipo;
                vinculo[1] = deportistas;

                vinculos.Add(vinculo);

                nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    for(int g = 0; g < vinculos.Count; g++)
                    {
                        vinculos[g][1].Visible = false;
                    }
                    deportistas.Visible = true;
                });

                imgequipo.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                {
                    for (int g = 0; g < vinculos.Count; g++)
                    {
                        vinculos[g][1].Visible = false;
                    }
                    deportistas.Visible = true;
                });
                
            }
                
        }
    }
}
