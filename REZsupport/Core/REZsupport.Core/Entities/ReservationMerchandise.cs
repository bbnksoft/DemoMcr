using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("ReservationMerchandise", Schema = "dbo")]
public class ReservationMerchandise
{
    [Key]
    public Guid ReservationMerchandiseId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ReservationId { get; set; }

    [Required]
    public Guid MerchandiseId { get; set; }

    public Guid? VariantId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ProductSKU { get; set; }

    public int Quantity { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal SubtotalAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [MaxLength(50)]
    public string FulfillmentStatus { get; set; } = "Pending";

    public DateTime? FulfillmentDate { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(ReservationId))]
    public virtual Reservation Reservation { get; set; } = null!;

    [ForeignKey(nameof(MerchandiseId))]
    public virtual Merchandise Merchandise { get; set; } = null!;

    [ForeignKey(nameof(VariantId))]
    public virtual MerchandiseVariant? Variant { get; set; }

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
