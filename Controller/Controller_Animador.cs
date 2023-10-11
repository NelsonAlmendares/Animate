using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace Controller
{
    public class Controller_Animador
    {
        public Controller_Animador() { }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }

        public int InsertData() 
        {
            return Model_Animadores.AddAnimadores(Nombre, Apellido, Documento);
        }
        public DataTable LoadGrid() 
        {
            return Model_Animadores.LoadDataGrid();
        }
}
}
