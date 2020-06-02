namespace UnitTestBase
{
    public class TestCasesProvider
    {
        public bool DBPurchacesAreSame(ExpectedVSExsistingPurchases expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == 0 && expectedAndExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == expectedAndExistingPurchaces.ExistingPurchases.Count)
            {
                int i = 0;
                foreach(var expectedPurchase in expectedAndExistingPurchaces.ExpectedPurchases)
                {
                    if ((expectedPurchase.StoreType == expectedAndExistingPurchaces.ExistingPurchases[i].StoreType
                    && expectedPurchase.ActivityDays == expectedAndExistingPurchaces.ExistingPurchases[i].ActivityDays
                    && expectedPurchase.StoreID == expectedAndExistingPurchaces.ExistingPurchases[i].StoreID
                    && expectedPurchase.CreditCard == expectedAndExistingPurchaces.ExistingPurchases[i].CreditCard
                    && expectedPurchase.PurchaseDate == expectedAndExistingPurchaces.ExistingPurchases[i].PurchaseDate
                    && expectedPurchase.InsertionDate == expectedAndExistingPurchaces.ExistingPurchases[i].InsertionDate
                    && expectedPurchase.TotalPrice == expectedAndExistingPurchaces.ExistingPurchases[i].TotalPrice
                    && expectedPurchase.Installments == expectedAndExistingPurchaces.ExistingPurchases[i].Installments
                    && expectedPurchase.PricePerInstallment == expectedAndExistingPurchaces.ExistingPurchases[i].PricePerInstallment
                    && expectedPurchase.IsValid == expectedAndExistingPurchaces.ExistingPurchases[i].IsValid
                    && expectedPurchase.WhyInvalid == expectedAndExistingPurchaces.ExistingPurchases[i].WhyInvalid) == false)
                    {
                        return false;
                    }

                    i++;
                }

                return true;
            }

            return false;
        }

        public bool WhyInvalidReasonIsSame(ExpectedVSExsistingPurchases expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == 0 && expectedAndExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == expectedAndExistingPurchaces.ExistingPurchases.Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces.ExpectedPurchases.Count; i++)
                {
                    if (expectedAndExistingPurchaces.ExpectedPurchases[i].WhyInvalid != expectedAndExistingPurchaces.ExistingPurchases[i].WhyInvalid)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool RoundedPricesUpperAreSame(ExpectedVSExsistingPurchases expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == 0 && expectedAndExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == expectedAndExistingPurchaces.ExistingPurchases.Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces.ExpectedPurchases.Count; i++)
                {
                    if ("67.5" != expectedAndExistingPurchaces.ExistingPurchases[i].TotalPrice.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool RoundedPricesLowerAreSame(ExpectedVSExsistingPurchases expectedAndExistingPurchaces)
        {
            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == 0 && expectedAndExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedAndExistingPurchaces.ExpectedPurchases.Count == expectedAndExistingPurchaces.ExistingPurchases.Count)
            {
                for (var i = 0; i < expectedAndExistingPurchaces.ExpectedPurchases.Count; i++)
                {
                    if ("39.4" != expectedAndExistingPurchaces.ExistingPurchases[i].TotalPrice.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool PricePerInstallmentOver5000AreSame(ExpectedVSExsistingPurchases expectedVSExistingPurchaces)
        {
            if (expectedVSExistingPurchaces.ExpectedPurchases.Count == 0 && expectedVSExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedVSExistingPurchaces.ExpectedPurchases.Count == expectedVSExistingPurchaces.ExistingPurchases.Count)
            {
                for (var i = 0; i < expectedVSExistingPurchaces.ExpectedPurchases.Count; i++)
                {
                    if ("6000" != expectedVSExistingPurchaces.ExistingPurchases[i].PricePerInstallment.ToString())
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool PricePerInstallmentBelow5000AreSame(ExpectedVSExsistingPurchases expectedVSExistingPurchaces)
        {
            if (expectedVSExistingPurchaces.ExpectedPurchases.Count == 0 && expectedVSExistingPurchaces.ExistingPurchases.Count == 0)
            {
                return true;
            }

            if (expectedVSExistingPurchaces.ExpectedPurchases.Count == expectedVSExistingPurchaces.ExistingPurchases.Count)
            {
                for (var i = 0; i < expectedVSExistingPurchaces.ExpectedPurchases.Count; i++)
                {
                    if ("3000" != expectedVSExistingPurchaces.ExistingPurchases[i].PricePerInstallment.ToString())
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
