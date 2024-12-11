using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class GetOrderingQueryHandler(IReadRepository<Ordering> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var data = await _readRepository.GetAllAsync();
        var mapData = _mapper.Map<List<GetOrderingQueryResult>>(data);
        return mapData;
    }
}
