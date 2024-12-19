using AutoMapper;
using MicroserviceAralik.Message.Dal.Entities;
using MicroserviceAralik.Message.Dtos;
using MicroserviceAralik.Message.Services.MessageServices;

namespace MicroserviceAralik.Message.Mapping;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
        CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResaultMessageDto>().ReverseMap();
    }
}
