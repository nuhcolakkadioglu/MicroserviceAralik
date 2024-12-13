using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Order.Presentation.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OrderDetailsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "OrderReadAccess")]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        List<Application.Features.Mediator.Results.OrderDetailResults.GetOrderDetailQueryResult> result = await _mediator.Send(new GetOrderDetailQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "OrderReadAccess")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        Application.Features.Mediator.Results.OrderDetailResults.GetOrderDetailByIdQueryResult result = await _mediator.Send(new GetOrderDetailByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand model)
    {
        await _mediator.Send(model);

        return Ok("OrderDetail  created successfully");
    }

    [HttpPut]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand model)
    {
        await _mediator.Send(model);

        return Ok("OrderDetail  updated successfully");
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> RemoveOrderDetail(int id)
    {
        await _mediator.Send(new RemoveOrderDetailCommand(id));

        return Ok("OrderDetail  updated successfully");
    }
}
