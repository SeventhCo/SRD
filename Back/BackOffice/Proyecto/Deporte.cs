using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Deporte : Form
    {
        public string deporte;
        public bool loged = false;
        public bool eliminar = false;

        public int cantTorn = 0;

        public List<Panel> torns = new List<Panel>();
        public List<Panel> elimTorns = new List<Panel>();
        public List<PictureBox> tornsImg = new List<PictureBox>();

        public Deporte()
        {
            InitializeComponent();
        }

        public void clickTorn(Panel torn, PictureBox tornElim)
        {
            if (eliminar)
            {
                if (tornElim.Name.Equals(torn.Name + "0"))
                {
                    tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\selected.png"));
                    tornElim.Name = torn.Name + "1";
                    elimTorns.Add(torn);
                }
                else if (tornElim.Name.Equals(torn.Name + "1"))
                {
                    tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                    tornElim.Name = torn.Name + "0";
                    elimTorns.Remove(torn);
                }
            }
            else
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
                if (!loged)
                {
                    Program.Blank.torn.button3.Visible = false;
                    Program.Blank.torn.label1.Visible = false;
                    for (int i = 0; i < Program.Blank.torn.Equipos.Count; i++)
                    {
                        Program.Blank.torn.Equipos[i].Enabled = false;
                    }
                }
            }
        }

        public void cargaTorn()
        {
            loged = Program.Blank.frmPrincipal.loged;
            for (int i = tornsImg.Count - 1; i >= 0; i--)
            {
                tornsImg[i].Dispose();
                tornsImg.Remove(tornsImg[i]);
            }
            for (int i = torns.Count - 1; i >= 0; i--)
            {
                torns[i].Dispose();
                torns.Remove(torns[i]);
            }
            for (int i = elimTorns.Count - 1; i >= 0; i--)
            {
                elimTorns[i].Dispose();
                elimTorns.Remove(elimTorns[i]);
            }
            cantTorn = 0;
            for (int i = 0; i < Logica.consultaMaxIndex("Select * from Torneo where nombreDep = '"+deporte+"'"); i++) 
            {
                dynamic[,] tornInfo = Logica.consulta("Select * from Torneo where nombreDep = '" + deporte + "'");
                Panel torn = new Panel();
                torn.Parent = pnlTorneos;
                torn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
                if (loged) torn.Location = new Point(17 + 78 * ((cantTorn + 2) % 8), 7 + 93 * ((cantTorn + 2) / 8));
                else torn.Location = new Point(17 + 78 * ((cantTorn) % 8), 7 + 93 * ((cantTorn) / 8));
                torn.Name = tornInfo[1, i];
                torn.Size = new Size(64, 80);
                cantTorn++;
                torns.Add(torn);

                PictureBox tornElim = new PictureBox();
                tornElim.Parent = torn;
                tornElim.Visible = false;
                tornElim.TabIndex = 1;
                tornElim.Location = new System.Drawing.Point(46, 0);
                tornElim.Size = new System.Drawing.Size(18, 18);
                tornElim.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Imagenes\\notselected.png"));
                tornElim.Name = torn.Name + "0";
                tornsImg.Add(tornElim);

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
                nomCorto.ForeColor = Color.FromArgb(255,255, 183, 3);

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

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            if(loged) Logica.consultaMaxIndex("UPDATE `deporte` SET `descripcion` = '" + desc.Text + "' WHERE (`nombreDep` = '" + deporte + "');");
            lblDepoInfo.Text = desc.Text;
            if (desc.Text.Equals("")) lblDepoInfo.Text = "Agregar Texto";
            desc.Visible = false;
        }

        private void lblDepoInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (loged)
            {
                desc.Visible = true;
                desc.BringToFront();
                if (desc.Text.Equals("Agregar Texto")) desc.Text = "";
                desc.Focus();
            }
        }

        private void desc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Logica.consultaMaxIndex("UPDATE `deporte` SET `descripcion` = '" + desc.Text + "' WHERE (`nombreDep` = '" + deporte + "');");
                lblDepoInfo.Text = desc.Text;
                if (desc.Text.Equals("")) lblDepoInfo.Text = "Agregar Texto";
                desc.Visible = false;
            }
        }
        public void actualizar()
        {
            Idioma.controles(pnlTorneos);
        }
        private void Deporte_Load(object sender, EventArgs e)
        {
            desc.Size = new Size(2,2);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cargaTorn();
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            if (eliminar)
            {
                MessageBox.Show("No puede agregar un deporte mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                Program.Blank.frmPrincipal.limpiar();
                Program.Blank.frmHerrTorneo.pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes\\nuevo.png"));
                Program.Blank.frmHerrTorneo.comboBox5.Items.Clear();
                dynamic[,] sist = Logica.consulta("Select * from deporte");
                if (!(sist == null))
                {
                    for (int i = 0; i < Logica.consultaMaxIndex("Select * from deporte"); i++)
                    {
                        Program.Blank.frmHerrTorneo.comboBox5.Items.Add(sist[1, i]);
                    }
                }
                Program.Blank.frmHerrTorneo.deporte = true;
                Program.Blank.frmHerrTorneo.comboBox5.Text = deporte;
                Program.Blank.frmHerrTorneo.Visible = true;
            }
        }
        
    }
}
