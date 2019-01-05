using Exercise.EF.DAL.Entities;
using Exercise.EF.DAL.Migrations;
using Exercise.EntityFramework.Logic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Exercise.EntityFramework.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private static TempDatabase _setup;
        private static string _name;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _name = Guid.NewGuid().ToString();

            _setup = new TempDatabase();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            _setup.Dispose();
        }

        private MyContext CreateContextWithTransaction(string connectionString)
        {
            var context = new MyContext(connectionString);

            context.Database.BeginTransaction();

            return context;
        }

        private MyContext CreateContext(string connectionString)
        {
            return new MyContext(connectionString);
        }

        [TestMethod]
        public void GetUserByEmail()
        {
            using (var context = CreateContextWithTransaction(_setup.ConnectionString))
            {
                var userService = new UserService(context);

                User user = userService.AddUser("test@email.com");

                context.SaveChanges();

                user.UserId.Should().NotBe(0);

                user.Email.Should().Be("test@email.com");
            }
        }

        [TestMethod]
        public void UserShouldExist()
        {
            using (var context = CreateContext(_setup.ConnectionString))
            {
                var userService = new UserService(context);

                User user = userService.AddUser("test@email.com");

                context.SaveChanges();

                user.UserId.Should().NotBe(0);

                user.Email.Should().Be("test@email.com");
            }

            using (var context = CreateContext(_setup.ConnectionString))
            {
                var users = context.Users.ToList();

                users.Should().NotBeEmpty();
            }
        }

        [TestMethod]
        public void UserShouldNotExist_TransactionTest()
        {
            using (var context = CreateContextWithTransaction(_setup.ConnectionString))
            {
                var userService = new UserService(context);

                User user = userService.AddUser("test@email.com");

                context.SaveChanges();

                user.UserId.Should().NotBe(0);

                user.Email.Should().Be("test@email.com");
            }

            // since we are using transactions, the users table should be still empty
            using (var context = CreateContextWithTransaction(_setup.ConnectionString))
            {
                var users = context.Users.ToList();

                users.Should().BeEmpty();
            }
        }
    }
}
