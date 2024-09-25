using DAL.Models;
using DAL.Models.Users;

namespace Data.Repositories.RepositoryInterfaces
{
    public interface IUnitOfWork <TEntity, TKey> : IDisposable
        where TEntity : class
    {
        public IGenericRepository<TEntity, TKey> Repository { get; }
        public IGenericRepository<User, Guid> Users { get; }
        public IGenericRepository<Product, int> Products { get; }
        public IGenericRepository<Address, int> Addresses { get; }
        public IGenericRepository<Category, int> Categories { get; }
        public IGenericRepository<Order, int> Orders { get; }
        public IGenericRepository<OrderItem, int> OrderItems { get; }
        public IGenericRepository<Payment, int> Payments { get; }
        public IGenericRepository<PaymentMethod, int> PaymentMethods { get; }
        Task SaveChangesAsync();
    }
}
