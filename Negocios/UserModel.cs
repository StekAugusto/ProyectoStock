using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Entidades.Cache;

namespace Negocios
{
    public class UserModel
    {
        DatosEmpleado userEmpleado = new DatosEmpleado();
        public bool LoginUsuario(String Usuario, String Clave)
        {
            return userEmpleado.Login(Usuario, Clave);
        }

        //public bool editarClave(int Dni, String Clave)
        //{
        //    /*
        //    if(Dni == CacheLogin.DNI_Empleado)
        //    {
                
        //    }
        //    */
        //    return true;
        //}

        // PERMISOS
        public void PermisosRol()
        {
            if (CacheLogin.TipoEmpleado == PosicionRol.Administrador)
            {

            }
            if (CacheLogin.TipoEmpleado == PosicionRol.Auditor)
            {

            }
            if (CacheLogin.TipoEmpleado == PosicionRol.Operador)
            {

            }
        }
    }
}
