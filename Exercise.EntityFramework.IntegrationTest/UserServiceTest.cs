using Exercise.EF.DAL.Entities;
using Exercise.EF.DAL.Migrations;
using Exercise.EntityFramework.Logic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.EntityFramework.Test
{

    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetUserByEmail()
        {
            var context = new MyContext();
            var userService = new UserService(context);

            User user = userService.GetUserByEmail("test@email.com");

            context.SaveChanges();

            user.UserId.Should().NotBe(0);
            user.Email.Should().Be("test@email.com");
        }
    }
}
