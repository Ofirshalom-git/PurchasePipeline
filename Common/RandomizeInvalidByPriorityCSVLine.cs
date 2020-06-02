using System;

namespace Common
{
    public class RandomizeInvalidByPriorityCSVLine
    {
        public string Price { get; set; }
        private RandomizeValidCSVLine ValidLineRandomizer { get; set; }
        private Random _yearRnd = new Random();
        private Random _monthRnd = new Random();
        private Random _dayRnd = new Random();
        private string _storeId { get; set; }

        public RandomizeInvalidByPriorityCSVLine(RandomizeValidCSVLine validLineRandomizer)
        {
            Price = RandomizeOverFiveThousandPrice(); 
            ValidLineRandomizer = validLineRandomizer;
            _storeId = ValidLineRandomizer.RandomizeStoreId();
        }

        //credit card
        public CSVPurchaseLine GetInvalidCreditCardNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), GetInvalidCreditCardNumeric(), RandomizeLatePurchaseDate(), Price, GetInvalidOverflowInstallments(Price));

        public CSVPurchaseLine GetInvalidCreditCardNonNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), GetInvalidCreditCardNonNumeric(), RandomizeLatePurchaseDate(), Price, GetInvalidOverflowInstallments(Price));

        //overflow installments
        public CSVPurchaseLine GetInvalidOverflowInstallments() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(), RandomizeLatePurchaseDate(), Price, RandomizeInvalidOverflowInstallments());

        //non activity date
        public CSVPurchaseLine GetInvalidDateNonActivityPurchaseLine() =>
            new CSVPurchaseLine("CC12345", ValidLineRandomizer.GetCreditCardNumber(), "1377-05-09", Price, GetValidInstallments(Price));

        //overflow per installment
        public CSVPurchaseLine GetInvalidOverflowPerInstallmentLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.GetCreditCardNumber(), RandomizeLatePurchaseDate(), Price, RandomizeInvalidOverflowPerInstallment(Price));

        //late date
        public CSVPurchaseLine GetInvalidDateLaterThanInsertionLine() =>
            new CSVPurchaseLine("AA12345", ValidLineRandomizer.GetCreditCardNumber(), RandomizeLatePurchaseDate(), Price, GetValidInstallments(Price));

        //credit card
        private string GetInvalidCreditCardNumeric() =>
            "123456789012345";

        private string GetInvalidCreditCardNonNumeric() =>
            "1Q2W3E4R5T6Y7U8I";

        //overflow installments
        private string RandomizeInvalidOverflowInstallments()
        {
            var price = (int)double.Parse(Price);
            Random rnd = new Random();

            return rnd.Next(price * 10 + 1, price * 100).ToString();
        }
        
        //overflow per installment
        private string RandomizeInvalidOverflowPerInstallment(string price)
        {
            var installments = 1;
            while(double.Parse(price) / installments > 5000)
            {
                installments++;
            }

            return (installments - 1).ToString();
        }

        private string RandomizeOverFiveThousandPrice() =>
            new Random().Next(5001, 100000).ToString();

        //late date
        private string RandomizeLatePurchaseDate()
        {
            var day = int.Parse(new Random().Next(1, 28).ToString());
            var month = int.Parse(new Random().Next(1, 12).ToString());
            var year = int.Parse(new Random().Next(DateTime.Today.Year + 1, DateTime.Today.Year + 50).ToString());

            var lateDate = new DateTime(year, month, day).ToString("yyyy-MM-dd");
            return lateDate;
        }

        private int GetValidInstallments(string price)
        {
            var installments = 1;
            while (double.Parse(price) / installments > 5000)
            {
                installments++;
            }

            return (installments);
        }

        private int GetInvalidOverflowInstallments(string price)
        {
            var installments = 1;
            while (double.Parse(price) / installments > 5000)
            {
                installments++;
            }

            return (installments - 1);
        }

    }
}
