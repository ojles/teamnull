using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

using Task3.DataAccess.Interfaces;

namespace Task3.DataAccess
{
    /// <summary>
    /// Used for managing the database with database context
    /// </summary>
    /// <typeparam name="TEntity">Template entity</typeparam>
    public sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Holds database content
        /// </summary>
        internal readonly DbContext Context;

        /// <summary>
        /// Holds specific database entity object
        /// </summary>
        internal readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Creates GenericRepository object
        /// </summary>
        /// <param name="context">Database context to manage db table</param>
        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns>Returns entity with specified id</returns>
        public TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Saves entity to table
        /// </summary>
        /// <param name="entity">Specific entity object</param>
        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Remove entity from database by id
        /// </summary>
        /// <param name="id">Id of entity</param>
        public void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Removes data from the database by entity object.
        /// </summary>
        /// <param name="entity">Specific entity.</param>
        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        /// <summary>
        /// Updates given entity in database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Saves context changes
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
