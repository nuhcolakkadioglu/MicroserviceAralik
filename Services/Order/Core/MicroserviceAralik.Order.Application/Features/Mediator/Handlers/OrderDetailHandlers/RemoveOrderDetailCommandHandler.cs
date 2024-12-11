using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class RemoveOrderDetailCommandHandler(IWriteRepository<OrderDetail> _writeRepository) : IRequestHandler<RemoveOrderDetailCommand>
{
    public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);
    }
}
