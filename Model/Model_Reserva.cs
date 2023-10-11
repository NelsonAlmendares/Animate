using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Reserva
    {
        public static int AddReservas (int Evento, int Client, int Horario, int Animador, int Disfraz, string Fecha, int Estado) 
        {
            int retorno;
            try
            {
                SqlCommand RunInsertQuery = new SqlCommand(string.Format("EXEC ValidateReservas @evento = '{0}', @cliente = '{1}'  , @horario = '{2}',  @animador = '{3}', @disfraz = '{4}', @fecha = '{5}', @estado = '{6}' ;",  + 
                    Evento, Client, Horario, Animador, Disfraz, Fecha, Estado), Model_Concection.Conectar());
                retorno = Convert.ToInt32(RunInsertQuery.ExecuteNonQuery());
                return retorno;
            }
            catch (SqlException SqlEx) 
            {
                Console.WriteLine("Sql Error at: " + SqlEx);
                return 0;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Sql Error at: " + Ex);
                return 0;
            }
        }

        public static string ShowDetail (int id_Evento)
        {
            string detalles = null;
            try
            {
                
                string RunDetailsQuery = "SELECT nombre_Evento AS Evento, descripcion_Evento AS Desctipción  FROM [dbo].[Evento] WHERE id_codigo = @id;";
                SqlCommand RunQuery = new SqlCommand(string.Format(RunDetailsQuery), Model_Concection.Conectar());
                RunQuery.Parameters.AddWithValue("@id", id_Evento);
                SqlDataReader reader = RunQuery.ExecuteReader();
                if (reader.Read())
                {
                    detalles = reader["Desctipción"].ToString();
                }
                reader.Close();
                Model_Concection.Conectar().Close();
                return detalles;
            }
            catch (SqlException ErrorSql)
            {
                Console.WriteLine("Error at: " + ErrorSql);
                return null;
            }
            catch (Exception ErrorNormal)
            {
                Console.WriteLine("Error at: " + ErrorNormal);
                return null;
            }
        }

        public static string ShowPrices(int id_Evento)
        {
            string precio = null;
            try
            {
                string RunDetailsQuery = "SELECT CONCAT('$ ', costo_Base) AS Costo FROM [dbo].[Evento] WHERE id_codigo = @id;";
                SqlCommand RunQuery = new SqlCommand(string.Format(RunDetailsQuery), Model_Concection.Conectar());
                RunQuery.Parameters.AddWithValue("@id", id_Evento);
                SqlDataReader reader = RunQuery.ExecuteReader();
                if (reader.Read())
                {
                    precio = reader["Costo"].ToString();
                }
                reader.Close();
                Model_Concection.Conectar().Close();
                return precio;
            }
            catch (SqlException ErrorSql)
            {
                Console.WriteLine("Error at: " + ErrorSql);
                return null;
            }
            catch (Exception ErrorNormal)
            {
                Console.WriteLine("Error at: " + ErrorNormal);
                return null;
            }
        }
        public static DataTable LoadData() 
        {
            DataTable Data;
            try
            {
                string SelectQuery = "SELECT [dbo].[Reservas].id_reserva AS 'Reserva N°', nombre_Evento AS Evento, CONCAT (nombre_Cliente, ' ', apellido_Cliente) AS Cliente, documento_Cliente  AS DUI, CONCAT ( CONVERT(VARCHAR, hora_inicio, 108), ' ', CASE WHEN DATEPART(HOUR, hora_inicio) >= 12 THEN ' PM ' ELSE ' AM' END , ' - ', CONVERT(VARCHAR, hora_fin, 108), CASE WHEN DATEPART(HOUR, hora_fin) >= 12 THEN ' PM ' ELSE ' AM' END) AS 'Horario: ', estado_reserva AS Estado, fecha_reserva AS Fecha FROM[dbo].[Reservas] INNER JOIN[dbo].[Evento] ON[dbo].[Evento].id_codigo = [dbo].[Reservas].id_evento INNER JOIN[dbo].[Clientes] ON[dbo].[Reservas].id_cliente = [dbo].[Clientes].id_Cliente INNER JOIN[dbo].[Horarios] ON[dbo].[Horarios].id_horario = [dbo].[Reservas].id_horario INNER JOIN[dbo].[EstadoReserva] ON[dbo].[EstadoReserva].id_estadoReserva = [dbo].[Reservas].id_estadoReservar; ";
                SqlCommand TblSelect = new SqlCommand(SelectQuery, Model_Concection.Conectar());
                SqlDataAdapter ADP = new SqlDataAdapter(TblSelect);
                Data = new DataTable();
                ADP.Fill(Data);
                return Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at: " + ex);
                return null;
            }
        }
    }
}
