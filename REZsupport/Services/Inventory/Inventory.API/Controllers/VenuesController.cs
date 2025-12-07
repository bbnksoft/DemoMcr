using Inventory.Application.Features.Venues.Commands;
using Inventory.Application.Features.Venues.Queries;
using Inventory.Application.Responses.Venues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenuesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VenuesController> _logger;

    public VenuesController(IMediator mediator, ILogger<VenuesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VenueResponse>>> GetAll()
    {
        var venues = await _mediator.Send(new GetAllVenuesQuery());
        return Ok(venues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VenueResponse>> GetById(Guid id)
    {
        var venue = await _mediator.Send(new GetVenueByIdQuery(id));
        return Ok(venue);
    }

    [HttpPost]
    public async Task<ActionResult<VenueResponse>> Create([FromBody] CreateVenueResponse dto)
    {
        var command = new CreateVenueCommand
        {
            //Name = dto.Name,
            //Description = dto.Description,
            //Address = dto.Address,
            //City = dto.City,
            //State = dto.State,
            //ZipCode = dto.ZipCode,
            //Country = dto.Country,
            //Capacity = dto.Capacity,
            //IsActive = dto.IsActive
        };

        var venue = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = venue.Id }, venue);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VenueResponse>> Update(Guid id, [FromBody] UpdateVenueResponse dto)
    {
        var command = new UpdateVenueCommand
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            Address = dto.Address,
            City = dto.City,
            State = dto.State,
            ZipCode = dto.ZipCode,
            Country = dto.Country,
            Capacity = dto.Capacity,
            IsActive = dto.IsActive
        };

        var venue = await _mediator.Send(command);
        return Ok(venue);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteVenueCommand(id));
        return NoContent();
    }
}
