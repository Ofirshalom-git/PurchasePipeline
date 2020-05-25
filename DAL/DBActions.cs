using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBActions
    {
        public MySqlConnection Connection;

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
            //connetionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connetionString = $"server=localhost;user=root;database=hafifot;password=root;";
            this.Connection = new MySqlConnection(connetionString);
        }

        public List<PurchaseDBBody> GetAllPurchases()
        {
            this.Connection.Open();

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            var sqlQuery = "SELECT * FROM purchases";
            MySqlCommand command = new MySqlCommand(sqlQuery, this.Connection);

            MySqlDataReader dataReader = command.ExecuteReader();
      
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(),
                    dataReader.GetValue(1).ToString(),
                    dataReader.GetValue(2).ToString(),
                    dataReader.GetValue(3).ToString(),
                    dataReader.GetValue(4).ToString(),
                    GetFormatedDate(dataReader.GetValue(5).ToString()), //date
                    GetFormatedDate(dataReader.GetValue(6).ToString()), //date
                    double.Parse(dataReader.GetValue(7).ToString()),
                    int.Parse(dataReader.GetValue(8).ToString()),
                    double.Parse(dataReader.GetValue(9).ToString()),
                    int.Parse(dataReader.GetValue(10).ToString()),
                    dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            EndCommand(dataReader, command);

            return purchases;
        }

        private string GetFormatedDate(string unformatedDate)
        {
            String formatedDate = "";

            if (unformatedDate[5] == '/' && unformatedDate[2] == '/')
            {
                formatedDate += unformatedDate[6];
                formatedDate += unformatedDate[7];
                formatedDate += unformatedDate[8];
                formatedDate += unformatedDate[9];
                formatedDate += "-";
                formatedDate += unformatedDate[0];
                formatedDate += unformatedDate[1];
                formatedDate += "-";
                formatedDate += unformatedDate[3];
                formatedDate += unformatedDate[4];
            }

            else if (unformatedDate[4] == '/' && unformatedDate[2] == '/')
            {
                formatedDate += unformatedDate[5];
                formatedDate += unformatedDate[6];
                formatedDate += unformatedDate[7];
                formatedDate += unformatedDate[8];
                formatedDate += "-";
                formatedDate += unformatedDate[0];
                formatedDate += unformatedDate[1];
                formatedDate += "-";
                formatedDate += "0";
                formatedDate += unformatedDate[3];
            }

            else if (unformatedDate[4] == '/' && unformatedDate[1] == '/')
            {
                formatedDate += unformatedDate[5];
                formatedDate += unformatedDate[6];
                formatedDate += unformatedDate[7];
                formatedDate += unformatedDate[8];
                formatedDate += "-";
                formatedDate += "0";
                formatedDate += unformatedDate[0];
                formatedDate += "-";
                formatedDate += unformatedDate[2];
                formatedDate += unformatedDate[3];
            }

            else if (unformatedDate[3] == '/' && unformatedDate[1] == '/')
            {
                formatedDate += unformatedDate[4];
                formatedDate += unformatedDate[5];
                formatedDate += unformatedDate[6];
                formatedDate += unformatedDate[7];
                formatedDate += "-";
                formatedDate += "0";
                formatedDate += unformatedDate[0];
                formatedDate += "-";
                formatedDate += "0";
                formatedDate += unformatedDate[2];
            }

            return formatedDate;
        }

        public List<PurchaseDBBody> GetPurchaseById(string id)
        {
            this.Connection.Open();
            MySqlCommand command;
            MySqlDataReader dataReader;

            List<PurchaseDBBody> purchases = new List<PurchaseDBBody>();

            var sqlQuery = $"SELECT * FROM purchases WHERE id={id}";
            command = new MySqlCommand(sqlQuery, Connection);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                purchases.Add(new PurchaseDBBody(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), double.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString()), int.Parse(dataReader.GetValue(9).ToString()), int.Parse(dataReader.GetValue(10).ToString()), dataReader.GetValue(11).ToString()));
                //Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            EndCommand(dataReader, command);

            return purchases;
        }

        private void EndCommand(MySqlDataReader dataReader, MySqlCommand command)
        {
            dataReader.Close();
            command.Dispose();
            Connection.Close();
        }

        public void InsertPurchase(PurchaseDBBody purchase)
        {
            this.Connection.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String sql = "";

            sql = $"insert into table (id, store_type, store_id, activity_days, credit_card, purchase_date, insertion_date, total_price, installments, price_per_installment, is_valid, why_invalid) values ({purchase.Id}, {purchase.StoreType}, {purchase.StoreID}, {purchase.ActivityDays}, {purchase.CreditCard}, {purchase.PurchaseDate}, {purchase.InsertionDate}, {purchase.TotalPrice}, {purchase.Installments}, {purchase.PricePerInstallment}, {purchase.IsValid}, {purchase.WhyInvalid})";

            command = new MySqlCommand(sql, Connection);

            adapter.InsertCommand = new MySqlCommand(sql, Connection);
            adapter.InsertCommand.BeginExecuteNonQuery();

            command.Dispose();
            Connection.Close();
        }

        public void DeleteAllPurchases()
        {
            try
            {
                this.Connection.Open();

                using (MySqlCommand command = new MySqlCommand("TRUNCATE TABLE hafifot.purchases", Connection))
                {
                    command.ExecuteNonQuery();
                }

                this.Connection.Close();
            }

            catch (SystemException ex)
            {
                Console.WriteLine(string.Format("An error occurred: {0}", ex.Message));
                //this.Connection.Close();
            }
        }
    }
}
