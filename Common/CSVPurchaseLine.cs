using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CSVPurchaseLine
    {
        public string StoreID { get; set; }
        public string CardID { get; set; }
        public string PurchaseDate { get; set; }
        public dynamic PayedPrice { get; set; }
        public dynamic Payments { get; set; }

        public CSVPurchaseLine()
        {

        }

        public CSVPurchaseLine(string storeID, string cardID, string purchaseDate, dynamic payedPrice, dynamic payments)
        {
            StoreID = storeID;
            CardID = cardID;
            PurchaseDate = purchaseDate;
            PayedPrice = payedPrice;
            Payments = payments;
        }

        public bool IsValidForDB() =>
            IsValidStoreIdFormat() && IsValidPrice() && IsValidInstallments() && IsValidPurchaseDateFormat();

        private bool IsValidStoreIdFormat()
        {
            if(StoreID.Length == 7)
            {
                if(StoreID[0] == 'A' || StoreID[0] == 'B' || StoreID[0] == 'C' || StoreID[0] == 'D' || StoreID[0] == 'E' || StoreID[0] == 'F')
                {
                    if (StoreID[1] == 'A' || StoreID[1] == 'B' || StoreID[1] == 'C' || StoreID[1] == 'D')
                    {
                        int num;
                        for (var i = 2; i < 7; i++)
                        {
                            if (!int.TryParse(StoreID[i].ToString(), out num))
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsValidPrice()
        {
            double price;

            if(double.TryParse(PayedPrice, out price))
            {
                return (price > 0 && price < 5000);
            }

            return false;
        }

        private bool IsValidInstallments()
        {
            double PaymentsValue;
            if (double.TryParse(Payments, out PaymentsValue))
            {
                return (PaymentsValue >= 1 && PaymentsValue < 10 * double.Parse(PayedPrice));
            }
            else if (Payments == "" || Payments == "FULL" )
            {
                return true;
            }
            
            return false;
        }

        private bool IsValidPurchaseDateFormat()
        {
            if(PurchaseDate.Length == 10 && (PurchaseDate[4] == '-' && PurchaseDate[7] == '-'))
            {
                int num;
                for(var i = 0; i < 10; i++)
                {
                    if(i != 4 && i != 7)
                    {
                        if(!int.TryParse(PurchaseDate[i].ToString(), out num))
                        {
                            return false;
                        }
                    }
                }

                try
                {
                    DateTime newDate = DateTime.ParseExact(PurchaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (newDate.Year > DateTime.Today.Year)
                    {
                        return false;
                    }

                    if (newDate.Year == DateTime.Today.Year)
                    {
                        if (newDate.Month > DateTime.Today.Month)
                        {
                            return false;
                        }

                        if (newDate.Month == DateTime.Today.Month)
                        {
                            if (newDate.Day > DateTime.Today.Day)
                            {
                                return false;
                            }
                        }
                    }

                    if (newDate.Month > 12 || newDate.Month < 1)
                    {
                        return false;
                    }

                    if (newDate.Day > 31 || newDate.Day < 1)
                    {
                        return false;
                    }
                }

                catch
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool IsValidAsPurchase() =>
            IsValidCreditCard() && IsValidInstallments() && IsBoughtOnActivityDay() && IsValidPrice() && IsValidPurchaseDateFormat();

        public int ExpectedIsValidNumber()
        {
            if(IsValidAsPurchase())
            {
                return 1;
            }

            return 0;
        }

        private bool IsValidCreditCard()
        {
            if(CardID.Length == 16)
            {
                int num;
                for(var i = 0; i < 16; i++)
                {
                    if(!int.TryParse(CardID[i].ToString(), out num))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private bool IsBoughtOnActivityDay()
        {
            DateTime date = DateTime.ParseExact(PurchaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            switch (StoreID[2])
            {
                case 'A':
                        return true;
                    break;

                case 'B':
                    if (date.DayOfWeek != DayOfWeek.Saturday)
                        return true;
                    break;

                case 'C':
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Friday)
                        return true;
                    break;

                case 'D':
                        return true;
                    break;
            }

            return false;
        }

        public string WhyInvalidPurchase()
        {
            if (!IsValidCreditCard())
            {
                return "The credit card number is not valid"; 
            }

            if (!IsValidInstallments())
            {
                return "Invalid installments";
            }

            if (!IsBoughtOnActivityDay())
            {
                return "Invalid purchase on non-activity day";
            }
            if (!IsValidPrice())
            {
                return "Price per installment cant be higher than 5000"; //by DB
            }

            if (!IsValidPurchaseDateFormat())
            {
                return "Invalid purchase date later than insertion";
            }

            return "null";
        }

        public PurchaseDBBody ExpectedPurchaseDBBody() =>
            new PurchaseDBBody("unknown", ExpectedStoreType(), ExpectedStoreId(), ExpectedActivityDays(), CardID, PurchaseDate, GetStringInsertionDate(), double.Parse(PayedPrice), ExpectedNumOfInstallments(), ExpectedPricePerInstallment(), ExpectedIsValidNumber(), WhyInvalidPurchase());

        private string ExpectedStoreType() =>
            StoreID[0].ToString();

        private string ExpectedStoreId() =>
            StoreID;

        private string ExpectedActivityDays() =>
            StoreID[1].ToString();

        private string GetStringInsertionDate()
        {
            String date = "";

            date += DateTime.Today.Year.ToString();
            date += "-";
            date += DateTime.Today.Month.ToString("D2");
            date += "-";
            date += DateTime.Today.Day.ToString("D2");

            return date;
        }

        private int ExpectedNumOfInstallments()
        {
            if (Payments == "FULL" || Payments == "")
            {
                return 1;
            }
            
            return int.Parse(Payments);
        }

        private double ExpectedPricePerInstallment() =>
            double.Parse(PayedPrice)/ExpectedNumOfInstallments();
        
    }
}
