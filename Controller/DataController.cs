using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Controller
{
    public class DataController
    {
        public static DataTable LoadEvento() 
        {
            return DataModel.LoadEvento();
        }
        public static DataTable LoadDisfraz ()
        {
            return DataModel.LoadDisfraz();
        }
        public static DataTable LoadHorario()
        {
            return DataModel.LoadHorario();
        }
        public static DataTable LoadAnimador ()
        {
            return DataModel.LoadAnimador();
        }
        public static DataTable LoadCliente() 
        {
            return DataModel.LoadCliente();
        }
        public static DataTable LoadEstados() 
        {
            return DataModel.LoadEstado();
        }
        public static DataTable LoadServicio() 
        {
            return DataModel.LoadServicio();
        }
        public static DataTable LoadReservas() 
        {
            return DataModel.LoadReserva();
        }
    }
}
