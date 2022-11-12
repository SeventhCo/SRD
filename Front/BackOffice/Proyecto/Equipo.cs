using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{

    public partial class Equipo : Form
    {
        public string equipo;
        string deporte;
        int cantTorn;
        int cantDepor;

        public List<Panel> depora = new List<Panel>();
        public List<Panel> elimDepor = new List<Panel>();
        public List<PictureBox> deporImg = new List<PictureBox>();

        public Equipo()
        {
            InitializeComponent();
        }

        public void cargarEquipo()
        {
            if (Program.Blank.frmPrincipal.loged)
            {
                pictureBox4.Visible = true;
                if (apiResultados.consultaMaxIndex("select * from favEquipo where gmail = '" + Program.Blank.user.gmail[0] + "' and dominio = '" + Program.Blank.user.gmail[1] + "' and nombreEqu = '" + equipo + "'") > 0)
                {
                    pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\favorito2.png"));
                }
                else
                {
                    pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\favorito.png"));
                }
            }
            if (Program.Blank.frmPrincipal.rol > 0)
            {
                Program.Blank.Equipo.pictureBox4.Visible = true;
            }
            dynamic[,] info = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("select * from equipo where nombreEqu = '" + equipo + "'"));
            
            pictureBox1.Image = Auxiliar.conByteImg(Convert.FromBase64String(info[2, 0]));
            deporte = info[5, 0];
            lblInfoEqui.Text = "Equipo : " + equipo + "\n" +
                               "Nombre Corto : " + info[1, 0] + "\n" +
                               "Deporte : " + info[5, 0] + "\n" +
                               "Cantidad de Deportistas : " + apiResultados.consultaMaxIndex("Select * from deportistaEquipo where nombreEqu = '" + equipo + "'");
            label1.Text = info[3, 0] + "";
            label2.Text = info[4, 0] + "";
            cargaTorn();
            cargaDeport();
            

        }

        void clickTorn(Panel torn, PictureBox tornElim)
        {
            Program.Blank.torn = new Torneo();
            Program.Blank.torn.MdiParent = Program.Blank;
            Program.Blank.torn.Show();
            Program.Blank.torn.Visible = false;

            Program.Blank.torn.torneo = torn.Name;
            dynamic[,] infoTorneo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from Torneo where nombreTorn = '" + torn.Name + "'"));
            Program.Blank.torn.lblInfoTorn.Text =
                "Nombre : " + infoTorneo[0, 0] + "\n" +
                "Cantidad de fases : " + apiResultados.consultaMaxIndex("Select idfase from fase where nombreTorn = '" + infoTorneo[0, 0] + "'") + "\n" +
                "Deporte : " + infoTorneo[5, 0] + "\n" +
                "Estado : " + infoTorneo[4, 0];
            Program.Blank.torn.pbDepoLogo.Image = Auxiliar.conByteImg(Convert.FromBase64String(infoTorneo[3, 0]));
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
            if(apiResultados.consultaMaxIndex("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'") > 0)
            {
                for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from Torneo where nombreTorn = '" + JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'"))[0, 0] + "'"); i++)
                {
                    dynamic[,] tornInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from Torneo where nombreTorn = '" + JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("select nombreTorn from EquipoTorneo where nombreEqu = '" + equipo + "'"))[0, 0] + "'"));
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
                    imgTorn.Image = Auxiliar.conByteImg(Convert.FromBase64String(tornInfo[3, i]));

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
            //if (loged) Logica.consultaMaxIndex("UPDATE `deporte` SET `descripcion` = '" + desc.Text + "' WHERE (`nombreDep` = '" + deporte + "');");
            //lblDepoInfo.Text = desc.Text;
            //if (desc.Text.Equals("")) lblDepoInfo.Text = "Agregar Texto";
            //desc.Visible = false;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            SubPanelTor.Visible = true;
            subPanelDeportistas.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subPanelDeportistas.Visible = true;
            SubPanelTor.Visible = false;
        }

        public void clickDeport(Panel depor, PictureBox deporElim)
        {
            Program.Blank.Depor.cedula = depor.Name;
            Program.Blank.Depor.cargarEquipo();
            Program.Blank.Depor.Show();
            Program.Blank.Depor.Location = new Point(0, 0);
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

            dynamic[,] tremendo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select cedula from deportistaEquipo where nombreEqu = '" + equipo + "'"));
            for (int y = 0; y < apiResultados.consultaMaxIndex("Select cedula from deportistaEquipo where nombreEqu = '" + equipo + "'"); y++) 
            {
                for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from deportista where cedula = "+tremendo[0,y]); i++)
                {
                    dynamic[,] deporInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from deportista where cedula = " + tremendo[0, y]));

                    Panel depor = new Panel();
                    depor.Parent = subPanelDeportistas;
                    depor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                    depor.Location = new System.Drawing.Point(17 + 78 * ((cantDepor) % 8), 7 + 93 * ((cantDepor) / 8));
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
                    imgDepor.Image = Auxiliar.conByteImg(Convert.FromBase64String(deporInfo[4, i]));

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
        }
        

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToBase64String(Auxiliar.conImgByte(pictureBox4.Image)).Equals(Convert.ToBase64String(Auxiliar.conImgByte(Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\favorito.png"))))))
            {
                pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\favorito2.png"));
                JsonConvert.DeserializeObject<object>(apiResultados.comando("insert into favEquipo values('" + Program.Blank.user.gmail[0] + "','" + Program.Blank.user.gmail[1] + "','" + equipo + "')"));
            }
            else
            {
                pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\favorito.png"));
                apiResultados.consultaMaxIndex("delete from favEquipo where gmail = '" + Program.Blank.user.gmail[0] + "' and dominio = '" + Program.Blank.user.gmail[1] + "' and nombreEqu = '" + equipo + "'");
            }
        }
    }
}
