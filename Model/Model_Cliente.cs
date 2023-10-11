using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Cliente
    {
        public static int InsertData (string nombre, string apellido, string usuario, string password, string documento, string telefono, string correo)
        {
            int retorno;
            try
            {
                SqlCommand RunInsetQuery = new SqlCommand(string.Format("INSERT INTO [dbo].[Clientes] (nombre_Cliente, apellido_Cliente, usuario_Cliente, password_Cliente, documento_Cliente, telefono_Cliente, correo_Cliente) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", nombre, apellido, usuario, password, documento, telefono, correo), Model_Concection.Conectar());
                retorno = Convert.ToInt32(RunInsetQuery.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at:" + Ex);
                return 0;
            }
        }
        public static DataTable ShowDataGrid() 
        {
            DataTable Data;
            try
            {
                string RunLoadQuery = "SELECT nombre_Cliente AS Nombre, apellido_Cliente AS Apellido, usuario_Cliente AS Usuario, documento_Cliente AS DUI, telefono_Cliente AS Teléfono, correo_Cliente AS Correo FROM [dbo].[Clientes];";
                SqlCommand RunQuery = new SqlCommand(RunLoadQuery, Model_Concection.Conectar());
                SqlDataAdapter ADP = new SqlDataAdapter(RunQuery);
                Data = new DataTable();
                ADP.Fill(Data);
                return Data;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at: " + Ex);
                return null;
            }
        }
    }
}
