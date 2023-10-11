using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Controller
{
    public class Controller_Presentador
    {
        public Controller_Presentador() { }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public int Evento { get; set; }

        public int InsertData() 
        {
            return Model_Presentador.AddPresentador(Nombre, Apellido, Documento, Evento);
        }

        public DataTable LoadData() 
        {
            return Model_Presentador.LoadData();
        }
    }
}
