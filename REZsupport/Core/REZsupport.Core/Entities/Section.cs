using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("Sections", Schema = "dbo")]
public class Section
{
    [Key]
    public Guid SectionId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid VenueId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    public Guid? ParentSectionId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SectionCode { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? SectionName { get; set; }

    [MaxLength(100)]
    public string? SectionType { get; set; }

    public int? SectionNumber { get; set; }

    public int DisplayOrder { get; set; } = 0;

    public int HierarchyLevel { get; set; } = 1;

    public int TotalUnits { get; set; } = 0;

    public int? MaxCapacity { get; set; }

    public bool HasPublicSpaces { get; set; } = false;

    [MaxLength(500)]
    public string? LayoutMapUrl { get; set; }

    public string? ExtendedAttributes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey(nameof(VenueId))]
    public virtual Venue Venue { get; set; } = null!;

    [ForeignKey(nameof(TenantId))]
    public virtual Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(ParentSectionId))]
    public virtual Section? ParentSection { get; set; }

    public virtual ICollection<Section> ChildSections { get; set; } = new List<Section>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
