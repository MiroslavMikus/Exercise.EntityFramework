using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exercise.EntityFramework.Examples.Model.Concurrency
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public string Phone { get; set; }

        // Setup optimistic concurrency (no locks)
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
