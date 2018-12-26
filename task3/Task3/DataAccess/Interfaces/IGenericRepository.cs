using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Task3.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
