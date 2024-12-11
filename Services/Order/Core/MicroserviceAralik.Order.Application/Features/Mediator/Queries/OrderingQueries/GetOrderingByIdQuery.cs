using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
public class GetOrderingByIdQuery(int id) : IRequest<GetOrderingByIdQueryResult>
{
    public int Id { get; set; } = id;
}
