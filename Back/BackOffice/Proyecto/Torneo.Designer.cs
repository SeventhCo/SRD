namespace Proyecto
{
    partial class Torneo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Torneo));
            this.button1 = new System.Windows.Forms.Button();
            this.lblInfoTorn = new System.Windows.Forms.Label();
            this.pbDepoLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(645, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // lblInfoTorn
            // 
            this.lblInfoTorn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfoTorn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.lblInfoTorn.Location = new System.Drawing.Point(82, 12);
            this.lblInfoTorn.Name = "lblInfoTorn";
            this.lblInfoTorn.Size = new System.Drawing.Size(176, 64);
            this.lblInfoTorn.TabIndex = 29;
            this.lblInfoTorn.Text = "Torneo:\r\n";
            this.lblInfoTorn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblInfoTorn_MouseDown);
            // 
            // pbDepoLogo
            // 
            this.pbDepoLogo.Location = new System.Drawing.Point(12, 12);
            this.pbDepoLogo.Name = "pbDepoLogo";
            this.pbDepoLogo.Size = new System.Drawing.Size(64, 64);
            this.pbDepoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDepoLogo.TabIndex = 27;
            this.pbDepoLogo.TabStop = false;
            this.pbDepoLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDepoLogo_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cero);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(106, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 312);
            this.panel1.TabIndex = 32;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // cero
            // 
            this.cero.Location = new System.Drawing.Point(0, 0);
            this.cero.Name = "cero";
            this.cero.Size = new System.Drawing.Size(1, 1);
            this.cero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Equipo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Menu;
            this.button2.Location = new System.Drawing.Point(12, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 30);
            this.button2.TabIndex = 40;
            this.button2.Text = "Equipos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Menu;
            this.button3.Location = new System.Drawing.Point(12, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 43);
            this.button3.TabIndex = 41;
            this.button3.Text = "Configurar Fases";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            // 
            // Torneo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInfoTorn);
            this.Controls.Add(this.pbDepoLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Torneo";
            this.Text = " ";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Torneo_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblInfoTorn;
        public System.Windows.Forms.PictureBox pbDepoLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label cero;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label label1;
    }
}