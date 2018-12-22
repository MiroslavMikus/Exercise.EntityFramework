using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.EntityFramework.Examples._01._Model._04._Dependencies
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
