using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("EventMerchandise", Schema = "dbo")]
public class EventMerchandise
{
    [Key]
    public Guid EventMerchandiseId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    [Required]
    public Guid MerchandiseId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? EventPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? EventCompareAtPrice { get; set; }

    public bool IsOnSale { get; set; } = false;

    public DateTime? SaleStartDate { get; set; }

    public DateTime? SaleEndDate { get; set; }

    public int? EventStockQuantity { get; set; }

    public int QuantitySold { get; set; } = 0;

    public int? MaxPerReservation { get; set; }

    public int DisplayOrder { get; set; } = 0;

    public bool IsVisible { get; set; } = true;

    public bool IsFeatured { get; set; } = false;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(MerchandiseId))]
    public virtual Merchandise Merchandise { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
