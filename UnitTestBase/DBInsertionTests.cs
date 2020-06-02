using System.Collections.Generic;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBase
{
    [TestClass]
    public class DBInsertionTests : UnitTestBase
    {
        [TestMethod]
        public void InvalidCreditCardReasonPriorityTestNumeric()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "numeric", 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCreditCardReasonPriorityTestNonNumeric()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "non numeric", 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void InvalidInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidOverflowInstallmentsCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidNonActivityDatePriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidNonActivityDateCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidPerInstallmentsOverflowPriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidPerInstallmentOverflowCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidFutureDatePriorityTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = DBTestsCases.SendInvalidFutureDateCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
