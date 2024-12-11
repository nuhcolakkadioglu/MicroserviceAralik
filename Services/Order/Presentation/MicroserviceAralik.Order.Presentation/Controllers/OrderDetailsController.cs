using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Order.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        var result = await _mediator.Send(new GetOrderDetailQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var result = await _mediator.Send(new GetOrderDetailByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand model)
    {
        await _mediator.Send(model);

        return Ok("OrderDetail  created successfully");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand model)
    {
        await _mediator.Send(model);

        return Ok("OrderDetail  updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveOrderDetail( int id)
    {
        await _mediator.Send(new RemoveOrderDetailCommand(id));

        return Ok("OrderDetail  updated successfully");
    }
}
