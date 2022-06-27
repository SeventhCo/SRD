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
            this.lblGmail = new System.Windows.Forms.Label();
            this.txtGmail = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblforPass = new System.Windows.Forms.Label();
            this.lblCrearCuenta = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.VerContra = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.pnlLogin.SuspendLayout();
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
            // lblGmail
            // 
            this.lblGmail.AutoSize = true;
            this.lblGmail.BackColor = System.Drawing.Color.Transparent;
            this.lblGmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmail.ForeColor = System.Drawing.Color.Black;
            this.lblGmail.Location = new System.Drawing.Point(14, 107);
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Size = new System.Drawing.Size(38, 15);
            this.lblGmail.TabIndex = 1;
            this.lblGmail.Text = "Gmail";
            // 
            // txtGmail
            // 
            this.txtGmail.BackColor = System.Drawing.Color.DarkGray;
            this.txtGmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGmail.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtGmail.ForeColor = System.Drawing.Color.Black;
            this.txtGmail.Location = new System.Drawing.Point(16, 127);
            this.txtGmail.Name = "txtGmail";
            this.txtGmail.Size = new System.Drawing.Size(200, 20);
            this.txtGmail.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(16, 145);
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
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.DarkGray;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(16, 180);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(180, 20);
            this.txtPass.TabIndex = 5;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(14, 160);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 15);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Contraseña";
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
            // lblforPass
            // 
            this.lblforPass.AutoSize = true;
            this.lblforPass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblforPass.Location = new System.Drawing.Point(13, 295);
            this.lblforPass.Name = "lblforPass";
            this.lblforPass.Size = new System.Drawing.Size(115, 13);
            this.lblforPass.TabIndex = 9;
            this.lblforPass.Text = "Olvide mi contraseña";
            // 
            // lblCrearCuenta
            // 
            this.lblCrearCuenta.AutoSize = true;
            this.lblCrearCuenta.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lblCrearCuenta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrearCuenta.Location = new System.Drawing.Point(144, 295);
            this.lblCrearCuenta.Name = "lblCrearCuenta";
            this.lblCrearCuenta.Size = new System.Drawing.Size(72, 13);
            this.lblCrearCuenta.TabIndex = 10;
            this.lblCrearCuenta.Text = "Crear cuenta";
            this.lblCrearCuenta.UseWaitCursor = true;
            this.lblCrearCuenta.Click += new System.EventHandler(this.label4_Click);
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
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Silver;
            this.pnlLogin.Controls.Add(this.panel2);
            this.pnlLogin.Controls.Add(this.VerContra);
            this.pnlLogin.Controls.Add(this.label7);
            this.pnlLogin.Controls.Add(this.panel8);
            this.pnlLogin.Controls.Add(this.panel1);
            this.pnlLogin.Controls.Add(this.lblCrearCuenta);
            this.pnlLogin.Controls.Add(this.lblGmail);
            this.pnlLogin.Controls.Add(this.lblforPass);
            this.pnlLogin.Controls.Add(this.txtGmail);
            this.pnlLogin.Controls.Add(this.panel3);
            this.pnlLogin.Controls.Add(this.lblPass);
            this.pnlLogin.Controls.Add(this.txtPass);
            this.pnlLogin.Location = new System.Drawing.Point(232, 54);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(231, 325);
            this.pnlLogin.TabIndex = 12;
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
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblGmail;
        private System.Windows.Forms.TextBox txtGmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblforPass;
        private System.Windows.Forms.Label lblCrearCuenta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox VerContra;
    }
}