using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;


namespace UnitTestBase
{
    [TestClass]
    public class CSVTests : UnitTestBase
    {
        [TestMethod]
        public void ValidCSVInsertionSucceedTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendValidCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
        
        [TestMethod]
        public void InvalidCSVStructuteSemiColonInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, CSVTestCases.SEMI_COLON, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVStructuteExtraFieldsInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, CSVTestCases.EXTRA_FIELDS, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestDot()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.DOT, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestOpposite()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.OPPOSITE, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestMonth()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.MONTH, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdLettersCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.LETTERS, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdDigitsCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.DIGITS, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdTypeCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.TYPE, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdActivityDaysCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.ACTIVITY_DAYS, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void EmptyStringPriceCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.EMPTY_STRING, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.STRING, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void NegitiveInstallmentsCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendNegitiveInstallmentsCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void LowerCaseFullStringInstallmentsCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.FULL, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            var expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, CSVTestCases.RANDOM, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
