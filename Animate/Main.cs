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

        public void setID(string ID) {
            label1.Text = ID; 
        }

        public int m, mx, my;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void Txt_Reserva_Click(object sender, EventArgs e)
        {
            Reservas FrmReserva = new Reservas();
            FrmReserva.TopLevel = false;
            MainPanel.Controls.Add(FrmReserva);
            FrmReserva.Dock = DockStyle.Fill;
            FrmReserva.Show();
        }

        private void BtnFactura_Click(object sender, EventArgs e)
        {
            Factura FrmFactura = new Factura();
            FrmFactura.TopLevel = false;
            MainPanel.Controls.Add(FrmFactura);
            FrmFactura.Dock = DockStyle.Fill;
            FrmFactura.Show();
        }

        private void Btn_Clientes_Click(object sender, EventArgs e)
        {
            Clientes FrmClientes = new Clientes();
            FrmClientes.TopLevel = false;
            FrmClientes.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(FrmClientes);
            FrmClientes.Show();
        }

        private void Btn_Disfraz_Click(object sender, EventArgs e)
        {
            Disfraces FrmDisfras = new Disfraces();
            FrmDisfras.TopLevel = false;
            FrmDisfras.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(FrmDisfras);
            FrmDisfras.Show();
        }

        private void Txt_Animador_Click(object sender, EventArgs e)
        {
            Animadores FrmAnimador = new Animadores();
            FrmAnimador.TopLevel = false;
            FrmAnimador.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(FrmAnimador);
            FrmAnimador.Show();
        }

        private void Txt_Presentador_Click(object sender, EventArgs e)
        {
            Presentadores FrmPresentadores = new Presentadores();
            FrmPresentadores.TopLevel = false;
            FrmPresentadores.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(FrmPresentadores);
            FrmPresentadores.Show();
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
