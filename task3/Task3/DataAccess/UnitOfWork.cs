using System;
using System.Data.Entity;
using System.Collections.Generic;

using Task3.DataAccess.Interface;
using Task3.Domain;

namespace Task3.DataAccess;
{
    /// <summary>
    /// Is used to manage repositories. 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Contains order context instance.
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Orders field is used to manage table 'Orders' in the database.
        /// </summary>
        public GenericRepository<Order> Orders { get; }

        /// <summary>
        /// Clients field is used to manage table 'Clients' in the database.
        /// </summary>
        public GenericRepository<Meal> Meals { get; }

        /// <summary>
        /// A variable which shows whether context is disposed or not.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Default constructor that instantiates UnitOfWork object. 
        /// </summary>
        public UnitOfWork()
        {
            _context = new OrderContext();
            Orders = new GenericRepository<Order>(_context);
            Meals = new GenericRepository<Meal>(_context);
        }

        /// <summary>
        /// Retrieves all orders from database.
        /// </summary>
        /// <returns>Orders list.</returns>
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders
                .Include(g => g.GoodsData)
                .Include(s => s.ShopData).Include(shop => shop.ShopData.Address)
                .Include(c => c.ClientData).Include(client => client.ClientData.Address);
        }

        /// <summary>
        /// Deletes order from database completely.
        /// </summary>
        /// <param name="id">Order id.</param>
        public void DeleteOrder(int id)
        {
            var order = Orders.GetById(id);
            Addresses.Delete(order.ClientData.Address);
            Addresses.Delete(order.ShopData.Address);
            Goods.Delete(order.GoodsData);
            Clients.Delete(order.ClientData);
            Shops.Delete(order.ShopData);
            Orders.Delete(order);
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
