using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    //Cosas pendientes: mostrar condicion de ingreso abajo, opcional
    
    public partial class FormHerramientas : Form
    {
        List<Panel> fsD = new List<Panel>();
        List<Panel> fsI = new List<Panel>();
        public bool deporte = false;
        string fCE = "1", fFP = "Indet";
        int cantEqu = 0;

        
        List<Vinculo> Vinculos = new List<Vinculo>();
        List<String> fases = new List<String>();
    
        Vinculo Final = null;


        public FormHerramientas()
        {
            InitializeComponent();
            panel8.Controls.SetChildIndex(panel9, 0);
            panel9.Controls.SetChildIndex(textBox2, 0);
            groupBox4.Controls.SetChildIndex(panel11, 3);
            panel11.Controls.SetChildIndex(textBox3, 0);
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
        }
        public void actualizar()
        {
            Idioma.controles(pnlCrearTorneo);
            Idioma.controles(pnlNombreTorn);
            Idioma.controles(pnlTrofeoTorn);
            Idioma.controles(pnlHerrTorneo);
            Idioma.controles(pnlNombreCortoTorneo);
            Idioma.controles(pnlDeporteTorneoH);
            Idioma.controles(pnlPaisTorneoH);
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif" ;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
        }
        

        private void btnNacional1_Click(object sender, EventArgs e)
        {
                btnNacional1.FlatAppearance.BorderSize = 2;
                btnNacional1.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnNacional1.BackColor = Color.FromArgb(255, 1, 30, 44);
                
                btnInternacional1.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnInternacional1.FlatAppearance.BorderSize = 0;

            textBox1.Enabled = true;
        }
        
        private void btnInternacional1_Click(object sender, EventArgs e)
        {
                btnInternacional1.FlatAppearance.BorderSize = 2;
                btnInternacional1.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 183, 3);
                btnInternacional1.BackColor = Color.FromArgb(255, 1, 30, 44);
                
                btnNacional1.BackColor = Color.FromArgb(255, 2, 48, 71);
                btnNacional1.FlatAppearance.BorderSize = 0;

            textBox1.Enabled = false;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Program.Blank.frmPrincipal.Enabled = true;
            this.Visible = false;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel25.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(fsI.Count == fsD.Count-1)
            {
                MessageBox.Show("Se encuentra en doble eliminacion, la cantidad de fases a la derecha de la final debera ser menor a la cantidad de fases a la izquierda");
            }
            else if(fsI.Count - fsD.Count > 1)
            {
                if(fsD.Count == 0)
                {
                    if (MessageBox.Show("Esto activara el modo doble eliminacion, desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        pictureBox5.Location = new Point(pictureBox5.Location.X + 103, pictureBox5.Location.Y);

                        Panel fase = new Panel();
                        fase.Location = new Point(pictureBox5.Location.X - 103, 3);
                        fase.Size = new Size(100, 204);
                        fase.Parent = panel6;
                        fase.BackColor = Color.LightGray;

                        fsD.Add(fase);
                        decorar(fase, true);
                    }
                }
                else
                {
                    pictureBox5.Location = new Point(pictureBox5.Location.X + 103, pictureBox5.Location.Y);

                    Panel fase = new Panel();
                    fase.Location = new Point(pictureBox5.Location.X - 103, 3);
                    fase.Size = new Size(100, 204);
                    fase.Parent = panel6;
                    fase.BackColor = Color.LightGray;

                    fsD.Add(fase);
                    decorar(fase, true);
                }
            }
            else
            {
                if(fsI.Count == 0 || fsI.Count == 1)
                {
                    MessageBox.Show("Deberá tener almenos 2 fases a la izquierda para poder agregar fases a la derecha");
                }
                else
                {
                    MessageBox.Show("Debera tener "+ (2- (fsI.Count - fsD.Count))+" fase mas a la izquierda para continuar agregando fases a la derecha");
                }
            }
        }

        public void decorar(Panel fase, bool derecha)
        {
            //Texto en ConfigActual
            string CE = "Indet", FP = "Indet";
            //CE = Cantidad enfrentamientos
            //FI = Fase inicial
            //FP = Fecha prevista
            //E = Estado

            //Creacion de la fase
            Button config = new Button();
            config.FlatAppearance.BorderSize = 2;
            config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            config.Location = new System.Drawing.Point(6, 6);
            config.Size = new System.Drawing.Size(88, 30);
            config.Text = "Configurar";
            config.Parent = fase;

            Panel nomFase = new Panel();
            nomFase.Location = new Point(3, 42);
            nomFase.Size = new Size(94, 57);
            nomFase.Parent = fase;
            nomFase.BackColor = Color.LightGray;
            fase.Controls.SetChildIndex(nomFase, 0);

            Panel sub = new Panel();
            sub.Location = new Point(0, 53);
            sub.Size = new Size(171, 3);
            sub.Parent = nomFase;
            sub.BackColor = Color.FromArgb(255, 2, 48, 71);

            TextBox txt = new TextBox();
            txt.Parent = nomFase;
            txt.BackColor = Color.DarkGray;
            txt.Location = new Point(3, 31); 
            txt.Font = new Font("Microsoft Sans Serif", 8.25F);
            txt.BackColor = Color.DarkGray;
            txt.BorderStyle = BorderStyle.None;
            txt.ForeColor = Color.Black;
            txt.Size = new Size(88, 20);
            txt.TextAlign = HorizontalAlignment.Center;
            nomFase.Controls.SetChildIndex(txt,0);

            Label nombre = new Label();
            nombre.Parent = nomFase;
            nombre.Text = "Nombre fase";
            nombre.Location = new Point(6, 10);
            nombre.Size = new Size(79, 15);
            nombre.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            Label confg = new Label();
            confg.Parent = fase;
            confg.AutoSize = false;
            confg.Text = "Confg Actual :";
            confg.FlatStyle = FlatStyle.Standard;
            confg.Location = new Point(3, 101);
            confg.Size = new Size(94, 62);
            confg.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            confg.BorderStyle = BorderStyle.FixedSingle;
            fase.Controls.SetChildIndex(confg, 1);

            PictureBox borrar = new PictureBox();
            borrar.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\RmFase.png"));
            borrar.Parent = fase;
            borrar.Location = new Point(6, 165);
            borrar.Size = new Size(88, 36);

            //Creacion del groupBox Configuracion

            GroupBox conf = new GroupBox();
            conf.Visible = false;
            conf.Location = new System.Drawing.Point(323, 4);
            conf.Size = new System.Drawing.Size(263, 223);
            conf.Text = "Configuracion";
            conf.Parent = panel7;

            Panel fecha = new Panel();
            fecha.Parent = conf;
            fecha.BackColor = System.Drawing.Color.LightGray;
            fecha.Location = new System.Drawing.Point(6, 91);
            fecha.Size = new System.Drawing.Size(111, 80);
            conf.Controls.SetChildIndex(fecha, 0);//0

            Panel vacio = new Panel();
            vacio.Visible = false;
            vacio.Parent = conf;

            Button editar = new Button();
            editar.Parent = conf;
            editar.Visible = false;

            Panel cantEnfrentamientos = new Panel();
            cantEnfrentamientos.BackColor = Color.LightGray;
            cantEnfrentamientos.Location = new Point(6, 19);
            cantEnfrentamientos.Size = new Size(111, 67);
            cantEnfrentamientos.Parent = conf;
            conf.Controls.SetChildIndex(cantEnfrentamientos, 3);//3

            Panel faseInc = new Panel();
            faseInc.BackColor = System.Drawing.Color.LightGray;
            faseInc.Location = new System.Drawing.Point(123, 19);
            faseInc.Size = new System.Drawing.Size(131, 59);
            faseInc.Parent = conf;
            conf.Controls.SetChildIndex(faseInc, 4);//4

            Label texto1 = new Label();
            texto1.AutoSize = true;
            texto1.BackColor = System.Drawing.Color.Transparent;
            texto1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            texto1.ForeColor = System.Drawing.Color.Black;
            texto1.Location = new System.Drawing.Point(6, 10);
            texto1.Size = new System.Drawing.Size(100, 30);
            texto1.Text = "Cantidad\r\nEnfrentamientos";
            texto1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            texto1.Parent = cantEnfrentamientos;

            TextBox cantEnf = new TextBox();
            cantEnf.BackColor = System.Drawing.Color.DarkGray;
            cantEnf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cantEnf.ForeColor = System.Drawing.SystemColors.Info;
            cantEnf.Location = new System.Drawing.Point(4, 41);
            cantEnf.Size = new System.Drawing.Size(102, 13);
            cantEnf.Parent = cantEnfrentamientos;
            cantEnfrentamientos.Controls.SetChildIndex(cantEnf, 0);

            Panel sub1 = new Panel();
            sub1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            sub1.Location = new System.Drawing.Point(0, 63);
            sub1.Size = new System.Drawing.Size(171, 3);
            sub1.Parent = cantEnfrentamientos;
            
            Panel subt = new Panel();
            subt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            subt.Location = new System.Drawing.Point(0, 56);
            subt.Size = new System.Drawing.Size(171, 3);
            subt.Parent = faseInc;

            CheckBox faseInicial = new CheckBox();
            //faseInicial.Location = new System.Drawing.Point(35, 9);
            //faseInicial.Size = new System.Drawing.Size(79, 17);
            //faseInicial.Text = "Fase Inicial";
            //faseInicial.UseVisualStyleBackColor = true;
            faseInicial.Parent = faseInc;
            faseInicial.Visible = false;

            Label sigeA = new Label();
            sigeA.Visible = false;
            sigeA.Parent = faseInc;

            ComboBox sigue = new ComboBox();
            sigue.Parent = faseInc;
            sigue.Visible = false;
            faseInc.Controls.SetChildIndex(sigue, 0);//0

            Label condicion = new Label();
            condicion.Location = new System.Drawing.Point(7, 15);
            condicion.Size = new System.Drawing.Size(107, 13);
            condicion.Text = "Condicion de Ingreso";
            condicion.Parent = faseInc;

            ComboBox cond = new ComboBox();
            cond.BackColor = System.Drawing.Color.DarkGray;
            cond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cond.Items.AddRange(new object[] {"Victoria","Derrota","Personalizado"});
            cond.Location = new System.Drawing.Point(6, 31);
            cond.Size = new System.Drawing.Size(122, 21);
            cond.Parent = faseInc;
            faseInc.Controls.SetChildIndex(cond, 1);//1
            
            Panel subF = new Panel();
            subF.Parent = fecha;
            subF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            subF.Location = new System.Drawing.Point(0, 77);
            subF.Size = new System.Drawing.Size(171, 3);

            Label Fprevista = new Label();
            Fprevista.Parent = fecha;
            Fprevista.BackColor = System.Drawing.Color.Transparent;
            Fprevista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Fprevista.ForeColor = System.Drawing.Color.Black;
            Fprevista.Location = new System.Drawing.Point(6, 10);
            Fprevista.Size = new System.Drawing.Size(87, 15);
            Fprevista.Text = "Fecha Prevista";
            Fprevista.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            TextBox dia = new TextBox();
            dia.Parent = fecha;
            dia.BackColor = System.Drawing.Color.DarkGray;
            dia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dia.ForeColor = System.Drawing.SystemColors.Menu;
            dia.Location = new System.Drawing.Point(4, 28);
            dia.Size = new System.Drawing.Size(47, 13);
            dia.Text = "Dia";
            dia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            fecha.Controls.SetChildIndex(dia, 0);

            TextBox mes = new TextBox();
            mes.Parent = fecha;
            mes.BackColor = System.Drawing.Color.DarkGray;
            mes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            mes.ForeColor = System.Drawing.SystemColors.Menu;
            mes.Location = new System.Drawing.Point(59, 28);
            mes.Size = new System.Drawing.Size(47, 13);
            mes.Text = "Mes";
            mes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            fecha.Controls.SetChildIndex(mes, 1);

            TextBox anio = new TextBox();
            anio.Parent = fecha;
            anio.BackColor = System.Drawing.Color.DarkGray;
            anio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            anio.ForeColor = System.Drawing.SystemColors.Menu;
            anio.Location = new System.Drawing.Point(4, 53);
            anio.Size = new System.Drawing.Size(102, 13);
            anio.Text = "Año";
            anio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            fecha.Controls.SetChildIndex(anio, 2);
            

            //Vinculo entre GB y fase

            int index = 0;
            Vinculo gbFase;
            if (derecha)
            {
                for (int xd = 0; xd < Vinculos.Count; xd++)
                {
                    if (Vinculos[xd].id > index) index = Vinculos[xd].id;
                }
                gbFase = new Vinculo(fase, conf,index+1);
                Vinculos.Add(gbFase);
            }
            else
            {
                for (int xd = 0; xd < Vinculos.Count; xd++)
                {
                    if (Vinculos[xd].id < index) index = Vinculos[xd].id;
                }
                gbFase = new Vinculo(fase, conf,index-1);
                Vinculos.Add(gbFase);
            }
            
            
            config.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                if(txt.Text == "")
                {
                    MessageBox.Show("Ingrese Un nombre a la fase");
                }
                else if (txt.ForeColor == Color.Red)
                {
                    MessageBox.Show("Este nombre Ya pertenece a otra fase");
                }
                else
                {
                    if (!fases.Contains(txt.Text)) fases.Add(txt.Text);
                    for (int i = 0; i < Vinculos.Count; i++)
                    {
                        if (Vinculos[i].fase.Controls[0].Controls[0] != txt)
                        {
                            if (Vinculos[i].fase.Controls[0].Controls[0].Text == txt.Text)
                            {
                                Vinculos[i].fase.Controls[0].Controls[0].ForeColor = Color.Red;
                            }
                        }
                    }
                    conf.BringToFront();
                    conf.Visible = true;
                    update();
                }
            });

            void fasesUpdate()
            {
                List<string> permanecen = new List<string>();
                for (int i = 0; i < Vinculos.Count; i++)
                {
                    if (fases.Contains(Vinculos[i].fase.Controls[0].Controls[0].Text))
                    {
                        permanecen.Add(Vinculos[i].fase.Controls[0].Controls[0].Text);
                    }
                }
                fases.Clear();
                for(int i = 0; i < permanecen.Count; i++)
                {
                    fases.Add(permanecen[i]);
                }
            }

            txt.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                if (fases.Contains(txt.Text)) txt.ForeColor = Color.Red;
                else txt.ForeColor = Color.Black;
                fasesUpdate();
                txt.Parent.Parent.Controls[1].Text = "Confg Actual :";
            });

            cantEnf.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                int num;
                if(!int.TryParse(cantEnf.Text, out num))
                {
                    cantEnf.ForeColor = Color.Red;
                }
                else
                {
                    cantEnf.ForeColor = System.Drawing.SystemColors.Menu;
                    CE = num + "";
                }
                update();
            });
            
            cond.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                update();
            });
            sigue.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                update();
            });
            string sdia = "", smes = "", sanio = "";
            dia.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                int num;
                if (!int.TryParse(dia.Text, out num))
                {
                    dia.ForeColor = Color.Red;
                }
                else if (num >= 32)
                {
                    dia.ForeColor = Color.Red;
                }
                else
                {
                    dia.ForeColor = System.Drawing.SystemColors.Menu;
                    sdia = dia.Text;
                    if (!sdia.Equals("") && !smes.Equals("") && !sanio.Equals(""))
                    {
                        FP = sdia + "/" + smes + "/" + sanio;
                    }
                }
                update();
            });
            mes.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                int num;
                if (!int.TryParse(mes.Text, out num))
                {
                    mes.ForeColor = Color.Red;
                }
                else if (num >= 13)
                {
                    mes.ForeColor = Color.Red;
                }
                else
                {
                    mes.ForeColor = System.Drawing.SystemColors.Menu;
                    smes = mes.Text;
                    if (!sdia.Equals("") && !smes.Equals("") && !sanio.Equals(""))
                    {
                        FP = sdia + "/" + smes + "/" + sanio;
                    }
                }
                update();
            });
            anio.TextChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                int num;
                if (!int.TryParse(anio.Text, out num))
                {
                    anio.ForeColor = Color.Red;
                }
                else if (num < 2000)
                {
                    anio.ForeColor = Color.Red;
                }
                else
                {
                    anio.ForeColor = System.Drawing.SystemColors.Menu;
                    sanio = anio.Text;
                    if(!sdia.Equals("") && !smes.Equals("") && !sanio.Equals(""))
                    {
                        FP = sdia + "/" + smes + "/" + sanio ;
                    }
                }
                update();
            });

            dia.Enter += new EventHandler(delegate (Object s, EventArgs exde)
            {
                if (dia.Text == "Dia")
                {
                    dia.Text = "";
                }
            });
            mes.Enter += new EventHandler(delegate (Object s, EventArgs exde)
            {
                if (mes.Text == "Mes")
                {
                    mes.Text = "";
                }
            });
            anio.Enter += new EventHandler(delegate (Object s, EventArgs exde)
            {
                if (anio.Text == "Año")
                {
                    anio.Text = "";
                }
            });

            void update()
            {
                confg.Text = "CE: "+CE + "\nFP: " + FP;
            }
            borrar.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                fases.Remove(fase.Controls[0].Controls[0].Text);
                if (fsD.Contains(fase))
                {
                    for (int i = fsD.IndexOf(fase); i < fsD.Count; i++)
                    {
                        fsD[i].Location = new Point(fsD[i].Location.X - 103, fsD[i].Location.Y);
                    }
                    pictureBox5.Location = new Point(pictureBox5.Location.X - 103, pictureBox5.Location.Y);
                    fsD.Remove(fase);
                    fase.Dispose();
                }
                else
                {
                    DesplazarIzquierda(fsI.IndexOf(fase));
                    fsI.Remove(fase);
                    if(fsD.Count == fsI.Count && fsD.Count != 0)
                    {
                        //borrar fase de la derecha

                        pictureBox5.Location = new Point(pictureBox5.Location.X - 103, pictureBox5.Location.Y);
                        for (int i = 0; i < Vinculos.Count; i++)
                        {
                            if (Vinculos[i].fase == fsD[fsD.Count - 1])
                            {
                                Vinculos[i].Dispose();
                                Vinculos.Remove(Vinculos[i]);
                                break;
                            }
                        }
                        fsD[fsD.Count - 1].Dispose();
                        fsD.Remove(fsD[fsD.Count-1]);
                    }
                    if(fsI.Count == 0)
                    {
                        comboBox2.Text = "";
                        comboBox2.Enabled = false;
                    }
                    else
                    {
                        for (int i = 0; i < Vinculos.Count; i++)
                        {
                            if (Vinculos[i].fase != fsI[fsI.Count-1])
                            {
                                Vinculos[i].config.Controls[4].Controls[1].Enabled = true;
                            }
                            else
                            {
                                Vinculos[i].config.Controls[4].Controls[1].Enabled = false;
                            }
                        }
                    }
                    fase.Dispose();
                }
                Vinculos.Remove(gbFase);
                gbFase.Dispose();
                gbFase = null;
            });

            sigue.GotFocus += new EventHandler(delegate (Object s, EventArgs exde)
            {
                sigue.Items.Clear();
                for (int i = 0; i < fases.Count;i++)
                {
                    if (fases[i] != txt.Text)
                    {
                        if (!sigue.Items.Contains(fases[i]))
                        {
                            sigue.Items.Add(fases[i]);
                        }
                    }
                }
            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(comboBox5.Text == "")
            {
                MessageBox.Show("Seleccione un deporte");
            }
            else
            {
                if(cantEqu != 2)
                {
                    pictureBox5.Visible = false;
                }
                else
                {
                    pictureBox5.Visible = true;
                }
                panel7.Visible = true;
                panel25.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel25.Visible = true;
            panel7.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel fase = new Panel();
            fase.Location = new Point(pictureBox3.Location.X +103, 3);
            fase.Size = new Size(100, 204);
            fase.Parent = panel6;
            fase.BackColor = Color.LightGray;

            DesplazarDerecha();
            fsI.Add(fase);
            decorar(fase,false);
            for(int i = 0; i < Vinculos.Count; i++)
            {
                if(Vinculos[i].fase != fase)
                {
                    Vinculos[i].config.Controls[4].Controls[1].Enabled = true;
                }
                else
                {
                    Vinculos[i].config.Controls[4].Controls[1].Enabled = false;
                }
            }
            comboBox2.Enabled = true;
        }

        private void DesplazarDerecha()
        {
            pictureBox5.Location = new Point(pictureBox5.Location.X + 103, pictureBox5.Location.Y);
            if (fsD.Count != 0)
            {
                for (int i = 0; i < fsD.Count; i++)
                {
                    fsD[i].Location = new Point(fsD[i].Location.X+103, fsD[i].Location.Y);
                }
            }
            panel8.Location = new Point(panel8.Location.X + 103, panel8.Location.Y);
            if (fsI.Count != 0)
            {
                for (int i = 0; i < fsI.Count; i++)
                {
                    fsI[i].Location = new Point(fsI[i].Location.X + 103, fsI[i].Location.Y);
                }
            }
        }

        private void DesplazarIzquierda(int x)
        {
            pictureBox5.Location = new Point(pictureBox5.Location.X - 103, pictureBox5.Location.Y);
            if (fsD.Count != 0)
            {
                for (int i = 0; i < fsD.Count; i++)
                {
                    fsD[i].Location = new Point(fsD[i].Location.X - 103, fsD[i].Location.Y);
                }
            }
            panel8.Location = new Point(panel8.Location.X - 103, panel8.Location.Y);
            if (x != 0)
            {
                for (int i = x; i >= 0; i--) 
                {
                    fsI[i].Location = new Point(fsI[i].Location.X - 103, fsI[i].Location.Y);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = "Nombre del Torneo : " + indet(txtNombreT.Text) + "\n" +
                          "Nombre Corto : " + indet(textBox9.Text) + "\n" +
                          "Deporte : " + indet(comboBox5.Text) + "\n" +
                          "Estado : Pendiente\n" +
                          "Cantidad de Fases : " + (Vinculos.Count + 1) + "\n" +
                          "Trofeo / Premio : " + indet(txtTrofeo.Text) + "\n" +
                          "Tipo : " + region();

            string indet(string txt)
            {
                if (txt == null || txt.Equals("") || txt.Equals("Indet")) return "Indeterminado";
                return txt;
            }
            string region()
            {
                if (btnInternacional1.FlatAppearance.BorderSize == 2) return "Internacional";
                return "Nacional";
            }
        }

        private void FormHerramientas_Load(object sender, EventArgs e)
        {
            Final = new Vinculo(panel8, groupBox4,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ingrese Un nombre a la fase");
            }
            else if (textBox2.ForeColor == Color.Red)
            {
                MessageBox.Show("Este nombre Ya pertenece a otra fase");
            }
            else
            {
                if (!fases.Contains(textBox2.Text)) fases.Add(textBox2.Text);
                for (int i = 0; i < Vinculos.Count; i++)
                {
                    if (Vinculos[i].fase.Controls[0].Controls[0] != textBox2)
                    {
                        if (Vinculos[i].fase.Controls[0].Controls[0].Text == textBox2.Text)
                        {
                            Vinculos[i].fase.Controls[0].Controls[0].ForeColor = Color.Red;
                        }
                    }
                }
                groupBox4.BringToFront();
                groupBox4.Visible = true;
                act();
                fases.Remove(textBox2.Text);
            }
        }

        void act(){
            
            if (textBox3.ForeColor == SystemColors.Menu) fCE = textBox3.Text;

            if (textBox4.ForeColor == SystemColors.Menu && textBox5.ForeColor == SystemColors.Menu && textBox6.ForeColor == SystemColors.Menu)
            {
                fFP = textBox4.Text + "/" + textBox6.Text + "/" + textBox5.Text;
            }

            label5.Text = "CE : " + fCE + "\nFP : " + fFP;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(textBox3.Text, out num))
            {
                textBox3.ForeColor = Color.Red;
            }
            else
            {
                textBox3.ForeColor = System.Drawing.SystemColors.Menu;
            }
            act();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(textBox5.Text + "-" + textBox6.Text + "-" + textBox4.Text);
                textBox4.ForeColor = System.Drawing.SystemColors.Menu;
                textBox5.ForeColor = System.Drawing.SystemColors.Menu;
                textBox6.ForeColor = System.Drawing.SystemColors.Menu;
                if (textBox5.Text.Length < 4)
                {
                    textBox4.ForeColor = Color.Red;
                    textBox5.ForeColor = Color.Red;
                    textBox6.ForeColor = Color.Red;
                }
            }
            catch
            {
                textBox4.ForeColor = Color.Red;
                textBox5.ForeColor = Color.Red;
                textBox6.ForeColor = Color.Red;
            }

            act();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(textBox5.Text + "-" + textBox6.Text + "-" + textBox4.Text);
                textBox4.ForeColor = System.Drawing.SystemColors.Menu;
                textBox5.ForeColor = System.Drawing.SystemColors.Menu;
                textBox6.ForeColor = System.Drawing.SystemColors.Menu;
                if (textBox5.Text.Length < 4)
                {
                    textBox4.ForeColor = Color.Red;
                    textBox5.ForeColor = Color.Red;
                    textBox6.ForeColor = Color.Red;
                }
            }
            catch
            {
                textBox4.ForeColor = Color.Red;
                textBox5.ForeColor = Color.Red;
                textBox6.ForeColor = Color.Red;
            }

            act();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Dia")
            {
                textBox4.Text = "";
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Mes")
            {
                textBox6.Text = "";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Año")
            {
                textBox5.Text = "";
            }
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            dynamic[,] var = Logica.consulta("SELECT nombreDep FROM deporte");
            if (var != null)
            {
                for (int i = 0; i < Logica.consultaMaxIndex("SELECT nombreDep FROM deporte"); i++)
                {
                    comboBox5.Items.Add(var[0, i]);
                }
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            if(comboBox5.Text != "")
            {
                cantEqu = Logica.consulta("Select cantEquipos from deporte where nombreDep = '" + comboBox5.Text + "'")[0, 0];
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png")))
            {
                MessageBox.Show("Ingrese una imagen");
            }
            else if (pictureBox1.Image.Size.Width + pictureBox1.Image.Size.Height > 256)
            {
                MessageBox.Show("Su imagen es demasiado grande, puede causar inconvenientes tanto en memoria como red, por favor reduzca su altura y anchura en píxeles, tal que su suma sea 256px o menor, esto no disminuirá la calidad, debido a que la imagen que se muestra tendrá 64x64 px, mayores resoluciones serán imperceptibles");
            }
            else if (txtNombreT.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de torneo");
            }
            else if (txtTrofeo.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de trofeo");
            }
            else if (comboBox5.Text == "")
            {
                MessageBox.Show("Ingrese un nombre de deporte");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Ingrese un nombre corto");
            }
            else if (btnInternacional1.FlatAppearance.BorderSize != 2 && textBox1.Text == "")
            {
                MessageBox.Show("Dado que es un torneo Nacional, ingrese el pais");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Compruebe que todas las fases tengan un nombre asignado");
            }
            else if (textBox4.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Compruebe que el dia de la fecha prevista de la fase '" + textBox2.Text + "' sea numerico");
            }
            else if (textBox6.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Compruebe que el mes de la fecha prevista de la fase '" + textBox2.Text + "' sea numerico");
            }
            else if (textBox5.ForeColor != SystemColors.Menu)
            {
                MessageBox.Show("Compruebe que el año de la fecha prevista de la fase '" + textBox2.Text + "' sea numerico");
            }
            else if ( comboBox2.Text == "" && fsI.Count != 0)
            {
                MessageBox.Show("Ingrese una condicion de ingreso en la fase '" + textBox2.Text + "'");
            }
            else if (Logica.addTorn(false,txtNombreT.Text, textBox9.Text, btnInternacional1.FlatAppearance.BorderSize != 2, txtTrofeo.Text, pictureBox1.Image, 0, comboBox5.Text,textBox1.Text))
            {
                int errores = 0;
                for (int i = 0; i < Vinculos.Count; i++)
                {
                    //banda de mensajes de error
                    if (Vinculos[i].fase.Controls[0].Controls[0].Text == "") { MessageBox.Show("Compruebe que todas las fases tengan un nombre asignado"); errores++; }
                    else if (Vinculos[i].config.Controls[3].Controls[0].ForeColor != SystemColors.Menu) { MessageBox.Show("Compruebe que la cantidad de enfrentamientos de la fase '" + Vinculos[i].fase.Controls[0].Controls[0].Text + "' sea numerico"); errores++; }
                    else if (Vinculos[i].config.Controls[0].Controls[0].ForeColor != SystemColors.Menu) { MessageBox.Show("Compruebe que el dia de la fecha prevista de la fase '" + Vinculos[i].fase.Controls[0].Controls[0].Text + "' sea numerico"); errores++; }
                    else if (Vinculos[i].config.Controls[0].Controls[1].ForeColor != SystemColors.Menu) { MessageBox.Show("Compruebe que el mes de la fecha prevista de la fase '" + Vinculos[i].fase.Controls[0].Controls[0].Text + "' sea numerico"); errores++; }
                    else if (Vinculos[i].config.Controls[0].Controls[2].ForeColor != SystemColors.Menu) { MessageBox.Show("Compruebe que el anio de la fecha prevista de la fase '" + Vinculos[i].fase.Controls[0].Controls[0].Text + "' sea numerico"); errores++; }
                    else if (Vinculos[i].fase.Controls[0].Controls[0].Text != fsI[fsI.Count-1].Controls[0].Controls[0].Text && Vinculos[i].config.Controls[4].Controls[1].Text == "") { MessageBox.Show("Ingrese una condicion de ingreso en la fase '" + Vinculos[i].fase.Controls[0].Controls[0].Text + "'"); errores++; }
                    if (errores > 0)
                    {
                        break;
                    }
                }
                if (errores == 0)
                {
                    List<Vinculo> izquierda = new List<Vinculo>();
                    List<Vinculo> derecha = new List<Vinculo>();

                    for (int z = 0; z < Vinculos.Count; z++)
                    {
                        if (Vinculos[z].id < 0) izquierda.Add(Vinculos[z]);
                        else derecha.Add(Vinculos[z]);
                    }

                    bool condicion = false;
                    Vinculo pivot = null;
                    while (!condicion)
                    {
                        int cambios = 0;
                        for (int h = 0; h < izquierda.Count; h++)
                        {
                            if (izquierda.Count > h + 1)
                            {
                                if (izquierda[h].id > izquierda[h + 1].id)
                                {
                                    pivot = izquierda[h + 1];
                                    izquierda[h + 1] = izquierda[h];
                                    izquierda[h] = pivot;
                                    cambios++;
                                }
                            }
                        }
                        for (int h = 0; h < derecha.Count; h++)
                        {
                            if (derecha.Count > h + 1)
                            {
                                if (derecha[h].id > derecha[h + 1].id)
                                {
                                    pivot = derecha[h + 1];
                                    derecha[h + 1] = derecha[h];
                                    derecha[h] = pivot;
                                    cambios++;
                                }
                            }
                        }
                        if (cambios == 0) condicion = true;
                    }
                    
                    for (int i = izquierda.Count-1; i >= 0; i--)
                    {
                        if(Math.Pow(cantEqu, izquierda.Count - i) + "" != izquierda[i].config.Controls[3].Controls[0].Text)
                        {
                            MessageBox.Show("La cantidad de equipos de la fase '" + izquierda[i].fase.Controls[0].Controls[0].Text + "' deberia ser : " + Math.Pow(cantEqu, izquierda.Count - i));
                            errores++;
                            break;
                        }
                    }
                    if (errores == 0)
                    {
                        for (int i = 0; i < derecha.Count; i++)
                        {
                            if (Math.Pow(cantEqu, i+1) + "" != derecha[i].config.Controls[3].Controls[0].Text)
                            {
                                MessageBox.Show("La cantidad de equipos de la fase '" + derecha[i].fase.Controls[0].Controls[0].Text + "' deberia ser : " + Math.Pow(cantEqu, i+1));
                                errores++;
                                break;
                            }
                        }
                    }
                    if (errores == 0)
                    {
                        Logica.addTorn(true, txtNombreT.Text, textBox9.Text, btnInternacional1.FlatAppearance.BorderSize != 2, txtTrofeo.Text, pictureBox1.Image, 0, comboBox5.Text, textBox1.Text);
                        for (int i = 0; i < izquierda.Count; i++) //los de la izquierda
                        {
                            int cond = 0;
                            switch (izquierda[i].config.Controls[4].Controls[1].Text)
                            {
                                case "Victoria":
                                    cond = 1;
                                    break;
                                case "Derrota":
                                    cond = 0;
                                    break;
                                case "Personalizado":
                                    cond = 2;
                                    break;
                            }
                            Logica.addfase(i - izquierda.Count, int.Parse(izquierda[i].config.Controls[3].Controls[0].Text), izquierda[i].fase.Controls[0].Controls[0].Text, izquierda[i].config.Controls[0].Controls[2].Text + "-" + izquierda[i].config.Controls[0].Controls[1].Text + "-" + izquierda[i].config.Controls[0].Controls[0].Text, 0, txtNombreT.Text, cond + "", false);
                        }
                        //Final
                        Logica.addfase(0, int.Parse(textBox3.Text), textBox2.Text, textBox5.Text + "-" + textBox6.Text + "-" + textBox4.Text, 0, txtNombreT.Text, null, true);
                        for (int i = 0; i < derecha.Count; i++) //los de la derecha
                        {
                            int cond = 0;
                            switch (derecha[i].config.Controls[4].Controls[1].Text)
                            {
                                case "Victoria":
                                    cond = 1;
                                    break;
                                case "Derrota":
                                    cond = 0;
                                    break;
                                case "Personalizado":
                                    cond = 2;
                                    break;
                            }
                            Logica.addfase(i + 1, int.Parse(derecha[i].config.Controls[3].Controls[0].Text), derecha[i].fase.Controls[0].Controls[0].Text, derecha[i].config.Controls[0].Controls[2].Text + "-" + derecha[i].config.Controls[0].Controls[1].Text + "-" + derecha[i].config.Controls[0].Controls[0].Text, 0, txtNombreT.Text, cond + "", false);
                        }

                        if (deporte)
                        {
                            Program.Blank.Depo.Enabled = true;
                            Program.Blank.Depo.cargaTorn();
                        }
                        else Program.Blank.frmPrincipal.Enabled = true;
                        this.Visible = false;

                        Program.Blank.frmPrincipal.cargaTorn();
                    }
                }
            }

            else
            {
                MessageBox.Show("Ya existe un Torneo llamado : " + txtNombreT.Text);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png; *jfif)|*.jpg; *.jpeg; *.bmp; *.png; *.jfif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label24.Text = textBox9.Text.Length + " / 12";
            if (textBox9.Text.Length > 0 && textBox9.Text.Length < 13) label24.ForeColor = Color.Green;
            else label24.ForeColor = Color.Red;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(textBox5.Text + "-" + textBox6.Text + "-" + textBox4.Text);
                textBox4.ForeColor = System.Drawing.SystemColors.Menu;
                textBox5.ForeColor = System.Drawing.SystemColors.Menu;
                textBox6.ForeColor = System.Drawing.SystemColors.Menu;
                if (textBox5.Text.Length < 4)
                {
                    textBox4.ForeColor = Color.Red;
                    textBox5.ForeColor = Color.Red;
                    textBox6.ForeColor = Color.Red;
                }
            }
            catch
            {
                textBox4.ForeColor = Color.Red;
                textBox5.ForeColor = Color.Red;
                textBox6.ForeColor = Color.Red;
            }

            act();
        }
        

    }
}
