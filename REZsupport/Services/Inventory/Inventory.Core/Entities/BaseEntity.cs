using System.ComponentModel.DataAnnotations;
namespace Inventory.Core.Entities;

/// <summary>
/// Base entity class that includes common properties for all entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The date and time when the entity was last modified.
    /// </summary>
    [Required]
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The creator of the entity.    
    /// </summary>
    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The modifier of the entity.        
    /// </summary>
    [MaxLength(450)]
    public string? ModifiedBy { get; set; }
}
