using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
    public class Controller_Disfras
    {
        public Controller_Disfras() { }
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public int AddData()
        {
            return Model_Disfras.InsertData(Tipo, Descripcion, Precio);
        }

        public DataTable LoadGrid() 
        {
            return Model_Disfras.LoadDataGrid();
        }
    }
}
