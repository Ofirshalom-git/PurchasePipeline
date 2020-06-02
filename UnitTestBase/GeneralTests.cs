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

        //system bug:)
        [TestMethod]
        public void PricePerInstallmentOver5000SucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "over 5000", 3);

            GeneralTests.PricePerInstallmentOver5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void PricePerInstallmentBelow5000SucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "below 5000", 3);

            GeneralTests.PricePerInstallmentBelow5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendInValidPriceTypeCSVFile(RabbitMQLogics, DBCommunication, 3);

            GeneralTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //test succeed but fails because of a not relatedprice bug
        [TestMethod]
        public void InvalidFailsValidSucceedCSVLinesInsertionTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTests.SendValidInvalidForInsertionCSVFile(RabbitMQLogics, DBCommunication);

            GeneralTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }


    }
}
