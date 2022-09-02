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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 285);
            this.panel1.TabIndex = 4;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Controls.Add(this.label1);
            this.panel21.Controls.Add(this.textBox1);
            this.panel21.Controls.Add(this.pictureBox1);
            this.panel21.Controls.Add(this.pictureBox2);
            this.panel21.Location = new System.Drawing.Point(12, 84);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(665, 29);
            this.panel21.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Torneos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(523, 20);
            this.textBox1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(606, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(636, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // Deporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.panel21);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInfoDepo);
            this.Controls.Add(this.pbDepoLogo);
            this.Controls.Add(this.lblDepoInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Deporte";
            this.Text = "Deporte";
            ((System.ComponentModel.ISupportInitialize)(this.pbDepoLogo)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDepoLogo;
        public System.Windows.Forms.Label lblDepoInfo;
        public System.Windows.Forms.Label lblInfoDepo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}