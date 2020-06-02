using Common;
using System.Collections.Generic;

namespace UnitTestBase
{
    public class TestCasesProvider
    {
        public bool DBPurchacesAreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ((expectedAndExistingPurchaces[0][i].StoreType == expectedAndExistingPurchaces[1][i].StoreType
                    && expectedAndExistingPurchaces[0][i].ActivityDays == expectedAndExistingPurchaces[1][i].ActivityDays
                    && expectedAndExistingPurchaces[0][i].StoreID == expectedAndExistingPurchaces[1][i].StoreID
                    && expectedAndExistingPurchaces[0][i].CreditCard == expectedAndExistingPurchaces[1][i].CreditCard
                    && expectedAndExistingPurchaces[0][i].PurchaseDate == expectedAndExistingPurchaces[1][i].PurchaseDate
                    && expectedAndExistingPurchaces[0][i].InsertionDate == expectedAndExistingPurchaces[1][i].InsertionDate
                    && expectedAndExistingPurchaces[0][i].TotalPrice == expectedAndExistingPurchaces[1][i].TotalPrice
                    && expectedAndExistingPurchaces[0][i].Installments == expectedAndExistingPurchaces[1][i].Installments
                    && expectedAndExistingPurchaces[0][i].PricePerInstallment == expectedAndExistingPurchaces[1][i].PricePerInstallment
                    && expectedAndExistingPurchaces[0][i].IsValid == expectedAndExistingPurchaces[1][i].IsValid
                    && expectedAndExistingPurchaces[0][i].WhyInvalid == expectedAndExistingPurchaces[1][i].WhyInvalid) == false)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool WhyInvalidReasonIsSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if (expectedAndExistingPurchaces[0][i].WhyInvalid != expectedAndExistingPurchaces[1][i].WhyInvalid)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool RoundedPricesUpperAreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ("67.5" != expectedAndExistingPurchaces[1][i].TotalPrice.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool RoundedPricesLowerAreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ("39.4" != expectedAndExistingPurchaces[1][i].TotalPrice.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool PricePerInstallmentOver5000AreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ("6000" != expectedAndExistingPurchaces[1][i].PricePerInstallment.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool PricePerInstallmentBelow5000AreSame(List<List<PurchaseDBBody>> expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces[0].Count == 0 && expectedAndExistingPurchaces[1].Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces[0].Count == expectedAndExistingPurchaces[1].Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces[0].Count; i++)
                {
                    if ("3000" != expectedAndExistingPurchaces[1][i].PricePerInstallment.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
