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

            Auth.SetUserCredentials("lPZEzMHtQ2OVkLRgIyLVmyJet","UHrpP7yJxbDJSCCkTcUaxANErFsVmYNnUOSx3jW1PE2NyRQ4zo","634238606-Io8cuzkSIgIVxqaKotYqxBrdSBzgm31LMw1GThbN","88pb1SP76KAW5e8XEw49BUmrKt8Hf8ASRz28cmdJSokZR");

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