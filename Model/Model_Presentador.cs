using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Presentador
    {
        public static int AddPresentador(string nombre, string apellido, string documento, int evento)
        {
            int retorno;
            try
            {
                SqlCommand RunInsertQuery = new SqlCommand(string.Format("INSERT INTO [dbo].[Presentador] (nombre_presentador, apellido_presentador, documento_presentador, id_evento) VALUES ('{0}', '{1}', '{2}', '{3}');", nombre, apellido, documento, evento), Model_Concection.Conectar());
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

        public static DataTable LoadData()
        {
            DataTable Data;
            try
            {
                string SelectQuery = "SELECT nombre_presentador, apellido_presentador, documento_presentador, id_evento FROM [dbo].[Presentador];";
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
