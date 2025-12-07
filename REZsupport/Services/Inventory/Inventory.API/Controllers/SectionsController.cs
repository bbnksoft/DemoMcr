using Inventory.Application.Features.Sections.Commands;
using Inventory.Application.Features.Sections.Queries;
using Inventory.Application.Responses.Sections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SectionsController> _logger;

    public SectionsController(IMediator mediator, ILogger<SectionsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SectionResponse>>> GetAll()
    {
        var sections = await _mediator.Send(new GetAllSectionsQuery());
        return Ok(sections);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SectionResponse>> GetById(Guid id)
    {
        var section = await _mediator.Send(new GetSectionByIdQuery(id));
        return Ok(section);
    }

    [HttpPost]
    public async Task<ActionResult<SectionResponse>> Create([FromBody] CreateSectionResponse dto)
    {
        var command = new CreateSectionCommand
        {
            Name = dto.Name,
            Description = dto.Description,
            VenueId = dto.VenueId,
            Capacity = dto.Capacity,
            RowCount = dto.RowCount,
            SectionType = dto.SectionType,
            IsActive = dto.IsActive
        };

        var section = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = section.Id }, section);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SectionResponse>> Update(Guid id, [FromBody] UpdateSectionResponse dto)
    {
        var command = new UpdateSectionCommand
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            VenueId = dto.VenueId,
            Capacity = dto.Capacity,
            RowCount = dto.RowCount,
            SectionType = dto.SectionType,
            IsActive = dto.IsActive
        };

        var section = await _mediator.Send(command);
        return Ok(section);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteSectionCommand(id));
        return NoContent();
    }
}
