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
    public partial class SisPunt : Form
    {
        public List<Panel> puntos = new List<Panel>();
        int cantFilas = 0;

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
            nomValor.Size = new Size(91, 15);

            TextBox txtVal = new TextBox();
            txtVal.Parent = valor;
            txtVal.Location = new Point(4, 41);
            txtVal.Size = new Size(162, 13);
            txtVal.BorderStyle = BorderStyle.None;
            txtVal.ForeColor = Color.FromArgb(0, 240, 240, 240);
            txtVal.BackColor = Color.DarkGray;

            Panel inutil2 = new Panel();
            inutil2.Parent = valor;
            inutil2.BackColor = Color.FromArgb(0, 2, 48, 71);
            inutil2.Location = new Point(0, 63);
            inutil2.Size = new Size(171, 3);
            
            cantFilas++;

            remove.MouseDown += new MouseEventHandler(delegate (Object s, MouseEventArgs exde)
            {
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

    }
}
