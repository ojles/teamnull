using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Task3.DataAccess.Interfaces;
using Task3.Domain;

namespace Task3.DataAccess
{
    /// <summary>
    /// Manages repositories of Orders and Meals
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Application context instance
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Repository to manage Order entity
        /// </summary>
        public GenericRepository<Order> Orders { get; }

        /// <summary>
        /// Repository to manage Meal entity
        /// </summary>
        public GenericRepository<Meal> Meals { get; }

        /// <summary>
        /// Variable which shows whether context is disposed or not
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitOfWork()
        {
            _context = new ApplicationContext();
            Orders = new GenericRepository<Order>(_context);
            Meals = new GenericRepository<Meal>(_context);
        }

        /// <summary>
        /// Retrieves all available meals
        /// </summary>
        /// <returns>Meal list</returns>
        public IEnumerable<Meal> GetMeals()
        {
            return _context.Meals.ToList();
        }

        /// <summary>
        /// Deletes order by id
        /// </summary>
        /// <param name="id">Order id</param>
        public void DeleteOrder(int orderId)
        {
            Orders.Delete(orderId);
        }

        /// <summary>
        /// Saves context changes.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Disposes context using disposing parameter.
        /// </summary>
        /// <param name="disposing">Sets disposing state.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Implements Dispose method.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
