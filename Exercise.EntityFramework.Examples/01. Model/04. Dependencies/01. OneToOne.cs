using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.EntityFramework.Examples.Model.Dependencies
{
    public class Employee
    {
        public int Id { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
    }
}
