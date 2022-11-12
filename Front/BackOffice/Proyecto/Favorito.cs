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
    public partial class Favorito : Form
    {

        int cantEqui;
        public Favorito()
        {
            InitializeComponent();
        }

        public void clickEqui(Panel equi, PictureBox equiElim)
        {
            Program.Blank.Equipo.equipo = equi.Name;
            Program.Blank.Equipo.cargarEquipo();
            Program.Blank.Equipo.Show();
            Program.Blank.Equipo.Location = new Point(0, 0);
        }

        public void cargaEqui()
        {
            cantEqui = 0;

            for (int k = 0; k < apiResultados.consultaMaxIndex("select nombreEqu from favEquipo where gmail = '" + Program.Blank.user.gmail[0] + "' and dominio = '" + Program.Blank.user.gmail[1] + "'"); k++)
            {
                for (int i = 0; i < apiResultados.consultaMaxIndex("Select * from equipo where nombreEqu = '" + JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("select nombreEqu from favEquipo where gmail = '" + Program.Blank.user.gmail[0] + "' and dominio = '" + Program.Blank.user.gmail[1] + "'"))[0, k] + "'"); i++)
                {
                    dynamic[,] equiInfo = JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("Select * from equipo where nombreEqu = '" + JsonConvert.DeserializeObject<dynamic[,]>(apiResultados.consulta("select nombreEqu from favEquipo where gmail = '" + Program.Blank.user.gmail[0] + "' and dominio = '" + Program.Blank.user.gmail[1] + "'"))[0, k] + "'"));
                    Panel equi = new Panel();
                    equi.Parent = SubPanelEqu;
                    equi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                    equi.Location = new System.Drawing.Point(17 + 78 * ((cantEqui) % 8), 7 + 93 * ((cantEqui) / 8));
                    equi.Name = equiInfo[0, i];
                    equi.Size = new System.Drawing.Size(64, 80);
                    cantEqui++;
                    PictureBox equiElim = new PictureBox();
                    equiElim.Parent = equi;
                    equiElim.Visible = false;
                    equiElim.TabIndex = 1;
                    equiElim.Location = new System.Drawing.Point(46, 0);
                    equiElim.Size = new System.Drawing.Size(18, 18);
                    equiElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    equiElim.Name = equi.Name + "0";

                    /* aqui se pone el logo del equipo */
                    PictureBox imgEqui = new PictureBox();
                    imgEqui.Name = equi.Name + "img";
                    imgEqui.Parent = equi;
                    imgEqui.Visible = true;
                    imgEqui.Location = new System.Drawing.Point(0, 0);
                    imgEqui.Size = new System.Drawing.Size(64, 64);
                    imgEqui.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgEqui.Image = Auxiliar.conByteImg(Convert.FromBase64String(equiInfo[2, i]));

                    Label nomCorto = new Label();
                    nomCorto.Parent = equi;
                    nomCorto.Text = equiInfo[1, i];
                    nomCorto.Visible = true;
                    nomCorto.AutoSize = false;
                    nomCorto.Size = new Size(64, 13);
                    nomCorto.TextAlign = ContentAlignment.MiddleCenter;
                    nomCorto.Location = new Point(0, 65);

                    nomCorto.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                    {
                        clickEqui(equi, equiElim);
                    });

                    imgEqui.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                    {
                        clickEqui(equi, equiElim);
                    });

                    equiElim.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
                    {
                        clickEqui(equi, equiElim);
                    });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
