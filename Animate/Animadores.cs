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
    public partial class Animadores : Form
    {
        public Animadores()
        {
            InitializeComponent();
        }

        private void Animadores_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        void LoadGrid() 
        {
            Controller_Animador AddData = new Controller_Animador();
            dataGridCliente.DataSource = AddData.LoadGrid();
        }

        void AddData() 
        {
            Controller_Animador AddData = new Controller_Animador();
            AddData.Nombre = TxtNombre.Text;
            AddData.Apellido = Txt_Apellido.Text;
            AddData.Documento = Txt_Documento.Text;
            int response = AddData.InsertData();
            if (response >= 1)
            {
                MessageBox.Show("Animador fue agregado correctamente", "SOLICITUD APROBADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Animador no pudo ser agregado", "SOLICITUD DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            AddData();
            LoadGrid();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
