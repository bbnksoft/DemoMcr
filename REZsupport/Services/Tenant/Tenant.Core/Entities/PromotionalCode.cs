using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Persistence.Entities;

[Table("PromotionalCodes", Schema = "dbo")]
public class PromotionalCode
{
    [Key]
    public Guid PromoCodeId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    public Guid? EventId { get; set; }

    [Required]
    [MaxLength(50)]
    public string PromoCode { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(50)]
    public string DiscountType { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountValue { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public bool IsActive { get; set; } = true;

    public int? UsageLimitTotal { get; set; }

    public int TimesUsed { get; set; } = 0;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(EventId))]
    public virtual Event? Event { get; set; }
}
