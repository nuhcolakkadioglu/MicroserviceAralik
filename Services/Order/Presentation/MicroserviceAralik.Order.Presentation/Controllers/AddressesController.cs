using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.AddressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.Order.Presentation.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class AddressesController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "OrderReadAccess")]
    public async Task<IActionResult> GetAllAddresses()
    {
        List<Application.Features.Mediator.Results.AddresResults.GetAddressQueryResult> result = await _mediator.Send(new GetAddressQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "OrderReadAccess")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        Application.Features.Mediator.Results.AddresResults.GetAdressByIdQueryResult result = await _mediator.Send(new GetAddressByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand model)
    {
        await _mediator.Send(model);

        return Ok("Address  created successfully");
    }

    [HttpPut]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand model)
    {
        await _mediator.Send(model);

        return Ok("Address  updated successfully");
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "OrderFullAccess")]
    public async Task<IActionResult> RemoveAddress(int id)
    {
        await _mediator.Send(new RemoveAddressCommand(id));

        return Ok("Address  updated successfully");
    }
}
