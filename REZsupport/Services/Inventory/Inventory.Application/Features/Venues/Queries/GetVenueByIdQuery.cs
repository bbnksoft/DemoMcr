using MediatR;
using Inventory.Application.Responses.Venues;

namespace Inventory.Application.Features.Venues.Queries;

public class GetVenueByIdQuery : IRequest<VenueResponse>
{
    public Guid Id { get; set; }
    public GetVenueByIdQuery(Guid id) { Id = id; }
}
