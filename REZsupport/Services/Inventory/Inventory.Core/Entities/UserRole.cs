using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents the association between a user and a role within the inventory management system,
/// including assignment metadata and navigation properties.
/// </summary>
public class UserRole
{
    /// <summary>
    /// Unique identifier for the user-role association.
    /// </summary>
    [Key]
    public Guid UserRoleId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Identifier of the user assigned to the role.
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Identifier of the role assigned to the user.
    /// </summary>
    [Required]
    public Guid RoleId { get; set; }

    /// <summary>
    /// Date and time when the role was assigned to the user.
    /// </summary>
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Identifier of the user who assigned the role, if applicable.
    /// </summary>
    public Guid? AssignedBy { get; set; }

    /// <summary>
    /// Navigation property to the associated user.
    /// </summary>
    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;

    /// <summary>
    /// Navigation property to the associated role.
    /// </summary>
    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;
}

