using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("Participants", Schema = "dbo")]
public class Participant
{
    [Key]
    public Guid ParticipantId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ContactId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ParticipantType { get; set; } = string.Empty;

    public Guid? CompanyId { get; set; }

    [MaxLength(200)]
    public string? Department { get; set; }

    [MaxLength(200)]
    public string? JobTitle { get; set; }

    [MaxLength(200)]
    public string? StageName { get; set; }

    [MaxLength(200)]
    public string? Specialty { get; set; }

    [MaxLength(50)]
    public string? ContractType { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? StandardRate { get; set; }

    [MaxLength(10)]
    public string Currency { get; set; } = "USD";

    [MaxLength(500)]
    public string? PaymentTerms { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    public decimal? RatingAverage { get; set; }

    public int TotalEventsWorked { get; set; } = 0;

    [MaxLength(50)]
    public string ParticipantStatus { get; set; } = "Active";

    public bool IsActive { get; set; } = true;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    [MaxLength(450)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ContactId))]
    public virtual Contact Contact { get; set; } = null!;

    [ForeignKey(nameof(CompanyId))]
    public virtual Company? Company { get; set; }

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
}
