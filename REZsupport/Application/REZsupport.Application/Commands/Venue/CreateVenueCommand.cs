using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Venue;

namespace Demo.Application.Commands.Venue;

public class CreateVenueCommand : IRequest<ApiResponse<VenueDto>>
{
    public CreateVenueDto Venue { get; set; } = null!;
}
