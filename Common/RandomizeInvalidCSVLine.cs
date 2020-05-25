using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetNegitiveInstallments());

        public CSVPurchaseLine GetLowerCaseFullInstallmentsLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, "full");

        public CSVPurchaseLine GetRandomalInstallmentsLine() =>
                    new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, GetRandomalStringInstallments());
                
        //price
        public CSVPurchaseLine GetInvalidPriceLineEmptyString() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), GetInvalidPriceEmptyString(), ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidPriceLineNumeric() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), GetInvalidPriceNumeric(), ValidLineRandomizer.RandomizeInstallments());

        //storeId
        public CSVPurchaseLine GetInvalidStoreIdLineLetters() =>
            new CSVPurchaseLine(GetInvalidStoreIdLetters(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineDigits() =>
            new CSVPurchaseLine(GetInvalidStoreIdDigits(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineType() =>
                    new CSVPurchaseLine(GetInvalidStoreIdType(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidStoreIdLineActivityDays() =>
                    new CSVPurchaseLine(GetInvalidStoreIdActivityDays(), ValidLineRandomizer.RandomizeCreditCard(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //date
        public CSVPurchaseLine GetInvalidDateFormatLineDot() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeInvalidDateFormatDot(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineOpposite() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeInvalidDateFormatOpposite(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidDateFormatLineMonth() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeInvalidDateFormatMonth(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //installments
        private string GetNegitiveInstallments()
        {
            String negativeInstallments = "";

            Random installmentsRnd = new Random();
            int installments = (int)installmentsRnd.Next(-5000, -1);

            negativeInstallments += installments;

            return negativeInstallments;
        }

        private string GetRandomalStringInstallments() => 
            new Guid().ToString();

        //price
        private string GetInvalidPriceEmptyString() =>
            "";

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
        private string GetInvalidStoreIdLetters()
        {
            String storeId = "";

            Random rnd = new Random();
            int storeType = (int)rnd.Next(65, 70);
            storeId += Char.ConvertFromUtf32(storeType);

            int storeActivityDays = (int)rnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(storeActivityDays);

            int spareLetter = (int)rnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(spareLetter);

            int storeNumericId = (int)rnd.Next(10000, 99999);
            storeId += storeNumericId.ToString();

            return storeId;
        }

        private string GetInvalidStoreIdDigits()
        {
            String storeId = "";

            Random rnd = new Random();
            int storeType = (int)rnd.Next(65, 70);
            storeId += Char.ConvertFromUtf32(storeType);

            int storeActivityDays = (int)rnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(storeActivityDays);

            int storeNumericId = (int)rnd.Next(100000, 999999);
            storeId += storeNumericId.ToString();

            return storeId;
        }

        private string GetInvalidStoreIdType()
        {
            String storeId = "";

            Random rnd = new Random();
            int storeType = (int)rnd.Next(71, 80);
            storeId += Char.ConvertFromUtf32(storeType);

            int storeActivityDays = (int)rnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(storeActivityDays);

            int storeNumericId = (int)rnd.Next(10000, 99999);
            storeId += storeNumericId.ToString();

            return storeId;
        }

        private string GetInvalidStoreIdActivityDays()
        {
            String storeId = "";

            Random rnd = new Random();
            int storeType = (int)rnd.Next(65, 70);
            storeId += Char.ConvertFromUtf32(storeType);

            int storeActivityDays = (int)rnd.Next(69, 80);
            storeId += Char.ConvertFromUtf32(storeActivityDays);

            int storeNumericId = (int)rnd.Next(10000, 99999);
            storeId += storeNumericId.ToString();

            return storeId;
        }

        //date
        private string RandomizeInvalidDateFormatDot()
        {
            String purchaseDate = "";

            Random yearRnd = new Random();
            int year = (int)yearRnd.Next(1000, DateTime.Now.Year - 1);

            Random monthRnd = new Random();
            int month = (int)yearRnd.Next(1, 12);

            Random dayRnd = new Random();
            int day = (int)yearRnd.Next(1, 28);

            purchaseDate += $"{year}.{month}.{day}";

            return purchaseDate.ToString();
        }

        private string RandomizeInvalidDateFormatOpposite()
        {
            String purchaseDate = "";

            Random yearRnd = new Random();
            int year = (int)yearRnd.Next(1000, DateTime.Now.Year - 1);

            Random monthRnd = new Random();
            int month = (int)yearRnd.Next(1, 12);

            Random dayRnd = new Random();
            int day = (int)yearRnd.Next(1, 28);

            purchaseDate += $"{day}-{month}-{year}";

            return purchaseDate.ToString();
        }

        private string RandomizeInvalidDateFormatMonth()
        {
            String purchaseDate = "";

            Random yearRnd = new Random();
            int year = (int)yearRnd.Next(1000, DateTime.Now.Year - 1);

            Random monthRnd = new Random();
            int month = (int)yearRnd.Next(13, 99);

            Random dayRnd = new Random();
            int day = (int)yearRnd.Next(1, 28);

            purchaseDate += $"{year}-{month}-{day}";

            return purchaseDate.ToString();
        }


    }
}
