using DAL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomaition
{
    public class DBLogics
    {
        public DBActions DBActions { get; set; }

        public DBLogics()
        {
            DBActions = new DBActions();
        }
        
        public void InsertPurchase(PurchaseDBBody purchase) =>
            DBActions.InsertPurchaseToDB(purchase);
        
        public List<PurchaseDBBody> GetAllPurchases() =>
            DBActions.GetAllDBPurchases();

        public List<PurchaseDBBody> GetPurchaseById(string id) =>
            DBActions.GetPurchaseFromDBById(id);

        public void deleteAllFromDB() =>
            DBActions.deleteAllFromDB();

    }
}
