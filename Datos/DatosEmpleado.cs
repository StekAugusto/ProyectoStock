using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
                    command.CommandText = "SELECT * FROM Empleados WHERE Usuario = @Usuario AND Clave = @Clave";
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Clave", Clave);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
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
    }
}
