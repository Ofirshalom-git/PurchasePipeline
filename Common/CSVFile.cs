using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CSVFile
    {
        public List<Purchace> Purchases { get; set; }

        public CSVFile()
        {

        }

        public CSVFile(List<Purchace> purchases)
        {
            Purchases = purchases;
        }
    }
}
