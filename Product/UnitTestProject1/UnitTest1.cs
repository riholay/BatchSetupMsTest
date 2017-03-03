using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
    }
}
