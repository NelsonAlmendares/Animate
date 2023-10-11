using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Disfras
    {
        public static int InsertData(string tipo, string descripccion, double precio)
        {
            int retorno;
            try
            {
                SqlCommand RunInsertQuery = new SqlCommand(string.Format("INSERT INTO [dbo].[Disfraz] (tipo_disfraz, descripcion, precio_alquiler) VALUES ('{0}', '{1}', '{2}');", tipo, descripccion, precio), Model_Concection.Conectar());
                retorno = Convert.ToInt32(RunInsertQuery.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error at:" + Ex);
                return 0;
            }
        }
        public static DataTable LoadDataGrid() 
        {
            DataTable Data;
            try
            {
                string RunLoadQuery = "SELECT id_disfraz, tipo_disfraz, descripcion, precio_alquiler FROM [dbo].[Disfraz];";
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
