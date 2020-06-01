using DAL;
using RabbitMQ;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace TestAutomaition
{
    public class RabbitMQLogics
    {
        private ConnectionFactory Factory { get; set; }

        public RabbitMQLogics()
        {
            Factory = new ConnectionFactory();
        }

        public void SendCSVToRabbitMQ(CSVFile file)
        {
            SendCSVStringBody(ConvertCSVFileToText(file));
        }

        public void SendCSVStringBody(string CSVBody)
        {
            using(var connection = Factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    var message = Encoding.UTF8.GetBytes(CSVBody);
                    channel.BasicPublish("", "TEST", null, message);
                }
            }
        }

        private string ConvertCSVFileToText(CSVFile file)
        {
            String body = "";
            foreach(var purchase in file.Purchases)
            {
                body = $"{body}{ConvertCSVLineToText(purchase)}{Environment.NewLine}";
            }

            return body;
        }

        public string ConvertCSVLineToText(CSVPurchaseLine purchase)
        {
            int PaymentValue;
            if (int.TryParse(purchase.Payments.ToString(), out PaymentValue))
            {
                return $"{purchase.StoreID},{purchase.CardID},{purchase.PurchaseDate},{purchase.PayedPrice},{int.Parse(purchase.Payments.ToString())}";
            }
            else
            {
                return $"{purchase.StoreID},{purchase.CardID},{purchase.PurchaseDate},{purchase.PayedPrice}";
            }
        }
    }
}
