using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a tenant in the multi-tenant inventory management system.
/// </summary>
public class Tenant : BaseEntity
{
    /// <summary>
    /// The unique identifier for the tenant.
    /// </summary>
    [Key]
    public Guid TenantId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique code for the tenant.
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string TenantCode { get; set; } = string.Empty;

    /// <summary>
    /// The name of the company associated with the tenant.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// The contact email for the tenant.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string ContactEmail { get; set; } = string.Empty;

    /// <summary>
    /// The contact phone number for the tenant.
    /// </summary>
    [MaxLength(50)]
    public string? ContactPhone { get; set; }

    /// <summary>
    /// The subscription tier of the tenant.
    /// </summary>
    [MaxLength(50)]
    public string SubscriptionTier { get; set; } = "Basic";

    /// <summary>
    /// Indicates whether the tenant is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// The maximum number of users allowed for the tenant.
    /// </summary>
    public int MaxUsers { get; set; } = 10;

    /// <summary>
    /// The maximum number of events allowed for the tenant.    
    /// </summary>
    public int MaxEvents { get; set; } = 50;

    /// <summary>
    /// The storage quota in GB for the tenant.
    /// </summary>
    public int StorageQuotaGB { get; set; } = 10;

    /// <summary>
    /// The primary vertical or industry of the tenant. 
    /// </summary>
    [MaxLength(50)]
    public string? PrimaryVertical { get; set; }

    /// <summary>
    /// JSON string to hold extended attributes for the tenant.   
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// The brand color of the tenant.
    /// </summary>
    // Computed Columns (mapped from JSON)
    [NotMapped]
    public string? BrandColor { get; set; }

    /// <summary>
    /// The time zone of the tenant. 
    /// </summary>
    [NotMapped]
    public string? TimeZone { get; set; }

    /// <summary>
    /// The currency used by the tenant.
    /// </summary>
    [NotMapped]
    public string? Currency { get; set; }

    /// <summary>
    /// Navigation properties for related entities.
    /// </summary>
    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();

    /// <summary>
    /// The collection of users associated with this tenant. 
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new List<User>();

    /// <summary>
    /// The collection of roles associated with this tenant. 
    /// </summary>
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    /// <summary>
    /// The collection of events associated with this tenant.
    /// </summary>
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
