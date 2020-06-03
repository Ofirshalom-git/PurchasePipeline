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

        public List<PurchaseDBBody> ExpectedDBBodyPurchases() =>
            new List<PurchaseDBBody>(Purchases.Where(purchase => purchase.IsValidForDBInsertion()).Select(p=>p.ExpectedPurchaseDBBody()).ToList());
    }
}
