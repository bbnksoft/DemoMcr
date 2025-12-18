using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("GroupMembers", Schema = "dbo")]
public class GroupMember
{
    [Key]
    public Guid GroupMemberId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public Guid ContactId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [MaxLength(200)]
    public string? RoleInGroup { get; set; }

    public bool IsPrimaryContact { get; set; } = false;

    public DateTime JoinDate { get; set; } = DateTime.Today;

    public DateTime? LeaveDate { get; set; }

    public bool IsActive { get; set; } = true;

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey(nameof(ContactId))]
    public virtual Contact Contact { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;
}
