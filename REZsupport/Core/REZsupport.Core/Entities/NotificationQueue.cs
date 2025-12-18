using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("NotificationQueue", Schema = "dbo")]
public class NotificationQueue
{
    [Key]
    public Guid QueueId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    public Guid? TemplateId { get; set; }

    [Required]
    [MaxLength(50)]
    public string RecipientType { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string RecipientAddress { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Subject { get; set; }

    public string? HtmlBody { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Queued";

    public DateTime? ScheduledSendDate { get; set; }

    public DateTime? ActualSendDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(TemplateId))]
    public virtual NotificationTemplate? Template { get; set; }
}
