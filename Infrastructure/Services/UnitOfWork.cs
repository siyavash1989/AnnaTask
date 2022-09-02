using System.Collections;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context.Store;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repository;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repository == null) _repository = new Hashtable();

            var type = typeof(T).Name;
            if (!_repository.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repository.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repository[type];
        }
    }
}