using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Task3.DataAccessLayer.Interfaces
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetOrdersList(); 
        T GetBook(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();  
    }
}
