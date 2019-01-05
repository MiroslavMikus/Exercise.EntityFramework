using Exercise.EntityFramework.Patterns.Repository;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns.UnitOfWork
{
    public class LazyUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        private Lazy<IUserRepository> _users;
        public IUserRepository Users { get => _users.Value; }

        public LazyUnitOfWork(DbContext context, Lazy<IUserRepository> userRepository)
        {
            _context = context;
            _users = userRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();

            Users = null;
        }
    }
}
