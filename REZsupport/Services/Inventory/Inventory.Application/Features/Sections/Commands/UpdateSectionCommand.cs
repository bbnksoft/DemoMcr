using Inventory.Application.Responses.Sections;
using MediatR;

namespace Inventory.Application.Features.Sections.Commands;

public class UpdateSectionCommand : IRequest<SectionResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; }
}

