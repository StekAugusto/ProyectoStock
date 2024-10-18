using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class UserModel
    {
        DatosEmpleado userEmpleado = new DatosEmpleado();
        public bool LoginUsuario(String Usuario, String Clave)
        {
            return userEmpleado.Login(Usuario, Clave);
        }

    }
}
