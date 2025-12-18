using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Payments", Schema = "dbo")]
public class Payment
{
    [Key]
    public Guid PaymentId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ReservationId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(50)]
    public string? PaymentNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string PaymentType { get; set; } = string.Empty;

    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [MaxLength(10)]
    public string Currency { get; set; } = "USD";

    [MaxLength(50)]
    public string PaymentStatus { get; set; } = "Pending";

    [MaxLength(255)]
    public string? TransactionId { get; set; }

    [MaxLength(100)]
    public string? ProcessorName { get; set; }

    public string? ProcessorResponseJson { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(ReservationId))]
    public virtual Reservation Reservation { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
