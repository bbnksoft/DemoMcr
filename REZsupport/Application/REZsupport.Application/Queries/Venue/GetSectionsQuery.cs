using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Section;

namespace REZsupport.Application.Queries.Venue;
public class GetSectionsQuery : IRequest<ApiResponse<List<SectionDto>>>
{
    public Guid VenueId { get; set; }
}
