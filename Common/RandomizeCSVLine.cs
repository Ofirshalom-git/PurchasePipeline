using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RandomizeCSVLine
    {
        public string Price { get; set; }

        public RandomizeCSVLine()
        {
            Price = RandomizePayedPrice();
        }
        
        public CSVPurchaseLine RandomizeLine() =>
            new CSVPurchaseLine(RandomizeStoreId(), RandomizeCreditCard(), RandomizePurchaseDate(), Price, RandomizeInstallments());
        
        private string RandomizeStoreId()
        {
            String storeId = "";
            //TODO: extract to method (26-28, 30-32, 34-37 it's repetitive)

            Random storeTypeRnd = new Random();
            int storeType = (int)storeTypeRnd.Next(65, 70);
            storeId += Char.ConvertFromUtf32(storeType);
            //TODO: why do you create another random?
            Random storeActivityDaysRnd = new Random();
            int storeActivityDays = (int)storeActivityDaysRnd.Next(65, 68);
            storeId += Char.ConvertFromUtf32(storeActivityDays);
            //TODO: why do you create another random?
            Random storeNumericIdRnd = new Random();
            int storeNumericId = (int)storeNumericIdRnd.Next(10000, 99999);
            storeId += storeNumericId.ToString();


            return storeId.ToString();
        }

        private string RandomizeCreditCard()
        {
            String CredirCard = "";
            Random numberUnit = new Random();

            for(var i =0; i < 16; i++)
            {
                CredirCard += numberUnit.Next(0, 9);
            }

            return CredirCard.ToString();
        }

        private string RandomizePurchaseDate()
        {
            String purchaseDate = "";

            Random yearRnd = new Random();
            int year = (int)yearRnd.Next(1000, DateTime.Now.Year - 1);

            //TODO: why do you create another random?
            Random monthRnd = new Random();
            int month = (int)yearRnd.Next(1, 12);

            Random dayRnd = new Random();
            int day = (int)yearRnd.Next(1, 28);

            purchaseDate += $"{year}-{month}-{day}";

            return purchaseDate.ToString();
        }

        private string RandomizePayedPrice()
        {
            String payedPrice = "";

            Random priceRnd = new Random();
            int price = (int)priceRnd.Next(0, 5000);

            Random decimalPriceRnd = new Random();
            int decimalPrice = (int)decimalPriceRnd.Next(0, 100);

            payedPrice += $"{price}.{decimalPrice}";

            return payedPrice;
        }

        private string RandomizeInstallments()
        {
            String installments = "";

            Random intOrStringRnd = new Random();
            int intOrString = (int)intOrStringRnd.Next(0, 9);

            switch (intOrString)
            {
                case 0:
                    installments += "FULL";
                    break;

                case 1:
                    installments += "";
                    break;

                default:
                    Random installmentsRnd = new Random();
                    installments += (int)installmentsRnd.Next(0, int.Parse(Price) * 10);
                    break;
            }

            return installments;            
        }
    }
}
