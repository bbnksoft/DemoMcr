using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Products", Schema = "dbo")]
public class Product
{
    [Key]
    public Guid ProductId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid VenueId { get; set; }

    [Required]
    public Guid SectionId { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProductCode { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? ProductName { get; set; }

    [MaxLength(100)]
    public string? ProductType { get; set; }

    [MaxLength(200)]
    public string? LocationDescription { get; set; }

    public bool IsAccessible { get; set; } = false;

    public bool IsConnecting { get; set; } = false;

    public Guid? ConnectsToProductId { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Available";

    public bool IsPhantom { get; set; } = false;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(VenueId))]
    public virtual Venue Venue { get; set; } = null!;

    [ForeignKey(nameof(SectionId))]
    public virtual Section Section { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public virtual ProductCategory Category { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(ConnectsToProductId))]
    public virtual Product? ConnectsToProduct { get; set; }

    public virtual ICollection<EventInventory> EventInventories { get; set; } = new List<EventInventory>();
    public virtual ICollection<ReservationProduct> ReservationProducts { get; set; } = new List<ReservationProduct>();
}
