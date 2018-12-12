using System;
using Exercise.EF.DAL.Migrations;
using Exercise.EntityFramework.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.EntityFramework.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new MyContext();
            var userService = new UserService(context);
        }
    }
}
