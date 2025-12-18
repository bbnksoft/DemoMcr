using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Venue;

namespace REZsupport.Application.Queries.Venue;
public class GetVenueByIdQuery : IRequest<ApiResponse<VenueDto>>
{
    public Guid VenueId { get; set; }
    public Guid? TenantId { get; set; }
}
