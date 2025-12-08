namespace Inventory.Application.Responses.Venues;

/// <summary>
/// Represents the response returned after creating a venue, containing venue details and attributes.
/// </summary>
public class CreateVenueResponse
{
    /// <summary>
    /// The name of the venue.
    /// </summary>
    public string VenueName { get; set; } = string.Empty;

    /// <summary>
    /// The unique code identifying the venue.
    /// </summary>
    public string? VenueCode { get; set; }

    /// <summary>
    /// The type or category of the venue.
    /// </summary>
    public string? VenueType { get; set; }

    /// <summary>
    /// The current status of the venue (e.g., Active, Inactive).
    /// </summary>
    public string Status { get; set; } = "Active";

    /// <summary>
    /// The maximum number of passengers the venue can accommodate.
    /// </summary>
    public int PassengerCapacity { get; set; }

    /// <summary>
    /// The maximum number of crew members the venue can accommodate.
    /// </summary>
    public int CrewCapacity { get; set; }

    /// <summary>
    /// The total number of decks in the venue.
    /// </summary>
    public int TotalDecks { get; set; }

    /// <summary>
    /// The total number of cabins in the venue.
    /// </summary>
    public int TotalCabins { get; set; }

    /// <summary>
    /// The gross tonnage of the venue.
    /// </summary>
    public decimal? GrossTonnage { get; set; }

    /// <summary>
    /// The length of the venue in meters.
    /// </summary>
    public decimal? Length { get; set; }

    /// <summary>
    /// The width of the venue in meters.
    /// </summary>
    public decimal? Width { get; set; }

    /// <summary>
    /// The draft of the venue in meters.
    /// </summary>
    public decimal? Draft { get; set; }

    /// <summary>
    /// The port where the venue is registered.
    /// </summary>
    public string? RegistryPort { get; set; }

    /// <summary>
    /// The International Maritime Organization (IMO) number of the venue.
    /// </summary>
    public string? IMONumber { get; set; }

    /// <summary>
    /// The country whose flag the venue is flying.
    /// </summary>
    public string? FlagCountry { get; set; }

    /// <summary>
    /// The year the venue was built.
    /// </summary>
    public int? BuildYear { get; set; }

    /// <summary>
    /// The year the venue was last refurbished.
    /// </summary>
    public int? RefurbishmentYear { get; set; }

    /// <summary>
    /// The home port of the venue.
    /// </summary>
    public string? HomePort { get; set; }

    /// <summary>
    /// The current location of the venue.
    /// </summary>
    public string? CurrentLocation { get; set; }

    /// <summary>
    /// The operational status of the venue (e.g., InService, OutOfService).
    /// </summary>
    public string OperationalStatus { get; set; } = "InService";

    /// <summary>
    /// Indicates whether the venue is available for booking.
    /// </summary>
    public bool AvailableForBooking { get; set; } = true;

    /// <summary>
    /// The URL of the venue's logo image.
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// The URL of the venue's main image.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// A description of the venue.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Additional notes about the venue.
    /// </summary>
    public string? Notes { get; set; }
}
