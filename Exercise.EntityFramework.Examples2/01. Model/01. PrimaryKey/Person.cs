namespace Exercise.EntityFramework.Examples.Model.PrimaryKey
{
    public class Person
    {
        /// <summary>
        /// Property with name 'Id' will be used as primary key.
        /// This will be set by Entity Framework naming convention.
        /// </summary>
        public int Id { get; set; }
    }
}
