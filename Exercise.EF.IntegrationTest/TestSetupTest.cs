using Exercise.EF.DAL.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;

namespace Exercise.EntityFramework.Test
{
    [TestClass]
    public class TestSetupTest
    {
        [TestMethod]
        public void CreateAndDropDb()
        {
            var name = Guid.NewGuid().ToString();

            Assert.IsFalse(File.Exists(name));

            var file = TempDatabase.Filename(name);

            using (var database = new TempDatabase(name))
            {
                Assert.IsTrue(File.Exists(file));

                var context = new MyContext(database.ConnectionString);

                var test = context.Users.ToList();
            }

            Assert.IsFalse(File.Exists(file));
        }

        [TestMethod]
        [Ignore]
        public void DeteteDb()
        {
            using (var setup = new TempDatabase())
            {
                setup.DeleteDatabase("c26fd39d-7a5e-45bf-98e7-9130ef0dc465");
            }
        }
    }
}
