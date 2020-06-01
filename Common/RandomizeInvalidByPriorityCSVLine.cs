using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Price = RandomizeOverFiveThousandPrice(); // will be over 5,000
            ValidLineRandomizer = validLineRandomizer;
            _storeId = ValidLineRandomizer.RandomizeStoreId();
        }

        //credit card
        public CSVPurchaseLine GetInvalidCreditCardNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNumeric(), RandomizeLatePurchaseDate(), Price, GetInvalidInstallments(Price));

        public CSVPurchaseLine GetInvalidCreditCardNonNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNonNumeric(), RandomizeLatePurchaseDate(), Price, GetInvalidInstallments(Price));

        //overflow installments
        public CSVPurchaseLine GetInvalidOverflowInstallments() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeLatePurchaseDate(), Price, RandomizeInvalidOverflowInstallments());

        //non activity date
        public CSVPurchaseLine GetInvalidDateNonActivityPurchaseLine() =>
            new CSVPurchaseLine("CC12345", ValidLineRandomizer.RandomizeCreditCard(), "1377-05-09", Price, GetValidInstallments(Price));

        //overflow per installment
        public CSVPurchaseLine GetInvalidOverflowPerInstallmentLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeLatePurchaseDate(), Price, RandomizeInvalidOverflowPerInstallment(Price));

        //late date
        public CSVPurchaseLine GetInvalidDateLaterThanInsertionLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), ValidLineRandomizer.RandomizeCreditCard(), RandomizeLatePurchaseDate(), Price, GetValidInstallments(Price));

        //Randomizer vvv

        //credit card
        private string RandomizeInvalidCreditCardNumeric()
        {
            Random rnd = new Random();
            String creditCard = "";

            for (var i = 0; i < 15; i++)
            {
                creditCard += rnd.Next(0, 9);
            }

            return creditCard;
        }

        private string RandomizeInvalidCreditCardNonNumeric()
        {
            Random rnd = new Random();
            String creditCard = "";

            for (var i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    creditCard += rnd.Next(0, 9);
                }

                else
                {
                    creditCard += "G";
                }
            }

            return creditCard;
        }

        //overflow installments
        private string RandomizeInvalidOverflowInstallments()
        {
            var price = (int)double.Parse(Price);
            Random rnd = new Random();

            return rnd.Next(price * 10 + 1, price * 100).ToString();
        }

        //non activity day
        private string RandomizeInvalidNonActivityDay()
        {
            int year, month, day;
            DateTime date;

            var count = 0;
            do
            {
                year = _yearRnd.Next(1000, DateTime.Now.Year - 1);
                month = _monthRnd.Next(1, 12);
                day = _dayRnd.Next(1, 28);

                date = new DateTime(year, month, day);
                count++;
            }

            while (BoughtOnActivityDay(date) && count < 100);

            //return $"{year}-{month:D2}-{day:D2}";
            return date.ToString("yyyy-MM-dd");
        }

        private bool BoughtOnActivityDay(DateTime date)
        {
            switch (_storeId[1])
            {
                case 'A':
                    return true;

                    break;

                case 'B':
                    if (date.DayOfWeek != DayOfWeek.Saturday)
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

        private int GetInvalidInstallments(string price)
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
