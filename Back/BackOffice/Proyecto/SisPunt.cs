using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class SisPunt : Form
    {
        public List<Panel> puntos = new List<Panel>();
        public List<TextBox> datosPuntos = new List<TextBox>();

        public List<Panel> sets = new List<Panel>();
        public List<TextBox> datosSets = new List<TextBox>();
        public List<CheckBox> cbSet = new List<CheckBox>();
        
        public List<List<Panel>> puntosSets = new List<List<Panel>>();
        public List<List<TextBox>> datosPuntosSets = new List<List<TextBox>>();

        int cantFilas = 0;
        int cantSets = 0;

        public void actualizar()
        {
            Idioma.controles(panelSisPuntaje);
            Idioma.controles(pnlSubSisPuntaje);
        }

        public SisPunt()
        {
            InitializeComponent();
        }

        public void crearPunto()
        {
            label3.Location = new Point(label3.Location.X,  6 + 72 * (cantFilas+1) + label1.Location.Y-1);

            Panel nombre = new Panel();
            nombre.Size = new Size(168, 67);
            nombre.Location = new Point(3, 6 + 72 * cantFilas + label1.Location.Y-1);
            nombre.BackColor = Color.LightGray;
            nombre.Parent = panel2;
            puntos.Add(nombre);

            Button remove = new Button();
            remove.Parent = nombre;
            remove.Size = new Size(24, 24);
            remove.Text = "-";
            remove.Location = new Point(135, 5);
            remove.BackColor = Color.LightGray;

            Label nomPunto = new Label();
            nomPunto.Location = new Point(6, 20);
            nomPunto.Text = "Nombre del punto";
            nomPunto.Parent = nombre;
            nomPunto.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            nomPunto.Size = new Size(109, 15);

            TextBox txtNom = new TextBox();
            txtNom.Parent = nombre;
            txtNom.Location = new Point(4, 41);
            txtNom.Size = new Size(160, 13);
            txtNom.BorderStyle = BorderStyle.None;
            txtNom.ForeColor = Color.FromArgb(0, 240, 240, 240);
            txtNom.BackColor = Color.DarkGray;
            datosPuntos.Add(txtNom);

            Panel inutil = new Panel();
            inutil.Parent = nombre;
            inutil.BackColor = Color.FromArgb(0, 2, 48, 71);
            inutil.Location = new Point(0, 63);
            inutil.Size = new Size(171, 3);

            Panel valor = new Panel();
            valor.Size = new Size(169, 67);
            valor.Location = new Point(176,  6 + (72 * cantFilas) + label1.Location.Y-1);
            valor.BackColor = Color.LightGray;
            valor.Parent = panel2;
            puntos.Add(valor);

            Label nomValor = new Label();
            nomValor.Location = new Point(6, 20);
            nomValor.Text = "Valor del punto";
            nomValor.Parent = valor;
            nomValor.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            nomValor.BringToFront();
            //nomValor.Size = new Size(91, 15);

            TextBox txtVal = new TextBox();
            txtVal.Parent = valor;
            txtVal.Location = new Point(4, 41);
            txtVal.Size = new Size(162, 13);
            txtVal.BorderStyle = BorderStyle.None;
            txtVal.ForeColor = Color.FromArgb(0, 240, 240, 240);
            txtVal.BackColor = Color.DarkGray;
            txtVal.BringToFront();
            datosPuntos.Add(txtVal);

            Panel inutil2 = new Panel();
            inutil2.Parent = valor;
            inutil2.BackColor = Color.FromArgb(0, 2, 48, 71);
            inutil2.Location = new Point(0, 63);
            inutil2.Size = new Size(171, 3);
            
            cantFilas++;

            remove.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                datosPuntos.Remove(txtNom);
                datosPuntos.Remove(txtVal);
                nombre.Dispose();
                puntos.Remove(nombre);
                valor.Dispose();
                puntos.Remove(valor);
                cantFilas = 0;
                for(int i = 0; i < puntos.Count; i = i+2)
                {
                    puntos[i].Location = new Point(3, 6 + 72 * cantFilas + label1.Location.Y - 1);
                    puntos[i+1].Location = new Point(176, 6 + (72 * cantFilas) + label1.Location.Y - 1);
                    cantFilas++;
                }
                label3.Location = new Point(label3.Location.X, 6 + 72 * (cantFilas) + label1.Location.Y - 1);
            });
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Equals("Punto"))
            {
                panel2.Visible = true;
                panel3.Visible = false;
                panel1.Visible = false;
            }
            else if (comboBox2.Text.Equals("Set"))
            {
                panel1.Visible = true;
                panel3.Visible = false;
                panel2.Visible = false;
            }
            else if (comboBox2.Text.Equals("Magnitud"))
            {
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            crearPunto();
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            
            int i = 0,cantPuntos = 0;
            for (int y = 0; y < sets.Count; y++)

            {
                i = i + 4 + sets[y].Size.Height;
            }
            label6.Location = new Point(label6.Location.X, 155 + 6 + i + label10.Location.Y - 1);

            Panel set = new Panel();
            set.Parent = panel1;
            set.Location = new Point(4,4+i+label10.Location.Y-1);
            set.Size = new Size(339, 155);
            set.BorderStyle = BorderStyle.FixedSingle;
            sets.Add(set);
            set.BackColor = Color.DimGray;

            Label cero = new Label();
            cero.Parent = set;
            cero.AutoSize = false;
            cero.Size = new Size(1,1);
            cero.Location = new Point(1, 1);

            Panel cantSet = new Panel();
            cantSet.Parent = set;
            cantSet.Location = new Point(3, 4+cero.Location.Y-1);
            cantSet.BackColor = Color.LightGray;
            cantSet.Size = new Size(97, 67);
            
            Label lblCantSet = new Label();
            lblCantSet.Parent = cantSet;
            lblCantSet.Location = new Point(6, 20);
            lblCantSet.Text = "Cant de Sets";
            lblCantSet.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblCantSet.Size = new Size(76, 15);

            TextBox txtCantSet = new TextBox();
            txtCantSet.Location = new Point(4, 41);
            txtCantSet.Parent = cantSet;
            txtCantSet.BackColor = Color.DarkGray;
            txtCantSet.Size = new Size(89, 20);
            txtCantSet.ForeColor = Color.FromArgb(0, 240, 240, 240);
            datosSets.Add(txtCantSet);

            Panel inutil1 = new Panel();
            inutil1.Parent = cantSet;
            inutil1.Location = new Point(0, 63);
            inutil1.Size = new Size(97, 3);
            inutil1.BackColor = Color.FromArgb(0, 2, 48, 71);

            Panel delim = new Panel();
            delim.Parent = set;
            delim.Location = new Point(106, 4 + cero.Location.Y - 1);
            delim.Size = new Size(106, 67);
            delim.BackColor = Color.LightGray;

            Label lblDelim = new Label();
            lblDelim.Parent = delim;
            lblDelim.Location = new Point(6,20);
            lblDelim.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblDelim.Size = new Size(73, 15);
            lblDelim.Text = "Delimitador";

            TextBox txtDelim = new TextBox();
            txtDelim.Location = new Point(4, 41);
            txtDelim.Parent = delim;
            txtDelim.BackColor = Color.DarkGray;
            txtDelim.Size = new Size(98, 20);
            txtDelim.ForeColor = Color.FromArgb(0, 240, 240, 240);
            datosSets.Add(txtDelim);

            Panel inutil2 = new Panel();
            inutil2.Parent = delim;
            inutil2.Location = new Point(0, 63);
            inutil2.Size = new Size(delim.Size.Width, 3);
            inutil2.BackColor = Color.FromArgb(0, 2, 48, 71);

            Panel suma = new Panel();
            suma.Parent = set;
            suma.Location = new Point(218, 4 + cero.Location.Y - 1);
            suma.Size = new Size(116, 67);
            suma.BackColor = Color.LightGray;

            CheckBox chkIndiv = new CheckBox();
            chkIndiv.Parent = suma;
            chkIndiv.Location = new Point(9, 35);
            chkIndiv.Size = new Size(71, 17);
            chkIndiv.Text = "Individual";
            chkIndiv.CheckState = CheckState.Checked;
            cbSet.Add(chkIndiv);

            CheckBox chkSuma = new CheckBox();
            chkSuma.Parent = suma;
            chkSuma.Location = new Point(9,12);
            chkSuma.Size = new Size(53, 17);
            chkSuma.Text = "Suma";
            chkSuma.CheckState = CheckState.Unchecked;
            cbSet.Add(chkSuma);

            chkSuma.CheckedChanged += new EventHandler(delegate (object s, EventArgs exde)
            {
                if (chkSuma.CheckState == CheckState.Checked) chkIndiv.CheckState = CheckState.Unchecked;
                else if (chkSuma.CheckState == CheckState.Unchecked) chkIndiv.CheckState = CheckState.Checked;
            });

            chkIndiv.CheckedChanged += new EventHandler(delegate (object s, EventArgs exde)
            {
                if (chkIndiv.CheckState == CheckState.Checked) chkSuma.CheckState = CheckState.Unchecked;
                else if (chkIndiv.CheckState == CheckState.Unchecked) chkSuma.CheckState = CheckState.Checked;
            });

            Button elimSet = new Button();
            elimSet.Parent = suma;
            elimSet.Location = new Point(89, 3);
            elimSet.Size = new Size(24, 24);
            elimSet.Text = "-";

            elimSet.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                for (int x = sets.IndexOf(set) + 1; x < sets.Count; x++)
                {
                    sets[x].Location = new Point(sets[x].Location.X, sets[x].Location.Y - 4 - set.Size.Height);
                }
                label6.Location = new Point(label6.Location.X, label6.Location.Y - 4 - set.Size.Height);

                sets.Remove(set);
                set.Dispose();
            });


            Panel inutil3 = new Panel();
            inutil3.Parent = suma;
            inutil3.Location = new Point(0, 63);
            inutil3.Size = new Size(suma.Size.Width, 3);
            inutil3.BackColor = Color.FromArgb(0, 2, 48, 71);

            Panel inutil4 = new Panel();
            inutil4.Parent = set;
            inutil4.Location = new Point(3,75+cero.Location.Y-1);
            inutil4.Size = new Size(331, 3);
            inutil4.BackColor = Color.Black;

            Label btnPunto = new Label();
            btnPunto.Parent = set;
            btnPunto.Location = new Point(3, 81);
            btnPunto.AutoSize = false;
            btnPunto.BackColor = Color.LightGray;
            btnPunto.BorderStyle = BorderStyle.FixedSingle;
            btnPunto.Size = new Size(331, 67);
            btnPunto.Font = new Font("Microsoft Sans Serif", 27.75f,FontStyle.Regular);
            btnPunto.TextAlign = ContentAlignment.MiddleCenter;
            btnPunto.Text = "Agregar Punto";

            List<Panel> puntos = new List<Panel>();
            List<TextBox> datosPuntos = new List<TextBox>();
            puntosSets.Add(puntos);
            datosPuntosSets.Add(datosPuntos);
            btnPunto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                label6.Location = new Point(label6.Location.X, label6.Location.Y + 72);
                set.Size = new Size(set.Size.Width,set.Size.Height+72);
                for (int x = sets.IndexOf(set) + 1; x < sets.Count; x++)
                {
                    sets[x].Location = new Point(sets[x].Location.X, sets[x].Location.Y + 72);
                }
                btnPunto.Location = new Point(btnPunto.Location.X, 82 + 72 * (cantPuntos + 1) + cero.Location.Y - 1);

                Panel nombre = new Panel();
                nombre.Name = sets.IndexOf(set)+"";
                nombre.Size = new Size(163, 67);
                nombre.Location = new Point(3, 82 + 72 * cantPuntos + cero.Location.Y - 1);
                nombre.BackColor = Color.LightGray;
                nombre.Parent = set;
                puntos.Add(nombre);

                Button remove = new Button();
                remove.Parent = nombre;
                remove.Size = new Size(24, 24);
                remove.Text = "-";
                remove.Location = new Point(135, 5);
                remove.BackColor = Color.LightGray;

                Label nomPunto = new Label();
                nomPunto.Location = new Point(6, 20);
                nomPunto.Text = "Nombre del punto";
                nomPunto.Parent = nombre;
                nomPunto.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                nomPunto.Size = new Size(109, 15);

                TextBox txtNom = new TextBox();
                txtNom.Parent = nombre;
                txtNom.Location = new Point(4, 41);
                txtNom.Size = new Size(155, 20);
                txtNom.BorderStyle = BorderStyle.None;
                txtNom.ForeColor = Color.FromArgb(0, 240, 240, 240);
                txtNom.BackColor = Color.DarkGray;
                datosPuntos.Add(txtNom);

                Panel inutil = new Panel();
                inutil.Parent = nombre;
                inutil.BackColor = Color.FromArgb(0, 2, 48, 71);
                inutil.Location = new Point(0, 63);
                inutil.Size = new Size(171, 3);

                Panel valor = new Panel();
                valor.Name = sets.IndexOf(set) + "";
                valor.Size = new Size(162, 67);
                valor.Location = new Point(172, 82 + (72 * cantPuntos) + cero.Location.Y - 1);
                valor.BackColor = Color.LightGray;
                valor.Parent = set;
                puntos.Add(valor);

                Label nomValor = new Label();
                nomValor.Location = new Point(6, 20);
                nomValor.Text = "Valor del punto";
                nomValor.Parent = valor;
                nomValor.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                nomValor.Size = new Size(91, 15);

                TextBox txtVal = new TextBox();
                txtVal.Parent = valor;
                txtVal.Location = new Point(4, 41);
                txtVal.Size = new Size(155, 20);
                txtVal.BorderStyle = BorderStyle.None;
                txtVal.ForeColor = Color.FromArgb(0, 240, 240, 240);
                txtVal.BackColor = Color.DarkGray;
                datosPuntos.Add(txtVal);

                Panel inutil24 = new Panel();
                inutil24.Parent = valor;
                inutil24.BackColor = Color.FromArgb(0, 2, 48, 71);
                inutil24.Location = new Point(0, 63);
                inutil24.Size = new Size(171, 3);

                cantPuntos++;

                remove.MouseDown += new MouseEventHandler(delegate (Object s1, MouseEventArgs exde1)
                {
                    datosPuntos.Remove(txtNom);
                    datosPuntos.Remove(txtVal);
                    nombre.Dispose();
                    puntos.Remove(nombre);
                    valor.Dispose();
                    puntos.Remove(valor);
                    cantPuntos = 0;
                    for (int ii = 0; ii < puntos.Count; ii = ii + 2)
                    {
                        puntos[ii].Location = new Point(3, 82 + 72 * cantPuntos + label1.Location.Y - 1);
                        puntos[ii + 1].Location = new Point(176, 82 + (72 * cantPuntos) + label1.Location.Y - 1);
                        cantPuntos++;
                    }
                    btnPunto.Location = new Point(btnPunto.Location.X,82 + 72 * (cantPuntos) + cero.Location.Y - 1);
                    set.Size = new Size(set.Size.Width, set.Size.Height - 72);
                    for (int x = sets.IndexOf(set) + 1; x < sets.Count; x++)
                    {
                        sets[x].Location = new Point(sets[x].Location.X, sets[x].Location.Y - 72);
                    }
                    label6.Location = new Point(label6.Location.X, label6.Location.Y - 72);
                });
            });
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            Program.Blank.frmHerramientas.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                MessageBox.Show("Ingrese un Nombre de Sistema");
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de Puntaje");
            }
            else if (Logica.consultaMaxIndex("Select * from sistema where nombre = '"+textBox6.Text+"'") > 0)
            {
                MessageBox.Show("Este nombre de Sistema ya esta existe");
            }
            else
            {
                if (comboBox2.SelectedIndex == 0) //punto
                {
                    if (datosPuntos.Count == 0)
                    {
                        MessageBox.Show("Agregue un punto");
                    }
                    else
                    {
                        string[] Punto = new string[datosPuntos.Count];
                        for (int i = 0; i < datosPuntos.Count; i++)
                        {
                            Punto[i] = datosPuntos[i].Text;
                        }
                        if (Punto.Contains("")) {
                            MessageBox.Show("Complete todos los campos");
                        }
                        else
                        {
                            bool valid = true;
                            for(int i = 1; i < datosPuntos.Count; i += 2)
                            {
                                if (!int.TryParse(datosPuntos[i].Text, out int x)) {

                                    valid = false;
                                    MessageBox.Show("El valor del punto '"+datosPuntos[i-1].Text+"' no es numerico");
                                    break;
                                }
                            }
                            if (valid)
                            {
                                bool noRepetido = true;
                                string[] nombres = new string[Punto.Length / 2];
                                for (int i = 0; i < Punto.Length; i += 2)
                                {
                                    nombres[i / 2] = Punto[i];
                                }
                                foreach (var grouping in nombres.GroupBy(t => t).Where(t => t.Count() != 1))
                                {
                                    MessageBox.Show(string.Format("'{0}' está repetido {1} veces.", grouping.Key, grouping.Count()));
                                    noRepetido = false;
                                    break;
                                }
                                if (noRepetido)
                                {
                                    Logica.addPunto(textBox6.Text, comboBox2.SelectedIndex, Punto);
                                    Program.Blank.frmHerramientas.comboBox3.Items.Add(textBox6.Text);
                                    Program.Blank.frmHerramientas.comboBox3.SelectedIndex = Program.Blank.frmHerramientas.comboBox3.Items.IndexOf(textBox6.Text);
                                    this.Visible = false;
                                    Program.Blank.frmHerramientas.Enabled = true;
                                }
                            }
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 1) //set
                {
                    if (sets.Count == 0)
                    {
                        MessageBox.Show("Agregue un set");
                    }
                    else
                    {
                        string[] Sets = new string[datosSets.Count];
                        for (int i = 0; i < datosSets.Count; i++)
                        {
                            Sets[i] = datosSets[i].Text;
                        }
                        if (Sets.Contains(""))
                        {
                            MessageBox.Show("Complete todos los campos");
                        }
                        else
                        {
                            bool valid = true;
                            for (int i = 1; i < datosSets.Count; i ++)
                            {
                                if (!int.TryParse(datosSets[i].Text, out int x))
                                {
                                    valid = false;
                                    MessageBox.Show("La cantidad de sets y su delimitador debe ser numerica en todos los sets");
                                    break;
                                }
                            }
                            if (valid)
                            {
                                if (sets.Count != datosPuntosSets.Count)
                                {
                                    MessageBox.Show("Agregue puntos a todos los sets");
                                }
                                else
                                {
                                    bool valido = true;
                                    List<string[]> Puntos = new List<string[]>();
                                    for (int i = 0; i < datosPuntosSets.Count; i++)
                                    {
                                        string[] textos = new string[datosPuntosSets[i].Count];
                                        for (int x = 0; x < datosPuntosSets[i].Count; x += 2)
                                        {
                                            textos[x] = datosPuntosSets[i][x].Text;
                                            textos[x + 1] = datosPuntosSets[i][x + 1].Text;
                                            if (textos.Contains(""))
                                            {
                                                MessageBox.Show("Complete todos los campos");
                                                valido = false;
                                                break;
                                            }
                                            else if (!int.TryParse(datosPuntosSets[i][x + 1].Text,out int a))
                                            {
                                                MessageBox.Show("El valor del punto '"+textos[x]+"' en el set numero '"+(i + 1) +"' no es numerico");
                                                valido = false;
                                                break;
                                            }
                                        }
                                        Puntos.Add(textos);
                                    }
                                    
                                    if (valido)
                                    {
                                        bool noRepetido = true;
                                        for (int x = 0; x < Puntos.Count; x++)
                                        {
                                            string[] nombres = new string[Puntos[x].Length / 2];
                                            for (int i = 0; i < Puntos[x].Length; i+=2)
                                            {
                                                nombres[i/2] = Puntos[x][i];
                                            }
                                            foreach (var grouping in nombres.GroupBy(t => t).Where(t => t.Count() != 1))
                                            {
                                                MessageBox.Show(string.Format("'{0}' está repetido {1} veces en el mismo set", grouping.Key, grouping.Count()));
                                                noRepetido = false;
                                                break;
                                            }
                                        }
                                        if (noRepetido)
                                        {
                                            Logica.addSet(textBox6.Text, Sets, cbSet);
                                            Program.Blank.frmHerramientas.comboBox3.Items.Add(textBox6.Text);
                                            Program.Blank.frmHerramientas.comboBox3.SelectedIndex = Program.Blank.frmHerramientas.comboBox3.Items.IndexOf(textBox6.Text);


                                            for(int i = 0; i < Puntos.Count; i++)
                                            {
                                                Logica.addPointToSet(textBox6.Text,i, Puntos[i]);
                                            }
                                            
                                            this.Visible = false;
                                            Program.Blank.frmHerramientas.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else //magnitud
                {
                    Logica.addMagnitud(textBox6.Text,comboBox1.SelectedIndex);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
