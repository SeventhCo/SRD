using Newtonsoft.Json;
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
        int estado;
        string arbitross;
        List<List<dynamic[]>> PadreAlineaciones = new List<List<dynamic[]>>();
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
            estado = info[1,0];
            if(!(info[4, 0] is System.DBNull)) arbitross = info[4, 0];
            //cargarArbitros();
            addEquipo();
            if(estado > 0)
            {
                button6.Text = "Finalizar Evento";
                button6.FlatAppearance.BorderColor = Color.Red;
            }
            equiposAlineaciones();
            label2.Text = "Torneo: " + nombreTorn + "\n"+
                          "Fase : "+nombreFase+"\n"+
                          "Cantidad de Equipos : "+ Logica.consultaMaxIndex("Select * from equiposEvento where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlEquipos.Visible = true;
            pnlSucesos.Visible = false;
            pnlAlineaciones.Visible = false;
            pnlArbitros.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlSucesos.Visible = true;
            pnlEquipos.Visible = false;
            pnlAlineaciones.Visible = false;
            pnlArbitros.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlAlineaciones.Visible = true;
            pnlSucesos.Visible = false;
            pnlEquipos.Visible = false;
            pnlArbitros.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlArbitros.Visible = true;
            pnlAlineaciones.Visible = false;
            pnlSucesos.Visible = false;
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

        private void label5_Click(object sender, EventArgs e)
        {
            Panel Arbitro = new Panel();
            Arbitro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            if(Arbitros.Count != 0)Arbitro.Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y-4));
            else  Arbitro.Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3));
            
            Arbitro.Size = new System.Drawing.Size(165, 85);
            Arbitro.Parent = pnlArbitros;
            Arbitros.Add(Arbitro);
            
            arbitros++;

            label5.Location = new Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y - 4));

            Label nom = new Label();
            nom.ForeColor = SystemColors.Control;
            nom.Location = new Point(9, 8);
            nom.Size = new System.Drawing.Size(47, 13);
            nom.Text = "Nombre:";
            nom.Parent = Arbitro;

            TextBox nombre = new TextBox();
            nombre.Location = new System.Drawing.Point(56, 5);
            nombre.Size = new System.Drawing.Size(100, 20);
            nombre.Parent = Arbitro;

            Label pis = new Label();
            pis.ForeColor = System.Drawing.SystemColors.Control;
            pis.Location = new System.Drawing.Point(9, 34);
            pis.Size = new System.Drawing.Size(33, 13);
            pis.Text = "Pais :";
            pis.Parent = Arbitro;

            TextBox pais = new TextBox();
            pais.Location = new System.Drawing.Point(56, 31);
            pais.Size = new System.Drawing.Size(100, 20);
            pais.Parent = Arbitro;

            Button borrar = new Button();
            borrar.FlatAppearance.BorderColor = Color.Red;
            borrar.FlatStyle = FlatStyle.Flat;
            borrar.ForeColor = SystemColors.Control;
            borrar.Location = new Point(8, 56);
            borrar.Size = new Size(148, 23);
            borrar.Text = "Quitar Arbitro";
            borrar.UseVisualStyleBackColor = true;
            borrar.Parent = Arbitro;

            borrar.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
                arbitros = 0;
                Arbitros.Remove(Arbitro);

                for(int t = 0; t < Arbitros.Count; t++)
                {
                    if (Arbitros.Count != 0) Arbitros[t].Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y - 4));
                    else Arbitros[t].Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3));
                    arbitros++;
                }

                if (Arbitros.Count != 0) label5.Location = new Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y - 4));
                else label5.Location = new Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3));

                Arbitro.Dispose();
            });

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text == "Iniciar Evento")
            {
                int errores = 0;
                for (int i = 0; i < PadreAlineaciones.Count; i++)
                {
                    for (int z = 0; z < PadreAlineaciones[i].Count; z++)
                    {
                        if (PadreAlineaciones[i][z][0].Text == "" || PadreAlineaciones[i][z][1].Text == "")
                        {
                            //errores++;
                            MessageBox.Show("Asegurese de completar todos los campos de todas las alineaciones de todos los equipos y guardar");
                            break;
                        }
                    }
                }
                Console.WriteLine("select * from Alineacion where nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and id = " + id + " group by nombreTorn,nombreFase,nombreEqu,id");
                Console.WriteLine("select * from Alineacion where nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and id = " + id + " group by nombreTorn,nombreFase,nombreEqu,id");
                Console.WriteLine("select * from Alineacion where nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and id = " + id + " group by nombreTorn,nombreFase,nombreEqu,id");
                if (Logica.consultaMaxIndex("select * from Alineacion where nombreFase = '"+nombreFase+"' and nombreTorn = '"+nombreTorn+"' and id = "+id+" group by nombreTorn,nombreFase,nombreEqu,id") != cantEquipos && errores == 0)
                {
                    errores++;
                    MessageBox.Show("Asegurese de completar guardar todas las alineaciones");
                }
                /*
                 * if (errores == 0)
                {
                    if (arbitros == 0)
                    {
                        if (MessageBox.Show("Seguro que desea continuar sin arbitros? no podra modificar las propiedades del evento una vez iniciado", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            errores++;
                        }
                    }
                }*/
                if (errores == 0)
                {
                    Logica.comando("update Evento set estado = 1 where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
                    List<Arbitro> arbitro = new List<Arbitro>();
                    for(int j = 0; j < Arbitros.Count; j++)
                    {
                        Arbitro arb = new Arbitro();
                        arb.nombre = Arbitros[j].Controls[1].Text;
                        arb.pais = Arbitros[j].Controls[3].Text;
                        arbitro.Add(arb);
                    }
                    Logica.comando("update Evento set arbitros = '" + JsonConvert.SerializeObject(arbitro)+"' where id = " + id + " and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");
                    button6.Text = "Finalizar Evento";
                    button6.ForeColor = Color.Red;
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Panel fondo = new Panel();
            if (Sucesos.Count > 0) fondo.Location = new System.Drawing.Point(4, 4 + Sucesos[Sucesos.Count-1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);
            else fondo.Location = new System.Drawing.Point(4, 4);
            fondo.Size = new System.Drawing.Size(514, 130);
            fondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fondo.Parent = pnlSucesos;
            Sucesos.Add(fondo);

            label18.Location = new Point(4, 4 + Sucesos[Sucesos.Count - 1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);

            Label txtId = new Label();
            txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtId.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtId.ForeColor = System.Drawing.SystemColors.Control;
            txtId.Location = new System.Drawing.Point(8, 6);
            txtId.Size = new System.Drawing.Size(97, 21);
            txtId.Text = "Suceso";
            txtId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txtId.Parent = fondo;

            ComboBox id = new ComboBox();
            id.FormattingEnabled = true;
            id.Location = new System.Drawing.Point(8, 30);
            id.Size = new System.Drawing.Size(97, 21);
            id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            id.Parent = fondo;

            id.Items.Add("Anotacion");
            id.Items.Add("Pausa");
            id.Items.Add("Sancion");
            
            id.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                for(int i = fondo.Controls.Count-1; i > 1; i--)
                {
                    fondo.Controls[i].Dispose();
                }
                switch (id.SelectedIndex)
                {
                    case 0:

                        fondo.Size = new System.Drawing.Size(514, 130);
                        txtId.Size = new System.Drawing.Size(97, 21);
                        id.Location = new System.Drawing.Point(8, 30);

                        Label equ = new Label();
                        equ.Parent = fondo;
                        equ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        equ.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        equ.ForeColor = System.Drawing.SystemColors.Control;
                        equ.Location = new System.Drawing.Point(110, 6);
                        equ.Size = new System.Drawing.Size(97, 21);
                        equ.Text = "Equipo";
                        equ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        ComboBox equipo = new ComboBox();
                        equipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        equipo.Parent = fondo;
                        equipo.FormattingEnabled = true;
                        equipo.Location = new System.Drawing.Point(110, 30);
                        equipo.Size = new System.Drawing.Size(97, 21);

                        Label depo = new Label();
                        depo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        depo.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        depo.ForeColor = System.Drawing.SystemColors.Control;
                        depo.Location = new System.Drawing.Point(213, 6);
                        depo.Size = new System.Drawing.Size(97, 21);
                        depo.Text = "Deportista";
                        depo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        depo.Parent = fondo;

                        ComboBox deportista = new ComboBox();
                        deportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        deportista.FormattingEnabled = true;
                        deportista.Location = new System.Drawing.Point(213, 30);
                        deportista.Size = new System.Drawing.Size(97, 21);
                        deportista.Parent = fondo;

                        Label anot = new Label();
                        anot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        anot.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        anot.ForeColor = System.Drawing.SystemColors.Control;
                        anot.Location = new System.Drawing.Point(316, 6);
                        anot.Size = new System.Drawing.Size(91, 21);
                        anot.Text = "Anotacion";
                        anot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        anot.Parent = fondo;

                        ComboBox anotacion = new ComboBox();
                        anotacion.FormattingEnabled = true;
                        anotacion.Location = new System.Drawing.Point(316, 30);
                        anotacion.Size = new System.Drawing.Size(91, 21);
                        anotacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        anotacion.Parent = fondo;

                        dynamic puntos = Logica.consulta("Select * from pointData where nombreSist = '"+Logica.consulta("Select sisPuntaje from deporte where nombreDep = '"+Logica.consulta("select nombreDep from Torneo where nombreTorn = '"+nombreTorn+"'")[0,0] +"'")[0,0] +"'");

                        for(int y = 0; y < Logica.consultaMaxIndex("Select * from pointData where nombreSist = '" + Logica.consulta("Select sisPuntaje from deporte where nombreDep = '" + Logica.consulta("select nombreDep from Torneo where nombreTorn = '" + nombreTorn + "'")[0, 0] + "'")[0, 0] + "'"); y++)
                        {
                            anotacion.Items.Add(puntos[1, y]);
                        }


                        Label min = new Label();
                        min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        min.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        min.ForeColor = System.Drawing.SystemColors.Control;
                        min.Location = new System.Drawing.Point(413, 6);
                        min.Size = new System.Drawing.Size(88, 21);
                        min.Text = "Minuto";
                        min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        min.Parent = fondo;

                        TextBox minuto = new TextBox();
                        minuto.Location = new System.Drawing.Point(413, 30);
                        minuto.Size = new System.Drawing.Size(88, 20);
                        minuto.Parent = fondo;

                        RichTextBox descripcion = new RichTextBox();
                        descripcion.Location = new System.Drawing.Point(8, 57);
                        descripcion.Size = new System.Drawing.Size(399, 66);
                        descripcion.Parent = fondo;

                        Button guardar = new Button();
                        guardar.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
                        guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        guardar.ForeColor = System.Drawing.SystemColors.Control;
                        guardar.Location = new System.Drawing.Point(413, 57);
                        guardar.Size = new System.Drawing.Size(88, 30);
                        guardar.Text = "Guardar";
                        guardar.UseVisualStyleBackColor = true;
                        guardar.Parent = fondo;

                        Button borrar = new Button();
                        borrar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                        borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        borrar.ForeColor = System.Drawing.SystemColors.Control;
                        borrar.Location = new System.Drawing.Point(413, 92);
                        borrar.Size = new System.Drawing.Size(88, 30);
                        borrar.Text = "Borrar";
                        borrar.UseVisualStyleBackColor = true;
                        borrar.Parent = fondo;

                        guardar.MouseDown += new MouseEventHandler(delegate (Object sg, MouseEventArgs exdge)
                        {
                            if(equipo.Text != "" && deportista.Text != "" && anotacion.Text != "" && minuto.Text != "")
                            {

                            }
                        });

                        borrar.MouseDown += new MouseEventHandler(delegate (Object sg, MouseEventArgs exdge)
                        {
                            // comando mysql borrar pendiente

                            Sucesos.Remove(fondo);

                            for (int i = 0; i < Sucesos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    Sucesos[0].Location = new System.Drawing.Point(4, 4);
                                }
                                else
                                {
                                    Sucesos[i].Location = new System.Drawing.Point(4, 4 + Sucesos[i - 1].Location.Y + Sucesos[i - 1].Size.Height);
                                }
                            }
                            if(Sucesos.Count > 0) label18.Location = new Point(4, 4 + Sucesos[Sucesos.Count - 1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);
                            else label18.Location = new Point(4, 4);
                            fondo.Dispose();
                        });
                        

                        break;
                    case 1:

                        fondo.Size = new Size(514, 68);
                        txtId.Size = new Size(97, 31);
                        id.Location = new Point(8, 40);

                        Label dur = new Label();
                        dur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        dur.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dur.ForeColor = System.Drawing.SystemColors.Control;
                        dur.Location = new System.Drawing.Point(110, 6);
                        dur.Size = new System.Drawing.Size(97, 32);
                        dur.Text = "Duracion";
                        dur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        dur.Parent = fondo;

                        TextBox duracion = new TextBox();
                        duracion.Location = new System.Drawing.Point(110, 41);
                        duracion.Size = new System.Drawing.Size(97, 20);
                        duracion.Parent = fondo;

                        RichTextBox descripcion2 = new RichTextBox();
                        descripcion2.Location = new System.Drawing.Point(213, 7);
                        descripcion2.Name = "richTextBox2";
                        descripcion2.Size = new System.Drawing.Size(97, 54);
                        descripcion2.Parent = fondo;

                        Label min2 = new Label();
                        min2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        min2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        min2.ForeColor = System.Drawing.SystemColors.Control;
                        min2.Location = new System.Drawing.Point(316, 7);
                        min2.Size = new System.Drawing.Size(88, 31);
                        min2.Text = "Minuto";
                        min2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        min2.Parent = fondo;

                        TextBox minuto2 = new TextBox();
                        minuto2.Location = new System.Drawing.Point(316, 41);
                        minuto2.Size = new System.Drawing.Size(88, 20);
                        minuto2.Parent = fondo;
                        
                        Button guardar2 = new Button();
                        guardar2.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
                        guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        guardar2.ForeColor = System.Drawing.SystemColors.Control;
                        guardar2.Location = new System.Drawing.Point(410, 7);
                        guardar2.Size = new System.Drawing.Size(88, 25);
                        guardar2.Text = "Guardar";
                        guardar2.UseVisualStyleBackColor = true;
                        guardar2.Parent = fondo;

                        Button borrar2 = new Button();
                        borrar2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                        borrar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        borrar2.ForeColor = System.Drawing.SystemColors.Control;
                        borrar2.Location = new System.Drawing.Point(410, 38);
                        borrar2.Size = new System.Drawing.Size(88, 25);
                        borrar2.Text = "Borrar";
                        borrar2.UseVisualStyleBackColor = true;
                        borrar2.Parent = fondo;

                        borrar2.MouseDown += new MouseEventHandler(delegate (Object sg, MouseEventArgs exdge)
                        {
                            // comando mysql borrar pendiente

                            Sucesos.Remove(fondo);

                            for (int i = 0; i < Sucesos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    Sucesos[0].Location = new System.Drawing.Point(4, 4);
                                }
                                else
                                {
                                    Sucesos[i].Location = new System.Drawing.Point(4, 4 + Sucesos[i - 1].Location.Y + Sucesos[i - 1].Size.Height);
                                }
                            }
                            if (Sucesos.Count > 0) label18.Location = new Point(4, 4 + Sucesos[Sucesos.Count - 1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);
                            else label18.Location = new Point(4, 4);
                            fondo.Dispose();
                        });

                        break;
                    case 2:

                        fondo.Size = new System.Drawing.Size(514, 130);
                        txtId.Size = new System.Drawing.Size(97, 21);
                        id.Location = new System.Drawing.Point(8, 30);

                        Label equ3 = new Label();
                        equ3.Parent = fondo;
                        equ3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        equ3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        equ3.ForeColor = System.Drawing.SystemColors.Control;
                        equ3.Location = new System.Drawing.Point(110, 6);
                        equ3.Size = new System.Drawing.Size(97, 21);
                        equ3.Text = "Equipo";
                        equ3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        ComboBox equipo3 = new ComboBox();
                        equipo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        equipo3.Parent = fondo;
                        equipo3.FormattingEnabled = true;
                        equipo3.Location = new System.Drawing.Point(110, 30);
                        equipo3.Size = new System.Drawing.Size(97, 21);

                        Label depo3 = new Label();
                        depo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        depo3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        depo3.ForeColor = System.Drawing.SystemColors.Control;
                        depo3.Location = new System.Drawing.Point(213, 6);
                        depo3.Size = new System.Drawing.Size(97, 21);
                        depo3.Text = "Deportista";
                        depo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        depo3.Parent = fondo;

                        ComboBox deportista3 = new ComboBox();
                        deportista3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        deportista3.FormattingEnabled = true;
                        deportista3.Location = new System.Drawing.Point(213, 30);
                        deportista3.Size = new System.Drawing.Size(97, 21);
                        deportista3.Parent = fondo;

                        Label grav = new Label();
                        grav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        grav.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        grav.ForeColor = System.Drawing.SystemColors.Control;
                        grav.Location = new System.Drawing.Point(316, 6);
                        grav.Size = new System.Drawing.Size(91, 21);
                        grav.Text = "Gravedad";
                        grav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        grav.Parent = fondo;

                        ComboBox gravedad = new ComboBox();
                        gravedad.Location = new System.Drawing.Point(316, 31);
                        gravedad.Size = new System.Drawing.Size(91, 20);
                        gravedad.Parent = fondo;

                        Label min3 = new Label();
                        min3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        min3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        min3.ForeColor = System.Drawing.SystemColors.Control;
                        min3.Location = new System.Drawing.Point(413, 6);
                        min3.Size = new System.Drawing.Size(88, 21);
                        min3.Text = "Minuto";
                        min3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        min3.Parent = fondo;

                        TextBox minuto3 = new TextBox();
                        minuto3.Location = new System.Drawing.Point(413, 30);
                        minuto3.Size = new System.Drawing.Size(88, 20);
                        minuto3.Parent = fondo;

                        RichTextBox descripcion3 = new RichTextBox();
                        descripcion3.Location = new System.Drawing.Point(8, 57);
                        descripcion3.Size = new System.Drawing.Size(399, 66);
                        descripcion3.Parent = fondo;

                        Button guardar3 = new Button();
                        guardar3.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
                        guardar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        guardar3.ForeColor = System.Drawing.SystemColors.Control;
                        guardar3.Location = new System.Drawing.Point(413, 57);
                        guardar3.Size = new System.Drawing.Size(88, 30);
                        guardar3.Text = "Guardar";
                        guardar3.UseVisualStyleBackColor = true;
                        guardar3.Parent = fondo;

                        Button borrar3 = new Button();
                        borrar3.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                        borrar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        borrar3.ForeColor = System.Drawing.SystemColors.Control;
                        borrar3.Location = new System.Drawing.Point(413, 92);
                        borrar3.Size = new System.Drawing.Size(88, 30);
                        borrar3.Text = "Borrar";
                        borrar3.UseVisualStyleBackColor = true;
                        borrar3.Parent = fondo;

                        borrar3.MouseDown += new MouseEventHandler(delegate (Object sg, MouseEventArgs exdge)
                        {
                            // comando mysql borrar pendiente

                            Sucesos.Remove(fondo);

                            for (int i = 0; i < Sucesos.Count; i++)
                            {
                                if (i == 0)
                                {
                                    Sucesos[0].Location = new System.Drawing.Point(4, 4);
                                }
                                else
                                {
                                    Sucesos[i].Location = new System.Drawing.Point(4, 4 + Sucesos[i - 1].Location.Y + Sucesos[i - 1].Size.Height);
                                }
                            }
                            if (Sucesos.Count > 0) label18.Location = new Point(4, 4 + Sucesos[Sucesos.Count - 1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);
                            else label18.Location = new Point(4, 4);
                            fondo.Dispose();
                        });

                        break;
                }
            }); id.SelectedIndex = 0;

            fondo.SizeChanged += new EventHandler(delegate (Object s, EventArgs exde)
            {
                for(int i = 0; i < Sucesos.Count; i++)
                {
                    if (i == 0)
                    {
                        Sucesos[0].Location = new System.Drawing.Point(4, 4);
                    }
                    else
                    {
                        Sucesos[i].Location = new System.Drawing.Point(4, 4 + Sucesos[i-1].Location.Y + Sucesos[i-1].Size.Height);
                    }
                }
                label18.Location = new Point(4, 4 + Sucesos[Sucesos.Count - 1].Location.Y + Sucesos[Sucesos.Count - 1].Size.Height);
            });
            
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
                int indices = Logica.consultaMaxIndex("Select nombreEqu,numero from deportistaEquipo where nombreEqu = '" + infoEquipos[1, i] + "'");
                for (int h = 0; h < Logica.consultaMaxIndex("Select nombreEqu,numero from deportistaEquipo where nombreEqu = '"+ infoEquipos[1, i] + "'"); h++)
                {
                    jugadoresDisponibles.Items.Add(infoDeportistas[1,h]+"");
                }

                dynamic[,] infoDepo = Logica.consulta("Select * from deporte where nombreDep = '" + Logica.consulta("Select nombreDep from Torneo where nombreTorn = '" + nombreTorn + "'")[0, 0] + "'");

                List<dynamic[]> enlaces = new List<dynamic[]>();
                PadreAlineaciones.Add(enlaces);

                for (int u = 0; u < infoDepo[4,0]; u++)
                {
                    ComboBox deportista = new ComboBox();
                    deportista.BackColor = Color.DarkGray;
                    deportista.DropDownStyle = ComboBoxStyle.DropDownList;
                    deportista.Location = new Point(9, 8 + 27 * u);
                    deportista.Size = new Size(162, 21);
                    deportista.Parent = deportistas;

                    Label previo = new Label();
                    previo.Parent = deportista;
                    previo.Text = "";
                    previo.Visible = false;

                    deportista.MouseWheel += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                    {
                        MessageBox.Show("Por favor no utilize la rueda del raton");

                        jugadoresDisponibles.Items.Clear();
                        for (int h = 0; h < indices ; h++)
                        {
                            jugadoresDisponibles.Items.Add(infoDeportistas[1, h] + "");
                        }
                        for(int o = 0; o < enlaces.Count; o++)
                        {
                            enlaces[o][0].Items.Clear();
                            enlaces[o][0].Controls[0].Text = "";
                        }
                    });

                    for (int o = 0; o < jugadoresDisponibles.Items.Count; o++)
                    {
                        deportista.Items.Add(jugadoresDisponibles.Items[o]);
                    }
                    deportista.SelectedIndexChanged += new EventHandler(delegate (Object s, EventArgs exde)
                    {
                        if (previo.Text == "")
                        {
                            jugadoresDisponibles.Items.Remove(deportista.Text);
                            previo.Text = deportista.Text;
                        }
                        else if (deportista.Text == "")
                        {
                            if(previo.Text != "")
                            {
                                jugadoresDisponibles.Items.Add(previo.Text);
                                previo.Text = "";
                            }
                        }
                        else
                        {
                            jugadoresDisponibles.Items.Add(previo.Text);
                            jugadoresDisponibles.Items.Remove(deportista.Text);
                            previo.Text = deportista.Text;
                        }
                    });

                    deportista.GotFocus += new EventHandler(delegate (Object s, EventArgs exde)
                    {
                        deportista.Items.Clear();

                        if (previo.Text != "")
                        {
                            jugadoresDisponibles.Items.Add(previo.Text);
                        }
                        previo.Text = "";

                        for (int o = 0; o < jugadoresDisponibles.Items.Count; o++)
                        {
                            deportista.Items.Add(jugadoresDisponibles.Items[o]);
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

                    dynamic[] enlace = new dynamic[2];
                    enlace[0] = deportista;
                    enlace[1] = posicion;

                    enlaces.Add(enlace);
                }

                if (Logica.consultaMaxIndex("Select * from Alineacion where id = "+id+ " and nombreEqu = '"+ infoPorEquipo[1, 0] + "' and nombreFase = '"+nombreFase+ "' and nombreTorn = '"+nombreTorn+"'") > 0)
                {
                    dynamic[,] alineacion = Logica.consulta("Select numero,posicion from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'");

                    for(int y = 0; y < Logica.consultaMaxIndex("Select numero,posicion from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "'"); y++)
                    {
                        enlaces[y][0].Text = alineacion[0, y]+"";
                        enlaces[y][1].Text = alineacion[1, y]+"";
                    }
                }
                

                Button guardar = new Button();
                guardar.FlatAppearance.BorderColor = Color.Lime;
                guardar.FlatStyle = FlatStyle.Flat;
                guardar.ForeColor = SystemColors.Control;
                guardar.Location = new Point(9, deportistas.Controls[deportistas.Controls.Count-1].Location.Y+27);
                guardar.Size = new Size(411, 23);
                guardar.Text = "Guardar";
                guardar.Parent = deportistas;

                if (estado > 0)
                {
                    deportistas.Enabled = false;
                    guardar.Visible = false;
                }

                guardar.Click += new EventHandler(delegate (Object s, EventArgs exde)
                {
                    int errores = 0;
                    for (int y = 0; y < enlaces.Count; y++)
                    {
                        if(enlaces[y][0].Text == "" || enlaces[y][1].Text == "")
                        {
                            MessageBox.Show("Completa todos los campos");
                            errores++;
                        }
                        break;
                    }
                    if(errores == 0)
                    {
                        for (int y = 0; y < enlaces.Count; y++)
                        {
                            Console.WriteLine("Select * from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and numero = " + enlaces[y][0].Text + ""); Console.WriteLine("Select * from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and numero = " + enlaces[y][0].Text + ""); Console.WriteLine("Select * from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and numero = " + enlaces[y][0].Text + "");
                            if (Logica.consultaMaxIndex("Select * from Alineacion where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and numero = " + enlaces[y][0].Text + "") > 0)
                            {
                                Logica.comando("update Alineacion set posicion = '" + enlaces[y][1].Text+ "' where id = " + id + " and nombreEqu = '" + infoPorEquipo[1, 0] + "' and nombreFase = '" + nombreFase + "' and nombreTorn = '" + nombreTorn + "' and numero = " + enlaces[y][0].Text);
                            }
                            else
                            {
                                Console.WriteLine("insert into Alineacion values(" + id + ",'" + infoPorEquipo[1, 0] + "'," + enlaces[y][0].Text + ",'" + nombreFase + "','" + nombreTorn + "','" + enlaces[y][1].Text + "')"); Console.WriteLine("insert into Alineacion values(" + id + ",'" + infoPorEquipo[1, 0] + "'," + enlaces[y][0].Text + ",'" + nombreFase + "','" + nombreTorn + "','" + enlaces[y][1].Text + "')"); Console.WriteLine("insert into Alineacion values(" + id + ",'" + infoPorEquipo[1, 0] + "'," + enlaces[y][0].Text + ",'" + nombreFase + "','" + nombreTorn + "','" + enlaces[y][1].Text + "')");
                                Logica.comando("insert into Alineacion values(" + id + ",'" + infoPorEquipo[1, 0] + "',"+ enlaces[y][0].Text + ",'" + nombreFase + "','" + nombreTorn + "','" + enlaces[y][1].Text + "')");
                            }
                        }
                    }
                });


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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        void cargarArbitros()
        {
            if(estado > 0)
            {
                label5.Visible = false;
                List<Arbitro> arb = JsonConvert.DeserializeObject<List<Arbitro>>(arbitross);

                for(int i = 0; i < arb.Count; i++)
                {
                    Panel Arbitro = new Panel();
                    Arbitro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    if (Arbitros.Count != 0) Arbitro.Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y - 4));
                    else Arbitro.Location = new System.Drawing.Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3));

                    Arbitro.Size = new System.Drawing.Size(165, 85);
                    Arbitro.Parent = pnlArbitros;
                    Arbitros.Add(Arbitro);

                    arbitros++;

                    label5.Location = new Point(4 + 171 * (arbitros % 3), 4 + 89 * (arbitros / 3) + (Arbitros[0].Location.Y - 4));

                    Label nom = new Label();
                    nom.ForeColor = SystemColors.Control;
                    nom.Location = new Point(9, 8);
                    nom.Size = new System.Drawing.Size(47, 13);
                    nom.Text = "Nombre:";
                    nom.Parent = Arbitro;

                    TextBox nombre = new TextBox();
                    nombre.Location = new System.Drawing.Point(56, 5);
                    nombre.Size = new System.Drawing.Size(100, 20);
                    nombre.Parent = Arbitro;
                    nombre.Text = arb[i].nombre;
                    nombre.Enabled = false;

                    Label pis = new Label();
                    pis.ForeColor = System.Drawing.SystemColors.Control;
                    pis.Location = new System.Drawing.Point(9, 34);
                    pis.Size = new System.Drawing.Size(33, 13);
                    pis.Text = "Pais :";
                    pis.Parent = Arbitro;
                    
                    TextBox pais = new TextBox();
                    pais.Location = new System.Drawing.Point(56, 31);
                    pais.Size = new System.Drawing.Size(100, 20);
                    pais.Parent = Arbitro;
                    pais.Text = arb[i].pais;
                    pais.Enabled = false;

                    Button borrar = new Button();
                    borrar.FlatAppearance.BorderColor = Color.Red;
                    borrar.FlatStyle = FlatStyle.Flat;
                    borrar.ForeColor = SystemColors.Control;
                    borrar.Location = new Point(8, 56);
                    borrar.Size = new Size(148, 23);
                    borrar.Text = "Quitar Arbitro";
                    borrar.UseVisualStyleBackColor = true;
                    borrar.Parent = Arbitro;

                    borrar.Enabled = false;
                }
            }
        }
    }
}
