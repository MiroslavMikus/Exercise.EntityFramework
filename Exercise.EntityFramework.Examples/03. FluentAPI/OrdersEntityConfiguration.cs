using Exercise.EntityFramework.Examples.Model.Dependencies;
using System.Data.Entity.ModelConfiguration;

namespace Exercise.EntityFramework.Examples.FluentAPI
{
    public class OrdersEntityConfiguration : EntityTypeConfiguration<Order>
    {
        public OrdersEntityConfiguration()
        {
            // mark customer property as mandatory
            HasRequired(a => a.Customer)
                .WithMany(a => a.Orders);
        }
    }
}
