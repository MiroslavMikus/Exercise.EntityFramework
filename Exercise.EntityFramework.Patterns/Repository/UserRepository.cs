using Exercise.EntityFramework.Patterns.Model;
using System.Data.Entity;
using System.Linq;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) 
            : base(context)
        {
        }

        public User GetUserByNameAndDomain(string Name, string Domain)
        {
            return _context.Set<User>().SingleOrDefault(a => a.Name == Name && a.Domain == Domain);
        }
    }
}
