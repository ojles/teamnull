using Microsoft.EntityFrameworkCore;

using Task3.Domain;

namespace Task3.DataAccess
{
    /// <summary>
    /// Application database context
    /// </summary>
    public class ApplicationContext : DbContext
    {   /// <summary>
        /// Holds user orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Holds available meals
        /// </summary>
        public DbSet<Meal> Meals { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Parameterless ApplicationContext constructor.
        /// </summary>
        public ApplicationContext()
        {
        }
    }
}
