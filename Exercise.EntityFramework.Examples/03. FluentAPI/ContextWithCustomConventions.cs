using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Exercise.EntityFramework.Examples.FluentAPI
{
    public class ContextWithCustomConventions : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Here you can write your Fluent API configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // all string properties max length will be 20
            modelBuilder
                .Properties()
                .Where(p => p.PropertyType.Name == "String")
                .Configure(p => p.HasMaxLength(20));

            modelBuilder.Conventions.Add<PrimaryKeyConvention>();
        }
    }

    public class PrimaryKeyConvention : Convention
    {
        public PrimaryKeyConvention()
        {
            // Property Customer_KEY and Order_KEY will be the primary key by convention!
            Properties()
                .Where(a => a.Name == a.DeclaringType.Name + "_KEY")
                .Configure(a => a.IsKey());
        }
    }
}
