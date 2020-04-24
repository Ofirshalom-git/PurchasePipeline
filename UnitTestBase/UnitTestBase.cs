using Common;
//using BL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomaition;

namespace UnitTestBase
{
    [TestClass]
    public class UnitTestBase
    {
        protected DBLogics DBLogics;
        protected RabbitMQLogics RabbitMQLogics;

        [TestInitialize]
        public void Initialize()
        {
            DBLogics = new DBLogics();
            RabbitMQLogics = new RabbitMQLogics();
        }

        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
