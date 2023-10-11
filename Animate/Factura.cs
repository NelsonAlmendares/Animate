using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace Animate
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void ShowServicios() 
        {
            CmbServicios.DataSource = DataController.LoadServicio();
            CmbServicios.DisplayMember = ("tipo_servicio");
            CmbServicios.ValueMember = ("id_servicios");
        }

        void ShowReservas() 
        {
            CmbReserva.DataSource = DataController.LoadReservas();
            CmbReserva.DisplayMember = ("Cliente");
            CmbReserva.ValueMember = ("id_reserva");
        }
        void ShowPrices(int ID) 
        {
            Controller_Factura item = new Controller_Factura();
            string ItemSelected = item.ShowPriceServices(ID);
            LblPrecio.Text = ItemSelected;
        }

        void LoadGrid() 
        {
            Controller_Factura item = new Controller_Factura();
            dataGridView.DataSource = item.ShowGrid();
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            ShowServicios();
            ShowReservas();
            LoadGrid();
            Btn_FacturaFinal.Enabled = false;
        }

        private void CmbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object Element = CmbServicios.SelectedValue;
            int SelectValue;
            if (int.TryParse(Element.ToString(), out SelectValue))
            {
                ShowPrices(SelectValue);
            }
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Posicion;
            Posicion = this.dataGridView.CurrentRow.Index;

            Txt_ID.Text = this.dataGridView[0, Posicion].Value.ToString();
            Btn_FacturaFinal.Enabled = true;
            
        }

        private void Btn_FacturaFinal_Click(object sender, EventArgs e)
        {

        }
    }
}
