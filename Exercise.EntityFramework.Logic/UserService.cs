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
    }
}