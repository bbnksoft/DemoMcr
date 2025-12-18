using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("Reservations", Schema = "dbo")]
public class Reservation
{
    [Key]
    public Guid ReservationId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    public Guid EventId { get; set; }

    [Required]
    public Guid PrimaryContactId { get; set; }

    public Guid? CompanyId { get; set; }

    public Guid? GroupId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ReservationNumber { get; set; } = string.Empty;

    [MaxLength(50)]
    public string ReservationStatus { get; set; } = "Pending";

    public DateTime BookingDate { get; set; } = DateTime.Now;

    public DateTime? ConfirmationDate { get; set; }

    public DateTime? CancellationDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal SubtotalAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal FeesAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; } = 0;

    [MaxLength(10)]
    public string Currency { get; set; } = "USD";

    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountPaid { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountDue { get; set; } = 0;

    [MaxLength(50)]
    public string PaymentStatus { get; set; } = "Pending";

    public int TotalGuests { get; set; } = 0;

    public int AdultCount { get; set; } = 0;

    public int ChildCount { get; set; } = 0;

    [MaxLength(100)]
    public string BookingSource { get; set; } = "Website";

    [MaxLength(255)]
    public string? ReferralSource { get; set; }

    public string? SpecialRequests { get; set; }

    public string? InternalNotes { get; set; }

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

    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(PrimaryContactId))]
    public virtual Contact PrimaryContact { get; set; } = null!;

    [ForeignKey(nameof(CompanyId))]
    public virtual Company? Company { get; set; }

    [ForeignKey(nameof(GroupId))]
    public virtual Group? Group { get; set; }

    public virtual ICollection<ReservationProduct> ReservationProducts { get; set; } = new List<ReservationProduct>();
    public virtual ICollection<ReservationGuest> ReservationGuests { get; set; } = new List<ReservationGuest>();
    public virtual ICollection<ReservationMerchandise> ReservationMerchandises { get; set; } = new List<ReservationMerchandise>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
