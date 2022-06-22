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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Torneos_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneo", "Advertencia", MessageBoxButtons.OK);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Application.Exit();
            }
            Opacity -= .2;
        }

        private void logoleave_MouseEnter(object sender, EventArgs e)
        {
            logoleave.Visible = false;
            logoenter.Visible = true;
        }

        private void logoenter_MouseLeave(object sender, EventArgs e)
        {
            logoleave.Visible = true;
            logoenter.Visible = false;
        }

        private void loginenter_MouseDown(object sender, MouseEventArgs e)
        {
            Program.frmPrincipal.frmLogin.Visible = true;
            Program.frmPrincipal.frmLogin.timer2.Stop();
            Program.frmPrincipal.frmLogin.timer1.Start();
        }

        private void loginenter_MouseLeave(object sender, EventArgs e)
        {
            loginleave.Visible = true;
            loginenter.Visible = false;
        }

        private void loginleave_MouseEnter(object sender, EventArgs e)
        {
            loginenter.Visible = true;
            loginleave.Visible = false;
        }

        private void panelInicio_MouseEnter(object sender, EventArgs e)
        {
            panelInicio.BackColor = Color.FromArgb(240, 172, 3);
            panel4.Visible = true;
        }

        private void panelInicio_MouseLeave(object sender, EventArgs e)
        {
            panelInicio.BackColor = Color.FromArgb(255, 183, 3);
            panel4.Visible = false;
        }

        private void panelDeportes_MouseEnter(object sender, EventArgs e)
        {
            panelDeportes.BackColor = Color.FromArgb(240, 172, 3);
            panel6.Visible = true;
        }

        private void LblInicio_MouseEnter(object sender, EventArgs e)
        {
            panelInicio.BackColor = Color.FromArgb(240, 172, 3);
            panel4.Visible = true;
        }

        private void panelDeportes_MouseLeave(object sender, EventArgs e)
        {
            panelDeportes.BackColor = Color.FromArgb(255, 183, 3);
            panel6.Visible = false;
        }

        private void LblDeportes_MouseEnter(object sender, EventArgs e)
        {
            panelDeportes.BackColor = Color.FromArgb(240, 172, 3);
            panel6.Visible = true;
        }

        private void panelAyuda_MouseEnter(object sender, EventArgs e)
        {
            panelAyuda.BackColor = Color.FromArgb(240, 172, 3);
            panel8.Visible = true;
        }

        private void panelAyuda_MouseLeave(object sender, EventArgs e)
        {
            panelAyuda.BackColor = Color.FromArgb(255, 183, 3);
            panel8.Visible = false;
        }

        private void LblAyuda_MouseEnter(object sender, EventArgs e)
        {
            panelAyuda.BackColor = Color.FromArgb(240, 172, 3);
            panel8.Visible = true;
        }

        private void exit_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
            exit.BackColor = Color.FromArgb(126, 2, 2);
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.FromArgb(142, 5, 5);
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
        }

        private void panelInicio_MouseDown(object sender, MouseEventArgs e)
        {
            Program.frmPrincipal.Visible = true;
            this.Visible = false;
        }

        private void LblInicio_MouseDown(object sender, MouseEventArgs e)
        {
            Program.frmPrincipal.Visible = true;
            this.Visible = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            logoenter.Visible = false;
            loginenter.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
        }

        private void ImgAgregar_MouseEnter(object sender, EventArgs e)
        {
            panelAgregar.BackColor = Color.FromArgb(2, 39, 57);
        }

        private void ImgAgregar_MouseLeave(object sender, EventArgs e)
        {
            panelAgregar.BackColor = Color.FromArgb(2, 43, 63);
        }

        private void ImgEliminar_MouseEnter(object sender, EventArgs e)
        {
            panelEliminar.BackColor = Color.FromArgb(2, 39, 57);
        }

        private void ImgEliminar_MouseLeave(object sender, EventArgs e)
        {
            panelEliminar.BackColor = Color.FromArgb(2, 43, 63);
        }

        private void ImgEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelBasket.Visible == false && ChkEquis.Visible == false)
            {
                DialogResult dialogResult2 = MessageBox.Show("No puede eliminar mas Torneos", "Advertencia", MessageBoxButtons.OK);
            }
            else if (panelBasket.Visible == true && ChkEquis.Visible == false)
            {
                ChkEquis.Visible = true;
                Titulo.Text = "       Eliminar Torneos";
                Titulo.BackColor = Color.Maroon;
            }
            else if (ChkEquis.Visible == true)
            {
                ChkEquis.Visible = false;
                Titulo.Text = "       Deportes - Torneos";
                Titulo.BackColor = Color.FromArgb(1, 26, 37);
            }
        }

        private void equis_Click(object sender, EventArgs e)
        {
            if (equis.Visible)
            {
                equis.Visible = false;
                ImgEliminar.Visible = true;
                ok.Visible = false;
            }
            else
            {
                equis.Visible = true;
                ImgEliminar.Visible = false;
                ok.Visible = true;
            }
        }

        private void ImgBasket_MouseEnter(object sender, EventArgs e)
        {
            panelBasket.BackColor = Color.FromArgb(2, 39, 57);
        }

        private void ImgBasket_MouseLeave(object sender, EventArgs e)
        {
            panelBasket.BackColor = Color.FromArgb(2, 43, 63);
        }

        private void ChkEquis_MouseClick(object sender, MouseEventArgs e)
        {
            if (equis.Visible)
            {
                equis.Visible = false;
                ImgEliminar.Visible = true;
                ok.Visible = false;
            }
            else
            {
                equis.Visible = true;
                ImgEliminar.Visible = false;
                ok.Visible = true;
            }
        }

        private void ok_MouseEnter(object sender, EventArgs e)
        {
            panelEliminar.BackColor = Color.FromArgb(2, 39, 57);
        }

        private void ok_MouseLeave(object sender, EventArgs e)
        {
            panelEliminar.BackColor = Color.FromArgb(2, 43, 63);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Titulo.Text = "       Deportes";
            Titulo.BackColor = Color.FromArgb(1, 26, 37);
            ok.Visible = false;
            ChkEquis.Visible = false;
            equis.Visible = false;
            ImgEliminar.Visible = true;
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este deporte?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                panelBasket.Visible = false;
                this.panelAgregar.Location = new System.Drawing.Point(20, 41);
                this.panelEliminar.Location = new System.Drawing.Point(111, 41);
            }
        }

        private void equiposleavegris_MouseEnter(object sender, EventArgs e)
        {
            equiposleavegris.Visible = false;
            equiposentergris.Visible = true;
            torneoleaveazulentergris.Visible = true;
            torneoleaveazul.Visible = false;
        }

        private void equiposentergris_MouseLeave(object sender, EventArgs e)
        {
            equiposentergris.Visible = false;
            equiposleavegris.Visible = true;
            torneoleaveazul.Visible = true;
            torneoleaveazulentergris.Visible = false;
        }

        private void torneoleaveazul_MouseEnter(object sender, EventArgs e)
        {
            torneoleaveazul.Visible = false;
            torneoenterazul.Visible = true;
        }

        private void torneoenterazul_MouseLeave(object sender, EventArgs e)
        {
            torneoenterazul.Visible = false;
            torneoleaveazul.Visible = true;
        }

        private void equiposentergris_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.frmPrincipal.frmEquipo.Visible = true;
        }

        private void torneoenterazul_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Ya te encuentras en Deportes - Torneos", "Advertencia", MessageBoxButtons.OK);
        }

        private void ImgAgregar_Click(object sender, EventArgs e)
        {
            if (ChkEquis.Visible == true)
            {
                DialogResult dialogResult = MessageBox.Show("No puede agregar un torneo mientras elimina uno", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                Titulo.Text = "       Agregar Torneo";
                Titulo.BackColor = Color.Green;
                Program.frmPrincipal.frmHerrTorneo.timer2.Stop();
                Program.frmPrincipal.frmHerrTorneo.Visible = true;
                Program.frmPrincipal.frmHerrTorneo.timer1.Start();
            }
        }

        private void unloginleave_MouseEnter(object sender, EventArgs e)
        {
            unloginleave.Visible = false;
            unloginenter.Visible = true;
        }

        private void unloginenter_MouseLeave(object sender, EventArgs e)
        {
            unloginenter.Visible = false;
            unloginleave.Visible = true;
        }
    }
}
