using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exercise.EntityFramework.Examples._01._Model._02._TableName
{
    /// <summary>
    /// Attribute '[Table]' tells the Entity Framework to put this class to specified table.
    /// </summary>
    [Table("Simple")]
    public class TypeWithComplexName
    {
        public int Id { get; set; }
    }
}
