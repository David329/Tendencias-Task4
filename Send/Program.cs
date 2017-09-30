using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Tweetinvi;
using System.Threading;

namespace send
{
    class Program
    {
        public static void Main()
        {

            Auth.SetUserCredentials("key1","key2","key3","key4");

            var stream = Stream.CreateSampleStream();

            var factory = new ConnectionFactory() { HostName = "166.62.89.37", Port = 8080 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");

                string message = "";
                stream.TweetReceived += (sender, res) =>
                {
                    message = res.Tweet.ToString();
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "direct_logs", routingKey: "trending", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", "trending", message);
                    // Thread.Sleep(500);//pa q valla desssspaaacito xd
                };
                stream.StartStream();
            }
        }
    }
}
