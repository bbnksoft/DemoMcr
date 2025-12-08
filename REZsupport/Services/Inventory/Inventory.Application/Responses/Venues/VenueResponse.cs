namespace Inventory.Application.Responses.Venues;

/// <summary>
/// Represents a venue with detailed specifications, registration, location, operational, and metadata information.
/// </summary>
public class VenueResponse
{
    /// <summary>
    /// Unique identifier for the venue.
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Identifier for the tenant that owns the venue.
    /// </summary>
    public Guid TenantId { get; set; }

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

    // Specifications

    /// <summary>
    /// Maximum number of passengers the venue can accommodate.
    /// </summary>
    public int PassengerCapacity { get; set; }

    /// <summary>
    /// Maximum number of crew members the venue can accommodate.
    /// </summary>
    public int CrewCapacity { get; set; }

    /// <summary>
    /// Total number of decks in the venue.
    /// </summary>
    public int TotalDecks { get; set; }

    /// <summary>
    /// Total number of cabins in the venue.
    /// </summary>
    public int TotalCabins { get; set; }

    // Physical Details

    /// <summary>
    /// Gross tonnage of the venue.
    /// </summary>
    public decimal? GrossTonnage { get; set; }

    /// <summary>
    /// Length of the venue in meters.
    /// </summary>
    public decimal? Length { get; set; }

    /// <summary>
    /// Width of the venue in meters.
    /// </summary>
    public decimal? Width { get; set; }

    /// <summary>
    /// Draft of the venue in meters.
    /// </summary>
    public decimal? Draft { get; set; }

    // Registration

    /// <summary>
    /// Port where the venue is registered.
    /// </summary>
    public string? RegistryPort { get; set; }

    /// <summary>
    /// International Maritime Organization (IMO) number.
    /// </summary>
    public string? IMONumber { get; set; }

    /// <summary>
    /// Country of the venue's flag.
    /// </summary>
    public string? FlagCountry { get; set; }

    // Dates

    /// <summary>
    /// Year the venue was built.
    /// </summary>
    public int? BuildYear { get; set; }

    /// <summary>
    /// Year the venue was last refurbished.
    /// </summary>
    public int? RefurbishmentYear { get; set; }

    // Location

    /// <summary>
    /// Home port of the venue.
    /// </summary>
    public string? HomePort { get; set; }

    /// <summary>
    /// Current location of the venue.
    /// </summary>
    public string? CurrentLocation { get; set; }

    // Operational

    /// <summary>
    /// Current operational status of the venue.
    /// </summary>
    public string OperationalStatus { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the venue is available for booking.
    /// </summary>
    public bool AvailableForBooking { get; set; }

    // Media

    /// <summary>
    /// URL to the venue's logo image.
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// URL to the venue's main image.
    /// </summary>
    public string? ImageUrl { get; set; }

    // Descriptions

    /// <summary>
    /// Description of the venue.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Additional notes about the venue.
    /// </summary>
    public string? Notes { get; set; }

    // Metadata

    /// <summary>
    /// Date and time when the venue was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Date and time when the venue was last modified.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    // Stats

    /// <summary>
    /// Number of active events at the venue.
    /// </summary>
    public int ActiveEvents { get; set; }

    /// <summary>
    /// Number of available cabins in the venue.
    /// </summary>
    public int AvailableCabins { get; set; }
}
