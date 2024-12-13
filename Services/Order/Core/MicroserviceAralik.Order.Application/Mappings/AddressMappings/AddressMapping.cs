using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.AddresResults;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Mappings.AddressMappings;
public class AddressMapping : Profile
{
    public AddressMapping()
    {
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, RemoveAddressCommand>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, GetAddressQueryResult>().ReverseMap();
        CreateMap<Address, GetAdressByIdQueryResult>().ReverseMap();

    }
}
