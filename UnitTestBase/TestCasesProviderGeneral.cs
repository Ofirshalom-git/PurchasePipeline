using Common;
using System.Collections.Generic;
using TestAutomaition;

namespace UnitTestBase
{
    public class TestCasesProviderGeneral : TestCasesProvider
    {
        //1
        public ExpectedVSExsistingPurchases SendPriceToRoundCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "upper round":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvLineRandomizer.RandomizeLineWithPriceToUpperRound());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "lower round":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvLineRandomizer.RandomizeLineWithPriceToLowerRound());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public ExpectedVSExsistingPurchases SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "over 5000":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvLineRandomizer.RandomizeLineWithPriceToDivideOver5000());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;


                case "below 5000":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvLineRandomizer.RandomizeLineWithPriceToDivideBelow5000());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            var expectedVSExsistingPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return expectedVSExsistingPurchases;
        }

        //3
        public ExpectedVSExsistingPurchases SendInValidPriceTypeCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineStringType());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //4
        public ExpectedVSExsistingPurchases SendValidInvalidForInsertionCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();
        
            CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineStringType());
            CSVLines.Add(CsvLineRandomizer.RandomizeLine());
            CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidStoreIdLineDigits());

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }
    }
}
