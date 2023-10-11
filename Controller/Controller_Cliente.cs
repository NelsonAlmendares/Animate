using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Controller
{
    public class Controller_Cliente
    {
        public Controller_Cliente() { }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string password { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public int AddData() {
            return Model_Cliente.InsertData(Nombre, Apellido, Usuario, password, Documento, Telefono, Correo);
        }
        public DataTable ShowData() {
            return Model_Cliente.ShowDataGrid();
        }
    }
}
