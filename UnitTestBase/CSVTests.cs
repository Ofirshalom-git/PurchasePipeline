using System;
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
        public void ValidCSVInsertionSucceedTest1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendValidCSVFile(RabbitMQLogics, DBCommunication, 1);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void ValidCSVInsertionSucceedTest2()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendValidCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
        
        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 1);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest2()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 1);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest3()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest4()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestDot()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "dot", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestOpposite()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "opposite", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestMonth()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "month", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdLettersCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "letters", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdDigitsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "digits", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdTypeCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "type", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void InvalidStoreIdActivityDaysCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "activity days", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void EmptyStringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "empty string", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void NumericStringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "numeric", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void NegitiveInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendNegitiveInstallmentsCSVFile(RabbitMQLogics, DBCommunication, 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void LowerCaseFullStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "full", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = CSVTests.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "random", 3);

            CSVTests.DBPurchacesAreSame(expectedAndExistingPurchases).Should().BeTrue();
        }
    }
}
