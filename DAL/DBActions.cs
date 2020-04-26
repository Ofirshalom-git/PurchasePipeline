using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;

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
            string server = "localhost";
            string database = "hafifot";
            string uid = "root";
            string password = "root";
            string connetionString;
            connetionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            Connection = new SqlConnection(connetionString);            
        }

        public List<PurchaseDBBody> GetAllDBPurchases()
        {
            Connection.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            sql = "SELECT * FROM hafifot";
            command = new SqlCommand(sql, Connection);

            dataReader = command.ExecuteReader();
            //1
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), bool.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            //messageBox.Show(Output);
            //or 2
            //PurchaseDBBody purchase = new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), DateTime.Parse(dataReader.GetValue(5).ToString()), DateTime.Parse(dataReader.GetValue(6).ToString()), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), bool.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString());
            
            dataReader.Close();
            command.Dispose();
            Connection.Close();

            return purchases;
        }

        public List<PurchaseDBBody> GetPurchaseFromDBById(string id)
        {
            Connection.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            sql = $"SELECT * FROM hafifot WHERE id={id}";
            command = new SqlCommand(sql, Connection);

            dataReader = command.ExecuteReader();
            //1
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), bool.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            //messageBox.Show(Output);
            //or 2
            //PurchaseDBBody purchase = new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), DateTime.Parse(dataReader.GetValue(5).ToString()), DateTime.Parse(dataReader.GetValue(6).ToString()), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), bool.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString());

            dataReader.Close();
            command.Dispose();
            Connection.Close();

            return purchases;
        }

        public void InsertPurchaseToDB(PurchaseDBBody purchase)
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

        public void deleteAllFromDB()
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
