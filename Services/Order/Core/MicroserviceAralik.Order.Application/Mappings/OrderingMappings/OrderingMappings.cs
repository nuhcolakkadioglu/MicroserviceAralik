using AutoMapper;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Mappings.OrderingMappings;
public class OrderingMappings:Profile
{
    public OrderingMappings()
    {
        CreateMap<Ordering,CreateOrderingCommand>().ReverseMap();
        CreateMap<Ordering,UpdateOrderingCommand>().ReverseMap();
        CreateMap<Ordering,RemoveOrderingCommand>().ReverseMap();
        CreateMap<Ordering,GetOrderingQuery>().ReverseMap();
        CreateMap<Ordering,GetOrderingByIdQuery>().ReverseMap();
    }
}
