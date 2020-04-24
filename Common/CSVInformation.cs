using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Purchace
    {
        public string StoreID { get; set; }
        public string CardID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PayedPrice { get; set; }
        public int Payments { get; set; }

        public Purchace()
        {

        }

        public Purchace(string storeID, string cardID, DateTime purchaseDate, double payedPrice, int payments)
        {
            StoreID = storeID;
            CardID = cardID;
            PurchaseDate = purchaseDate;
            PayedPrice = payedPrice;
            Payments = payments;
        }
    }
}
