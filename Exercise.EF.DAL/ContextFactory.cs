namespace Exercise.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Infrastructure;

    public class ContextFactory : IDbContextFactory<MyContext>
    {
        private static string _connection;

        public static void InitFactory(string connection)
        {
            _connection = connection;
        }

        public MyContext Create()
        {
            if (string.IsNullOrEmpty(_connection))
            {
                throw new ArgumentException($"{nameof(ContextFactory)} says: '{nameof(_connection)} cannot be empty!'");
            }

            return new MyContext(_connection);
        }
    }
}
