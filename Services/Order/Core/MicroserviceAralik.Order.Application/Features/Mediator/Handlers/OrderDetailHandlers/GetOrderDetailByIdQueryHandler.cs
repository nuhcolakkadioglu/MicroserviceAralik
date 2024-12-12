using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class GetOrderDetailByIdQueryHandler(IReadRepository<OrderDetail> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
{
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        OrderDetail data = await _readRepository.GetByIdAsync(request.Id);
        GetOrderDetailByIdQueryResult map = _mapper.Map<GetOrderDetailByIdQueryResult>(data);

        return map;
    }
}
