namespace Inventory.Application.Responses.Venues;

/// <summary>
/// Represents a summary of venue information for list responses.
/// </summary>
public class VenueListItemResponse
{
    /// <summary>
    /// Unique identifier for the venue.
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Name of the venue.
    /// </summary>
    public string VenueName { get; set; } = string.Empty;

    /// <summary>
    /// Optional code representing the venue.
    /// </summary>
    public string? VenueCode { get; set; }

    /// <summary>
    /// Optional type of the venue.
    /// </summary>
    public string? VenueType { get; set; }

    /// <summary>
    /// Status of the venue.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Maximum passenger capacity of the venue.
    /// </summary>
    public int PassengerCapacity { get; set; }

    /// <summary>
    /// Total number of decks in the venue.
    /// </summary>
    public int TotalDecks { get; set; }

    /// <summary>
    /// Total number of cabins in the venue.
    /// </summary>
    public int TotalCabins { get; set; }

    /// <summary>
    /// Optional IMO (International Maritime Organization) number.
    /// </summary>
    public string? IMONumber { get; set; }

    /// <summary>
    /// Optional home port of the venue.
    /// </summary>
    public string? HomePort { get; set; }

    /// <summary>
    /// Operational status of the venue.
    /// </summary>
    public string OperationalStatus { get; set; } = string.Empty;
}
