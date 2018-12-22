using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.EntityFramework.Examples.Model.PrimaryKey
{
    public class Customer
    {
        /// <summary>
        /// Propery named 'class name'Id will be used as primary key.
        /// This will be set by Entity Framework naming convention.
        /// </summary>
        public int CustomerId { get; set; }
    }
}
