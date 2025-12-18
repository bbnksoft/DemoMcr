using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("EventParticipants", Schema = "dbo")]
public class EventParticipant
{
    [Key]
    public Guid EventParticipantId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    [Required]
    public Guid ParticipantId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(200)]
    public string? RoleOnEvent { get; set; }

    public DateTime? AssignmentStartDate { get; set; }

    public DateTime? AssignmentEndDate { get; set; }

    public Guid? ProductId { get; set; }

    public DateTime? ProductAssignmentDate { get; set; }

    [MaxLength(50)]
    public string? CheckInStatus { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CompensationAmount { get; set; }

    [MaxLength(50)]
    public string? CompensationType { get; set; }

    [MaxLength(50)]
    public string PaymentStatus { get; set; } = "Pending";

    public string? ScheduleJson { get; set; }

    public string? TasksJson { get; set; }

    public int TasksCompletedCount { get; set; } = 0;

    [MaxLength(50)]
    public string ParticipationStatus { get; set; } = "Confirmed";

    public bool IsActive { get; set; } = true;

    public string? Notes { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(ParticipantId))]
    public virtual Participant Participant { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product? Product { get; set; }

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
