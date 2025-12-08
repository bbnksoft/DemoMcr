using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a product category in the inventory management system. 
/// </summary>
public class ProductCategory : BaseEntity
{
    /// <summary>
    /// The unique identifier for the product category. 
    /// </summary>
    [Key]
    public Guid CategoryId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the product type that this category belongs to. 
    /// </summary>
    [Required]
    public Guid ProductTypeId { get; set; }

    /// <summary>
    /// The unique identifier for the tenant that owns this product category. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the product category. 
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the product category. 
    /// </summary>
    [MaxLength(50)]
    public string? CategoryCode { get; set; }

    /// <summary>
    /// The description of the product category.
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// The capacity of the product category (e.g., number of items allowed in this category). 
    /// </summary>
    public int? Capacity { get; set; }

    /// <summary>
    /// The display order of the product category in listings.  
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Indicates whether the product category is active. 
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Extended attributes for the product category in JSON format. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Navigation property to the ProductType entity that this category belongs to. 
    /// </summary>
    [ForeignKey("ProductTypeId")]
    public virtual ProductType ProductType { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Tenant that owns this product category.  
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Navigation property to the collection of Products associated with this category. 
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
