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
        public static void SendValidCSVFile(int numOfLines, RabbitMQLogics rabbitMOLogics)
        {
            RandomizeCSVLine CsvLineRandomizer = new RandomizeCSVLine();

            List<CSVPurchaseLine> CSVLines = new List<CSVPurchaseLine>();

            for (var i = 0; i < numOfLines; i++)
            {
                CSVLines.Add(CsvLineRandomizer.RandomizeLine());
            }

            rabbitMOLogics.SendCSVToRabbitMQ(new CSVFile(CSVLines));
        }
    }
}
