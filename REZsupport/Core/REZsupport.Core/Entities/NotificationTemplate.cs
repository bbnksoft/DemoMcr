using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("NotificationTemplates", Schema = "dbo")]
public class NotificationTemplate
{
    [Key]
    public Guid TemplateId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(100)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string TemplateName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string TemplateType { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Subject { get; set; }

    public string? HtmlBody { get; set; }

    public bool IsActive { get; set; } = true;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<NotificationQueue> NotificationQueues { get; set; } = new List<NotificationQueue>();
}
