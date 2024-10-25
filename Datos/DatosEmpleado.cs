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
using System.Net;

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

        // Obtener empleados desde base de datos
        // ---------------------------------------------------------------------------
        public DataTable ObtenerEmpleados()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Empleados";
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable tablaEmpleados = new DataTable();
                    tablaEmpleados.Load(reader);
                    return tablaEmpleados;
                }
            }
        }

        // ---------------------------------------------------------------------------

        // Verificar si el DNI existe
        // ---------------------------------------------------------------------------
        public bool ExisteEmpleado(long dni)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(1) FROM Empleados WHERE DNI = @DNI";
                    command.Parameters.AddWithValue("@DNI", dni);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
        // ---------------------------------------------------------------------------

        // Insertar un nuevo empleado
        // ---------------------------------------------------------------------------
        public bool AgregarEmpleado(long DNI,string apellido, string nombre, string telefono, DateTime fechaNacimiento, string usuario, string clave, string rol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Empleados (DNI, Apellido, Nombre, Telefono, FechaNac, Usuario, Clave, TipoEmpleado) 
                                        VALUES (@DNI,@Apellido, @Nombre, @Telefono, @FechaNac, @Usuario, @Clave, @TipoEmpleado)";
                    command.Parameters.AddWithValue("@DNI", DNI);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@FechaNac", fechaNacimiento);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@TipoEmpleado", rol);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        // ---------------------------------------------------------------------------

        // Modificar empleado
        // ---------------------------------------------------------------------------
        public bool ModificarEmpleado(long dni, string apellido, string nombre, string telefono, DateTime fechaNacimiento, string usuario, string clave, string rol)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Empleados SET Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, 
                                        FechaNac = @FechaNac, Usuario = @Usuario, Clave = @Clave, TipoEmpleado = @TipoEmpleado
                                        WHERE DNI = @DNI";
                    command.Parameters.AddWithValue("@DNI", dni);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@FechaNac", fechaNacimiento);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@TipoEmpleado", rol);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        // ---------------------------------------------------------------------------

        // Eliminar empleado
        // ---------------------------------------------------------------------------
        public bool EliminarEmpleado(long dni)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Empleados WHERE DNI = @DNI";
                    command.Parameters.AddWithValue("@DNI", dni);
                    return command.ExecuteNonQuery() > 0; // Retorna true si se eliminó alguna fila
                }
            }
        }
        // ---------------------------------------------------------------------------

    }
}
