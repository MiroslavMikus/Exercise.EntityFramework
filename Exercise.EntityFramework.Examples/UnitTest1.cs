using Exercise.EntityFramework.Examples.Model.Dependencies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.EntityFramework.Examples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new TestContext())
            {
                var customer = new Customer()
                {
                    Name = "Miro"
                };

                var order = new Order
                {
                    Customer = customer
                };

                context.Orders.Add(order);

                context.SaveChanges();
            }
        }
    }
}
