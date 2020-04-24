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

        public void ConnectToDB()
        {
            string server = "localhost";
            string database = "hafifot";
            string uid = "root";
            string password = "root";
            string connetionString;
            connetionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            Connection = new SqlConnection(connetionString);            
        }

        public void AcssesData()
        {
            Connection.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT id, store_type, store_id, activity_days, credit_card, purchase_date, insertion_date, total_price, installments, price_per_installment, is_valid, why_invalid FROM hafifot";
            command = new SqlCommand(sql, Connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "/n";    
            }

            //messageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            Connection.Close();
        }

        private void insert(PurchaseInformation purchase)
        {
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
    }
}
