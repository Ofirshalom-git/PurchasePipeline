using Common;
using System;
using System.Text;
using RabbitMQ.Client;

namespace TestAutomaition
{
    public class RabbitMQLogics
    {
        private const string _routingKey = "TEST";
        private ConnectionFactory Factory { get; set; }

        public RabbitMQLogics()
        {
            Factory = new ConnectionFactory();
        }

        public void SendCSVToRabbitMQ(CSVFile file) =>
            SendCSVStringBody(ConvertCSVFileToText(file));

        public void SendCSVStringBody(string CSVBody)
        {
            using(var connection = Factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    var message = Encoding.UTF8.GetBytes(CSVBody);
                    channel.BasicPublish("", _routingKey, null, message);
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
            if (int.TryParse(purchase.Payments.ToString(), out int paymentValue))
            {
                return $"{purchase.StoreID},{purchase.CardID},{purchase.PurchaseDate},{purchase.PayedPrice},{int.Parse(purchase.Payments.ToString())}";
            }
            
            return $"{purchase.StoreID},{purchase.CardID},{purchase.PurchaseDate},{purchase.PayedPrice}";
        }
    }
}
