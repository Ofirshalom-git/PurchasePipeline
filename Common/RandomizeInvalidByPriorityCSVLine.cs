using System;

namespace Common
{
    public class RandomizeInvalidByPriorityCSVLine
    {
        public string Price { get; set; }
        private RandomizeValidCSVLine ValidLineRandomizer { get; set; }
        private string StoreId { get; set; }
        private const string _dateFormat = "yyyy-MM-dd";

        public RandomizeInvalidByPriorityCSVLine(RandomizeValidCSVLine validLineRandomizer)
        {
            Price = new Random().Next(5001, 100000).ToString();
            ValidLineRandomizer = validLineRandomizer;
            StoreId = ValidLineRandomizer.RandomizeStoreId();
        }

        //credit card
        public CSVPurchaseLine GetInvalidCreditCardNunericLine() =>
            new CSVPurchaseLine(StoreId, "123456789012345", RandomizeFuturePurchaseDate(), Price, GetInvalidOverflowInstallments(Price));
        
        public CSVPurchaseLine GetInvalidCreditCardNonNunericLine() =>
            new CSVPurchaseLine(StoreId, "1Q2W3E4R5T6Y7U8I", RandomizeFuturePurchaseDate(), Price, GetInvalidOverflowInstallments(Price));

        //overflow installments
        public CSVPurchaseLine GetInvalidOverflowInstallments() =>
            new CSVPurchaseLine(StoreId, ValidLineRandomizer.GetCreditCardNumber(), RandomizeFuturePurchaseDate(), Price, RandomizeInvalidOverflowInstallments());

        //non activity date
        public CSVPurchaseLine GetInvalidDateNonActivityPurchaseLine() =>
            new CSVPurchaseLine("CC12345", ValidLineRandomizer.GetCreditCardNumber(), "1377-05-09", Price, GetValidInstallments(Price));

        //overflow per installment
        public CSVPurchaseLine GetInvalidOverflowPerInstallmentLine() =>
            new CSVPurchaseLine(StoreId, ValidLineRandomizer.GetCreditCardNumber(), RandomizeFuturePurchaseDate(), Price, GetInvalidOverflowInstallments(Price));

        //late date
        public CSVPurchaseLine GetInvalidDateLaterThanInsertionLine() =>
            new CSVPurchaseLine("AA12345", ValidLineRandomizer.GetCreditCardNumber(), RandomizeFuturePurchaseDate(), Price, GetValidInstallments(Price));

        //overflow installments
        private string RandomizeInvalidOverflowInstallments()
        {
            var price = (int)double.Parse(Price);
            Random rnd = new Random();
            //CR {711mikik} - why 10 and 100?
            return rnd.Next(price * 10 + 1, price * 100).ToString();
        }

        //late date
        private string RandomizeFuturePurchaseDate()
        {
            var day = int.Parse(new Random().Next(1, 28).ToString());
            var month = int.Parse(new Random().Next(1, 12).ToString());
            var year = int.Parse(new Random().Next(DateTime.Today.Year + 1, DateTime.Today.Year + 50).ToString());

            var lateDate = new DateTime(year, month, day).ToString(_dateFormat);
            return lateDate;
        }

        //overflow per installment
        private int GetValidInstallments(string price)
        {
            var installments = 1;
            while (double.Parse(price) / installments > 5000)
            {
                installments++;
            }

            return (installments);
        }

        private string GetInvalidOverflowInstallments(string price)
        {
            var installments = 0;
            while (double.Parse(price) / installments > 5000)
            {
                installments++;
            }

            return installments.ToString();
        }
    }
}
