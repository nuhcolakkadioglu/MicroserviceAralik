using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class RemoveAddressCommandHandler(IWriteRepository<Address> _writeRepository) : IRequestHandler<RemoveAddressCommand>
{
    public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);
    }
}
