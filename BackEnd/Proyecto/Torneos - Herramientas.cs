﻿using System;
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
    public partial class FormHerramientas : Form
    {
        List<Panel> tornes = new List<Panel>();
        int cantBotones = 3;
        public FormHerramientas()
        {
            InitializeComponent();
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                Program.frmPrincipal.frmHerrTorneo.Visible = false;
            }
            Opacity -= .2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Aceptar_MouseEnter(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.FromArgb(1, 110, 1);
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.BackColor = Color.Green;
        }

        private void Cancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(161,2,2);
        }

        private void Cancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Panel torne = new Panel();
            torne.Parent = Program.frmPrincipal.SubPanelTor;
            torne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            torne.Location = new System.Drawing.Point(17 + 78 * (cantBotones % 8), 36 + 78 * (cantBotones / 8));
            torne.Name = txtNombreT.Text;
            torne.Size = new System.Drawing.Size(64, 65);
            cantBotones++;
            torne.TabIndex = cantBotones;
            tornes.Add(torne);
            Label txt = new Label();
            txt.Parent = torne;
            txt.Visible = true;
            txt.Text = torne.Name;
            torne.Click += new EventHandler(delegate (Object s, EventArgs exde) {
                Program.frmPrincipal.pnlTorneos.Visible = false;
                Program.frmPrincipal.pnlLiga.Visible = true;
                Program.frmPrincipal.label23.Text = torne.Name;
            });
            txtNombreT.Text = "";
            timer2.Start();
        }
    }
}
