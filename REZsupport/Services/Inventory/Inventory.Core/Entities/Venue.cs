using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a venue (Ship/Hotel/Venue) in the inventory management system. 
/// </summary>
public class Venue : BaseEntity
{
    /// <summary>
    /// The unique identifier for the venue.    
    /// </summary>
    [Key]
    public Guid VenueId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the tenant that owns this venue. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the venue.  
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string VenueName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the venue.   
    /// </summary>
    [MaxLength(50)]
    public string? VenueCode { get; set; }

    /// <summary>
    /// The type of the venue (e.g., Cruise Ship, Yacht, Ferry).   
    /// </summary>
    [MaxLength(100)]
    public string? VenueType { get; set; }

    /// <summary>
    /// The current status of the venue (e.g., Active, Inactive, UnderMaintenance).
    /// </summary>
    [MaxLength(50)]
    public string Status { get; set; } = "Active";

    //-- Specifications

    /// <summary>
    /// The maximum passenger capacity of the venue.     
    /// </summary>
    public int PassengerCapacity { get; set; }

    /// <summary>
    /// The maximum crew capacity of the venue.
    /// </summary>
    public int CrewCapacity { get; set; }

    /// <summary>
    /// The total number of decks on the venue. 
    /// </summary>
    public int TotalDecks { get; set; }

    /// <summary>
    /// The total number of cabins on the venue.
    /// </summary>
    public int TotalCabins { get; set; }

    //-- Physical Details

    /// <summary>
    /// The gross tonnage of the venue. 
    /// </summary>
    public decimal? GrossTonnage { get; set; }

    /// <summary>
    /// The length, width, and draft of the venue in meters.
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

    //-- Registration

    /// <summary>
    /// The registry number of the venue. 
    /// </summary>
    [MaxLength(100)]
    public string? RegistryPort { get; set; }

    /// <summary>
    /// The IMO number of the venue. 
    /// </summary>
    [MaxLength(50)]
    public string? IMONumber { get; set; }

    /// <summary>
    /// The MMSI number of the venue. 
    /// </summary>
    [MaxLength(100)]
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
    [MaxLength(200)]
    public string? HomePort { get; set; }

    /// <summary>
    /// The current location of the venue.     
    /// </summary>
    [MaxLength(200)]
    public string? CurrentLocation { get; set; }

    /// <summary>
    /// The URL of the venue's logo image. 
    /// </summary>
    [MaxLength(500)]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// The URL of an image representing the venue. 
    /// </summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// The operational status of the venue (e.g., InService, OutOfService). 
    /// </summary>
    [MaxLength(50)]
    public string OperationalStatus { get; set; } = "InService";

    /// <summary>
    /// Indicates whether the venue is available for booking.   
    /// </summary>
    public bool AvailableForBooking { get; set; } = true;

    /// <summary>
    /// A detailed description of the venue. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// Additional notes about the venue.  
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Notes { get; set; }

    /// <summary>
    /// JSON string to store extended attributes for the venue. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Navigation property to the Tenant that owns this venue.  
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Sections within this venue. 
    /// </summary>
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    /// <summary>
    /// Navigation property to the Products within this venue. 
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// Navigation property to the Events associated with this venue. 
    /// </summary>
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}