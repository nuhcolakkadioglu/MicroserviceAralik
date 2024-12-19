using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.Order.Persistence.Repositories;
public class OrderingRepository(AppDbContext appDbContext) : IOrderingInterface
{

    public async Task<int> CreateOrdering(CreateOrderingCommand model)
    {
        var result = await appDbContext.Orderings.AddAsync(new Domain.Entities.Ordering
        {
            OrderDate = DateTime.Now,
            TotalPrice = model.TotalPrice,
            UserId = model.UserId,
        });

        await appDbContext.SaveChangesAsync();

        return result.Entity.Id;

    }


}
