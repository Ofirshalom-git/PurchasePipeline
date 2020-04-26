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
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(RabbitMQLogics, DBLogics, 1);
            for(var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        public void ValidCSVInsertionSucceedTest2(int numOfLines, RabbitMQLogics rabbitMOLogics)
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(RabbitMQLogics, DBLogics, 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
        
        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest1(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBLogics, ';');
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest2(List<CSVPurchaseLine> list, List<PurchaseDBBody> expectedList)
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBLogics, "invalidNumOfFields");
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
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
