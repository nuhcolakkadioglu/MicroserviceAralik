using System.Text;
using System.Text.Json;
using MicroserviceAralik.Message.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroserviceAralik.Message.Services.RabbitMqServices;

public class RabbitMQConsumer : BackgroundService
{

    private readonly IServiceScopeFactory _scopeFactory;

    public RabbitMQConsumer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "localhost",
        };
        IConnection connection = factory.CreateConnection();
        IModel chanell = connection.CreateModel();

        chanell.QueueDeclare(queue: "message_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);


        EventingBasicConsumer consumer = new EventingBasicConsumer(chanell);
        consumer.Received += async (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string messageJson = Encoding.UTF8.GetString(body);
            CreateMessageDto? message = JsonSerializer.Deserialize<CreateMessageDto>(messageJson);
            Console.WriteLine("Consume Mesaj >>>>" + messageJson);

        };


        chanell.BasicConsume(queue: "message_queue", autoAck: true, consumer: consumer);
        await Task.Delay(Timeout.Infinite, stoppingToken);

    }
}
