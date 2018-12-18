using System;
using System.Data.SqlClient;
using System.Data;

namespace Task4
{
   public class DataBase
    {
        private string connectionString;
        private SqlConnection connection;

        public DataBase(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool Connect()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    return true;
                }
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return false;
        }

        public bool Disconnect()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                return connection.State == ConnectionState.Closed;
            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return false;
        }
    }
}
