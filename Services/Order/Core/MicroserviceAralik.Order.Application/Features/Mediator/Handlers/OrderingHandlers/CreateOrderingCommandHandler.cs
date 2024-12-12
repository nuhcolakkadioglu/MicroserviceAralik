using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class CreateOrderingCommandHandler(IWriteRepository<Ordering> _writeRepository, IMapper _mapper) : IRequestHandler<CreateOrderingCommand>
{
    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering map = _mapper.Map<Ordering>(request);
        await _writeRepository.CreateAsync(map);
    }
}
