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
