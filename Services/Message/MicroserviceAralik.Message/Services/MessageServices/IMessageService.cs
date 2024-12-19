using MicroserviceAralik.Message.Dtos;

namespace MicroserviceAralik.Message.Services.MessageServices;

public interface IMessageService
{
    Task<CreateMessageDto> CreateMessage(CreateMessageDto model);
    Task<List<ResaultMessageDto>> GetAllMessages();
    Task UpdateMessage(UpdateMessageDto model);
    Task<List<ResaultMessageDto>> GetInBox(string receiverId);
    Task<List<ResaultMessageDto>> GetSendBox(string SenderId);
    Task<ResaultMessageDto> GetMessageById(int id);



}
