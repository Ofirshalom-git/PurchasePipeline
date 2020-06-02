using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class CSVFile
    {
        public List<CSVPurchaseLine> Purchases { get; set; }

        public CSVFile(List<CSVPurchaseLine> purchases)
        {
            Purchases = purchases;
        }

        public List<PurchaseDBBody> ExpectedDBBodyPurchases()
        {
            List<PurchaseDBBody> expectedPurchases = new List<PurchaseDBBody>();
            //CR {711mikik} - use link...
            foreach (var purchase in Purchases)
            {
                if (purchase.IsValidForDBInsertion())
                {
                    expectedPurchases.Add(purchase.ExpectedPurchaseDBBody());
                }
            }

            //Purchases.Where(purchase => purchase.IsValidForDBInsertion() == true)
            return expectedPurchases;
        }
    }
}
