using System.Data.Entity.Migrations;

namespace Exercise.EntityFramework.Examples
{
    public class Configuration : DbMigrationsConfiguration<TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestContext context)
        {
        }
    }
}
