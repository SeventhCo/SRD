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
    public partial class Evento : Form
    {
        int cantFilas = 0;
        public List<CheckBox> cantEquipos = new List<CheckBox>();
        public List<Panel> depos = new List<Panel>();
        public Evento()
        {
            InitializeComponent();
            Deportes();
            Torneos();
        }




        public void addEquipo()
        {
            List<string> lista = new List<string>();
            label6.Location = new Point(label6.Location.X,42 + 24  * (cantFilas));
            ComboBox cbEquipos = new ComboBox();
            cbEquipos.Parent = panel1;
            cbEquipos.Size = new Size(174, 23);
            cbEquipos.Location = new Point(9, 18 + 24 * cantFilas );
            cbEquipos.BackColor = Color.DarkGray;
            cbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;


            
            dynamic[,] variable = Logica.consulta("SELECT nombreEqu FROM equipo " );
            
            
            for (int i = 0; i < Logica.consultaMaxIndex("Select nombreEqu from equipo"); i++)
            {

                cbEquipos.Items.Add(variable[0, i]);
                





            }
            cantFilas++;

            
        }




        public void Deportes()
        {


            dynamic[,] variable = Logica.consulta("Select nombreDep from deporte ");
            for (int i = 0; i < Logica.consultaMaxIndex("Select nombreDep from deporte"); i++)
            {

                cbDeporte.Items.Add(variable[0, i]);




            }



        }

        public void Torneos()
        {


            dynamic[,] variable = Logica.consulta("Select nombreTorn from torneo ");
            for (int i = 0; i < Logica.consultaMaxIndex("Select nombreTorn from torneo"); i++)
            {

                cbDeporte.Items.Add(variable[0, i]);




            }



        }











        

        private void label6_Click(object sender, EventArgs e)
        {
            addEquipo();
        }

        

        private void label6_Click_1(object sender, EventArgs e)
        {
            addEquipo();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
