using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CSVFile
    {
        public List<CSVPurchaseLine> Purchases { get; set; }

        public CSVFile()
        {

        }

        public CSVFile(List<CSVPurchaseLine> purchases)
        {
            Purchases = purchases;
        }

        public List<PurchaseDBBody> ExpectedDBBodyPurchases()
        {
            List<PurchaseDBBody> expectedPurchases = new List<PurchaseDBBody>();

            foreach(var purchase in Purchases)
            {
                if (purchase.isValidForDB())
                {
                    PurchaseDBBody expectedPurchase = new PurchaseDBBody("unknown", purchase.StoreID[0]);
                    
                    //create expected db body

                    expectedPurchases.Add(expectedPurchase);
                }
            }

            
        }
    }
}
