using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{
}
