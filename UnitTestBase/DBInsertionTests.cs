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
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "numeric", 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCreditCardReasonPriorityTestNonNumeric()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidCreditCardPriorityCSV(RabbitMQLogics, DBCommunication, "non numeric", 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void InvalidInstallmentsOverflowPriorityTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidOverflowInstallmentsCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidNonActivityDatePriorityTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidNonActivityDateCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidPerInstallmentsOverflowPriorityTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidPerInstallmentOverflowCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidFutureDatePriorityTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = DBTestsCases.SendInvalidFutureDateCSV(RabbitMQLogics, DBCommunication, 1);

            DBTestsCases.WhyInvalidReasonIsSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
