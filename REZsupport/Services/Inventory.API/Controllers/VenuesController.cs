using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inventory.Application.DTOs;
using Inventory.Application.Features.Venues.Commands.CreateVenue;
using Inventory.Application.Features.Venues.Commands.UpdateVenue;
using Inventory.Application.Features.Venues.Commands.DeleteVenue;
using Inventory.Application.Features.Venues.Queries.GetVenueById;
using Inventory.Application.Features.Venues.Queries.GetAllVenues;

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
    public async Task<ActionResult<IEnumerable<VenueDto>>> GetAll()
    {
        var venues = await _mediator.Send(new GetAllVenuesQuery());
        return Ok(venues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VenueDto>> GetById(Guid id)
    {
        var venue = await _mediator.Send(new GetVenueByIdQuery(id));
        return Ok(venue);
    }

    [HttpPost]
    public async Task<ActionResult<VenueDto>> Create([FromBody] CreateVenueDto dto)
    {
        var command = new CreateVenueCommand
        {
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
        return CreatedAtAction(nameof(GetById), new { id = venue.Id }, venue);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<VenueDto>> Update(Guid id, [FromBody] UpdateVenueDto dto)
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
