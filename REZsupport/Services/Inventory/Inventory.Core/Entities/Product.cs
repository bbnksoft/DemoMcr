using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Core.Entities;

/// <summary>
/// Represents a product (e.g., room, cabin, space) in the inventory management system. 
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// The unique identifier for the product. 
    /// </summary>
    [Key]
    public Guid ProductId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier for the venue that this product belongs to.   
    /// </summary>
    [Required]
    public Guid VenueId { get; set; }

    /// <summary>
    /// The unique identifier for the section that this product belongs to. 
    /// </summary>
    [Required]
    public Guid SectionId { get; set; }

    /// <summary>
    /// The unique identifier for the category of this product. 
    /// </summary>
    [Required]
    public Guid CategoryId { get; set; }

    /// <summary>
    /// The unique identifier for the tenant that owns this product. 
    /// </summary>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the product.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The code of the product.
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// The current status of the product (e.g., Available, Unavailable, Maintenance).
    /// </summary>
    [MaxLength(50)]
    public string Status { get; set; } = "Available";

    /// <summary>
    /// The capacity of the product (e.g., number of occupants for a room). 
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// The base price of the product. 
    /// </summary>
    //[Column(TypeName = "decimal(18,2)")]
    public decimal? BasePrice { get; set; }

    /// <summary>
    /// The price for double occupancy of the product.
    /// </summary>
    //[Column(TypeName = "decimal(18,2)")]
    public decimal? DoubleOccupancyPrice { get; set; }

    /// <summary>
    /// The price for single supplement of the product.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SingleSupplementPrice { get; set; }

    //-- Physical Details

    /// <summary>
    /// The square footage of the product (e.g., room size). 
    /// </summary>
    public decimal? SquareFeet { get; set; }

    /// <summary>
    /// The type of bed(s) in the product (e.g., King, Queen, Twin). 
    /// </summary>
    [MaxLength(50)]
    public string? BedType { get; set; }

    /// <summary>
    /// The number of beds in the product. 
    /// </summary>
    public int? BathroomCount { get; set; }

    //-- Features

    /// <summary>
    /// Indicates whether the product has a balcony.
    /// </summary>
    public bool HasBalcony { get; set; }

    /// <summary>
    /// Indicates whether the product has a window.  
    /// </summary>
    public bool HasWindow { get; set; }

    /// <summary>
    /// Indicates whether the product is accessible (e.g., wheelchair accessible). 
    /// </summary>
    public bool IsAccessible { get; set; }

    /// <summary>
    /// A list of amenities provided with the product.        
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Amenities { get; set; }

    /// <summary>
    /// The URL of the image representing the product.   
    /// </summary>
    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// A detailed description of the product.
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    /// <summary>
    /// Additional notes about the product. 
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? Notes { get; set; }

    /// <summary>
    /// JSON string to store extended attributes for the product.  
    /// </summary>
    //[Column(TypeName = "nvarchar(max)")]
    public string? ExtendedAttributes { get; set; }

    /// <summary>
    /// Navigation property to the Venue that owns this product. 
    /// </summary>
    // Navigation Properties
    [ForeignKey("VenueId")]
    public virtual Venue Venue { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Section that owns this product.   
    /// </summary>
    [ForeignKey("SectionId")]
    public virtual Section Section { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Category of this product. 
    /// </summary>
    [ForeignKey("CategoryId")]
    public virtual ProductCategory Category { get; set; } = null!;

    /// <summary>
    /// Navigation property to the Tenant that owns this product.
    /// </summary>
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// Navigation property to the EventInventories associated with this product.
    /// </summary>
    public virtual ICollection<EventInventory> EventInventories { get; set; } = new List<EventInventory>();
}
