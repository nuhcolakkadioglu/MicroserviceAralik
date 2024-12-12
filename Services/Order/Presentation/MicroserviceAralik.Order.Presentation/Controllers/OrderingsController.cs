using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Order.Presentation.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OrderingsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderings()
    {
        List<Application.Features.Mediator.Results.OrderingResults.GetOrderingQueryResult> result = await _mediator.Send(new GetOrderingQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        Application.Features.Mediator.Results.OrderingResults.GetOrderingByIdQueryResult result = await _mediator.Send(new GetOrderingByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand model)
    {
        await _mediator.Send(model);

        return Ok("Ordering  created successfully");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand model)
    {
        await _mediator.Send(model);

        return Ok("Ordering  updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveOrdering(int id)
    {
        await _mediator.Send(new RemoveOrderingCommand(id));

        return Ok("Ordering  updated successfully");
    }
}
