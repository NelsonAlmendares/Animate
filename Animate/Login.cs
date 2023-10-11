using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Controller;

namespace Animate
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void Test_Connection_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con = Controller_Conecction.ConnectModel();

            if (con != null) {
                MessageBox.Show("Conectado", "Conexión Establecida", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
            } else {
                MessageBox.Show("Algo salió mal", "Sin conexión F", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void user(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar <= 91 && e.KeyChar >= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255)) {
                MessageBox.Show("Se detéctaron caáretes no válidos \n Los carácteres especiales no son permitidos", "CARÁCTERES NO VÁLIDOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (Txt_user.Text == "" && Txt_password.Text == "") {
                MessageBox.Show("Llene todos los campos del sistema!", "Todos los campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (Txt_user.Text == "") {
                MessageBox.Show("El campo de Usuario debe estar lleno!", "Campos deben estar llenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (Txt_password.Text == "") {
                MessageBox.Show("El campo de contraseña debe estar lleno!", "Campos deben estar llenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                ConnectLogin();
            }
        }

        void ConnectLogin() {
            Login_Controller IniciarSesion = new Login_Controller();

            string user = Txt_user.Text;
            string pwd = Txt_password.Text;

            bool response = IniciarSesion.VerifyData(user, pwd);
            Main dashboard = new Main();

            if (response == true)
            {
                MessageBox.Show("Acceso conseguido! Bienvenido al sistema.", "LOGIN COMPROBADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                dashboard.Show();
                CleanData();

                // Asigno el nombre 
                string usuario = IniciarSesion.getUser(user);
                dashboard.setUserLabel(usuario);
            }
            else
            {
                MessageBox.Show("Credenciales no válidas, vuelva a intentarlo.", "LOGIN FALLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CleanData()
        {
            Txt_password.Clear();
            Txt_user.Clear();
        }

    }
}
