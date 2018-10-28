using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horses.DataAccess
{
    public class PaardContext
    {
        public string ConnectionString { get; set; }

        public PaardContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
