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
public class RemoveOrderingCommandHandler(IWriteRepository<Ordering> _writeRepository) : IRequestHandler<RemoveOrderingCommand>
{
    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);
    }
}
