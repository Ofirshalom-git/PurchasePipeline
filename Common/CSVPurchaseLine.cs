using System;
using System.Collections.Generic;
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


        public bool isValidForDB()
        {

        }


        public bool isValidAsPurchase()
        {

        }

        public PurchaseDBBody expectedPurchaseDBBody()
        {
            PurchaseDBBody expectedPurchase = new PurchaseDBBody("unknown", expectedStoreType(), expectedStoreId(), expectedActivityDays(), CardID, )
        }

        private string expectedStoreType()
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

        private string expectedStoreId()
        {
            String storeId = "";

            for(var i = 2; i < 7; i++)
            {
                storeId += StoreID[i];
            }

            return storeId;
        }

        private string expectedActivityDays()
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
    }
}
