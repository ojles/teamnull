using System;

namespace Task4
{
    class Task
    {
        private DataBase db;

        public Task()
        {
            db = new DataBase(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True");
        }

        private void ConnectToDatabase()
        {
            db.Connect();          
            Console.WriteLine("\n Successfully connected to the database \n\n");
        }

        private void DisconnectFromDatabase()
        {
            db.Disconnect();          
            Console.WriteLine("\n Successfully disconnected from the database \n\n");
        }

        public void ExecuteTask()
        {           
            ConnectToDatabase();                   
            DisconnectFromDatabase();           
        }
    }
}
