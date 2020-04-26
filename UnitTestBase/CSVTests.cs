using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using TestAutomaition;
using FluentAssertions;
using System.Collections.Generic;
using System.Dynamic;


namespace UnitTestBase
{
    [TestClass]
    public class CSVTests : UnitTestBase
    {
        [TestMethod]        
        public void ValidCSVInsertionSucceedTest1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(1, RabbitMQLogics, DBLogics);
            for(var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        public void ValidCSVInsertionSucceedTest2(int numOfLines, RabbitMQLogics rabbitMOLogics)
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(3, RabbitMQLogics, DBLogics);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            CSVFile file = new CSVFile(list);
            RabbitMQLogics.SendCSVToRabbitMQ(file);
            DBLogics.GetAllPurchases().Should().BeSameAs(expectedList);
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTest(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            CSVFile file = new CSVFile(list);
            RabbitMQLogics.SendCSVToRabbitMQ(file);
            DBLogics.GetAllPurchases().Should().BeSameAs(expectedList);
        }

        [TestMethod]
        public void InvalidStoreIdCSVLineInsertionFailsTest(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            CSVFile file = new CSVFile(list);
            RabbitMQLogics.SendCSVToRabbitMQ(file);
            DBLogics.GetAllPurchases().Should().BeSameAs(expectedList);
        }

        [TestMethod]
        public void NonNumericPriceCSVLineInsertionFailsTest(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            CSVFile file = new CSVFile(list);
            RabbitMQLogics.SendCSVToRabbitMQ(file);
            DBLogics.GetAllPurchases().Should().BeSameAs(expectedList);
        }

        [TestMethod]
        public void NonFULLStringInstallmentsCSVLineInsertionFailsTest(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            CSVFile file = new CSVFile(list);
            RabbitMQLogics.SendCSVToRabbitMQ(file);
            DBLogics.GetAllPurchases().Should().BeSameAs(expectedList);
        }
    }
}
