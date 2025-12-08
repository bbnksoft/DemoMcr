using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a product type in the inventory management system. 
/// </summary>
public class ProductType : BaseEntity
{
    /// <summary>
    /// The unique identifier for the product type. 
    /// </summary>
    [Key]
    public Guid ProductTypeId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the tenant that owns this product type. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the product type. 
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string ProductTypeName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the product type.  
    /// </summary>
    [MaxLength(50)]
    public string? ProductTypeCode { get; set; }

    /// <summary>
    /// The description of the product type.
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether the product type is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// The tenant that owns this product type. 
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// The collection of product categories associated with this product type. 
    /// </summary>
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
