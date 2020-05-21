using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//make PurchaceIsValid nullable

namespace Common
{
    public class PurchaseDBBody
    {
        public string Id { get; set; }
        public string StoreType { get; set; }
        public string ActivityDays { get; set; }
        public string StoreID { get; set; }
        public string CreditCard { get; set; }
        public string PurchaseDate { get; set; }
        public string InsertionDate { get; set; }
        public double TotalPrice { get; set; }
        public int Installments { get; set; }
        public double PricePerInstallment { get; set; }
        public int IsValid { get; set; }
        public string WhyInvalid { get; set; }
        
        public PurchaseDBBody()
        {

        }

        public PurchaseDBBody(string purchaseID, string storeType, string storeID, string activateDays, string creditCard,
            string purchaseDate, string insertionDate, double totalPrice, int installments,
            double pricePerInstallment, int isValid, string whyInvalid)
        {
            Id = purchaseID;
            StoreType = storeType;
            StoreID = storeID;
            ActivityDays = activateDays;
            CreditCard = creditCard;
            PurchaseDate = purchaseDate;
            InsertionDate = insertionDate;
            TotalPrice = totalPrice;
            Installments = installments;
            PricePerInstallment = pricePerInstallment;
            IsValid = isValid;
            WhyInvalid = whyInvalid;
        }
    }
}
