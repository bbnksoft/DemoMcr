using Inventory.Application.EnumTypes;
namespace Inventory.Application.Responses.Venues;
public class VenueResponse
{
    public Guid Id { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public VenueType VenueType { get; set; }
    public string VenueTypeDisplay => VenueType.ToString();
    public string Operator { get; set; } = string.Empty;
    public int? YearBuilt { get; set; }
    public int? Capacity { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    // Vertical-specific display names
    public string DisplayLabel => VenueType switch
    {
        VenueType.Cruise => "Ship",
        VenueType.Hotel => "Hotel",
        VenueType.Resort => "Resort",
        VenueType.Conference => "Conference",
        _ => "Venue"
    };
}
