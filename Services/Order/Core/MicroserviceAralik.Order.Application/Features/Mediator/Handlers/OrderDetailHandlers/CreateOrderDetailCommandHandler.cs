using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class CreateOrderDetailCommandHandler(IWriteRepository<OrderDetail> _writeRepository, IMapper _mapper) : IRequestHandler<CreateOrderDetailCommand>
{
    public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail mapData = _mapper.Map<OrderDetail>(request);
        await _writeRepository.CreateAsync(mapData);
    }
}
