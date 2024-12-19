using MicroserviceAralik.Message.Dtos;
using MicroserviceAralik.Message.Services.RabbitMqServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Message.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessagesController(RabbitMQPublisher _rabbitMQPublisher) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageDto model)
    {
        _rabbitMQPublisher.Publish(model);
        return Ok("Send Message");
    }
}
