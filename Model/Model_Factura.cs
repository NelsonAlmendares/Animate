using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    public class Model_Factura
    {
        public static string ShowPrices(int id_Servicio)
        {
            string precio = null;
            try
            {

                string RunDetailsQuery = "SELECT CONCAT('$ ', precio_servicio) AS precio_servicio FROM [dbo].[Servicios] WHERE id_servicios = @id;";
                SqlCommand RunQuery = new SqlCommand(string.Format(RunDetailsQuery), Model_Concection.Conectar());
                RunQuery.Parameters.AddWithValue("@id", id_Servicio);
                SqlDataReader reader = RunQuery.ExecuteReader();
                if (reader.Read())
                {
                    precio = reader["precio_servicio"].ToString();
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

        public static DataTable LoadGrid() 
        {
            DataTable Data;
            try
            {
                string SelectQuery = "SELECT Fact.codigo_Factura, direccion_evento AS Dirección, fecha_reserva AS Fecha, CONCAT(nombre_Cliente, ' ', apellido_Cliente) AS Cliente, SUM(precio_servicio) + costo_Base AS Total FROM[dbo].[Factura] AS Fact INNER JOIN[dbo].[Reservas] ON[dbo].[Reservas].id_reserva = Fact.id_reserva INNER JOIN[dbo].[Clientes] ON[dbo].[Reservas].id_cliente = [dbo].[Clientes].id_Cliente INNER JOIN[dbo].[DetalleFactura] ON[dbo].[DetalleFactura].codigo_Factura = Fact.codigo_Factura INNER JOIN[dbo].[Servicios] ON[dbo].[DetalleFactura].id_servicios = [dbo].[Servicios].id_servicios INNER JOIN[dbo].[Evento] ON[dbo].[Evento].id_codigo = [dbo].[Reservas].id_evento GROUP BY Fact.codigo_Factura, direccion_evento, fecha_reserva, nombre_Cliente, apellido_Cliente, precio_servicio, costo_Base";
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

        /* public static int InsertData(int Servicio, int Reserva, string Direccion) 
        {
            int retorno;
            try
            {
                SqlCommand RunInsertQuery = new SqlCommand(string.Format("INSERT INTO [dbo][]"), Model_Concection.Conectar());
                return retorno;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return 0;
            }
        } */
    }
}
