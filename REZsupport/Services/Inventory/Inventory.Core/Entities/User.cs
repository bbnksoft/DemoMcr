using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a user in the inventory management system. 
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// The unique identifier for the user. 
    /// </summary>
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the tenant that owns this user. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The username of the user. 
    /// </summary>
    [Required]
    [MaxLength(256)]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the user.
    /// </summary>
    [Required]
    [MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the user's email address has been confirmed. 
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// The hashed password of the user. 
    /// </summary>
    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// A random value that must change whenever a user's credentials change (password changed, login removed).  
    /// </summary>
    public string? SecurityStamp { get; set; }

    /// <summary>
    /// The phone number of the user. 
    /// </summary>
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Indicates whether the user's phone number has been confirmed. 
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// Indicates whether two-factor authentication is enabled for the user. 
    /// </summary>
    public bool TwoFactorEnabled { get; set; }

    /// <summary>
    /// The date and time when the user is locked out until. 
    /// </summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>
    /// Indicates whether lockout is enabled for the user.   
    /// </summary>
    public bool LockoutEnabled { get; set; } = true;

    /// <summary>
    /// The number of failed access attempts for the user. 
    /// </summary>
    public int AccessFailedCount { get; set; }

    /// <summary>
    /// The first name of the user. 
    /// </summary>
    [MaxLength(100)]
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the user.  
    /// </summary>
    [MaxLength(100)]
    public string? LastName { get; set; }

    /// <summary>
    /// The display name of the user. 
    /// </summary>
    [MaxLength(200)]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Indicates whether the user is active. 
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// The date and time of the user's last login. 
    /// </summary>
    public DateTime? LastLoginDate { get; set; }

    /// <summary>
    /// Additional attributes for the user stored in JSON format. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// The tenant that owns this user. 
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// The collection of roles associated with this user.   
    /// </summary>
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
