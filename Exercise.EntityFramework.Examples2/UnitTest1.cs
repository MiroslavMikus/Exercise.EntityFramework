using Exercise.EntityFramework.Examples.Model.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercise.EntityFramework.Examples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new TestContext("Temp_testDb"))
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
