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
        private MySqlConnection connection = Database.GetConnection();

        [TestMethod]
        public void Query9Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[8], connection))
            {
                command.Parameters.AddWithValue("@LimitAmount", 8);
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

        [TestMethod]
        public void Query10Test()
        {           
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[9], connection))
            {
                command.Parameters.AddWithValue("@LimitAmount", 8);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetValue(0), "Margaret");
                    Assert.AreEqual(dataReader.GetValue(1), "Peacock");

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }

        [TestMethod]
        public void Query15Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[14], connection))
            {
                command.Parameters.AddWithValue("@OrderDate", 1997);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetName(2), "Orders made");
                    Assert.AreEqual(dataReader.GetValue(0), "Nancy");
                    Assert.AreEqual(dataReader.GetValue(1), "Davolio");
                    Assert.AreEqual(dataReader.GetValue(2), "55");

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }

        [TestMethod]
        public void Query20Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[19], connection))
            {
                command.Parameters.AddWithValue("@ProductName", "Tofu");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "ContactName");
                    Assert.AreEqual(dataReader.GetName(1), "ContactTitle");
                    Assert.AreEqual(dataReader.GetValue(0), "Karin Josephs");
                    Assert.AreEqual(dataReader.GetValue(1), "Marketing Manager");

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }
    }
}
