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
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(RabbitMQLogics, DBCommunication, 1);
            for(var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void ValidCSVInsertionSucceedTest2()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendValidCSVFile(RabbitMQLogics, DBCommunication, 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
        
        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest1()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 1);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                Console.WriteLine(expectedAndExistingPurchases[0].Count);
                Console.WriteLine(expectedAndExistingPurchases[1].Count);
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest2()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 1);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest3()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, ";", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidCSVLineStructuteInsertionFailsTest4()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidCSVLineStructute(RabbitMQLogics, DBCommunication, "invalidNumOfFields", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
                
        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestDot()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "dot", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
        
        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestOpposite()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "opposite", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
        
        [TestMethod]
        public void InvalidDateFormatCSVLineInsertionFailsTestMonth()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidDateFormatCSVFile(RabbitMQLogics, DBCommunication, "month", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
                
        [TestMethod]
        public void InvalidStoreIdLettersCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "letters", 3);
            for (var i = 1; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidStoreIdDigitsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "digits", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidStoreIdTypeCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "type", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void InvalidStoreIdActivityDaysCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidStoreIdFormatCSVFile(RabbitMQLogics, DBCommunication, "activity days", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void EmptyStringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "empty string", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void NumericStringPriceCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInValidPriceFormatCSVFile(RabbitMQLogics, DBCommunication, "numeric", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {

                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void NegitiveInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendNegitiveInstallmentsCSVFile(RabbitMQLogics, DBCommunication, 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
        
        [TestMethod]
        public void LowerCaseFullStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "full", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }

        [TestMethod]
        public void RandomalStringInstallmentsCSVLineInsertionFailsTest()
        {
            List<List<PurchaseDBBody>> expectedAndExistingPurchases = TestCasesProvider.SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics, DBCommunication, "random", 3);
            for (var i = 0; i < expectedAndExistingPurchases[0].Count; i++)
            {
                expectedAndExistingPurchases[0][i].Should().BeSameAs(expectedAndExistingPurchases[1][i]);
            }
        }
    }
}
