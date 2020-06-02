using System;

namespace Common
{
    public class RandomizeValidCSVLine
    {
        public string Price { get; set; }
        private static Random _numberUnit { get; set; }
        private static Random _yearRnd { get; set; }
        private static Random _monthRnd { get; set; }
        private static Random _dayRnd { get; set; }
        private static string _storeId {get; set;}

        public RandomizeValidCSVLine()
        {
            Price = RandomizePayedPrice();
            _numberUnit = new Random();
            _yearRnd = new Random();
            _monthRnd = new Random();
            _dayRnd = new Random();
            _storeId = RandomizeStoreId();
        }
        
        public CSVPurchaseLine RandomizeLine() =>
            new CSVPurchaseLine(_storeId, GetCreditCardNumber(), RandomizePurchaseDate(), Price, RandomizeInstallments());

        public string RandomizeStoreId()
        {
            String storeId = "";

            Random rnd = new Random();
            int storeType = (int)rnd.Next(65, 70);
            storeId += Char.ConvertFromUtf32(storeType);

            int storeActivityDays = (int)rnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(storeActivityDays);

            int storeNumericId = (int)rnd.Next(10000, 99999);
            storeId += storeNumericId.ToString();

            return storeId;
        }

        public string GetCreditCardNumber() =>
            "4557446145890236";

        public bool BoughtOnActivityDay(DateTime date)
        {
            switch (_storeId[1])
            {
                case 'A':
                    return true;

                case 'B':
                    if(date.DayOfWeek != DayOfWeek.Saturday)
                    {
                        return true;
                    }

                    break;

                case 'C':
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Friday)
                    {
                        return true;
                    }

                    break;

                case 'D':
                    return true;
            }

            return false;
        }

        public string RandomizePurchaseDate()
        {
            int year, month, day;
            DateTime date;

            do 
            {
                year = _yearRnd.Next(1000, DateTime.Now.Year - 1);
                month = _monthRnd.Next(1, 12);
                day = _dayRnd.Next(1, 28);

                date = new DateTime(year, month, day);
            }

            while (!BoughtOnActivityDay(date));

            return date.ToString("yyyy-MM-dd");
        }

        public string RandomizePayedPrice()
        {
            String payedPrice = "";

            Random priceRnd = new Random();
            int price = (int)priceRnd.Next(0, 5000);

            Random decimalPriceRnd = new Random();
            int decimalPrice = (int)decimalPriceRnd.Next(0, 100);

            payedPrice += $"{price}.{decimalPrice}";

            return payedPrice;
        }

        public string RandomizeInstallments()
        {
            var intOrString = new Random().Next(0, 9);

            switch (intOrString)
            {
                case 0:
                    return "FULL";
                
                case 1:
                    return "";                
            }

            return new Random().Next(0, (int)Convert.ToDouble(Price) * 10).ToString();
        }

        public CSVPurchaseLine RandomizeLineWithPriceToUpperRound() =>
            new CSVPurchaseLine(_storeId, GetCreditCardNumber(), RandomizePurchaseDate(), "67.48", RandomizeInstallments());

        public CSVPurchaseLine RandomizeLineWithPriceToLowerRound() =>
            new CSVPurchaseLine(_storeId, GetCreditCardNumber(), RandomizePurchaseDate(), "39.45", RandomizeInstallments());

        public CSVPurchaseLine RandomizeLineWithPriceToDivideOver5000() =>
            new CSVPurchaseLine(_storeId, GetCreditCardNumber(), RandomizePurchaseDate(), "18000", "3");

        public CSVPurchaseLine RandomizeLineWithPriceToDivideBelow5000() =>
            new CSVPurchaseLine(_storeId, GetCreditCardNumber(), RandomizePurchaseDate(), "18000", "6");
    }
}
