using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Data;
using Task4;

namespace task4Test
{
    [TestClass]
    public class Task4Tests
    {
        MySqlConnection connection = Database.GetConnection();

        [TestMethod]
        public void Select10Test()
        {           
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[9], connection))
            {
                command.Parameters.AddWithValue("@LIMIT_AMOUNT", 8);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetValue(0), "Margaret");
                    Assert.AreEqual(dataReader.GetValue(1), "Peacock");
                }                  
            }
        }
    }
}
