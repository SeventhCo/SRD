namespace Proyecto
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.VerContra = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 45;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 45;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.DarkGray;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(16, 127);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(200, 20);
            this.txtUser.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel1.Location = new System.Drawing.Point(16, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel2.Location = new System.Drawing.Point(16, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 2);
            this.panel2.TabIndex = 6;
            // 
            // txtContra
            // 
            this.txtContra.BackColor = System.Drawing.Color.DarkGray;
            this.txtContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContra.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtContra.ForeColor = System.Drawing.Color.Black;
            this.txtContra.Location = new System.Drawing.Point(16, 180);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '*';
            this.txtContra.Size = new System.Drawing.Size(180, 20);
            this.txtContra.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(-28, -25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 88);
            this.button1.TabIndex = 7;
            this.button1.Text = "Iniciar sesion";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(62, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 42);
            this.panel3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Olvide mi contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.label4.Location = new System.Drawing.Point(158, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Crear cuenta";
            this.label4.UseWaitCursor = true;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(327, -3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 20);
            this.button2.TabIndex = 11;
            this.button2.Text = "salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.VerContra);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtUser);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtContra);
            this.panel4.Location = new System.Drawing.Point(232, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 325);
            this.panel4.TabIndex = 12;
            // 
            // VerContra
            // 
            this.VerContra.BackColor = System.Drawing.Color.DarkGray;
            this.VerContra.Image = ((System.Drawing.Image)(resources.GetObject("VerContra.Image")));
            this.VerContra.Location = new System.Drawing.Point(196, 180);
            this.VerContra.Name = "VerContra";
            this.VerContra.Size = new System.Drawing.Size(20, 20);
            this.VerContra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VerContra.TabIndex = 19;
            this.VerContra.TabStop = false;
            this.VerContra.Click += new System.EventHandler(this.VerContra_Click);
            this.VerContra.MouseEnter += new System.EventHandler(this.VerContra_MouseEnter);
            this.VerContra.MouseLeave += new System.EventHandler(this.VerContra_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(53, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 47);
            this.label7.TabIndex = 18;
            this.label7.Text = "Log in";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel8.Location = new System.Drawing.Point(6, 93);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(220, 2);
            this.panel8.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, -16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(695, 444);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox VerContra;
    }
}