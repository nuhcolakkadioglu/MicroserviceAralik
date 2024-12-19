using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MicroserviceAralik.RabbitMQ.Abstract;
using RabbitMQ.Client;

namespace MicroserviceAralik.RabbitMQ.Concrete;
public class RabbitMQPublisher : IRabbitMQPublisher
{
    private readonly IConnectionFactory _connectionFactory;
    public RabbitMQPublisher(string hostname, string username, string password)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = hostname,
            Password = password,
            UserName = username
        };
    }
    public void Publish<T>(string queuename, T message)
    {
        IConnection connection = _connectionFactory.CreateConnection();
        IModel chanell = connection.CreateModel();
        chanell.QueueDeclare(queuename, durable: true, exclusive: false, autoDelete: false, arguments: null);
        string messageBody = JsonSerializer.Serialize(message);
        byte[] body = Encoding.UTF8.GetBytes(messageBody);
        chanell.BasicPublish(exchange: "", routingKey: queuename, basicProperties: null, body: body);
    }
}
