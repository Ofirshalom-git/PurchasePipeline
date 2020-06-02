using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using System.Collections.Generic;


namespace UnitTestBase
{
    [TestClass]
    public class CSVTests : UnitTestBase
    {
        [TestMethod]
        public void ValidCSVInsertionSucceedTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendValidCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
        
        [TestMethod]
        public void InvalidCSVStructuteSemiColonInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVStructuteExtraFieldsInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestDot()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "dot", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestOpposite()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "opposite", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestMonth()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "month", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdLettersCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "letters", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdDigitsCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "digits", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdTypeCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "type", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdActivityDaysCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "activity days", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void EmptyStringPriceCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "empty string", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "string", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void NegitiveInstallmentsCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendNegitiveInstallmentsCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void LowerCaseFullStringInstallmentsCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "full", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            ExpectedVSExsistingPurchases expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "random", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
