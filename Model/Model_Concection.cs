using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{
    public class Model_Concection {
        public static SqlConnection Conectar() { 
            SqlConnection connect;

            try
            {
                string server, database, uid, pwd;
                server = "DESKTOP-SUBCSB2";
                database = "Animate";
                uid = "NelsonAlmendares";
                pwd = "admin";

                string ConnectionSql = "Data Source=" + server + ";" + "Initial Catalog=" + database + ";" + "User ID=" + uid + ";" + "Password=" + pwd + ";";
                connect = new SqlConnection(ConnectionSql);
                connect.Open();
                return connect;
            }
            catch (Exception)
            {
                return connect = null;
            }
        }
    }
}
