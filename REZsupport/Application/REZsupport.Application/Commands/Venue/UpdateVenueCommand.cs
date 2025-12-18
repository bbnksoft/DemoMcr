using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Venue;

namespace Demo.Application.Commands.Venue;

public class UpdateVenueCommand : IRequest<ApiResponse<VenueDto>>
{
    public Guid VenueId { get; set; }
    public UpdateVenueDto Venue { get; set; } = null!;
}
