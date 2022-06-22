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
    public partial class FormEquipos : Form
    {
        public FormEquipos()
        {
            InitializeComponent();
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

        private void panelDeportes_MouseLeave(object sender, EventArgs e)
        {
            panelDeportes.BackColor = Color.FromArgb(255, 183, 3);
            panel6.Visible = false;
        }

        private void LblInicio_MouseEnter(object sender, EventArgs e)
        {
            panelInicio.BackColor = Color.FromArgb(240, 172, 3);
            panel4.Visible = true;
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

        private void loginleave_MouseEnter(object sender, EventArgs e)
        {
            loginenter.Visible = true;
            loginleave.Visible = false;
        }

        private void FormEquipos_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            logoenter.Visible = false;
            loginenter.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
        }

        private void loginenter_MouseLeave(object sender, EventArgs e)
        {
            loginleave.Visible = true;
            loginenter.Visible = false;
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.BackColor = Color.FromArgb(142, 5, 5);
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            timer1.Start();
            exit.BackColor = Color.FromArgb(126, 2, 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Application.Exit();
            }
            Opacity -= .2;
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
    }
}
