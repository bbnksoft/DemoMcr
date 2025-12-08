using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a section (Deck/Floor/Area) within a venue in the inventory management system. 
/// </summary>
public class Section : BaseEntity
{
    /// <summary>
    /// The unique identifier for the section.  
    /// </summary>
    [Key]
    public Guid SectionId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the venue that this section belongs to.   
    /// </summary>
    [Required]
    public Guid VenueId { get; set; }

    /// <summary>
    /// The unique identifier for the tenant that owns this section.  
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the section.  
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string SectionName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the section. 
    /// </summary>
    [MaxLength(50)]
    public string? SectionCode { get; set; }

    /// <summary>
    /// The number of the section. 
    /// </summary>
    public int SectionNumber { get; set; }

    /// <summary>
    /// The type of the section (e.g., Dining, Lounge, Cabin). 
    /// </summary>
    [MaxLength(100)]
    public string? SectionType { get; set; }

    /// <summary>
    /// The current status of the section (e.g., Active, Inactive, UnderMaintenance). 
    /// </summary>
    [MaxLength(50)]
    public string Status { get; set; } = "Active";

    /// <summary>
    /// The capacity of the section (e.g., number of seats, rooms). 
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// The total number of products associated with this section. 
    /// </summary>
    public int TotalProducts { get; set; }

    /// <summary>
    /// A detailed description of the section.  
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// Extended attributes for the section in JSON format. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Navigation property to the Venue entity that this section belongs to.
    /// </summary>
    [ForeignKey("VenueId")]
    public virtual Venue Venue { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Tenant entity that owns this section.     
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Navigation property to the collection of Products associated with this section. 
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}