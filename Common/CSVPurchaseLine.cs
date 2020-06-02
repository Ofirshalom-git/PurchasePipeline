using System;
using System.Text.RegularExpressions;

namespace Common
{
    public class CSVPurchaseLine
    {
        public string StoreID { get; set; }
        public string CardID { get; set; }
        public string PurchaseDate { get; set; }
        public dynamic PayedPrice { get; set; }
        public dynamic Payments { get; set; }
        private static bool BoughtOnActivityDay { get; set; }
        private const string _validCardID = "4557446145890236";

        public CSVPurchaseLine(string storeID, string cardID, string purchaseDate, dynamic payedPrice, dynamic payments)
        {
            StoreID = storeID;
            CardID = cardID;
            PurchaseDate = purchaseDate;
            PayedPrice = payedPrice;
            Payments = payments;
        }

        public bool IsValidForDBInsertion() =>
            IsValidStoreIdFormat() && IsValidPriceForInsertion() && IsValidInstallmentsForInsertion() && IsValidPurchaseDateFormat();

        private bool IsValidStoreIdFormat()
        {
            if(StoreID.Length == 7)
            {
                //CR {711mikik} - Enum or array?
                if (StoreID[0] == 'A' || StoreID[0] == 'B' || StoreID[0] == 'C' || StoreID[0] == 'D' || StoreID[0] == 'E' || StoreID[0] == 'F')
                {
                    //CR {711mikik} - Enum or array? pt.2
                    if (StoreID[1] == 'A' || StoreID[1] == 'B' || StoreID[1] == 'C' || StoreID[1] == 'D')
                    {
                        for (var i = 2; i < 7; i++)
                        {
                            //CR {711mikik} - You dont use num... Why do you have it?
                            //CR {711mikik} - Why not just return the outcome? why if and ! etc.
                            if (!int.TryParse(StoreID[i].ToString(), out int num))
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

        private bool IsValidPriceForInsertion() =>
            double.TryParse(PayedPrice.ToString(), out double price);

        private bool IsValidInstallmentsForInsertion()
        {
            if (int.TryParse(Payments.ToString(), out int PaymentsValue))
            {
                return (PaymentsValue >= 1);
            }

            else if (Payments == "" || Payments == "FULL" )
            {
                return true;
            }
            
            return false;
        }

        private bool IsValidOverflowInstallmentsAsPurchase(string price)
        {
            var payedPrice = price;
            if (double.TryParse(Payments.ToString(), out double PaymentsValue))
            {
                return (PaymentsValue <= 10 * double.Parse(payedPrice));
            }

            return (Payments.ToString() == "" || Payments.ToString() == "FULL");
        }

        private bool IsValidOverflowPerInstallmentsAsPurchase(string price)
        {
            var payedPrice = double.Parse(price);
            if (double.TryParse(Payments.ToString(), out double PaymentsValue))
            {
                return (payedPrice / PaymentsValue <= 5000);
            }

            return (Payments.ToString() == "" && payedPrice < 5000) || (Payments.ToString() == "FULL" && payedPrice < 5000);
        }

        private bool IsValidPurchaseDateFormat()
        {
            string pattern = @"\d{ 4}-\d{ 2}-\d{ 2}";
            Match match = Regex.Match(PurchaseDate, pattern);
            if(match.Success)
            {
                return true;
            }

            return false;
        }

        public bool IsValidAsPurchase(string price, DateTime purchaseDate) =>
            IsValidCreditCard() && IsValidOverflowInstallmentsAsPurchase(price) && IsValidOverflowPerInstallmentsAsPurchase(price) && IsValidDateNotLate(purchaseDate) && BoughtOnActivityDay;

        public bool IsValidDateNotLate(DateTime purchaseDate)
        {
            //CR {711mikik} - why if?
            if (purchaseDate.Year < DateTime.Today.Year)
            {
                return true;
            }

            else if (purchaseDate.Year == DateTime.Today.Year)
            {
                //CR {711mikik} - why if?
                if (purchaseDate.Month < DateTime.Today.Month)
                {
                    return true;
                }

                else if (purchaseDate.Month == DateTime.Today.Month)
                {
                    //CR {711mikik} - why if?
                    if (purchaseDate.Day < DateTime.Today.Day)
                    {
                        return true;
                    }
                    //CR {711mikik} - why if
                    else if (purchaseDate.Day == DateTime.Today.Day)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int ExpectedIsValidNumber()
        {
            if(IsValidAsPurchase(PayedPrice, ParseToDateBySystemFormat(PurchaseDate)))
            {
                return 1;
            }

            return 0;
        }

        private bool IsValidCreditCard() =>
            CardID == _validCardID;

        private bool IsBoughtOnActivityDay(DateTime date)
        {
            switch (StoreID[1])
            {
                case 'A':
                    BoughtOnActivityDay = true;
                        return true;

                case 'B':
                    if (date.DayOfWeek != DayOfWeek.Saturday)
                    {
                        BoughtOnActivityDay = true;
                        return true;
                    }

                    break;

                case 'C':
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Friday)
                    {
                        BoughtOnActivityDay = true;
                        return true;
                    }

                    break;

                case 'D':
                    BoughtOnActivityDay = true;
                    return true;
            }

            BoughtOnActivityDay = false;
            return false;
        }

        public string WhyInvalidAsPurchase()
        {
            if (!IsValidCreditCard())
            {
                return "The credit card number is not valid"; 
            }

            else if (!IsValidOverflowInstallmentsAsPurchase(PayedPrice))
            {
                return "Invalid installments";
            }

            else if (!IsBoughtOnActivityDay(ParseToDateBySystemFormat(PurchaseDate))) 
            {
                return "Purchase was made on a day that the store is closed";
            }

            else if (!IsValidOverflowPerInstallmentsAsPurchase(PayedPrice))
            {
                return "Price per installment cant be higher than 5000"; 
            }

            if (!IsValidDateNotLate(ParseToDateBySystemFormat(PurchaseDate)))
            {
                return "The purchase date cant be in the future";
            }

            return "null";
        }

        private DateTime ParseToDateBySystemFormat(string date)
        {
            //CR {711mikik} - weird numbers.... why?
            var day = int.Parse($"{date[8]}{date[9]}");
            var month = int.Parse($"{date[5]}{date[6]}");
            var year = int.Parse($"{date[0]}{date[1]}{date[2]}{date[3]}");
            
            DateTime newDate = new DateTime(year, month, day);
            return newDate;
        }

        public PurchaseDBBody ExpectedPurchaseDBBody() =>
            new PurchaseDBBody("unknown", ExpectedStoreType(), ExpectedStoreId(), ExpectedActivityDays(), CardID, PurchaseDate, GetStringInsertionDate(),
                double.Parse(GetExpectedPrice()), ExpectedNumOfInstallments(), ExpectedPricePerInstallment(), ExpectedIsValidNumber(), WhyInvalidAsPurchase());
        
        private string GetExpectedPrice()
        {
            var price = PayedPrice.ToString();

            if (price.Contains(".")) 
            {
                //CR {711mikik} - cant you just use double to int to round it?
                return Math.Round(double.Parse(price), 1).ToString();
            }

            return price;
        }

        private string ExpectedStoreType() =>
            StoreID[0].ToString();

        private string ExpectedActivityDays() =>
            StoreID[1].ToString();

        private string ExpectedStoreId() =>
            StoreID;

        private string GetStringInsertionDate()
        {
            String date = "";
            //CR {711mikik} - why not using different vars and string formatting? (the ${
            date += DateTime.Today.Year.ToString();
            date += "-";
            // D2 because the system's valid date format is two digits for month or day
            date += DateTime.Today.Month.ToString("D2");
            date += "-";
            date += DateTime.Today.Day.ToString("D2");

            return date;
        }

        private int ExpectedNumOfInstallments()
        {
            //CR {711mikik} - what if it is a string which is not FULL
            if (Payments.ToString() == "FULL" || Payments.ToString() == "")
            {
                return 1;
            }            

            return int.Parse(Payments.ToString());
        }

        private double ExpectedPricePerInstallment() =>
            double.Parse(PayedPrice.ToString())/ExpectedNumOfInstallments();
    }
}
