using MediatR;
using Inventory.Application.Responses.Sections;

namespace Inventory.Application.Features.Sections.Commands;
public class CreateSectionCommand : IRequest<SectionResponse>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; } = true;
}
