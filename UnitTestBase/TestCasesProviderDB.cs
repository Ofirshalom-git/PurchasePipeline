using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomaition;

namespace UnitTestBase
{
    public class TestCasesProviderDB : TestCasesProvider
    {
        //DB insertion tests

        //1
        public List<List<PurchaseDBBody>> SendInvalidCreditCardPriorityCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }

        //2
        public List<List<PurchaseDBBody>> SendInvalidOverflowInstallmentsCSV(RabbitMQLogics rabbitMOLogics, DBCommunication dbLogics, string testCase, int numOfLines)
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

            List<List<PurchaseDBBody>> existingAndExpectedPurchases = new List<List<PurchaseDBBody>>();
            existingAndExpectedPurchases.Add(new CSVFile(CSVLines).ExpectedDBBodyPurchases());
            existingAndExpectedPurchases.Add(dbLogics.GetAllPurchases());

            return existingAndExpectedPurchases;
        }



    }
}
