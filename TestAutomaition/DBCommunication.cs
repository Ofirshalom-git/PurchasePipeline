using DAL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomaition
{
    public class DBCommunication
    {
        public DBActions DBActions { get; set; }

        public DBCommunication()
        {
            DBActions = new DBActions();
        }
        
        public void InsertPurchase(PurchaseDBBody purchase) =>
            DBActions.InsertPurchase(purchase);
        
        public List<PurchaseDBBody> GetAllPurchases() =>
            DBActions.GetAllPurchases();

        public List<PurchaseDBBody> GetPurchaseById(string id) =>
            DBActions.GetPurchaseById(id);

        public void deleteAllPurchases() =>
            DBActions.DeleteAllPurchases();

    }
}
