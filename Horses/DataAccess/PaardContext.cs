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
            string connectionString = "Server=https://db4free.net/phpmyadmin;Database=gpsporthorses;UserID=matijs;Password=Glekke69;";
            //string connectionString = "Server=localhost:3306;Database=gpsporthorses;UserID=matijs;Password=Glekke69;";

            return new MySqlConnection(connectionString);
        }
    }
}
