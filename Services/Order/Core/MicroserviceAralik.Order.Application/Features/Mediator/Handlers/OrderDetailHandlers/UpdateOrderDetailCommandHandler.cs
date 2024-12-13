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
public class UpdateOrderDetailCommandHandler(IWriteRepository<OrderDetail> _writeRepository, IMapper _mapper, IReadRepository<OrderDetail> _readRepository) : IRequestHandler<UpdateOrderDetailCommand>
{
    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail value = await _readRepository.GetByIdAsync(request.Id);
        OrderDetail map = _mapper.Map(request, value);

        await _writeRepository.UpdateAsync(map);
    }
}
