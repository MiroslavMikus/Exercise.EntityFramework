using Exercise.EntityFramework.Patterns.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns
{
    public class SampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SampleContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
