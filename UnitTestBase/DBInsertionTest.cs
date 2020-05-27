using System;
using System.Collections.Generic;
using System.Data;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBase
{
    [TestClass]
    public class DBInsertionTest : UnitTestBase
    {
        [TestMethod]
        [DataRow("numeric")]
        [DataRow("non numeric")]
        public void InvalidCreditCardReasonPriorityTest(string testCase)
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCreditCardCSVFile(RabbitMQLogics, DBCommunication, testCase, 1);

            TestCasesProvider.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCreditCardCSVFile(RabbitMQLogics, DBCommunication, 1);
            // create send invalid installments csv file 
            TestCasesProvider.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCreditCardCSVFile(RabbitMQLogics, DBCommunication, 1);
            // create send invalid purchase by non activity date csv file 
            TestCasesProvider.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }


        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestMethod]
        public void TestMethod1()
        {
        }




    }
}
