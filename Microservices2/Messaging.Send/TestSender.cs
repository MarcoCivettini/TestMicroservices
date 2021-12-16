using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Microservices2.Messaging.Send
{
    public class TestSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        public TestSender(/*IOptions<RabbitMqConfiguration> rabbitMqOptions*/)
        {
            _queueName = "testQueue";
            _hostname = ".";
            _username = "guest";
            _password = "guest";
        }

        public void SendTestMessage()
        {
            var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password, VirtualHost = "/", Port = 5672, AmqpUriSslProtocols = SslProtocols .None};
            using var connection = factory.CreateConnection(); ;
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes("Hello world");
            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

        }
    }
}
