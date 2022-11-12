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
    public partial class Deportista : Form
    {
        string equipo;
        public string cedula;
        int cantTorn;
        public Deportista()
        {
            InitializeComponent();
        }

        public void cargarEquipo()
        {
            dynamic[,] infoDepo = Logica.consulta("select * from deportista where cedula = " + cedula );

            label1.Text =      "Nombre : " + infoDepo[1,0] + "\n" +
                               "Cedula : " + infoDepo[0, 0] + "\n" +
                               "Edad : " + infoDepo[2, 0] + "\n" +
                               "Altura : " + infoDepo[3, 0];

            pictureBox2.Image = Logica.conByteImg(Convert.FromBase64String(infoDepo[4, 0]));

            equipo = Logica.consulta("select nombreEqu from deportistaEquipo where cedula = " + cedula )[0, 0];

            dynamic[,] info = Logica.consulta("select * from equipo where nombreEqu = '" + equipo + "'");

            pictureBox1.Image = Logica.conByteImg(Convert.FromBase64String(info[2, 0]));

            lblInfoEqui.Text = "Equipo : " + equipo + "\n" +
                               "Nombre Corto : " + info[1, 0] + "\n" +
                               "Deporte : " + info[5, 0] + "\n" +
                               "Cantidad de Deportistas : " + Logica.consultaMaxIndex("Select * from deportistaEquipo where nombreEqu = '" + equipo + "'");
            cargaTorn();
        }

        void clickTorn(Panel torn, PictureBox tornElim)
        {
            Program.Blank.torn = new Torneo();
            Program.Blank.torn.MdiParent = Program.Blank;
            Program.Blank.torn.Show();
            Program.Blank.torn.Visible = false;

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

            for (int i = 0; i < Program.Blank.torn.Equipos.Count; i++)
            {
                Program.Blank.torn.Equipos[i].Enabled = false;
            }
        }

        void cargaTorn()
        {
            cantTorn = 0;
            if (Logica.consultaMaxIndex("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'") > 0)
            {
                for (int i = 0; i < Logica.consultaMaxIndex("Select * from Torneo where nombreTorn = '" + Logica.consulta("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'")[0, 0] + "'"); i++)
                {
                    dynamic[,] tornInfo = Logica.consulta("Select * from Torneo where nombreTorn = '" + Logica.consulta("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'")[0, 0] + "'");
                    Panel torn = new Panel();
                    torn.Parent = SubPanelTor;
                    torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                    torn.Location = new Point(17 + 78 * ((cantTorn) % 8), 7 + 93 * ((cantTorn) / 8));
                    torn.Name = tornInfo[1, i];
                    torn.Size = new Size(64, 80);
                    cantTorn++;

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
                    imgTorn.Image = Logica.conByteImg(Convert.FromBase64String(tornInfo[3, i]));

                    Label nomCorto = new Label();
                    nomCorto.Parent = torn;
                    nomCorto.Text = tornInfo[1, i];
                    nomCorto.Visible = true;
                    nomCorto.AutoSize = false;
                    nomCorto.Size = new Size(64, 13);
                    nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                    nomCorto.Location = new Point(0, 65);
                    nomCorto.ForeColor = Color.FromArgb(255, 255, 183, 3);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.Blank.Equipo.equipo = equipo;
            Program.Blank.Equipo.cargarEquipo();
            Program.Blank.Equipo.Show();
            Program.Blank.Equipo.Location = new Point(0, 0);
        }
    }
}
