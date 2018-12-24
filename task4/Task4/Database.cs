using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Task4
{
    public sealed class Database
    {
        private const string connectionString = "server=localhost;user id=root;database=northwind; password=smart";                          
        private static readonly MySqlConnection Connection = new MySqlConnection(connectionString);

        public static MySqlConnection GetConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            return Connection;
        }
    }
}
