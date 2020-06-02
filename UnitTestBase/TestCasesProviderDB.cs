using Common;
using System.Collections.Generic;
using TestAutomaition;

namespace UnitTestBase
{
    public class TestCasesProviderDB : TestCasesProvider
    {
        //1
        public ExpectedVSExsistingPurchases SendInvalidCreditCardPriorityCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidByPriorityCSVLine CsvInvalidByPriorityRandomizer = new RandomizeInvalidByPriorityCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            switch (testCase)
            {
                case "numeric":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidCreditCardNunericLine());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;

                case "non numeric":
                    for (var i = 0; i < numOfLines; i++)
                    {
                        CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidCreditCardNonNunericLine());
                    }

                    rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
                    break;
            }

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public ExpectedVSExsistingPurchases SendInvalidOverflowInstallmentsCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidByPriorityCSVLine CsvInvalidByPriorityRandomizer = new RandomizeInvalidByPriorityCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();
            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidOverflowInstallments());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //3
        public ExpectedVSExsistingPurchases SendInvalidNonActivityDateCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidByPriorityCSVLine CsvInvalidByPriorityRandomizer = new RandomizeInvalidByPriorityCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();
            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidDateNonActivityPurchaseLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //4
        public ExpectedVSExsistingPurchases SendInvalidPerInstallmentOverflowCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidByPriorityCSVLine CsvInvalidByPriorityRandomizer = new RandomizeInvalidByPriorityCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();
            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidOverflowPerInstallmentLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //5
        public ExpectedVSExsistingPurchases SendInvalidFutureDateCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidByPriorityCSVLine CsvInvalidByPriorityRandomizer = new RandomizeInvalidByPriorityCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();
            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidByPriorityRandomizer.GetInvalidDateLaterThanInsertionLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            ExpectedVSExsistingPurchases existingAndExpectedPurchases = new ExpectedVSExsistingPurchases
                (new CSVFile(CSVLines).ExpectedDBBodyPurchases(), dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }
    }
}
