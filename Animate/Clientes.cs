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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        void ShowGrid() 
        {
            Controller_Cliente Load = new Controller_Cliente();
            dataGridCliente.DataSource = Load.ShowData();
        }

        void CleanData() 
        {
            TxtNombre.ResetText();
            TxtApellido.ResetText();
            TxtUsuario.ResetText();
            TxtPassword.ResetText();
            TxtDocumento.ResetText();
            TxtTelefono.ResetText();
            TxtCorreo.ResetText();
        }

        void AddData() 
        {
            Controller_Cliente AddData = new Controller_Cliente();
            AddData.Nombre = TxtNombre.Text;
            AddData.Apellido = TxtApellido.Text;
            AddData.Usuario = TxtUsuario.Text;
            AddData.password = TxtPassword.Text;
            AddData.Documento = TxtDocumento.Text;
            AddData.Telefono = TxtTelefono.Text;
            AddData.Correo = TxtCorreo.Text;
            int response = AddData.AddData();
            if (response <= 1)
            {
                MessageBox.Show("Cliente fue agregado correctamente", "SOLICITUD APROBADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowGrid();
            }
            else 
            {
                MessageBox.Show("Cliente no pudo ser agregado", "SOLICITUD DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            AddData();
            ShowGrid();
            CleanData();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ShowGrid();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
