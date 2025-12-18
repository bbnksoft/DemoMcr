using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("ProductTypes", Schema = "dbo")]
public class ProductType
{
    [Key]
    public Guid ProductTypeId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProductTypeCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string ProductTypeName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ApplicableVerticals { get; set; }

    public bool IsActive { get; set; } = true;

    public int DisplayOrder { get; set; } = 0;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
