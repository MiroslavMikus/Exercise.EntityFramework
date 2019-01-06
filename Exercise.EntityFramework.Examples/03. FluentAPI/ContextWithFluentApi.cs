using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity;

namespace Exercise.EntityFramework.Examples._02._Context
{
    public class ContextWithFluentApi : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasRequired(a => a.Customer)
                .WithMany(a => a.Orders);

            modelBuilder.Entity<Customer>()
                .ToTable("SuperCustomers");
        }
    }
}
