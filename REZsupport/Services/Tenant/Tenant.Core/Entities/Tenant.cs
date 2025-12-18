using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Tenants", Schema = "dbo")]
public class Tenant
{
    [Key]
    public Guid TenantId { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(50)]
    public string TenantCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string ContactEmail { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? ContactPhone { get; set; }

    [MaxLength(50)]
    public string SubscriptionTier { get; set; } = "Basic";

    public bool IsActive { get; set; } = true;

    public int MaxUsers { get; set; } = 10;

    public int MaxEvents { get; set; } = 50;

    public int StorageQuotaGB { get; set; } = 10;

    [MaxLength(50)]
    public string? PrimaryVertical { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    [MaxLength(450)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<TenantSetting> TenantSettings { get; set; } = new List<TenantSetting>();
    public virtual ICollection<TenantFeature> TenantFeatures { get; set; } = new List<TenantFeature>();
    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
