using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exercise.EntityFramework.Examples.Model.Validation
{
    public class Customer
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(12)]
        public string UserName { get; set; }

        [Range(18,99)]
        public int Age { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        public string MobilePhone { get; set; }

        [RegularExpression("SuperCrazy Regex")]
        public string Phone { get; set; }
    }
}
