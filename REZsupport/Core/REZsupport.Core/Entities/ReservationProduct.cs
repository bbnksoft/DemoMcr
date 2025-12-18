using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("ReservationProducts", Schema = "dbo")]
public class ReservationProduct
{
    [Key]
    public Guid ReservationProductId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ReservationId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    public string? AssignedContactsJson { get; set; }

    public int Occupancy { get; set; } = 1;

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal SubtotalAmount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Confirmed";

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(ReservationId))]
    public virtual Reservation Reservation { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
