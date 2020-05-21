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

        public RandomizeValidCSVLine()
        {
            Price = RandomizePayedPrice();
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
            String CredirCard = "";
            Random numberUnit = new Random();

            for(var i =0; i < 16; i++)
            {
                CredirCard += numberUnit.Next(0, 9);
            }

            return CredirCard.ToString();
        }

        public string RandomizePurchaseDate()
        {
            String purchaseDate = "";

            Random yearRnd = new Random();
            int year = (int)yearRnd.Next(1000, DateTime.Now.Year - 1);

            Random monthRnd = new Random();
            int month = (int)yearRnd.Next(1, 12);

            Random dayRnd = new Random();
            int day = (int)yearRnd.Next(1, 28);

            purchaseDate += $"{year}-{month}-{day}";

            return purchaseDate.ToString();
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
