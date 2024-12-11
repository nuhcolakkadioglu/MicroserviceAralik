using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class GetOrderingByIdQueryHandler(IReadRepository<Ordering> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _readRepository.GetByIdAsync(request.Id);
        var mapData = _mapper.Map<GetOrderingByIdQueryResult>(data);
        return mapData;

    }
}
