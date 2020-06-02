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
        public ExpectedVSExsistingPurchases SendInvalidCSVLineStructute(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, CSVTestCases testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            var randomizedLine = CsvLineRandomizer.RandomizeLine();

            String randomizedLineText = "";

            String CSVTextBody = "";

            if (testCase == CSVTestCases.SEMI_COLON)
            {
                var csvLine = rabbitMOLogics.ConvertCSVLineToText(randomizedLine);

                randomizedLineText = csvLine.Replace(',', ';');
            }

            if (testCase == CSVTestCases.EXTRA_FIELDS)
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
        public ExpectedVSExsistingPurchases SendInValidDateFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, CSVTestCases testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case CSVTestCases.DOT:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidDateFormatLineDot());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;

                case CSVTestCases.OPPOSITE:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidDateFormatLineOpposite());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case CSVTestCases.MONTH:
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
        public ExpectedVSExsistingPurchases SendInValidStoreIdFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, CSVTestCases testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case CSVTestCases.LETTERS:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineLetters());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case CSVTestCases.DIGITS:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineDigits());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case CSVTestCases.TYPE:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineType());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case CSVTestCases.ACTIVITY_DAYS:
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
        public ExpectedVSExsistingPurchases SendInValidPriceFormatCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, CSVTestCases testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case CSVTestCases.EMPTY_STRING:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineEmptyString());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case CSVTestCases.STRING:
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
        public ExpectedVSExsistingPurchases SendInvalidNonFullStringInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, CSVTestCases testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case CSVTestCases.FULL:
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidLineRandomizer.GetLowerCaseFullInstallmentsLine());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
                    
                case CSVTestCases.RANDOM:
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
