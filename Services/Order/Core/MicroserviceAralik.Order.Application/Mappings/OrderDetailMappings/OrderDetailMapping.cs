using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Mappings.OrderDetailMappings;
public class OrderDetailMapping : Profile
{
    public OrderDetailMapping()
    {
        CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, RemoveOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>().ReverseMap();

    }
}
