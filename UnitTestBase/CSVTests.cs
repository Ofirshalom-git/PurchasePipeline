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
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendValidCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
        
        [TestMethod]
        public void InvalidCSVStructuteSemiColonInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVStructuteExtraFieldsInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestDot()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "dot", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestOpposite()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "opposite", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestMonth()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "month", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdLettersCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "letters", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdDigitsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "digits", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdTypeCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "type", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdActivityDaysCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "activity days", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void EmptyStringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "empty string", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void StringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "string", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void NegitiveInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendNegitiveInstallmentsCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void LowerCaseFullStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "full", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTestsCases.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "random", 3);

            CSVTestsCases.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
