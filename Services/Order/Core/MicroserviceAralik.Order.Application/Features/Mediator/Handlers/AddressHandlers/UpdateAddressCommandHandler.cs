using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class UpdateAddressCommandHandler(IReadRepository<Address> _readRepository, IWriteRepository<Address> _writeRepository, IMapper _mapper) : IRequestHandler<UpdateAddressCommand>
{
    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {

        var value = await _readRepository.GetByIdAsync(request.Id);
        var map = _mapper.Map(request, value);

        await _writeRepository.UpdateAsync(map);
    }
}
