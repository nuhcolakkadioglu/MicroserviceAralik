using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;

namespace MicroserviceAralik.Order.Application.Interfaces;
public interface IOrderingInterface
{
    Task<int> CreateOrdering(CreateOrderingCommand model);
}
