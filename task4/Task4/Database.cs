using System;
using MySql.Data.MySqlClient;

namespace Task4
{
    public sealed class Database
    {
        private const string connectionString = "server=localhost;user id=root;database=northwind; password=smart";                          
        private static readonly MySqlConnection Connection = new MySqlConnection(connectionString);

        public static Connection GetConnection()
        {
            if (!Connection.IsOpen())
            {
                Connection.Open();
            }

            return Connection;
        }
    }
}
