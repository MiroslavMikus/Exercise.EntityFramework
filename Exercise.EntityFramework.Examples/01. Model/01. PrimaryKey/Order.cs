using System.ComponentModel.DataAnnotations;

namespace Exercise.EntityFramework.Examples.Model
{
    public class Order
    {
        /// <summary>
        /// Since the property OrderKey doesn't have 'Id' on the end, Entity Framework can't 
        /// recognize it as primary key. This can be fixed with the [Key] attribute.
        /// (or fluent api)
        /// </summary>
        [Key]
        public int OrderKey { get; set; }
    }
}
