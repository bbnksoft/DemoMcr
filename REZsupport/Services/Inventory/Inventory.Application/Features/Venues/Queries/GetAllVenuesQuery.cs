using MediatR;
using Inventory.Application.Responses.Venues;

namespace Inventory.Application.Features.Venues.Queries;

public class GetAllVenuesQuery : IRequest<IEnumerable<VenueResponse>> 
{ 
}

