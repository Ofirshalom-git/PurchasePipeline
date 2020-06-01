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

            DBTests.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCreditCardReasonPriorityTestNonNumeric()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "non numeric", 1);

            DBTests.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void InvalidInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidOverflowInstallmentsCSV(RabbitMQLogics, DBCommunication, 1);

            DBTests.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidNonActivityDatePriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidNonActivityDateCSV(RabbitMQLogics, DBCommunication, 1);

            DBTests.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }


        [TestMethod]
        public void InvalidPerInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTests.SendInvalidPerInstallmentOverflowCSV(RabbitMQLogics, DBCommunication, 1);

            DBTests.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }



    }
}
