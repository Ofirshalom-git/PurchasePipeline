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
        //1
        public static List<List<PurchaseDBBody>> SendValidCSVFile(RabbitMQLogics rabbitMOLogics, DBLogics dbLogics, int numOfLines)
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
        public static List<List<PurchaseDBBody>> SendInvalidCSVLineStructute(RabbitMQLogics rabbitMOLogics, DBLogics dbLogics, dynamic testCase)
        {
            RandomizeValidCSVLine CsvLineRandomizer = new RandomizeValidCSVLine();

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            var randomizedLine = CsvLineRandomizer.RandomizeLine();

            String randomizedLineText = "";

            String CSVTextBody = "";

            if (testCase == ';')
            {
                var csvLine = rabbitMOLogics.ConvertCSVLineToText(randomizedLine);

                randomizedLineText = csvLine.Replace(',', ';');
            }

            if (testCase == "invalidNumOfFields")
            {
                var csvLine = rabbitMOLogics.ConvertCSVLineToText(randomizedLine);

                randomizedLineText += $"{csvLine},100";
            }

            for (var i = 0; i < 3; i++)
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
        public static List<List<PurchaseDBBody>> SendValidCSVFile(int numOfLines, RabbitMQLogics rabbitMOLogics, DBLogics dbLogics)
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


    }
}
