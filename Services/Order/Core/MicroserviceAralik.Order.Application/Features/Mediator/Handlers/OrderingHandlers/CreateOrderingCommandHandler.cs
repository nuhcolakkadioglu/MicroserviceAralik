using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Events;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;
using MicroserviceAralik.RabbitMQ.Abstract;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class CreateOrderingCommandHandler(IOrderingInterface _writeRepository, IRabbitMQPublisher _rabbitMQPublisher) : IRequestHandler<CreateOrderingCommand, int>
{
    public async Task<int> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
         var result = await _writeRepository.CreateOrdering(request);

        var orderCreatedEvent = new OrderCreateEvent()
        {
            Id = result,
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId
        };

        _rabbitMQPublisher.Publish("orderCreatedQueue", orderCreatedEvent);


        return result;
    }
}
