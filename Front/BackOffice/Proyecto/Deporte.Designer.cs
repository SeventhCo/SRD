namespace Proyecto
{
    partial class Deporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deporte));
            this.pbDepoLogo = new System.Windows.Forms.PictureBox();
            this.lblDepoInfo = new System.Windows.Forms.Label();
            this.lblInfoDepo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTorneos = new System.Windows.Forms.Panel();
            this.pnlSubBuscador = new System.Windows.Forms.Panel();
            this.lblTorneosDep = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).BeginInit();
            this.pnlSubBuscador.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDepoLogo
            // 
            this.pbDepoLogo.Location = new System.Drawing.Point(12, 12);
            this.pbDepoLogo.Name = "pbDepoLogo";
            this.pbDepoLogo.Size = new System.Drawing.Size(64, 64);
            this.pbDepoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDepoLogo.TabIndex = 0;
            this.pbDepoLogo.TabStop = false;
            // 
            // lblDepoInfo
            // 
            this.lblDepoInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDepoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.lblDepoInfo.Location = new System.Drawing.Point(264, 12);
            this.lblDepoInfo.Name = "lblDepoInfo";
            this.lblDepoInfo.Size = new System.Drawing.Size(375, 64);
            this.lblDepoInfo.TabIndex = 1;
            this.lblDepoInfo.Text = "(Aniadir Texto)";
            // 
            // lblInfoDepo
            // 
            this.lblInfoDepo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfoDepo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.lblInfoDepo.Location = new System.Drawing.Point(82, 12);
            this.lblInfoDepo.Name = "lblInfoDepo";
            this.lblInfoDepo.Size = new System.Drawing.Size(176, 64);
            this.lblInfoDepo.TabIndex = 2;
            this.lblInfoDepo.Text = "Deporte : 12345678901234567890";
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
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // pnlTorneos
            // 
            this.pnlTorneos.AutoSize = true;
            this.pnlTorneos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTorneos.Location = new System.Drawing.Point(12, 115);
            this.pnlTorneos.Name = "pnlTorneos";
            this.pnlTorneos.Size = new System.Drawing.Size(665, 285);
            this.pnlTorneos.TabIndex = 4;
            // 
            // pnlSubBuscador
            // 
            this.pnlSubBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.pnlSubBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubBuscador.Controls.Add(this.lblTorneosDep);
            this.pnlSubBuscador.Location = new System.Drawing.Point(12, 84);
            this.pnlSubBuscador.Name = "pnlSubBuscador";
            this.pnlSubBuscador.Size = new System.Drawing.Size(665, 29);
            this.pnlSubBuscador.TabIndex = 26;
            // 
            // lblTorneosDep
            // 
            this.lblTorneosDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTorneosDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.lblTorneosDep.Location = new System.Drawing.Point(3, 4);
            this.lblTorneosDep.Name = "lblTorneosDep";
            this.lblTorneosDep.Size = new System.Drawing.Size(68, 20);
            this.lblTorneosDep.TabIndex = 0;
            this.lblTorneosDep.Text = "Torneos";
            this.lblTorneosDep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Deporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.pnlSubBuscador);
            this.Controls.Add(this.pnlTorneos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInfoDepo);
            this.Controls.Add(this.pbDepoLogo);
            this.Controls.Add(this.lblDepoInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deporte";
            this.Text = "Deporte";
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).EndInit();
            this.pnlSubBuscador.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDepoLogo;
        public System.Windows.Forms.Label lblDepoInfo;
        public System.Windows.Forms.Label lblInfoDepo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlTorneos;
        private System.Windows.Forms.Panel pnlSubBuscador;
        private System.Windows.Forms.Label lblTorneosDep;
    }
}