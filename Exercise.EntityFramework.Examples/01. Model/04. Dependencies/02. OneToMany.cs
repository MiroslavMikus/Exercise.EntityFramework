using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.EntityFramework.Examples.Model.Dependencies
{
    public class Customer
    {
        public int CustomerKey { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public string DoNotMap { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
