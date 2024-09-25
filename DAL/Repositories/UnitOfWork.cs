using DAL.Ef_Core;
using DAL.Models;
using DAL.Models.Users;
using Data.Repositories.RepositoryInterfaces;

namespace Repositories
{
    public class UnitOfWork <TEntity, TKey>  : IUnitOfWork <TEntity, TKey>
        where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        public IGenericRepository<User, Guid> _userRepository;

        private IGenericRepository<TEntity, TKey> _repository;
        public IGenericRepository<Product, int> _productRepository;
        public IGenericRepository<Address, int> _addressRepository;
        public IGenericRepository<Category, int> _categoryRepository;
        public IGenericRepository<Order, int> _orderRepository;
        public IGenericRepository<OrderItem, int> _orderItemRepository;
        public IGenericRepository<Payment, int> _paymentRepository;
        public IGenericRepository<PaymentMethod, int> _paymentMethodRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IGenericRepository<User, Guid> Users => _userRepository ??= new GenericRepository<User, Guid>(_appDbContext);

        public IGenericRepository<TEntity, TKey> Repository => _repository ??= new GenericRepository<TEntity, TKey>(_appDbContext);

        public IGenericRepository<Product, int> Products => _productRepository ??= new GenericRepository<Product, int>(_appDbContext);

        public IGenericRepository<Address, int> Addresses => _addressRepository ??= new GenericRepository<Address, int>(_appDbContext);

        public IGenericRepository<Category, int> Categories => _categoryRepository ??= new GenericRepository<Category, int>(_appDbContext);

        public IGenericRepository<Order, int> Orders => _orderRepository ??= new GenericRepository<Order, int>(_appDbContext);

        public IGenericRepository<OrderItem, int> OrderItems => _orderItemRepository ??= new GenericRepository<OrderItem, int>(_appDbContext);

        public IGenericRepository<Payment, int> Payments => _paymentRepository ??= new GenericRepository<Payment, int>(_appDbContext);

        public IGenericRepository<PaymentMethod, int> PaymentMethods => _paymentMethodRepository ??= new GenericRepository<PaymentMethod, int>(_appDbContext);

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
