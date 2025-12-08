using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents an event in the inventory management system. 
/// </summary>
public class Event : BaseEntity
{
    /// <summary>
    /// The unique identifier for the event. 
    /// </summary>
    [Key]
    public Guid EventId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the tenant that owns this event. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The unique identifier for the venue associated with this event.
    /// </summary>
    [Required]
    public Guid VenueId { get; set; }

    /// <summary>
    /// The name of the event.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string EventName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the event. 
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string EventCode { get; set; } = string.Empty;

    /// <summary>
    /// The type of the event (e.g., Concert, Conference, Festival).  
    /// </summary>
    [MaxLength(100)]
    public string? EventType { get; set; }

    /// <summary>
    /// The current status of the event (e.g., Draft, Published, Cancelled). 
    /// </summary>
    [MaxLength(50)]
    public string Status { get; set; } = "Draft";

    /// <summary>
    /// The start date and time of the event. 
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// The end date and time of the event.  
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// The duration of the event in days. 
    /// </summary>
    public int DurationDays { get; set; }

    /// <summary>
    /// The total capacity for the event (e.g., number of attendees). 
    /// </summary>
    public int TotalCapacity { get; set; }

    /// <summary>
    /// The number of booked slots for the event. 
    /// </summary>
    public int BookedCount { get; set; }

    /// <summary>
    /// The number of available slots for the event. 
    /// </summary>
    public int AvailableCount { get; set; }

    /// <summary>
    /// The base price for attending the event. 
    /// </summary>
    //[Column(TypeName = "decimal(18,2)")]
    public decimal? BasePrice { get; set; }

    /// <summary>
    /// Indicates whether the event is published or not. 
    /// </summary>
    public bool IsPublished { get; set; }

    /// <summary>
    /// The date and time when the event was published. 
    /// </summary>
    public DateTime? PublishedDate { get; set; }

    /// <summary>
    /// A detailed description of the event. 
    /// </summary>
    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// Extended attributes for the event in JSON format. 
    /// </summary>
    [Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Navigation property for the tenant that owns this event. 
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Navigation property for the venue associated with this event. 
    /// </summary>
    [ForeignKey("VenueId")]
    public virtual Venue Venue { get; set; } = null!;

    /// <summary>
    /// Navigation property for the collection of event inventories associated with this event. 
    /// </summary>
    public virtual ICollection<EventInventory> EventInventories { get; set; } = new List<EventInventory>();
}

