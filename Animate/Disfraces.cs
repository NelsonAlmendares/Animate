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
    public partial class Disfraces : Form
    {
        public Disfraces()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            Controller_Disfras Load = new Controller_Disfras();
            dataGridView1.DataSource = Load.LoadGrid();
        }
        void InsertData()
        {
            Controller_Disfras AddData = new Controller_Disfras();
            AddData.Tipo = TxtNombre.Text;
            AddData.Descripcion = Txt_Descrripcion.Text;
            AddData.Precio = Convert.ToDouble(Txt_Precio.Text);
            int response = AddData.AddData();
            if (response >= 1)
            {
                MessageBox.Show("Disfraz fue agregado correctamente", "SOLICITUD APROBADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Disfraz no pudo ser agregado", "SOLICITUD DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CleanData ()
        {
            TxtNombre.ResetText();
            Txt_Descrripcion.ResetText();
            Txt_Precio.ResetText();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            InsertData();
            LoadData();
            CleanData();
        }

        private void Disfraces_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
