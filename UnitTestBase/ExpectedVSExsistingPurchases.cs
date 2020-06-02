using System.Collections.Generic;
using Common;

namespace UnitTestBase
{
    //CR {711mikik} - MA ZE
    public class ExpectedVSExsistingPurchases
    {
        public List<PurchaseDBBody> ExpectedPurchases { get; set; }
        public List<PurchaseDBBody> ExistingPurchases { get; set; }

        public ExpectedVSExsistingPurchases(List<PurchaseDBBody> expectedPurchases, List<PurchaseDBBody> existingPurchases)
        {
            ExpectedPurchases = expectedPurchases;
            ExistingPurchases = existingPurchases;
        }
    }
}
