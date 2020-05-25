using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new CSVPurchaseLine(_storeId, RandomizeCreditCard(), RandomizePurchaseDate(), Price, RandomizeInstallments());
        
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

        public string RandomizeCreditCard()
        {
            return "4557446145890236";
        }

        private bool BoughtOnActivityDay(DateTime date)
        {
            switch (_storeId[1])
            {
                case 'A':
                    return true;
                        break;

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
                    break;
            }

            return false;
        }

        public string RandomizePurchaseDate()
        {
            int year, month, day;
            DateTime date;

            do //date is not on an open day
            {
                year = _yearRnd.Next(1000, DateTime.Now.Year - 1);
                month = _monthRnd.Next(1, 12);
                day = _dayRnd.Next(1, 28);

                date = new DateTime(year, month, day);
            }

            while (!BoughtOnActivityDay(date));

            return $"{year}-{month:D2}-{day:D2}";

            //int year = (int)_yearRnd.Next(1000, DateTime.Now.Year - 1);

            //int month = (int)_monthRnd.Next(1, 12);

            //int day = (int)_dayRnd.Next(1, 28);

            //return $"{year}-{month:D2}-{day:D2}";
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
            Random intOrStringRnd = new Random();
            int intOrString = (int)intOrStringRnd.Next(0, 9);

            switch (intOrString)
            {
                case 0:
                    return "FULL";
                case 1:
                    return "";
                default:
                    return new Random().Next(0, (int)Convert.ToDouble(Price) * 10).ToString();
            }
        }
    }
}
