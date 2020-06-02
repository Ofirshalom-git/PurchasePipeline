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

        //installments
        public CSVPurchaseLine GetNegitiveInstallmentsLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(), 
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetNegitiveInstallments());

        public CSVPurchaseLine GetLowerCaseFullInstallmentsLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, "full");
        
        public CSVPurchaseLine GetRandomalInstallmentsLine() =>
                    new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetRandomalStringInstallments());
                
        //price
        public CSVPurchaseLine GetInvalidPriceLineEmptyString() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), "", ValidLineRandomizer.RandomizeInstallments());

        //price
        public CSVPurchaseLine GetInvalidPriceLineStringType() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), "feu3hu", ValidLineRandomizer.RandomizeInstallments());

        //storeId
        public CSVPurchaseLine GetInvalidStoreIdLineLetters() =>
            new CSVPurchaseLine(GetInvalidStoreIdLetters(), ValidLineRandomizer.GetCreditCardNumber(),
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineDigits() =>
            new CSVPurchaseLine(GetInvalidStoreIdDigits(), ValidLineRandomizer.GetCreditCardNumber(), 
                ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineType() =>
                    new CSVPurchaseLine(GetInvalidStoreIdType(), ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineActivityDays() =>
                    new CSVPurchaseLine(GetInvalidStoreIdActivityDays(), ValidLineRandomizer.GetCreditCardNumber(),
                        ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //date
        public CSVPurchaseLine GetInvalidDateFormatLineDot() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                GetInvalidDateFormatDot(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineOpposite() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                GetInvalidDateFormatOpposite(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineMonth() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(),
                GetInvalidDateFormatMonth(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //installments
        private string GetNegitiveInstallments()
        {
            Random installmentsRnd = new Random();
            int installments = (int)installmentsRnd.Next(-5000, -1);

            return installments.ToString();
        }

        private string GetRandomalStringInstallments() => 
            new Guid().ToString();

        private string GetInvalidPriceNumeric()
        {
            String payedPrice = "";

            Random priceRnd = new Random();
            int price = (int)priceRnd.Next(0, 5000);

            Random decimalPriceRnd = new Random();
            int decimalPrice = (int)decimalPriceRnd.Next(0, 100);

            payedPrice += $"{price}.{decimalPrice}";

            return payedPrice;
        }

        //storeId
        private string GetInvalidStoreIdLetters() =>
            "BCA12345";

        private string GetInvalidStoreIdDigits() =>
            "CA123456";

        private string GetInvalidStoreIdType() =>
            "KC12345";

        private string GetInvalidStoreIdActivityDays() =>
            "AZ12345";

        //date
        private string GetInvalidDateFormatDot() =>
            "2020.04.01";

        private string GetInvalidDateFormatOpposite() =>
            "01-04-2020";

        private string GetInvalidDateFormatMonth() =>
            "2020.43.01";
    }
}
