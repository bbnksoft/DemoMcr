using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("Groups", Schema = "dbo")]
public class Group
{
    [Key]
    public Guid GroupId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string GroupType { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string GroupName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? GroupCode { get; set; }

    public string? Description { get; set; }

    public Guid? CompanyId { get; set; }

    public Guid? PrimaryContactId { get; set; }

    public bool IsActive { get; set; } = true;

    [MaxLength(50)]
    public string GroupStatus { get; set; } = "Active";

    public int TotalMembers { get; set; } = 0;

    public int TotalBookings { get; set; } = 0;

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

    [ForeignKey(nameof(CompanyId))]
    public virtual Company? Company { get; set; }

    [ForeignKey(nameof(PrimaryContactId))]
    public virtual Contact? PrimaryContact { get; set; }

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
