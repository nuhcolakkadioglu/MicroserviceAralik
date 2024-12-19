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

        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
        };
        var connection = factory.CreateConnection();
        var chanell = connection.CreateModel();

        chanell.QueueDeclare(queue: "message_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);


        var consumer = new EventingBasicConsumer(chanell);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var messageJson = Encoding.UTF8.GetString(body);
            var message = JsonSerializer.Deserialize<CreateMessageDto>(messageJson);
            Console.WriteLine("Consume Mesaj >>>>"+ messageJson);

        };


        chanell.BasicConsume(queue: "message_queue",autoAck:true,consumer:consumer);
        await Task.Delay(Timeout.Infinite, stoppingToken);

    }
}
