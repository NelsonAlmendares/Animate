using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class Login_Controller
    {
        // Constructor de la clase
        public Login_Controller() { }
        // Atributos
        public int ID { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }

        // Método para verificar los datos
        public bool VerifyData(string User, string Pwd) {
            return LoginModel.IniciarSesion(User, Pwd);
        }

        public string getUser(string usuario) {
            return LoginModel.GetUser(usuario);
        }
    }
}
