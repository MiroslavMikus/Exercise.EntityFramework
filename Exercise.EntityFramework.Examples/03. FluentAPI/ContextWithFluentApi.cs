using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity;

namespace Exercise.EntityFramework.Examples.FluentAPI
{
    public class ContextWithFluentApi : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Here you can write your Fluent API configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            // Add customer configuration
            modelBuilder.Configurations.Add(new CustomerEntityConfiguration());

            // Add order configuration
            modelBuilder.Configurations.Add(new OrdersEntityConfiguration());
        }
    }
}
