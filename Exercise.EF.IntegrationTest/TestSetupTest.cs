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
    }
}
