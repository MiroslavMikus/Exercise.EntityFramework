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
            OrderSetup(modelBuilder);

            CustomerSetup(modelBuilder);
        }

        private static void OrderSetup(DbModelBuilder modelBuilder)
        {
            // mark customer property as mandatory
            modelBuilder.Entity<Order>()
                .HasRequired(a => a.Customer)
                .WithMany(a => a.Orders);
        }

        private static void CustomerSetup(DbModelBuilder modelBuilder)
        {
            // since the Entity Framework can't recognize the id by convention (Id or CustomerId)
            // we have to set it manually.
            modelBuilder.Entity<Customer>()
                .HasKey(a => a.CustomerKey);

            // Ignore DoNotMap property
            modelBuilder.Entity<Customer>()
                .Ignore(a => a.DoNotMap);

            // Save customer to a custom table instad of 'Customers'
            modelBuilder.Entity<Customer>()
                .ToTable("SuperCustomers");

            // Setup cascade on delete
            modelBuilder.Entity<Customer>()
                .HasMany(a => a.Orders)
                .WithRequired(a => a.Customer)
                .WillCascadeOnDelete(true);
        }
    }
}
