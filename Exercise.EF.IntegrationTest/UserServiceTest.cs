using Exercise.EF.DAL.Entities;
using Exercise.EF.DAL.Migrations;
using Exercise.EntityFramework.Logic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace Exercise.EntityFramework.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private static TestSetup _setup;
        private static string _name;
        private static SqlConnectionStringBuilder _connection;

        [AssemblyInitialize()]
        public static void ClassInit(TestContext context)
        {
            _name = Guid.NewGuid().ToString();

            _setup = new TestSetup();

            _setup.SetUpDatabase(_name);

            _connection = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = _name,
                IntegratedSecurity = true
            };
        }

        [AssemblyCleanup()]
        public static void ClassCleanup()
        {
            _setup.DeleteDatabase(_name);
        }

        [TestMethod]
        public void GetUserByEmail()
        {
            var test = _connection.ConnectionString.ToString();

            using (var context = new MyContext(_connection.ConnectionString))
            {
                var userService = new UserService(context);

                User user = userService.GetUserByEmail("test@email.com");

                context.SaveChanges();

                user.UserId.Should().NotBe(0);
                user.Email.Should().Be("test@email.com");
            }
        }
    }
}
