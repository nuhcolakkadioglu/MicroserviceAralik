using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.AddresResults;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Queries.AddressQueries;
public class GetAddressByIdQuery(int id) : IRequest<GetAdressByIdQueryResult>
{
    public int Id { get; set; } = id;
}
