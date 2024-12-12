using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.AddresResults;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Queries.AddressQueries;
public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
{
}
