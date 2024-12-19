using AutoMapper;
using MicroserviceAralik.Message.Dal.Context;
using MicroserviceAralik.Message.Dal.Entities;
using MicroserviceAralik.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Message.Services.MessageServices;

public class MessageService(IMapper _map, AppDbContext _context) : IMessageService
{
    public async Task<CreateMessageDto> CreateMessage(CreateMessageDto model)
    {
        var mappMessage = _map.Map<UserMessage>(model);
        mappMessage.Status = "Gönderildi";
        mappMessage.SendDate = DateTime.UtcNow;
        var value = await _context.UserMessages. AddAsync(mappMessage);
       // await _context.SaveChangesAsync();

        mappMessage.Id = value.Entity.Id;

        return model;
    }

    public async Task<List<ResaultMessageDto>> GetAllMessages()
    {
        var values = await _context.UserMessages.ToListAsync();

        var map = _map.Map<List<ResaultMessageDto>>(values);

        return map;
    }

    public async Task<List<ResaultMessageDto>> GetInBox(string receiverId)
    {
        var values = await _context.UserMessages
            .Where(m=>m.ReceiverdId == receiverId).ToListAsync();

        var map = _map.Map<List<ResaultMessageDto>>(values);

        return map;
    }

    public async Task<ResaultMessageDto> GetMessageById(int id)
    {
        var values = await _context.UserMessages.FirstOrDefaultAsync(m => m.Id == id);

        var map = _map.Map<ResaultMessageDto>(values);

        return map;
    }

    public async Task<List<ResaultMessageDto>> GetSendBox(string receiverId)
    {
        var values = await _context.UserMessages.Where(m => m.SenderId == receiverId).ToListAsync();

        var map = _map.Map<List<ResaultMessageDto>>(values);

        return map;
    }

    public async Task UpdateMessage(UpdateMessageDto model)
    {
        var mappMessage = _map.Map<UserMessage>(model);
        mappMessage.Status = "Gönderildi";
        mappMessage.SendDate = DateTime.UtcNow;
        var value =   _context.Update(mappMessage);
        await _context.SaveChangesAsync();

       

       
    }
}
