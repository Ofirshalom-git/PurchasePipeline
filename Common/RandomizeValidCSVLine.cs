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

        public RandomizeValidCSVLine()
        {
            Price = RandomizePayedPrice();
            _numberUnit = new Random();
            _yearRnd = new Random();
            _monthRnd = new Random();
            _dayRnd = new Random();
        }
        
        public CSVPurchaseLine RandomizeLine() =>
            new CSVPurchaseLine(RandomizeStoreId(), RandomizeCreditCard(), RandomizePurchaseDate(), Price, RandomizeInstallments());
        
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
            //String CredirCard = "";

            //for(var i =0; i < 16; i++)
            //{
            //    CredirCard += _numberUnit.Next(0, 9);
            //}

            //return CredirCard.ToString();

            return "4557446145890236";
        }

        public string RandomizePurchaseDate()
        {
            int year = (int)_yearRnd.Next(1000, DateTime.Now.Year - 1);

            int month = (int)_monthRnd.Next(1, 12);

            int day = (int)_dayRnd.Next(1, 28);

            return $"{year}-{month:D2}-{day:D2}";
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
