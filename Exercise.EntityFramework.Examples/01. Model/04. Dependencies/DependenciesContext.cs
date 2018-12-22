using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity;

namespace Exercise.EntityFramework.Examples.Model.Dependencies
{
    public class DependenciesContext : DbContext
    {
        public DependenciesContext() : base("DependenciesContext")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
