using Task3.Domain;

namespace Task3.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Meal> Meals { get; }
        GenericRepository<Order> Orders { get; }
        void Save();
    }
}
