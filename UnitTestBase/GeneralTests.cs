using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBase
{
    [TestClass]
    public class GeneralTests : UnitTestBase
    {
        //CR {711mikik} - weird comment. What does it mean?
        //system bug:)
        [TestMethod]
        public void RoundingPriceUpperSucceedTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, GeneralTestCases.UPPER_ROUND, 3);

            GeneralTestsCases.RoundedPricesUpperAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //CR {711mikik} - weird comment. What does it mean?
        //system bug:)
        [TestMethod]
        public void RoundingPriceLowerSucceedTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendPriceToRoundCSVFile(RabbitMQLogics, DBCommunication, GeneralTestCases.LOWER_ROUND, 3);

            GeneralTestsCases.RoundedPricesLowerAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //CR {711mikik} - weird comment. What does it mean?
        //system bug:)
        [TestMethod]
        public void PricePerInstallmentOver5000SucceedTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, GeneralTestCases.OVER_5000, 3);

            GeneralTestsCases.PricePerInstallmentOver5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
        //CR {711mikik} - weird comment. What does it mean?
        //system bug:)
        [TestMethod]
        public void PricePerInstallmentBelow5000SucceedTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics, DBCommunication, GeneralTestCases.BELOW_5000, 3);

            GeneralTestsCases.PricePerInstallmentBelow5000AreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendInValidPriceTypeCSVFile(RabbitMQLogics, DBCommunication, 3);

            GeneralTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        //test succeed but fails because of a not related price bug
        [TestMethod]
        public void InvalidFailsValidSucceedCSVLinesInsertionTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = GeneralTestsCases.SendValidInvalidForInsertionCSVFile(RabbitMQLogics, DBCommunication);

            GeneralTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
