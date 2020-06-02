using System;

namespace Common
{
    //CR {711mikik} - This entire class looks the same as CSVPurchaseLine.... everything is duplicated more or less
    public class RandomizeValidCSVLine
    {
        public string Price { get; set; }
        //CR {711mikik} - why underline?
        private Random NumberUnit { get; set; }
        private Random YearRnd { get; set; }
        private Random MonthRnd { get; set; }
        private Random DayRnd { get; set; }
        private string StoreId {get; set;}

        public RandomizeValidCSVLine()
        {
            Price = RandomizePayedPrice();
            NumberUnit = new Random();
            YearRnd = new Random();
            MonthRnd = new Random();
            DayRnd = new Random();
            StoreId = RandomizeStoreId();
        }
        
        public CSVPurchaseLine RandomizeLine() =>
            new CSVPurchaseLine(StoreId, GetCreditCardNumber(), RandomizePurchaseDate(), Price, RandomizeInstallments());

        //CR {711mikik} - why not just make one and use it? why randomize?
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
        //CR {711mikik} - again with the one line thing
        public string GetCreditCardNumber() =>
            "4557446145890236";

        public bool BoughtOnActivityDay(DateTime date)
        {
            //CR {711mikik} - you did this code already..... find a way to make it to one method
            switch (StoreId[1])
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
                year = YearRnd.Next(1000, DateTime.Now.Year - 1);
                month = MonthRnd.Next(1, 12);
                day = DayRnd.Next(1, 28);

                date = new DateTime(year, month, day);
            }

            while (!BoughtOnActivityDay(date));

            return date.ToString("yyyy-MM-dd");
        }

        public string RandomizePayedPrice()
        {
            String payedPrice = "";

            Random priceRnd = new Random();
            int price = priceRnd.Next(0, 5000);

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
            new CSVPurchaseLine(StoreId, GetCreditCardNumber(), RandomizePurchaseDate(), "67.48", RandomizeInstallments());

        public CSVPurchaseLine RandomizeLineWithPriceToLowerRound() =>
            new CSVPurchaseLine(StoreId, GetCreditCardNumber(), RandomizePurchaseDate(), "39.45", RandomizeInstallments());

        public CSVPurchaseLine RandomizeLineWithPriceToDivideOver5000() =>
            new CSVPurchaseLine(StoreId, GetCreditCardNumber(), RandomizePurchaseDate(), "18000", "3");

        public CSVPurchaseLine RandomizeLineWithPriceToDivideBelow5000() =>
            new CSVPurchaseLine(StoreId, GetCreditCardNumber(), RandomizePurchaseDate(), "18000", "6");
    }
}
