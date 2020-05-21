using Common;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomaition;
using System.Diagnostics;

namespace UnitTestBase
{
    [TestClass]
    public class UnitTestBase
    {
        protected DBCommunication DBCommunication = new DBCommunication();
        protected RabbitMQLogics RabbitMQLogics = new RabbitMQLogics();

        [TestInitialize]
        public void Initialize()
        {
            //string commad = "/c java -jar PurchasesPipeline_1.0.1.jar";
            //System.Diagnostics.Process.Start("CMD.exe", commad);
            DBCommunication.deleteAllPurchases();
        }

        [TestMethod]
        public void TestMethod1()
        {

        }

        //[TestCleanup]
        //public void CleanUp()
        //{
        //    this.DBCommunication.DBActions
        //}
    }
}
