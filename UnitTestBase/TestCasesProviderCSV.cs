using System;
using System.Collections.Generic;
using Common;
using TestAutomaition;

namespace UnitTestBase
{
    public class TestCasesProviderCSV : TestCasesProvider
    {
        //1
        public ExpectedVSExsistingPurchases SendValidCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvLineRandomizer.RandomizeLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public ExpectedVSExsistingPurchases SendInvalidCSVLineStructute(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

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

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (purchaseFromDB, expectedList);

            return existingAndExpectedPurchases;
        }

        //3
        public ExpectedVSExsistingPurchases SendInValidDateFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //4
        public ExpectedVSExsistingPurchases SendInValidStoreIdFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }
        
        //5
        public ExpectedVSExsistingPurchases SendInValidPriceFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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


                case "string":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineStringType());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //6
        public ExpectedVSExsistingPurchases SendNegitiveInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidLineRandomizer.GetNegitiveInstallmentsLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //7
        public ExpectedVSExsistingPurchases SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }
    }
}
