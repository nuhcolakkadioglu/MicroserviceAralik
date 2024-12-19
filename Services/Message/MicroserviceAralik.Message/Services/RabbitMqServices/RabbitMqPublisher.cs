using System.Text;
using System.Text.Json;
using MicroserviceAralik.Message.Dtos;
using MicroserviceAralik.Message.Services.MessageServices;
using RabbitMQ.Client;

namespace MicroserviceAralik.Message.Services.RabbitMqServices;

public class RabbitMQPublisher
{
    private readonly string _hostname = "localhost";
    private readonly string _queueName = "message_queue";
    private readonly IMessageService _messageService;

    public RabbitMQPublisher(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async void Publish<T>(T message) where T : CreateMessageDto
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostname,
        };

   var values =     await _messageService.CreateMessage(message);


        var connection = factory.CreateConnection();
        var chanell = connection.CreateModel();
        chanell.QueueDeclare(queue: _queueName,durable:true,exclusive:false,autoDelete:false,arguments:null);

        var messageBody = JsonSerializer.Serialize(values); //serileştir
        var body = Encoding.UTF8.GetBytes(messageBody); // byte cevir

        chanell.BasicPublish(exchange:"",routingKey: _queueName, body: body);

        Console.WriteLine($"Mesaj Kuyruga alındı MESAJ =>{message}");
    }
}
