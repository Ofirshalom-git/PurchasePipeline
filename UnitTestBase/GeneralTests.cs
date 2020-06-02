using System;
using System.Collections.Generic;
using Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBase
{
    [TestClass]
    public class GeneralTests : UnitTestBase
    {
        //system bug:)
        [TestMethod]
        public void RoundingPriceUpperSucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, "upper round", 3);

            GeneralTests.RoundedPricesUpperAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void RoundingPriceLowerSucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, "lower round", 3);

            GeneralTests.RoundedPricesLowerAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, "lower round", 3);

            GeneralTests.PricePerInstallmentAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
