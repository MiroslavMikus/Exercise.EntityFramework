using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity;

namespace Exercise.EntityFramework.Examples
{
    public class TestContext : DbContext
    {
        public TestContext(string dbName) : base(dbName)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
