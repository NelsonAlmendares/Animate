using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace Controller
{
    public class Controller_Reserva
    {
        // Constructor de la clase 
        public Controller_Reserva() { }

        // Instancias de métodos para las varibles que retorna la vista
        public int ID { get; set; }
        public int Evento { get; set; }
        public int Cliente { get; set; }
        public int Horario { get; set; }
        public int Animador { get; set; }
        public int Disfraz { get; set; }
        public string Fecha { get; set; }
        public int EstadoReserva { get; set; }

        // Métodos
        public int InsertReserva () {
            return Model_Reserva.AddReservas(Evento, Cliente, Horario, Animador, Disfraz, Fecha, EstadoReserva);
        }
        public string ShowDetails(int Evento) {
            return Model_Reserva.ShowDetail(Evento);
        }
        public string ShowPrice(int Evento) {
            return Model_Reserva.ShowPrices(Evento);
        }
        public DataTable LoadGrid () {
            return Model_Reserva.LoadData();
        }
    }
}
