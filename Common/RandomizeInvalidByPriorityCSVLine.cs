using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RandomizeInvalidByPriorityCSVLine
    {
        RandomizeValidCSVLine ValidLineRandomizer { get; set; }
        RandomizeInvalidCSVLine InvalidLineRandomizer { get; set; }

        public RandomizeInvalidByPriorityCSVLine(RandomizeValidCSVLine validLineRandomizer)
        {
            ValidLineRandomizer = validLineRandomizer;
        }


        //credit card
        public CSVPurchaseLine GetInvalidCreditCardNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        public CSVPurchaseLine GetInvalidCreditCardNonNunericLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNonNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //overflow installments
        //actualize it
        public CSVPurchaseLine GetOverflowInstallments() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());


        //non activity date
        //actualize it
        public CSVPurchaseLine GetInvalidDateNonActivityPurchaseLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNonNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());


        //overflow per installment
        //actualize it
        public CSVPurchaseLine GetInvalidOverflowPerInstallmentLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNonNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

        //late date
        //actualize it
        public CSVPurchaseLine GetInvalidDateLaterThanInsertionLine() =>
            new CSVPurchaseLine(ValidLineRandomizer.RandomizeStoreId(), RandomizeInvalidCreditCardNonNumeric(), ValidLineRandomizer.RandomizePurchaseDate(), ValidLineRandomizer.Price, ValidLineRandomizer.RandomizeInstallments());

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
    }
}
