using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Animadores
    {
        public static int AddAnimadores(string nombre, string apellido, string documento)
        {
            int retorno;
            try
            {
                SqlCommand RunInsertQuery = new SqlCommand(string.Format("INSERT INTO [dbo].[Animador] (nombre_animador, apellido_animador, documento_animador) VALUES ('{0}', '{1}', '{2}');", nombre, apellido, documento), Model_Concection.Conectar());
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

        public static DataTable LoadDataGrid()
        {
            DataTable Data;
            try
            {
                string SelectQuery = "SELECT nombre_animador, apellido_animador, documento_animador FROM [dbo].[Animador];";
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
