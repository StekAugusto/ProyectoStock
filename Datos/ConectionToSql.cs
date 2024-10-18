using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class ConectionToSql
    {
        private readonly String connectionString;
        public ConectionToSql()
        {
            connectionString = "Server = (localdb)\\Stek; DataBase = StockSystem; integrated security = true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
