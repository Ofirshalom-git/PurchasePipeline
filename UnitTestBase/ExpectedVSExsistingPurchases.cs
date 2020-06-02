using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace UnitTestBase
{
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
