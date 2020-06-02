using System;

namespace Common
{
    public class RandomizeInvalidCSVLine
    {
        RandomizeValidCSVLine ValidLineRandomizer { get; set; }

        public RandomizeInvalidCSVLine(RandomizeValidCSVLine validLineRandomizer)
        {
            ValidLineRandomizer = validLineRandomizer;
        }

        public CSVPurchaseLine GetNegitiveInstallmentsLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(), 
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetNegitiveInstallments());

        public CSVPurchaseLine GetLowerCaseFullInstallmentsLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, "full");
        
        public CSVPurchaseLine GetRandomalInstallmentsLine() =>
                    new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetRandomalStringInstallments());
                
        public CSVPurchaseLine GetInvalidPriceLineEmptyString() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), "", ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidPriceLineStringType() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), "feu3hu", ValidLineRandomizer.RandomizeInstallments());
        
        public CSVPurchaseLine GetInvalidStoreIdLineLetters() =>
            new CSVPurchaseLine("BCA12345", ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineDigits() =>
            new CSVPurchaseLine("CA123456", ValidLineRandomizer.GetCreditCardNumber(), 
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineType() =>
                    new CSVPurchaseLine("KC12345", ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineActivityDays() =>
                    new CSVPurchaseLine("AZ12345", ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());
        public CSVPurchaseLine GetInvalidDateFormatLineDot() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                "2020.04.01", ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineOpposite() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                "01-04-2020", ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineMonth() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                "2020-43-01", ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        private string GetNegitiveInstallments()
        {
            Random installmentsRnd = new Random();
            int installments = installmentsRnd.Next(-5000, -1);

            return installments.ToString();
        }

        private string GetRandomalStringInstallments() => 
            new Guid().ToString();
    }
}
