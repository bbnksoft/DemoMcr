using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("ProductCategories", Schema = "dbo")]
public class ProductCategory
{
    [Key]
    public Guid CategoryId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    public Guid? VenueId { get; set; }

    [Required]
    public Guid ProductTypeId { get; set; }

    public Guid? ParentCategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CategoryCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int StandardOccupancy { get; set; } = 1;

    public int MaxOccupancy { get; set; } = 1;

    [Column(TypeName = "decimal(10,2)")]
    public decimal? Size { get; set; }

    [MaxLength(50)]
    public string? SizeUnit { get; set; }

    public string? AmenitiesJson { get; set; }

    [MaxLength(500)]
    public string? ThumbnailImageUrl { get; set; }

    public string? ImageGalleryJson { get; set; }

    public bool IsActive { get; set; } = true;

    public int DisplayOrder { get; set; } = 0;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(VenueId))]
    public virtual Venue? Venue { get; set; }

    [ForeignKey(nameof(ProductTypeId))]
    public virtual ProductType ProductType { get; set; } = null!;

    [ForeignKey(nameof(ParentCategoryId))]
    public virtual ProductCategory? ParentCategory { get; set; }

    public virtual ICollection<ProductCategory> ChildCategories { get; set; } = new List<ProductCategory>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
