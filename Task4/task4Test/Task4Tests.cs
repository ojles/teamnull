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
        public void Query1Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[0], connection))
            {
                command.Parameters.AddWithValue("@EmployeeID", 8);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "EmployeeID");
                    Assert.AreEqual(dataReader.GetName(2), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetValue(0), (Int32)8);
                    Assert.AreEqual(dataReader.GetValue(2), "Laura");
                    Assert.AreEqual(dataReader.GetValue(1), "Callahan");
                }
            }
        }

        [TestMethod]
        public void Query2Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[1], connection))
            {
                command.Parameters.AddWithValue("@CityName", "London");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetValue(0), "Steven");
                    Assert.AreEqual(dataReader.GetValue(1), "Buchanan");

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }

        [TestMethod]
        public void Query5Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[1], connection))
            {
                command.Parameters.AddWithValue("@CityName", "London");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "COUNT");
                    Assert.AreEqual(dataReader.GetValue(0), (Int64)4);
                }
            }
        }

        [TestMethod]
        public void Query6Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[1], connection))
            {
                command.Parameters.AddWithValue("@CityName", "London");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "MaxAge");
                    Assert.AreEqual(dataReader.GetName(1), "MinAge");
                    Assert.AreEqual(dataReader.GetName(2), "AverageAge");
                    Assert.AreEqual(dataReader.GetValue(0), (Int64)63);
                    Assert.AreEqual(dataReader.GetValue(1), (Int64)52);
                    Assert.AreEqual(dataReader.GetValue(2), (Int64)57);
                }
            }
        }

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
        public void Query11Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[10], connection))
            {                
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "City");
                    Assert.AreEqual(dataReader.GetValue(0), "Seattle");

                    /*                                                                                                                                                                                                                                                    
                     * TODO: iterate over DataReader                                                                                                                                                                                                                      
                     *       check multiple employees                                                                                                                                                                                                                     
                     * */
                }
            }
        }

        [TestMethod]
        public void Query13Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[1], connection))
            {
                command.Parameters.AddWithValue("@CityName", "Madrid");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetValue(0), "Nancy");
                    Assert.AreEqual(dataReader.GetValue(1), "Davolio");
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
                    Assert.AreEqual(dataReader.GetValue(2), (Int64)55);

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }

        public void Query16Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[13], connection))
            {
                command.Parameters.AddWithValue("@OrderDate", 1997);
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "FirstName");
                    Assert.AreEqual(dataReader.GetName(1), "LastName");
                    Assert.AreEqual(dataReader.GetName(2), "Orders amount");
                    Assert.AreEqual(dataReader.GetValue(0), "Nancy");
                    Assert.AreEqual(dataReader.GetValue(1), "Davolio");
                    Assert.AreEqual(dataReader.GetValue(2), (Int64)1);

                    /*
                     * TODO: iterate over DataReader
                     *       check multiple employees
                     * */
                }
            }
        }

        [TestMethod]
        public void Query18Test()
        {
            using (MySqlCommand command = new MySqlCommand(Task4.Query.Q[1], connection))
            {
                command.Parameters.AddWithValue("@CountryName", "France");
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    Assert.AreEqual(dataReader.GetName(0), "CustomerID");
                    Assert.AreEqual(dataReader.GetName(1), "Country");
                    Assert.AreEqual(dataReader.GetName(2), "Orders");
                    Assert.AreEqual(dataReader.GetValue(0), "BLONP");
                    Assert.AreEqual(dataReader.GetValue(1), "France");
                    Assert.AreEqual(dataReader.GetValue(2), (Int64)11);
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
