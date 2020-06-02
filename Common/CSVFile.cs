using System.Collections.Generic;

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

            foreach(var purchase in Purchases)
            {
                if (purchase.IsValidForDBInsertion())
                {
                    expectedPurchases.Add(purchase.ExpectedPurchaseDBBody());
                }
            }

            return expectedPurchases;
        }
    }
}
