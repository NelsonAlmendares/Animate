using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animate
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Dejo el método para hacer que el label de usuario contenga el nombre del usuario que se loguea
        public void setUserLabel(string usuario) {
            user.Text = usuario;
        }

        public int m, mx, my;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1) {
                this.SetDesktopLocation(MousePosition.X -mx, MousePosition.Y - my);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
