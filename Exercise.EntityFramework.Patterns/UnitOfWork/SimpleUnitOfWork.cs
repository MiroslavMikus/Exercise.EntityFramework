using Exercise.EntityFramework.Patterns.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns.UnitOfWork
{
    public class SimpleUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public IUserRepository Users { get; }

        public SimpleUnitOfWork(DbContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
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
        }
    }
}
