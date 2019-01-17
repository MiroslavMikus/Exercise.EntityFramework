using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity.ModelConfiguration;

namespace Exercise.EntityFramework.Examples.FluentAPI
{
    public class CustomerEntityConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfiguration()
        {
            // Since the Entity Framework can't recognize the id by convention (Id or CustomerId)
            // we have to set it manually.
            HasKey(a => a.CustomerKey);

            // Ignore DoNotMap property
            Ignore(a => a.DoNotMap);

            // Save customer to a custom table instad of 'Customers'
            ToTable("SuperCustomers");

            // Setup cascade on delete
            HasMany(a => a.Orders)
               .WithRequired(a => a.Customer)
               .WillCascadeOnDelete(true);

            // Set the name max length to 20
            Property(a => a.Name)
               .HasMaxLength(20);

            // Setup optimistic concurrency (no locks)
            Property(a => a.RowVersion)
               .IsRowVersion();
        }
    }
}
