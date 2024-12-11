using AutoMapper;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Mappings.OrderingMappings;
public class OrderingMappings:Profile
{
    public OrderingMappings()
    {
        CreateMap<Ordering,CreateOrderingCommand>().ReverseMap();
        CreateMap<Ordering,UpdateOrderingCommand>().ReverseMap();
        CreateMap<Ordering,RemoveOrderingCommand>().ReverseMap();
        CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
        CreateMap<Ordering,GetOrderingByIdQueryResult>().ReverseMap();
    }
}
