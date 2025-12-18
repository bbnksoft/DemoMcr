using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Contacts", Schema = "dbo")]
public class Contact
{
    [Key]
    public Guid ContactId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    public Guid? CompanyId { get; set; }

    [MaxLength(50)]
    public string? ContactCode { get; set; }

    [MaxLength(50)]
    public string ContactType { get; set; } = "Individual";

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? MiddleName { get; set; }

    [MaxLength(100)]
    public string? PreferredName { get; set; }

    [MaxLength(20)]
    public string? Salutation { get; set; }

    [MaxLength(20)]
    public string? Suffix { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }

    [MaxLength(50)]
    public string? AlternatePhone { get; set; }

    [MaxLength(50)]
    public string PreferredContactMethod { get; set; } = "Email";

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(50)]
    public string? Gender { get; set; }

    [MaxLength(100)]
    public string? Nationality { get; set; }

    [MaxLength(100)]
    public string? PassportNumber { get; set; }

    public DateTime? PassportExpiry { get; set; }

    [MaxLength(100)]
    public string? PassportCountry { get; set; }

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
    public string? EmergencyContactName { get; set; }

    [MaxLength(50)]
    public string? EmergencyContactPhone { get; set; }

    [MaxLength(100)]
    public string? EmergencyContactRelation { get; set; }

    [MaxLength(200)]
    public string? JobTitle { get; set; }

    [MaxLength(200)]
    public string? Department { get; set; }

    public bool IsPrimaryContact { get; set; } = false;

    public Guid? LinkedUserId { get; set; }

    [MaxLength(50)]
    public string CustomerStatus { get; set; } = "Active";

    public DateTime? CustomerSince { get; set; }

    public int TotalBookings { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal LifetimeValue { get; set; } = 0;

    public bool MarketingOptIn { get; set; } = false;

    [MaxLength(200)]
    public string? Source { get; set; }

    public string? TagsJson { get; set; }

    [MaxLength(500)]
    public string? ProfileImageUrl { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; } = true;

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

    [ForeignKey(nameof(CompanyId))]
    public virtual Company? Company { get; set; }

    [ForeignKey(nameof(LinkedUserId))]
    public virtual User? LinkedUser { get; set; }

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<ReservationGuest> ReservationGuests { get; set; } = new List<ReservationGuest>();
}
