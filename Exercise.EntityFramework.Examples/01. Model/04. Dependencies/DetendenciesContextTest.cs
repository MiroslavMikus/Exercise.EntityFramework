using Exercise.EntityFramework.Examples.Model.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercise.EntityFramework.Examples.Model.Dependencies
{
    [TestClass]
    public class DetendenciesContextTest
    {
        [TestMethod]
        public void CreateDbTest()
        {
            using (var context = new DependenciesContext())
            {
                var customer = new Customer()
                {
                    Name = "Miro",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            ItemName = "notebook"
                        }
                    }
                };

                context.Customers.Add(customer);

                context.SaveChanges();

                var order = new Order
                {
                    ItemName = "Pen",
                    Customer = customer
                };

                context.Orders.Add(order);
            }
        }
    }
}
