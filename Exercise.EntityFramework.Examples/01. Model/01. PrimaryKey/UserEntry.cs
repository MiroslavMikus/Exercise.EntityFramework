using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exercise.EntityFramework.Examples._01._Model._01._PrimaryKey
{
    /// <summary>
    /// Class with composite key.
    /// </summary>
    public class UserEntry
    {
        [Key, Column(Order = 0)]
        public string UserName { get; set; }

        [Key, Column(Order = 1)]
        public string Domain { get; set; }
    }
}
