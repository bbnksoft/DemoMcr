// Venue Commands and Queries
using MediatR;
using Inventory.Application.EnumTypes;
using Inventory.Application.Responses.Venues;

namespace Inventory.Application.Features.Venues.Commands;

public class CreateVenueCommand : IRequest<VenueResponse>
{
    public string VenueName { get; set; } = string.Empty;
    public VenueType VenueType { get; set; }
    public string Operator { get; set; } = string.Empty;
    public int? YearBuilt { get; set; } 
    public int? Capacity { get; set; }
    public string LocationData { get; set; } = string.Empty; // JSON
}
