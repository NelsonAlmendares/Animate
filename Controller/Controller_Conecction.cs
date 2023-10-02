using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace Controller
{
    public class Controller_Conecction
    {
        public static SqlConnection ConnectModel() {
            return Model_Concection.Conectar();
        }
    }
}
