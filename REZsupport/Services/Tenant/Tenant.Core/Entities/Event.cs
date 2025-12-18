using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Events", Schema = "dbo")]
public class Event
{
    [Key]
    public Guid EventId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    public Guid VenueId { get; set; }

    [Required]
    [MaxLength(50)]
    public string EventCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string EventName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string EventType { get; set; } = "General";

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [MaxLength(100)]
    public string? TimeZone { get; set; }

    public int? MaxParticipants { get; set; }

    public int? MinParticipants { get; set; }

    public int CurrentBookingCount { get; set; } = 0;

    [MaxLength(50)]
    public string Status { get; set; } = "Planning";

    public bool IsWebEnabled { get; set; } = false;

    public bool IsBookingOpen { get; set; } = false;

    public DateTime? BookingOpenDate { get; set; }

    public DateTime? BookingCloseDate { get; set; }

    [MaxLength(200)]
    public string? EventBrand { get; set; }

    [MaxLength(200)]
    public string? EventTheme { get; set; }

    [MaxLength(500)]
    public string? BackdropImageUrl { get; set; }

    [MaxLength(500)]
    public string? ThumbnailImageUrl { get; set; }

    [MaxLength(255)]
    public string? ContactEmail { get; set; }

    [MaxLength(50)]
    public string? ContactPhone { get; set; }

    public string? TagsJson { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    [MaxLength(450)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(VenueId))]
    public virtual Venue Venue { get; set; } = null!;

    public virtual ICollection<EventInventory> EventInventories { get; set; } = new List<EventInventory>();
    public virtual ICollection<EventMerchandise> EventMerchandises { get; set; } = new List<EventMerchandise>();
    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
