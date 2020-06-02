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
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, "upper round", 3);

            GeneralTestsCases.RoundedPricesUpperAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void RoundingPriceLowerSucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, "lower round", 3);

            GeneralTestsCases.RoundedPricesLowerAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void PricePerInstallmentOver5000SucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "over 5000", 3);

            GeneralTestsCases.PricePerInstallmentOver5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //system bug:)
        [TestMethod]
        public void PricePerInstallmentBelow5000SucceedTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "below 5000", 3);

            GeneralTestsCases.PricePerInstallmentBelow5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendInValidPriceTypeCSVFile(RabbitMQLogics, DBCommunication, 3);

            GeneralTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //test succeed but fails because of a not related price bug
        [TestMethod]
        public void InvalidFailsValidSucceedCSVLinesInsertionTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = GeneralTestsCases.SendValidInvalidForInsertionCSVFile(RabbitMQLogics, DBCommunication);

            GeneralTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
