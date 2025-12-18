using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("TenantFeatures", Schema = "dbo")]
public class TenantFeature
{
    [Key]
    public Guid FeatureId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FeatureCode { get; set; } = string.Empty;

    public bool IsEnabled { get; set; } = true;

    public int? FeatureLimit { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? ConfigurationJson { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
