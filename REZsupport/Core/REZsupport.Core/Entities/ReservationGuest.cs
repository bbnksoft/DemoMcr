using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("ReservationGuests", Schema = "dbo")]
public class ReservationGuest
{
    [Key]
    public Guid GuestId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ReservationId { get; set; }

    public Guid? ContactId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(50)]
    public string GuestType { get; set; } = "Adult";

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(100)]
    public string? PassportNumber { get; set; }

    public DateTime? PassportExpiry { get; set; }

    [MaxLength(50)]
    public string CheckInStatus { get; set; } = "NotCheckedIn";

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(ReservationId))]
    public virtual Reservation Reservation { get; set; } = null!;

    [ForeignKey(nameof(ContactId))]
    public virtual Contact? Contact { get; set; }

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
