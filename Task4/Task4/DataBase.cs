using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Task4
{
   public class DataBase
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public DataBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Connect()
        {            
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }
                
            return false;
        }

        public bool Disconnect()
        {          
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                return connection.State == ConnectionState.Closed;
            }

            return false;
        }       
   }
}
