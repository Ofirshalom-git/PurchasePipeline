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
        protected DBCommunication DBCommunication;
        protected RabbitMQLogics RabbitMQLogics;

        [TestInitialize]
        public void Initialize()
        {
            //var startInfo = new ProcessStartInfo
            //{
            //    FileName = "filePath";
            //    WorkingDirectory = @"file path";
            //    Arguments = "/c java -jar PurchasesPipeline_1.0.1.jar";
            //};

            //_process = new Process{StartInfo = startInfo};
            //_process.Start();

            DBCommunication = new DBCommunication();
            RabbitMQLogics = new RabbitMQLogics();
            DBCommunication.deleteAllPurchases();            
        }

        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestCleanup]
        public void CleanUp()
        {
            //_process.CloseMainWindow();
        }
    }
}
