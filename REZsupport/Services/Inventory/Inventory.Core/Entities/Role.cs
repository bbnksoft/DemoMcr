using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a user role within a tenant in the inventory management system, including its permissions and associations.
/// </summary>
public class Role : BaseEntity
{
    /// <summary>
    /// Unique identifier for the role.
    /// </summary>
    [Key]
    public Guid RoleId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Identifier of the tenant to which the role belongs.
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// Name of the role (max 100 characters).
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Optional description of the role (max 500 characters).
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Indicates if the role is a system-defined role.
    /// </summary>
    public bool IsSystemRole { get; set; }

    /// <summary>
    /// Serialized permissions assigned to the role.
    /// </summary>
    [Column(TypeName = "nvarchar(max)")]
    public string? Permissions { get; set; }

    // Navigation Properties

    /// <summary>
    /// Navigation property to the associated Tenant entity.
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Collection of user-role associations for this role.
    /// </summary>
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

