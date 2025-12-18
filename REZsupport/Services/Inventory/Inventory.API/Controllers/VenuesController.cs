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
    /// <summary>
    /// The mediator instance for handling requests. 
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// The logger instance for logging information and errors. 
    /// </summary>
    private readonly ILogger<VenuesController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="VenuesController"/> class. 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="logger"></param>
    public VenuesController(IMediator mediator, ILogger<VenuesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Gets all venues.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<VenueResponse>>> GetAllVenuesAsync()
    {
        _logger.LogInformation("Getting all venues");

        var query = new GetAllVenuesQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VenueResponse>> GetVenueByIdAsync(Guid id)
    {
        _logger.LogInformation("Getting venue by ID: {VenueId}", id);

        var query = new GetVenueByIdQuery(id);
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<VenueResponse>> CreateVenue([FromBody] CreateVenueCommand command)
    {
        _logger.LogInformation("Creating a new venue");

        //var result = await _mediator.Send(command);
        //return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

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
    public async Task<ActionResult<VenueResponse>> UpdateVenue(Guid id, [FromBody] UpdateVenueResponse dto)
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
    public async Task<IActionResult> DeleteVenue(Guid id)
    {
        await _mediator.Send(new DeleteVenueCommand(id));
        return NoContent();
    }
}
