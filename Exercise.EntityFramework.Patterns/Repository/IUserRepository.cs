using Exercise.EntityFramework.Patterns.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByNameAndDomain(string Name, string Domain);
    }
}
