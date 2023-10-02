using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{
    public class LoginModel
    {
        public static bool IniciarSesion (string user, string password) 
        {
            bool resultado = false;
            try 
            {
                // Cadena para ver los datos de Sql Server
                string query = "SELECT usuario_Cliente, password_Cliente FROM [dbo].[Clientes] WHERE usuario_Cliente = @user AND password_Cliente = @password;";
                // Agregamos parámetros a la consulta de SQL
                SqlConnection connect = Model_Concection.Conectar();
                SqlCommand runQuery = new SqlCommand(query, Model_Concection.Conectar());
                
                runQuery.Parameters.AddWithValue("@user", user);
                runQuery.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = runQuery.ExecuteReader();
                if (reader.Read()) 
                {
                    resultado = true;
                }
                connect.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EROOR: " + ex);
                return resultado = false;
            }
        }

        public static string GetUser (string usuario) {
            string user = null;
            try
            {
                string query = "SELECT CONCAT(nombre_Cliente, ' ', apellido_Cliente) AS Cliente FROM [dbo].[Clientes] WHERE usuario_Cliente = @usuario;";
                // Agregamos parámetros a la consulta de SQL
                SqlConnection connect = Model_Concection.Conectar();
                SqlCommand runQuery = new SqlCommand(query, Model_Concection.Conectar());

                runQuery.Parameters.AddWithValue("@usuario", usuario);
                SqlDataReader reader = runQuery.ExecuteReader();
                if (reader.Read())
                {
                    user = reader["Cliente"].ToString();
                }
                connect.Close();
                return user;
            }
            catch (Exception ex)
            {
                return user = null;
                Console.WriteLine("ERROR: " + ex);
            }
        }
    }
}
