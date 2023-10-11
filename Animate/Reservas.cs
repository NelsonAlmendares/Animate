using System;
using System.Windows.Forms;
using Controller;

namespace Animate
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }

        void LoadEventos() {
            CmbEvento.DataSource = DataController.LoadEvento();
            CmbEvento.DisplayMember = ("nombre_Evento");
            CmbEvento.ValueMember = ("id_codigo");
        }
        void LoadDisfraz()
        {
            CmbDisfraz.DataSource = DataController.LoadDisfraz();
            CmbDisfraz.DisplayMember = ("tipo_disfraz");
            CmbDisfraz.ValueMember = ("id_disfraz");
        }

        void LoadHorario()
        {
            CmbHorario.DataSource = DataController.LoadHorario();
            CmbHorario.DisplayMember = ("Horario: ");
            CmbHorario.ValueMember = ("id_horario");
        }
        void LoadAnimador()
        {
            CmbAnimdor.DataSource = DataController.LoadAnimador();
            CmbAnimdor.DisplayMember = ("Animador");
            CmbAnimdor.ValueMember = ("id_animador");
        }
        void LoadClientes() 
        {
            CmbCliente.DataSource = DataController.LoadCliente();
            CmbCliente.DisplayMember = ("Nombre");
            CmbCliente.ValueMember = ("id_Cliente");
        }
        void LoadEstado()
        {
            CmbEstado.DataSource = DataController.LoadEstados();
            CmbEstado.DisplayMember = ("estado_reserva");
            CmbEstado.ValueMember = ("id_estadoReserva");
        }
        void ShowDatos() 
        {
            Controller_Reserva Load = new Controller_Reserva();
            dataGridView.DataSource = Load.LoadGrid();
        }
        void ShowDetailsItem(int ID)
        {
            Controller_Reserva item = new Controller_Reserva();
            string ItemSelected = item.ShowDetails(ID);
            LblDescripcion.Text = ItemSelected;
        }

        void ShowPrices(int ID)
        {
            Controller_Reserva item = new Controller_Reserva();
            string SelectItem = item.ShowPrice(ID);
            LblPrecio.Text = SelectItem;
        }

        Controller_Reserva AddData = new Controller_Reserva();
        void InsertData () {
            DateTime fecha = dateTimePicker.Value;
            string DateFormat = fecha.ToString("yyyy-MM-dd");
            AddData.Evento = Convert.ToInt32(CmbEvento.SelectedValue);
            AddData.Cliente = Convert.ToInt32(CmbCliente.SelectedValue);
            AddData.Horario = Convert.ToInt32(CmbHorario.SelectedValue);
            AddData.Animador = Convert.ToInt32(CmbAnimdor.SelectedValue);
            AddData.Disfraz = Convert.ToInt32(CmbDisfraz.SelectedValue);
            AddData.Fecha = DateFormat;
            AddData.EstadoReserva = Convert.ToInt32(CmbEstado.SelectedValue);            

            int response = AddData.InsertReserva();
            if (response >= 1)
            {
                MessageBox.Show("Reserva agregada correctamente", "SOLICITUD APROBADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reserva no pude ser registrada correctamente", "SOLICITUD DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            InsertData();
            ShowDatos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object Element = CmbEvento.SelectedValue;
            int SelectValue;
            if (int.TryParse(Element.ToString(), out SelectValue))
            {
                ShowDetailsItem(SelectValue);
                ShowPrices(SelectValue);
            }
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            LoadEventos();
            LoadDisfraz();
            LoadHorario();
            LoadAnimador();
            LoadClientes();
            LoadEstado();
            ShowDatos();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
