using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//make PurchaceIsValid nullable

namespace Common
{
    public class PurchaseInformation
    {
        public string Id { get; set; }
        public string StoreType { get; set; }
        public string ActivityDays { get; set; }
        public string StoreID { get; set; }
        public string CreditCard { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime InsertionDate { get; set; }
        public double TotalPrice { get; set; }
        public int Installments { get; set; }
        public double PricePerInstallment { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }
        
        public PurchaseInformation()
        {

        }

        public PurchaseInformation(string purchaseID, string storeType, string activateDays, string storeID, string cardID, DateTime purchaseDate, DateTime insertionDate, double purchasePrice, int installments, double pricePerInstallment, bool isValid, string whyInvalid)
        {
            Id = purchaseID;
            StoreType = storeType;
            ActivityDays = activateDays;
            StoreID = storeID;
            CreditCard = cardID;
            PurchaseDate = purchaseDate;
            InsertionDate = insertionDate;
            TotalPrice = purchasePrice;
            Installments = installments;
            PricePerInstallment = pricePerInstallment;
            IsValid = isValid;
            WhyInvalid = whyInvalid;
        }
    }
}
