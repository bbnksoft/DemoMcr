using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Merchandise", Schema = "dbo")]
public class Merchandise
{
    [Key]
    public Guid MerchandiseId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    public Guid? CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string SKU { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProductType { get; set; } = string.Empty;

    public int StockQuantity { get; set; } = 0;

    public int LowStockThreshold { get; set; } = 10;

    public bool TrackInventory { get; set; } = true;

    public bool AllowBackorder { get; set; } = false;

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasePrice { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CompareAtPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CostPrice { get; set; }

    [MaxLength(50)]
    public string TaxCategory { get; set; } = "Standard";

    public bool HasVariants { get; set; } = false;

    public string? VariantOptionsJson { get; set; }

    [MaxLength(500)]
    public string? ThumbnailImageUrl { get; set; }

    public string? ImageGalleryJson { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsWebVisible { get; set; } = true;

    [MaxLength(255)]
    public string? SlugUrl { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    [MaxLength(450)]
    public string? ModifiedBy { get; set; }

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public virtual MerchandiseCategory? Category { get; set; }

    public virtual ICollection<MerchandiseVariant> MerchandiseVariants { get; set; } = new List<MerchandiseVariant>();
    public virtual ICollection<EventMerchandise> EventMerchandises { get; set; } = new List<EventMerchandise>();
}
