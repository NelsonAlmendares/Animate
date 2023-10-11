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
    public partial class Presentadores : Form
    {
        public Presentadores()
        {
            InitializeComponent();
        }

        private void Prresentadores_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadEventos();
        }

        void LoadGrid()
        {
            comboBox.DataSource = DataController.LoadEvento();
            comboBox.DisplayMember = ("nombre_Evento");
            comboBox.ValueMember = ("id_codigo" );
        }

        void CleanData() 
        {
            TxtNombre.ResetText();
            Txt_Apellido.ResetText();
            Txt_Documento.ResetText();
        }

        void LoadEventos() 
        {
            Controller_Presentador LoadGrid = new Controller_Presentador();
            dataGridCliente.DataSource = LoadGrid.LoadData();
        }
        void InsertData() 
        {
            Controller_Presentador LoadEvento = new Controller_Presentador();
            LoadEvento.Nombre = TxtNombre.Text;
            LoadEvento.Apellido = Txt_Apellido.Text;
            LoadEvento.Documento = Txt_Documento.Text;
            LoadEvento.Evento = Convert.ToInt32(comboBox.SelectedValue);
            int retorno = LoadEvento.InsertData();
            if (retorno >= 1)
            {
                MessageBox.Show("Presentador fue agregado correctamente", "SOLICITUD APROBADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Animador no pudo ser Agregado", "SOLICITUD DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            CleanData();
            LoadEventos();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
