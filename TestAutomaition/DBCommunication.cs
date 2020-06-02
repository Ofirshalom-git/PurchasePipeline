using DAL;
using Common;
using System.Collections.Generic;

namespace TestAutomaition
{
    public class DBCommunication
    {
        public DBActions DBActions { get; set; }

        public DBCommunication()
        {
            DBActions = new DBActions();
        }
        
        public List<PurchaseDBBody> GetAllPurchases() =>
            DBActions.GetAllPurchases();

        public void DeleteAllPurchases() =>
            DBActions.DeleteAllPurchases();
    }
}
