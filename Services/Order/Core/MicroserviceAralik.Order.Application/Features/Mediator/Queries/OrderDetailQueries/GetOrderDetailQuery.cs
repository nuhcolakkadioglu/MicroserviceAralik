using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
public class GetOrderDetailQuery:IRequest<List<GetOrderDetailQueryResult>>
{
}
