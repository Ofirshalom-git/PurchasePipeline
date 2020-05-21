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
        
        public bool IsValidForDB()
        {
            if(IsValidStoreIdFormat() && IsValidPrice() && IsValidInstallments() && IsValidPurchaseDateFormat())
            {
                return true;
            }

            return false;
        }

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

                            return true;
                        }
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
                if(price > 0 && price < 5000)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidInstallments()
        {
            double PaymentsValue;
            if (double.TryParse(Payments, out PaymentsValue))
            {
                if (PaymentsValue >= 1 && PaymentsValue < 10 * double.Parse(PayedPrice))
                {
                    return true;
                }
            }
            else if (Payments == "" || Payments == "FULL" )
            {
                return true;
            }
            
            return false;
        }

        private bool IsValidPurchaseDateFormat()
        {
            if(PurchaseDate.Length == 10 && (PurchaseDate[5] == '-' && PurchaseDate[8] == '-'))
            {
                int num;
                for(var i = 0; i < 10; i++)
                {
                    if(i != 5 && i != 8)
                    {
                        if(!int.TryParse(PurchaseDate[i].ToString(), out num))
                        {
                            return false;
                        }
                    }
                }

                DateTime newDate = DateTime.ParseExact(PurchaseDate, "YYYY-MM-dd", CultureInfo.InvariantCulture);

                if (newDate.Year > DateTime.Today.Year)
                {                    
                    return false;
                }

                if (newDate.Year == DateTime.Today.Year)
                {
                    if(newDate.Month > DateTime.Today.Month)
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

                if(newDate.Month >12 || newDate.Month < 1)
                {
                    return false;
                }

                if (newDate.Day > 31 || newDate.Day < 1)
                {
                    return false;
                }

                return true;
            }

            return false;
            //if(PurchaseDate.Length == 10)
            //{
            //    String expectedYear = "";

            //    expectedYear += $"{PurchaseDate[0].ToString()}{PurchaseDate[1].ToString()}{PurchaseDate[2].ToString()}{PurchaseDate[3].ToString()}";

            //    int year;
            //    if (int.TryParse(expectedYear, out year) && year <= DateTime.Today.Year)
            //    {
            //        String expectedMonth = "";

            //        expectedMonth += $"{PurchaseDate[5].ToString()}{PurchaseDate[6].ToString()}";

            //        int month;
            //        if (int.TryParse(expectedMonth, out month))
            //        {
            //            if (year == DateTime.Today.Year)
            //            {
            //                if()
            //            }
            //        }
            //    }
            //}
        }

        public bool IsValidAsPurchase()
        {
            if(IsValidCreditCard() && IsValidInstallments() && IsBoughtOnActivityDay() && IsValidPrice() && IsValidPurchaseDateFormat())
            {
                return true;
            }

            return false;
        }

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
            DateTime date = DateTime.ParseExact(PurchaseDate, "YYYY-MM-dd", CultureInfo.InvariantCulture);

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
                return "The credit card number is not valid"; //by DB
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

            return "couldn't find a reason";
        }

        public PurchaseDBBody ExpectedPurchaseDBBody() =>
            new PurchaseDBBody("unknown", ExpectedStoreType(), ExpectedStoreId(), ExpectedActivityDays(), CardID, PurchaseDate, GetStringInsertionDate(), PayedPrice, ExpectedNumOfInstallments(), ExpectedPricePerInstallment(), ExpectedIsValidNumber(), WhyInvalidPurchase());
        
        private string ExpectedStoreType()
        {
            switch (StoreID[0])
            {
                case 'A':
                    return "clothes";
                    break;

                case 'B':
                    return "food";
                    break;

                case 'C':
                    return "matirials";
                    break;

                case 'D':
                    return "medical";
                    break;

                case 'E':
                    return "electronics";
                    break;

                case 'F':
                    return "other/ unknown";
                    break;
            }

            return "non";
        }

        private string ExpectedStoreId()
        {
            String storeId = "";

            for(var i = 2; i < 7; i++)
            {
                storeId += StoreID[i];
            }

            return storeId;
        }

        private string ExpectedActivityDays()
        {
            switch (StoreID[1])
            {
                case 'A':
                    return "all week";
                    break;

                case 'B':
                    return "sunday to friday";
                    break;

                case 'C':
                    return "sunday to thursday";
                    break;

                case 'D':
                    return "unknown/ other";
                    break;
            }

            return "non";
        }

        private string GetStringInsertionDate()
        {
            String date = "";

            date += DateTime.Today.Year.ToString();
            date += "-";
            date += DateTime.Today.Month.ToString();
            date += "-";
            date += DateTime.Today.Day.ToString();

            return date;
        }

        private int ExpectedNumOfInstallments()
        {
            if (Payments == "FULL" || Payments == "")
            {
                return 1;
            }

            else
            {
                return Payments;
            }
        }

        private double ExpectedPricePerInstallment() =>
            PayedPrice/Payments;
        
    }
}
