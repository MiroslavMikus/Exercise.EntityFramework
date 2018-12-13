using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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

            var setup = new TestSetup();

            setup.SetUpDatabase(name);

            var file = TestSetup.Filename(name);

            Assert.IsTrue(File.Exists(file));

            setup.DeleteDatabase(name);

            Assert.IsFalse(File.Exists(file));
        }

        [TestMethod]
        public void DeteteDb()
        {
            var setup = new TestSetup();
            setup.DeleteDatabase("e6e5bbeb-b2d0-4954-9dac-6a80fb3f1edf");
        }
    }
}
