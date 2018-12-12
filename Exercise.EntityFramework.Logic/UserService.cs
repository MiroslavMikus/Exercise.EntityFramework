using System;
using System.Linq;
using Exercise.EF.DAL.Entities;
using Exercise.EF.DAL.Migrations;

namespace Exercise.EntityFramework.Logic
{
    public class UserService
    {
        private MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Add(new User { Email = email });
        }
    }
}