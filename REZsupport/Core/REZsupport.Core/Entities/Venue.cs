using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REZsupport.Core.Entities;

[Table("Venues", Schema = "dbo")]
public class Venue
{
    [Key]
    public Guid VenueId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(50)]
    public string VenueCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string VenueName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string VenueType { get; set; } = string.Empty;

    public Guid? OperatorCompanyId { get; set; }

    [MaxLength(255)]
    public string? OperatorName { get; set; }

    [MaxLength(100)]
    public string? OperatorCode { get; set; }

    [MaxLength(255)]
    public string? AddressLine1 { get; set; }

    [MaxLength(255)]
    public string? AddressLine2 { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? StateProvince { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [Column(TypeName = "decimal(10,8)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(11,8)")]
    public decimal? Longitude { get; set; }

    public int? MaxCapacity { get; set; }

    public int? TotalUnits { get; set; }

    public int? YearBuilt { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Size { get; set; }

    [MaxLength(50)]
    public string? SizeUnit { get; set; }

    [MaxLength(50)]
    public string? ContactPhone { get; set; }

    [MaxLength(255)]
    public string? ContactEmail { get; set; }

    [MaxLength(500)]
    public string? Website { get; set; }

    [MaxLength(500)]
    public string? ThumbnailImageUrl { get; set; }

    public string? ImageGalleryJson { get; set; }

    public bool IsActive { get; set; } = true;

    [MaxLength(50)]
    public string Status { get; set; } = "Active";

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

    [ForeignKey(nameof(OperatorCompanyId))]
    public virtual Company? OperatorCompany { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
