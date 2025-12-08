using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;
public class EventInventory : BaseEntity
{
    [Key]
    public Guid EventInventoryId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(50)]
    public string ReservationStatus { get; set; } = "Available";

    public bool IsAvailable { get; set; } = true;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? DoubleOccupancyPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SingleSupplementPrice { get; set; }

    public Guid? ReservationId { get; set; }
    public DateTime? ReservedDate { get; set; }
    public DateTime? HoldExpirationDate { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    // Navigation Properties
    [ForeignKey("EventId")]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;
}