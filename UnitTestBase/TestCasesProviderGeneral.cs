using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomaition;

namespace UnitTestBase
{
    public class TestCasesProviderGeneral : TestCasesProvider
    {

        //1
        public List<List<PurchaseDBBody>> SendPriceToRoundCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public List<List<PurchaseDBBody>> SendPriceToDivideToInstallmentsCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }


        //3
        public List<List<PurchaseDBBody>> SendInValidPriceTypeCSVFile(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, int numOfLines)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            RandomizeInvalidCSVLine CsvInvalidLineRandomizer = new RandomizeInvalidCSVLine(CsvLineRandomizer);

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvInvalidLineRandomizer.GetInvalidPriceLineStringType());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

    }
}
