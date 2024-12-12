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
    public async Task<IActionResult> GetAllAddresses()
    {
        var result = await _mediator.Send(new GetAddressQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var result = await _mediator.Send(new GetAddressByIdQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand model)
    {
        await _mediator.Send(model);

        return Ok("Address  created successfully");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand model)
    {
        await _mediator.Send(model);

        return Ok("Address  updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAddress( int id)
    {
        await _mediator.Send(new RemoveAddressCommand(id));

        return Ok("Address  updated successfully");
    }
}
