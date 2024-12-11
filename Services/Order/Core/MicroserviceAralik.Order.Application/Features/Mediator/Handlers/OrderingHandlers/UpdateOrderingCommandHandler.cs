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
public class UpdateOrderingCommandHandler(IWriteRepository<Ordering> _writeRepository, IReadRepository<Ordering> _readRepository, IMapper _mapper) : IRequestHandler<UpdateOrderingCommand>
{
    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _readRepository.GetByIdAsync(request.Id);
        var map = _mapper.Map(request,value);
        await _writeRepository.UpdateAsync(map);
    }
}
