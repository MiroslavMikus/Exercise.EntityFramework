using System.Data.Entity.Infrastructure;

namespace Exercise.EntityFramework.Examples
{
    public class ContextFactory : IDbContextFactory<TestContext>
    {
        private static string _connection;

        public static void InitFactory(string connection)
        {
            _connection = connection;
        }

        public TestContext Create()
        {
            return new TestContext("temp_test");
        }
    }
}
