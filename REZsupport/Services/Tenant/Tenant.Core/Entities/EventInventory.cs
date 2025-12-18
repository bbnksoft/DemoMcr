using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("EventInventory", Schema = "dbo")]
public class EventInventory
{
    [Key]
    public Guid EventInventoryId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EventId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    public bool IsAvailable { get; set; } = true;

    [MaxLength(50)]
    public string ReservationStatus { get; set; } = "Available";

    public DateTime? ReservedUntil { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? SingleOccupancyPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? DoubleOccupancyPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TripleOccupancyPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? QuadOccupancyPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? AdditionalGuestPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? ChildPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? InfantPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? DepositAmount { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal? DepositPercentage { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TaxesAndFeesAmount { get; set; }

    public int? MinimumStay { get; set; }

    public int? MaximumStay { get; set; }

    public string? RestrictionsJson { get; set; }

    public int DisplayOrder { get; set; } = 0;

    public bool IsFeatured { get; set; } = false;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public virtual ProductCategory Category { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
