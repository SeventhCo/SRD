using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Evento : Form
    {
        int cantFilas = 0;
        public List<ComboBox> lista = new List<ComboBox>();
        List<string> datos = new List<string>();
        public Panel caller;

        void cargarDatos()
        {
            datos.Clear();
            dynamic[,] var = Logica.consulta("SELECT nombreEqu FROM equipo");
            if (var != null)
            {
                for (int i = 0; i < var.Length; i++)
                {
                    datos.Add(var[0, i]);
                }
            }
        }

        public Evento()
        {
            InitializeComponent();
            Deportes();
            Torneos();
            cargarDatos();
        }

        public void actualizar()
        {
            Idioma.controles(panel26);
            Idioma.controles(panel2);
            Idioma.controles(panel22);
            Idioma.controles(panel4);
            Idioma.controles(pnlEventos);
            Idioma.controles(panel16);
            Idioma.controles(panel1);
        }

        public void addEquipo()
        {
            if(cbDeporte.Text != "")
            {

                button3.Location = new Point(button3.Location.X, 42 + 24 * (cantFilas));
                ComboBox cbEquipos = new ComboBox();
                cbEquipos.Parent = panel1;
                cbEquipos.Size = new Size(174, 23);
                cbEquipos.Location = new Point(9, 18 + 24 * cantFilas);
                cbEquipos.BackColor = Color.DarkGray;
                cbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
                lista.Add(cbEquipos);

                cantFilas++;
                for (int i = 0; i < datos.Count; i++)
                {
                    cbEquipos.Items.Add(datos[i]);
                }

                List<string> seleccionados1 = new List<string>();

                for (int x = 0; x < lista.Count; x++)
                {
                    seleccionados1.Add(lista[x].Text);
                }
                for (int z = 0; z < seleccionados1.Count; z++)
                {
                    cbEquipos.Items.Remove(seleccionados1[z]);
                }

                cbEquipos.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        List<string> seleccionados = new List<string>();
                        string text = lista[i].Text;

                        for (int f = 0; f < datos.Count; f++)
                        {
                            if (!lista[i].Items.Contains(datos[f]))
                            {
                                lista[i].Items.Add(datos[f]);
                            }
                        }

                        for (int x = 0; x < lista.Count; x++)
                        {
                            if (lista[x] != lista[i]) seleccionados.Add(lista[x].Text);
                        }
                        for (int z = 0; z < seleccionados.Count; z++)
                        {
                            lista[i].Items.Remove(seleccionados[z]);
                        }
                        for (int t = 0; t < lista[i].Items.Count; t++)
                        {
                            if (lista[i].Items.IndexOf("") == t)
                            {
                                lista[i].Items.RemoveAt(t);
                            }
                        }

                        if (lista[i].Text != "")
                        {
                            lista[i].Items.Add("");
                        }
                    }
                });
            }
            else
            {
                MessageBox.Show("Seleccione Deporte");
            }
        }

        public void Deportes()
        {
            cbDeporte.Items.Clear();
            dynamic[,] variable = Logica.consulta("Select nombreDep from deporte ");
            if (variable != null)
            {
                for (int i = 0; i < variable.Length; i++)
                {
                    cbDeporte.Items.Add(variable[0, i]);
                }
            }
        }

        public void Torneos()
        {
            comboBox1.Items.Clear();
            dynamic[,] variable = Logica.consulta("Select nombreTorn from Torneo ");
            if (variable != null)
            {
                for (int i = 0; i < variable.Length; i++)
                {
                    comboBox1.Items.Add(variable[0, i]);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
            Program.Blank.torn.frmEvento = null; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addEquipo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "")
            {
                MessageBox.Show("Ingrese un Titulo al evento");
            }
            else if (textBox1.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Ingrese un Dia valido en la fecha del evento");
            }
            else if (textBox2.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Ingrese un Mes valido en la fecha del evento");
            }
            else if (textBox3.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Ingrese un Año valido en la fecha del evento");
            }
            else
            {
                for (int i = 0; i < Program.Blank.torn.vinculos.Count; i++)
                {
                    for (int x = 0; x < Program.Blank.torn.vinculos[i][1].Count; x++)
                    {
                        if (Program.Blank.torn.vinculos[i][1][x] == caller)
                        {
                            if (Program.Blank.torn.vinculos[i][1][x].Controls.Count >= 3)
                            {
                                Program.Blank.torn.vinculos[i][1][x].Controls[1].Dispose();
                            }

                            Label enf = new Label();
                            enf.Parent = Program.Blank.torn.vinculos[i][1][x];
                            enf.Location = new Point(0, 15);
                            enf.Text = textBox6.Text;
                            enf.AutoSize = false;
                            enf.BringToFront();
                            Program.Blank.torn.vinculos[i][1][x].Controls[1].BringToFront();

                            /*
                             *Indice de las putas cosas 
                             * 0 = Boton de enfrentamiento
                             * 1 = Label enf
                             * 2 = Label cant Equipos
                             */


                            //.Controls.SetChildIndex();
                            Label titulo = new Label();
                            titulo.Parent = enf;
                            titulo.Visible = false;
                            titulo.Text = textBox6.Text;

                            Label dia = new Label();
                            dia.Parent = enf;
                            dia.Visible = false;
                            dia.Text = textBox1.Text;

                            Label mes = new Label();
                            mes.Parent = enf;
                            mes.Visible = false;
                            mes.Text = textBox2.Text;

                            Label Ano = new Label();
                            Ano.Parent = enf;
                            Ano.Visible = false;
                            Ano.Text = textBox3.Text;

                            Program.Blank.frmPrincipal.Enabled = true;
                            this.Visible = false;
                            Program.Blank.torn.frmEvento = null;

                        }
                    }
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(textBox1.Text, out num)) textBox1.ForeColor = Color.Red;
            else if (num >= 32) textBox1.ForeColor = Color.Red;
            else textBox1.ForeColor = System.Drawing.SystemColors.Menu;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(textBox2.Text, out num)) textBox2.ForeColor = Color.Red;
            else if (num >= 13) textBox2.ForeColor = Color.Red;
            else textBox2.ForeColor = System.Drawing.SystemColors.Menu;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(textBox3.Text, out num)) textBox3.ForeColor = Color.Red;
            else if (num < 2000) textBox3.ForeColor = Color.Red;
            else textBox3.ForeColor = System.Drawing.SystemColors.Menu;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Dia")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Mes")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Año")
            {
                textBox3.Text = "";
            }
        }
        
    }
}
