using System.Data.Entity;

using Task3.Domain;

namespace Task3.DataAccess;
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an order.
    /// </summary>
    public class ApplicationContext : DbContext
    {   /// <summary>
        /// Holds orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Contains client personal information.
        /// </summary>
        public DbSet<Meal> Meals { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Parameterless OrderContext constructor.
        /// </summary>
        public OrderContext() : base("CargoDeliveryDb")
        {
        }
    }
}
