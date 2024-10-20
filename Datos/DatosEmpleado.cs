using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Cache;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using Entidades;

namespace Datos
{
    public class DatosEmpleado : ConectionToSql
    {
        public bool Login(String Usuario, string Clave)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;

                    // limpiar los parámetros
                    command.Parameters.Clear();

                    // Consulta SQL
                    command.CommandText = "SELECT * FROM Empleados WHERE Usuario = @Usuario AND Clave = @Clave";
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Clave", Clave);
                    // ----------------------------
                    command.Parameters.AddWithValue("@DNI", CacheLogin.DNI_Empleado);
                    // ----------------------------
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    // Ejecutar consulta
                    //SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheLogin.DNI_Empleado = reader.GetInt64(0);
                            CacheLogin.ApellidoEmpleado = reader.GetString(1);
                            CacheLogin.NombreEmpleado = reader.GetString(2);
                            CacheLogin.TelefonoEmpleado = reader.GetString(3);
                            CacheLogin.FechaNacimientoEmpleado = reader.GetDateTime(4);
                            CacheLogin.UsuarioEmpleado = reader.GetString(5);
                            CacheLogin.ClaveEmpleado = reader.GetString(6);
                            CacheLogin.TipoEmpleado = reader.GetString(7);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                connection.Close();
            }
        }
        // Metodo para permisos y roles
        public void PermisosRol()
        {
            if(CacheLogin.TipoEmpleado == PosicionRol.Administrador)
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
