using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Controller
{
    public class Controller_Factura
    {
        public Controller_Factura() { }
        public int ID { get; set; }
        public int Servicio { get; set; }
        public int Reserva { get; set; }
        public string Direccion { get; set; }

        public string ShowPriceServices(int Servicio) 
        {
            return Model_Factura.ShowPrices(Servicio);
        }
        public DataTable ShowGrid() 
        {
            return Model_Factura.LoadGrid();
        }
    }
}
