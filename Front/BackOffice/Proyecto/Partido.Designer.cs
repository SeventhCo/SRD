namespace Proyecto
{
    partial class Partido
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
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlEquipos = new System.Windows.Forms.Panel();
            this.cero = new System.Windows.Forms.Label();
            this.pnlAlineaciones = new System.Windows.Forms.Panel();
            this.pnlEquipoAlineacion = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlArbitros = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlEquipos.SuspendLayout();
            this.pnlAlineaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 64);
            this.label1.TabIndex = 30;
            this.label1.Text = "Lorem Ipsum!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Menu;
            this.button3.Location = new System.Drawing.Point(12, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 43);
            this.button3.TabIndex = 42;
            this.button3.Text = "Alineaciones";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Menu;
            this.button2.Location = new System.Drawing.Point(12, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 43);
            this.button2.TabIndex = 44;
            this.button2.Text = "Equipos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlEquipos
            // 
            this.pnlEquipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEquipos.Controls.Add(this.cero);
            this.pnlEquipos.Location = new System.Drawing.Point(128, 97);
            this.pnlEquipos.Name = "pnlEquipos";
            this.pnlEquipos.Size = new System.Drawing.Size(546, 303);
            this.pnlEquipos.TabIndex = 45;
            this.pnlEquipos.Visible = false;
            // 
            // cero
            // 
            this.cero.AutoSize = true;
            this.cero.Location = new System.Drawing.Point(0, 0);
            this.cero.Name = "cero";
            this.cero.Size = new System.Drawing.Size(0, 13);
            this.cero.TabIndex = 0;
            this.cero.Visible = false;
            // 
            // pnlAlineaciones
            // 
            this.pnlAlineaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlineaciones.Controls.Add(this.pnlEquipoAlineacion);
            this.pnlAlineaciones.Location = new System.Drawing.Point(128, 97);
            this.pnlAlineaciones.Name = "pnlAlineaciones";
            this.pnlAlineaciones.Size = new System.Drawing.Size(546, 303);
            this.pnlAlineaciones.TabIndex = 47;
            this.pnlAlineaciones.Visible = false;
            // 
            // pnlEquipoAlineacion
            // 
            this.pnlEquipoAlineacion.AutoScroll = true;
            this.pnlEquipoAlineacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEquipoAlineacion.Location = new System.Drawing.Point(0, 0);
            this.pnlEquipoAlineacion.Name = "pnlEquipoAlineacion";
            this.pnlEquipoAlineacion.Size = new System.Drawing.Size(88, 303);
            this.pnlEquipoAlineacion.TabIndex = 48;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.Menu;
            this.button4.Location = new System.Drawing.Point(12, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 43);
            this.button4.TabIndex = 48;
            this.button4.Text = "Arbitros";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pnlArbitros
            // 
            this.pnlArbitros.AutoScroll = true;
            this.pnlArbitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArbitros.Location = new System.Drawing.Point(128, 97);
            this.pnlArbitros.Name = "pnlArbitros";
            this.pnlArbitros.Size = new System.Drawing.Size(546, 303);
            this.pnlArbitros.TabIndex = 46;
            this.pnlArbitros.Visible = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(410, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 64);
            this.label2.TabIndex = 49;
            this.label2.Text = "Torneo:\r\nFase :\r\nCantidad de Equipos:\r\n";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.Menu;
            this.button5.Location = new System.Drawing.Point(12, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 43);
            this.button5.TabIndex = 54;
            this.button5.Text = "Minuto a Minuto";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Partido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlArbitros);
            this.Controls.Add(this.pnlEquipos);
            this.Controls.Add(this.pnlAlineaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Partido";
            this.Text = "Partido";
            this.pnlEquipos.ResumeLayout(false);
            this.pnlEquipos.PerformLayout();
            this.pnlAlineaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlEquipos;
        private System.Windows.Forms.Panel pnlAlineaciones;
        public System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlArbitros;
        private System.Windows.Forms.Label cero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlEquipoAlineacion;
        public System.Windows.Forms.Button button5;
    }
}