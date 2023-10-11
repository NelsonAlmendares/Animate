using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class DataModel
    {
        public static DataTable LoadEvento () 
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT * FROM [dbo].[Evento]";
                SqlCommand CmbSelectEvento = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectEvento);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx) 
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadDisfraz()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT * FROM [dbo].[Disfraz]";
                SqlCommand CmbSelectDisfraz = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectDisfraz);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadHorario()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT * FROM Horario";
                SqlCommand CmbSelectHorarios = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectHorarios);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadAnimador()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT id_animador, CONCAT(nombre_animador, ' ' ,apellido_animador) AS Animador FROM [dbo].[Animador];";
                SqlCommand CmbSelectAnimador = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectAnimador);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadCliente()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT id_Cliente, CONCAT (nombre_Cliente, ' ' , apellido_Cliente) AS Nombre FROM [dbo].[Clientes];";
                SqlCommand CmbSelectAnimador = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectAnimador);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadEstado()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT id_estadoReserva, estado_reserva FROM [dbo].[EstadoReserva];";
                SqlCommand CmbSelectAnimador = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectAnimador);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadServicio ()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT id_servicios, tipo_servicio FROM [dbo].[Servicios];";
                SqlCommand CmbSelectAnimador = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectAnimador);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }

        public static DataTable LoadReserva()
        {
            DataTable Data;
            try
            {
                string RunEventQuery = "SELECT id_reserva, CONCAT ('#',id_reserva, '. ',nombre_Cliente, ' ', apellido_Cliente) AS Cliente FROM[dbo].[Reservas] AS Re INNER JOIN[dbo].[Clientes] ON[dbo].[Clientes].id_Cliente = Re.id_cliente; ";
                SqlCommand CmbSelectAnimador = new SqlCommand(string.Format(RunEventQuery), Model_Concection.Conectar());
                SqlDataAdapter APD = new SqlDataAdapter(CmbSelectAnimador);
                Data = new DataTable();
                APD.Fill(Data);
                return Data;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return null;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }
    }
}
