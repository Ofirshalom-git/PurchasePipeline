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
        public void InvalidCreditCardReasonPriorityTestNumeric()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "numeric", 1);

            DBTests.WyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCreditCardReasonPriorityTestNonNumeric()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "non numeric", 1);

            DBTests.WyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidCreditCardCSVFile(RabbitMQLogics, DBCommunication, 1);
            // create send invalid installments csv file 
            DBTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidCreditCardCSVFile(RabbitMQLogics, DBCommunication, 1);
            // create send invalid purchase by non activity date csv file 
            DBTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
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
