using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace DAL
{
    public class DBActions
    {
        public SqlConnection Connection;

        public DBActions()
        {
            ConnectToDB();
        }

        private void ConnectToDB()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string database = ConfigurationManager.AppSettings["database"];
            string uid = ConfigurationManager.AppSettings["uid"];
            string password = ConfigurationManager.AppSettings["password"];
            string connetionString;
            connetionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            this.Connection = new SqlConnection(connetionString);            
        }

        public List<PurchaseDBBody> GetAllPurchases()
        {
            this.Connection.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            var sqlQuery = "SELECT * FROM hafifot";
            command = new SqlCommand(sqlQuery, Connection);

            dataReader = command.ExecuteReader();
      
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), int.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            EndCommand(dataReader, command);

            return purchases;
        }

        public List<PurchaseDBBody> GetPurchaseById(string id)
        {
            Connection.Open();

            SqlCommand command;
            SqlDataReader dataReader;

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            var sqlQuery = $"SELECT * FROM hafifot WHERE id={id}";
            command = new SqlCommand(sqlQuery, Connection);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), int.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            EndCommand(dataReader, command);

            return purchases;
        }

        private void EndCommand(SqlDataReader dataReader, SqlCommand command)
        {
            dataReader.Close();
            command.Dispose();
            Connection.Close();
        }

        public void InsertPurchase(PurchaseDBBody purchase)
        {
            Connection.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = $"insert into table (id, store_type, store_id, activity_days, credit_card, purchase_date, insertion_date, total_price, installments, price_per_installment, is_valid, why_invalid) values ({purchase.Id}, {purchase.StoreType}, {purchase.StoreID}, {purchase.ActivityDays}, {purchase.CreditCard}, {purchase.PurchaseDate}, {purchase.InsertionDate}, {purchase.TotalPrice}, {purchase.Installments}, {purchase.PricePerInstallment}, {purchase.IsValid}, {purchase.WhyInvalid})";

            command = new SqlCommand(sql, Connection);

            adapter.InsertCommand = new SqlCommand(sql, Connection);
            adapter.InsertCommand.BeginExecuteNonQuery();

            command.Dispose();
            Connection.Close();
        }

        public void DeleteAllPurchases()
        {
            try
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE * FROM hafifot", Connection))
                {
                    command.ExecuteNonQuery();
                }

                Connection.Close();
            }

            catch (SystemException ex)
            {
                //MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
    }
}
