using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using TestAutomaition;

namespace UnitTestBase
{
    public static class TestCasesProvider
    {
        public static bool DBPurchacesAreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if(expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }
        
            if(expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for(var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ((expectedAndExistingPurchaces[0][i].StoreType == expectedAndExistingPurchaces[1][i].StoreType
                    && expectedAndExistingPurchaces[0][i].ActivityDays == expectedAndExistingPurchaces[1][i].ActivityDays
                    && expectedAndExistingPurchaces[0][i].StoreID == expectedAndExistingPurchaces[1][i].StoreID
                    && expectedAndExistingPurchaces[0][i].CreditCard == expectedAndExistingPurchaces[1][i].CreditCard
                    && expectedAndExistingPurchaces[0][i].PurchaseDate == expectedAndExistingPurchaces[1][i].PurchaseDate
                    && expectedAndExistingPurchaces[0][i].InsertionDate == expectedAndExistingPurchaces[1][i].InsertionDate
                    && expectedAndExistingPurchaces[0][i].TotalPrice == expectedAndExistingPurchaces[1][i].TotalPrice
                    && expectedAndExistingPurchaces[0][i].Installments == expectedAndExistingPurchaces[1][i].Installments
                    && expectedAndExistingPurchaces[0][i].PricePerInstallment == expectedAndExistingPurchaces[1][i].PricePerInstallment
                    && expectedAndExistingPurchaces[0][i].IsValid == expectedAndExistingPurchaces[1][i].IsValid
                    && expectedAndExistingPurchaces[0][i].WhyInvalid == expectedAndExistingPurchaces[1][i].WhyInvalid) == false)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        //1
        public static List<List<PurchaseDBBody>> SendValidCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvLineRandomizer.RandomizeLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public static List<List<PurchaseDBBody>> SendInvalidCSVLineStructute(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            var randomizedLine = CsvLineRandomizer.RandomizeLine();

            String randomizedLineText = "";

            String CSVTextBody = "";

            if (testCase == ";")
            {
                var csvLine = rabbitMOLogics.ConvertCSVLineToText(randomizedLine);

                randomizedLineText = csvLine.Replace(',', ';');
            }

            if (testCase == "invalidNumOfFields")
            {
                var csvLine = rabbitMOLogics.ConvertCSVLineToText(randomizedLine);

                randomizedLineText += $"{csvLine},100";
            }

            for (var i = 0; i < numOfLines; i++)
            {
                CSVTextBody += $"{randomizedLineText}{Environment.NewLine}";
            }

            rabbitMOLogics.SendCSVStringBody(CSVTextBody);

            List<PurchaseDBBody> purchaseFromDB = dbLogics.GetAllPurchases();
            List<PurchaseDBBody> expectedList = new List<PurchaseDBBody>();

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(purchaseFromDB);
            existingAndExpectedPurchases.Add(expectedList);

            return existingAndExpectedPurchases;
        }

        //3
        public static List<List<PurchaseDBBody>> SendInValidDateFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "dot":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidDateFormatLineDot());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "opposite":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidDateFormatLineOpposite());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "month":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidDateFormatLineMonth());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //4
        public static List<List<PurchaseDBBody>> SendInValidStoreIdFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "letters":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineLetters());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "digits":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineDigits());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "type":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineType());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "activity days":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineActivityDays());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }
        
        //5
        public static List<List<PurchaseDBBody>> SendInValidPriceFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "empty string":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineEmptyString());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "numeric":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineNumeric());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //6
        public static List<List<PurchaseDBBody>> SendNegitiveInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidLineRandomizer.GetNegitiveInstallmentsLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
        
            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //7
        public static List<List<PurchaseDBBody>> SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "full":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetLowerCaseFullInstallmentsLine());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
                    
                case "random":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetRandomalInstallmentsLine());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

    }
}
