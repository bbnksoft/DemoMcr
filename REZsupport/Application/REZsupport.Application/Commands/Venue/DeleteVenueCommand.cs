using MediatR;
using REZsupport.Application.DTOs.Common;

namespace Demo.Application.Commands.Venue;

public class DeleteVenueCommand : IRequest<ApiResponse<bool>>
{
    public Guid VenueId { get; set; }
}
