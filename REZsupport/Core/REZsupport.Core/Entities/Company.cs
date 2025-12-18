using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("Companies", Schema = "dbo")]
public class Company : BaseEntity
{
    [Key]
    public Guid CompanyId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(50)]
    public string? CompanyCode { get; set; }

    [Required]
    [MaxLength(255)]
    public string CompanyName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? CompanyType { get; set; }

    [MaxLength(255)]
    public string? LegalName { get; set; }

    [MaxLength(100)]
    public string? TaxId { get; set; }

    [MaxLength(100)]
    public string? BusinessRegistrationNumber { get; set; }

    public Guid? PrimaryContactId { get; set; }

    [MaxLength(255)]
    public string? PrimaryEmail { get; set; }

    [MaxLength(50)]
    public string? PrimaryPhone { get; set; }

    [MaxLength(500)]
    public string? Website { get; set; }

    [MaxLength(255)]
    public string? AddressLine1 { get; set; }

    [MaxLength(255)]
    public string? AddressLine2 { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? StateProvince { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [MaxLength(200)]
    public string? IndustryType { get; set; }

    [MaxLength(50)]
    public string? CompanySize { get; set; }

    [MaxLength(50)]
    public string AccountStatus { get; set; } = "Active";

    public DateTime? CustomerSince { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalRevenue { get; set; } = 0;

    public int TotalBookings { get; set; } = 0;

    [MaxLength(500)]
    public string? LogoUrl { get; set; }

    [MaxLength(50)]
    public string? BrandColor { get; set; }

    [MaxLength(200)]
    public string? Source { get; set; }

    public string? TagsJson { get; set; }

    public string? Notes { get; set; }

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

    [ForeignKey(nameof(PrimaryContactId))]
    public virtual Contact? PrimaryContact { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
