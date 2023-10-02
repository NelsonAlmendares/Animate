
namespace Animate
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_singup = new System.Windows.Forms.Button();
            this.Txt_user = new Guna.UI.WinForms.GunaLineTextBox();
            this.Txt_password = new Guna.UI.WinForms.GunaLineTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Test_Connection = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.Test_Connection);
            this.panel2.Controls.Add(this.btn_minimize);
            this.panel2.Controls.Add(this.btn_exit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 43);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_singup);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1047, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 778);
            this.panel3.TabIndex = 1;
            // 
            // btn_singup
            // 
            this.btn_singup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(44)))));
            this.btn_singup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_singup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_singup.FlatAppearance.BorderSize = 0;
            this.btn_singup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_singup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_singup.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_singup.Location = new System.Drawing.Point(88, 611);
            this.btn_singup.Name = "btn_singup";
            this.btn_singup.Size = new System.Drawing.Size(235, 52);
            this.btn_singup.TabIndex = 9;
            this.btn_singup.Text = "Sing Up!";
            this.btn_singup.UseVisualStyleBackColor = false;
            // 
            // Txt_user
            // 
            this.Txt_user.BackColor = System.Drawing.Color.White;
            this.Txt_user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_user.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(78)))), ((int)(((byte)(99)))));
            this.Txt_user.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_user.LineColor = System.Drawing.Color.Gainsboro;
            this.Txt_user.Location = new System.Drawing.Point(279, 321);
            this.Txt_user.Name = "Txt_user";
            this.Txt_user.PasswordChar = '\0';
            this.Txt_user.SelectedText = "";
            this.Txt_user.Size = new System.Drawing.Size(445, 42);
            this.Txt_user.TabIndex = 3;
            this.Txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user);
            // 
            // Txt_password
            // 
            this.Txt_password.BackColor = System.Drawing.Color.White;
            this.Txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_password.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(78)))), ((int)(((byte)(99)))));
            this.Txt_password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_password.LineColor = System.Drawing.Color.Gainsboro;
            this.Txt_password.Location = new System.Drawing.Point(279, 438);
            this.Txt_password.Name = "Txt_password";
            this.Txt_password.PasswordChar = '●';
            this.Txt_password.SelectedText = "";
            this.Txt_password.Size = new System.Drawing.Size(445, 42);
            this.Txt_password.TabIndex = 4;
            this.Txt_password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(276, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label3.Location = new System.Drawing.Point(276, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(78)))), ((int)(((byte)(99)))));
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_login.Location = new System.Drawing.Point(385, 596);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(235, 52);
            this.btn_login.TabIndex = 8;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(313, 706);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Forgot your password?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(41)))), ((int)(((byte)(67)))));
            this.linkLabel1.Location = new System.Drawing.Point(518, 706);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 24);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here to change!";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Animate.Properties.Resources.pwd;
            this.pictureBox4.Location = new System.Drawing.Point(369, 388);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 39);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Animate.Properties.Resources.user;
            this.pictureBox3.Location = new System.Drawing.Point(321, 259);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Animate.Properties.Resources.Welcome;
            this.pictureBox2.Location = new System.Drawing.Point(345, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(361, 124);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Animate.Properties.Resources.Captura_de_pantalla_2023_09_20_135812;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 778);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Test_Connection
            // 
            this.Test_Connection.BackColor = System.Drawing.Color.White;
            this.Test_Connection.BackgroundImage = global::Animate.Properties.Resources.wifi;
            this.Test_Connection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Test_Connection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Test_Connection.FlatAppearance.BorderSize = 0;
            this.Test_Connection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Test_Connection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Test_Connection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_Connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Test_Connection.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Test_Connection.Location = new System.Drawing.Point(1006, 3);
            this.Test_Connection.Name = "Test_Connection";
            this.Test_Connection.Size = new System.Drawing.Size(35, 37);
            this.Test_Connection.TabIndex = 15;
            this.Test_Connection.UseVisualStyleBackColor = false;
            this.Test_Connection.Click += new System.EventHandler(this.Test_Connection_Click_1);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(167)))), ((int)(((byte)(173)))));
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(204)))), ((int)(((byte)(209)))));
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Image = global::Animate.Properties.Resources.minimizar_signo;
            this.btn_minimize.Location = new System.Drawing.Point(38, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(40, 43);
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(11)))), ((int)(((byte)(23)))));
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(96)))), ((int)(((byte)(108)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Image = global::Animate.Properties.Resources.cerrar;
            this.btn_exit.Location = new System.Drawing.Point(0, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(38, 43);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1431, 778);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_password);
            this.Controls.Add(this.Txt_user);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaLineTextBox Txt_user;
        private Guna.UI.WinForms.GunaLineTextBox Txt_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_singup;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button Test_Connection;
    }
}

