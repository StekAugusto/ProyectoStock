using System;
using System.Collections.Generic;
using System.Data;
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

        // Método para verificar si el DNI existe
        // --------------------------------------------------------------
        public bool ExisteEmpleado(long dni)
        {
            return userEmpleado.ExisteEmpleado(dni);
        }
        // --------------------------------------------------------------

        // Método para agregar un nuevo empleado
        // --------------------------------------------------------------
        public bool AgregarEmpleado(long dni,string apellido, string nombre, string telefono, DateTime fechaNacimiento, string usuario, string clave, string rol)
        {
            return userEmpleado.AgregarEmpleado(dni,apellido, nombre, telefono, fechaNacimiento, usuario, clave, rol);
        }
        // --------------------------------------------------------------

        // Método para actualizar un empleado
        // --------------------------------------------------------------
        public bool ModificarEmpleado(long dni, string apellido, string nombre, string telefono, DateTime fechaNacimiento, string usuario, string clave, string rol)
        {
            return userEmpleado.ModificarEmpleado(dni, apellido, nombre, telefono, fechaNacimiento, usuario, clave, rol);
        }
        // --------------------------------------------------------------

        

        //public bool editarClave(int Dni, String Clave)
        //{
        //    /*
        //    if(Dni == CacheLogin.DNI_Empleado)
        //    {

        //    }
        //    */
        //    return true;
        //}

        // PERMISOS rol
        // --------------------------------------------------------------
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
        // --------------------------------------------------------------

        //Interactuar con DatosEmpleado
        // --------------------------------------------------------------
        public DataTable ObtenerEmpleados()
        {
            return userEmpleado.ObtenerEmpleados();
        }
        // --------------------------------------------------------------

        // Eliminar empleado
        // --------------------------------------------------------------
        public bool EliminarEmpleado(long dni)
        {
            return userEmpleado.EliminarEmpleado(dni);
        }
        // --------------------------------------------------------------
    }
}
