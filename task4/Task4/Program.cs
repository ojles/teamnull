using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace Task4
{
    static class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user id=root;database=northwind; password=smart" ;

            MySqlConnection connection = new MySqlConnection(connectionString);                
            connection.Open();

            string query = Query.Q[9];

            using (connection)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@LIMIT_AMOUNT", 2);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        Console.Write("{0,-20}", reader.GetName(i));
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; ++i)
                        {
                            Console.Write("{0,-20}", reader.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                }
                connection.Close();
            }
        }

        static void RunQuery(string query)
        {
        }
    }
}
