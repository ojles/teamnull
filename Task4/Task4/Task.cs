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
            if (!db.Connect())
            {
                throw new Exception("Can't connect to database!");
            }

            Console.WriteLine("\n Successfully connected to the database \n\n");
        }

        private void DisconnectFromDatabase()
        {
            if (!db.Disconnect())
            {
                throw new Exception("Can't disconnect from database!");
            }

            Console.WriteLine("\n Successfully disconnected from the database \n\n");
        }

        public void ExecuteTask()
        {
            try
            {
                ConnectToDatabase();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
    
            try
            {
                DisconnectFromDatabase();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
