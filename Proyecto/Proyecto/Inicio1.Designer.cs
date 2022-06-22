namespace Proyecto
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.PanelLateral = new System.Windows.Forms.Panel();
            this.unloginleave = new System.Windows.Forms.PictureBox();
            this.logoenter = new System.Windows.Forms.PictureBox();
            this.loginenter = new System.Windows.Forms.PictureBox();
            this.panelAyuda = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LblAyuda = new System.Windows.Forms.Label();
            this.panelDeportes = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LblDeportes = new System.Windows.Forms.Label();
            this.logoleave = new System.Windows.Forms.PictureBox();
            this.loginleave = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblInicio = new System.Windows.Forms.Label();
            this.unloginenter = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Panel = new System.Windows.Forms.Panel();
            this.PanelAnuncio = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.INICIO = new System.Windows.Forms.Label();
            this.PanelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloginleave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginenter)).BeginInit();
            this.panelAyuda.SuspendLayout();
            this.panelDeportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoleave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginleave)).BeginInit();
            this.panelInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloginenter)).BeginInit();
            this.Panel.SuspendLayout();
            this.PanelAnuncio.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLateral
            // 
            this.PanelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.PanelLateral.Controls.Add(this.unloginleave);
            this.PanelLateral.Controls.Add(this.logoenter);
            this.PanelLateral.Controls.Add(this.panelAyuda);
            this.PanelLateral.Controls.Add(this.panelDeportes);
            this.PanelLateral.Controls.Add(this.logoleave);
            this.PanelLateral.Controls.Add(this.exit);
            this.PanelLateral.Controls.Add(this.panelInicio);
            this.PanelLateral.Controls.Add(this.unloginenter);
            this.PanelLateral.Controls.Add(this.loginenter);
            this.PanelLateral.Controls.Add(this.loginleave);
            this.PanelLateral.Location = new System.Drawing.Point(-17, -6);
            this.PanelLateral.Name = "PanelLateral";
            this.PanelLateral.Size = new System.Drawing.Size(704, 63);
            this.PanelLateral.TabIndex = 0;
            // 
            // unloginleave
            // 
            this.unloginleave.Image = ((System.Drawing.Image)(resources.GetObject("unloginleave.Image")));
            this.unloginleave.Location = new System.Drawing.Point(609, 10);
            this.unloginleave.Name = "unloginleave";
            this.unloginleave.Size = new System.Drawing.Size(37, 45);
            this.unloginleave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.unloginleave.TabIndex = 6;
            this.unloginleave.TabStop = false;
            this.unloginleave.Visible = false;
            this.unloginleave.WaitOnLoad = true;
            this.unloginleave.MouseLeave += new System.EventHandler(this.unloginenter_MouseLeave);
            // 
            // logoenter
            // 
            this.logoenter.Image = ((System.Drawing.Image)(resources.GetObject("logoenter.Image")));
            this.logoenter.Location = new System.Drawing.Point(3, 0);
            this.logoenter.Name = "logoenter";
            this.logoenter.Size = new System.Drawing.Size(139, 80);
            this.logoenter.TabIndex = 1;
            this.logoenter.TabStop = false;
            this.logoenter.MouseLeave += new System.EventHandler(this.logoenter_MouseLeave);
            // 
            // loginenter
            // 
            this.loginenter.Image = ((System.Drawing.Image)(resources.GetObject("loginenter.Image")));
            this.loginenter.Location = new System.Drawing.Point(609, 10);
            this.loginenter.Name = "loginenter";
            this.loginenter.Size = new System.Drawing.Size(37, 45);
            this.loginenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loginenter.TabIndex = 5;
            this.loginenter.TabStop = false;
            this.loginenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginenter_MouseDown);
            this.loginenter.MouseLeave += new System.EventHandler(this.loginenter_MouseLeave);
            // 
            // panelAyuda
            // 
            this.panelAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.panelAyuda.Controls.Add(this.panel8);
            this.panelAyuda.Controls.Add(this.LblAyuda);
            this.panelAyuda.Location = new System.Drawing.Point(395, 16);
            this.panelAyuda.Name = "panelAyuda";
            this.panelAyuda.Size = new System.Drawing.Size(95, 39);
            this.panelAyuda.TabIndex = 2;
            this.panelAyuda.MouseEnter += new System.EventHandler(this.panelAyuda_MouseEnter);
            this.panelAyuda.MouseLeave += new System.EventHandler(this.panelAyuda_MouseLeave);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel8.Location = new System.Drawing.Point(0, 35);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(147, 4);
            this.panel8.TabIndex = 1;
            // 
            // LblAyuda
            // 
            this.LblAyuda.AutoSize = true;
            this.LblAyuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblAyuda.ForeColor = System.Drawing.Color.White;
            this.LblAyuda.Image = ((System.Drawing.Image)(resources.GetObject("LblAyuda.Image")));
            this.LblAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblAyuda.Location = new System.Drawing.Point(9, 13);
            this.LblAyuda.Name = "LblAyuda";
            this.LblAyuda.Size = new System.Drawing.Size(71, 17);
            this.LblAyuda.TabIndex = 0;
            this.LblAyuda.Text = "      Ayuda";
            this.LblAyuda.MouseEnter += new System.EventHandler(this.LblAyuda_MouseEnter);
            // 
            // panelDeportes
            // 
            this.panelDeportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.panelDeportes.Controls.Add(this.panel6);
            this.panelDeportes.Controls.Add(this.LblDeportes);
            this.panelDeportes.Location = new System.Drawing.Point(271, 16);
            this.panelDeportes.Name = "panelDeportes";
            this.panelDeportes.Size = new System.Drawing.Size(95, 39);
            this.panelDeportes.TabIndex = 2;
            this.panelDeportes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDeportes_MouseDown);
            this.panelDeportes.MouseEnter += new System.EventHandler(this.panelDeportes_MouseEnter);
            this.panelDeportes.MouseLeave += new System.EventHandler(this.panelDeportes_MouseLeave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel6.Location = new System.Drawing.Point(0, 35);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(147, 4);
            this.panel6.TabIndex = 1;
            // 
            // LblDeportes
            // 
            this.LblDeportes.AutoSize = true;
            this.LblDeportes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblDeportes.ForeColor = System.Drawing.Color.White;
            this.LblDeportes.Image = ((System.Drawing.Image)(resources.GetObject("LblDeportes.Image")));
            this.LblDeportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblDeportes.Location = new System.Drawing.Point(4, 13);
            this.LblDeportes.Name = "LblDeportes";
            this.LblDeportes.Size = new System.Drawing.Size(88, 17);
            this.LblDeportes.TabIndex = 0;
            this.LblDeportes.Text = "      Deportes";
            this.LblDeportes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblDeportes_MouseDown);
            this.LblDeportes.MouseEnter += new System.EventHandler(this.LblDeportes_MouseEnter);
            // 
            // logoleave
            // 
            this.logoleave.Image = ((System.Drawing.Image)(resources.GetObject("logoleave.Image")));
            this.logoleave.Location = new System.Drawing.Point(3, 0);
            this.logoleave.Name = "logoleave";
            this.logoleave.Size = new System.Drawing.Size(139, 80);
            this.logoleave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoleave.TabIndex = 1;
            this.logoleave.TabStop = false;
            this.logoleave.MouseEnter += new System.EventHandler(this.logoleave_MouseEnter);
            // 
            // loginleave
            // 
            this.loginleave.Image = ((System.Drawing.Image)(resources.GetObject("loginleave.Image")));
            this.loginleave.Location = new System.Drawing.Point(609, 10);
            this.loginleave.Name = "loginleave";
            this.loginleave.Size = new System.Drawing.Size(37, 45);
            this.loginleave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loginleave.TabIndex = 4;
            this.loginleave.TabStop = false;
            this.loginleave.MouseEnter += new System.EventHandler(this.loginleave_MouseEnter);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(669, 5);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(35, 22);
            this.exit.TabIndex = 2;
            this.exit.Text = "x";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exit_MouseClick);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // panelInicio
            // 
            this.panelInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.panelInicio.Controls.Add(this.panel4);
            this.panelInicio.Controls.Add(this.LblInicio);
            this.panelInicio.Location = new System.Drawing.Point(148, 16);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(95, 39);
            this.panelInicio.TabIndex = 1;
            this.panelInicio.MouseEnter += new System.EventHandler(this.panelInicio_MouseEnter);
            this.panelInicio.MouseLeave += new System.EventHandler(this.panelInicio_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel4.Location = new System.Drawing.Point(0, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 4);
            this.panel4.TabIndex = 1;
            // 
            // LblInicio
            // 
            this.LblInicio.AutoSize = true;
            this.LblInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblInicio.ForeColor = System.Drawing.Color.White;
            this.LblInicio.Image = ((System.Drawing.Image)(resources.GetObject("LblInicio.Image")));
            this.LblInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblInicio.Location = new System.Drawing.Point(19, 13);
            this.LblInicio.Name = "LblInicio";
            this.LblInicio.Size = new System.Drawing.Size(58, 17);
            this.LblInicio.TabIndex = 0;
            this.LblInicio.Text = "    Inicio";
            this.LblInicio.MouseEnter += new System.EventHandler(this.LblInicio_MouseEnter);
            // 
            // unloginenter
            // 
            this.unloginenter.Image = ((System.Drawing.Image)(resources.GetObject("unloginenter.Image")));
            this.unloginenter.Location = new System.Drawing.Point(609, 10);
            this.unloginenter.Name = "unloginenter";
            this.unloginenter.Size = new System.Drawing.Size(37, 45);
            this.unloginenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.unloginenter.TabIndex = 7;
            this.unloginenter.TabStop = false;
            this.unloginenter.Visible = false;
            this.unloginenter.MouseEnter += new System.EventHandler(this.unloginleave_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.Panel.Controls.Add(this.PanelAnuncio);
            this.Panel.Controls.Add(this.INICIO);
            this.Panel.Location = new System.Drawing.Point(1, 55);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(686, 356);
            this.Panel.TabIndex = 1;
            // 
            // PanelAnuncio
            // 
            this.PanelAnuncio.BackColor = System.Drawing.Color.White;
            this.PanelAnuncio.Controls.Add(this.label1);
            this.PanelAnuncio.Controls.Add(this.label5);
            this.PanelAnuncio.Location = new System.Drawing.Point(555, 15);
            this.PanelAnuncio.Name = "PanelAnuncio";
            this.PanelAnuncio.Size = new System.Drawing.Size(123, 332);
            this.PanelAnuncio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Publicidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "Publicidad";
            // 
            // INICIO
            // 
            this.INICIO.AutoSize = true;
            this.INICIO.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.INICIO.Location = new System.Drawing.Point(259, 156);
            this.INICIO.Name = "INICIO";
            this.INICIO.Size = new System.Drawing.Size(84, 32);
            this.INICIO.TabIndex = 0;
            this.INICIO.Text = "INICIO";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.PanelLateral);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormInicio";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelLateral.ResumeLayout(false);
            this.PanelLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloginleave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginenter)).EndInit();
            this.panelAyuda.ResumeLayout(false);
            this.panelAyuda.PerformLayout();
            this.panelDeportes.ResumeLayout(false);
            this.panelDeportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoleave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginleave)).EndInit();
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unloginenter)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.PanelAnuncio.ResumeLayout(false);
            this.PanelAnuncio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLateral;
        private System.Windows.Forms.PictureBox logoleave;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.Label LblInicio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label INICIO;
        private System.Windows.Forms.PictureBox logoenter;
        private System.Windows.Forms.Panel panelAyuda;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LblAyuda;
        private System.Windows.Forms.Panel panelDeportes;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LblDeportes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox loginleave;
        public System.Windows.Forms.PictureBox loginenter;
        public System.Windows.Forms.PictureBox unloginenter;
        public System.Windows.Forms.PictureBox unloginleave;
        public System.Windows.Forms.Panel PanelAnuncio;
    }
}
