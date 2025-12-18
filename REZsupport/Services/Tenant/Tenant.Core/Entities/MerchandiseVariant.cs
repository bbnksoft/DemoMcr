using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("MerchandiseVariants", Schema = "dbo")]
public class MerchandiseVariant
{
    [Key]
    public Guid VariantId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid MerchandiseId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(100)]
    public string VariantSKU { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string VariantName { get; set; } = string.Empty;

    public string? OptionValuesJson { get; set; }

    public int StockQuantity { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CompareAtPrice { get; set; }

    public bool IsActive { get; set; } = true;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(MerchandiseId))]
    public virtual Merchandise Merchandise { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
