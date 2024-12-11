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
public class GetOrderDetailQueryHandler(IReadRepository<OrderDetail> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
{
    public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var data = await _readRepository.GetAllAsync();
        var map = _mapper.Map<List<GetOrderDetailQueryResult>>(data);
        return map;
    }
}
