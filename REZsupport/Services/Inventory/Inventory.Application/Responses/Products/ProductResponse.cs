namespace Inventory.Application.Responses.Products;

/// <summary>
/// Represents the detailed response data for a product in the inventory system. 
/// </summary>
public class ProductResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the product. 
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the venue associated with the product.  
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the section associated with the product. 
    /// </summary>
    public Guid SectionId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the category associated with the product.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product type associated with the product. 
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product. 
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the product. 
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the type of the product.  
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the capacity of the product. 
    /// </summary>
    public int Capacity { get; set; }

    // Pricing
    /// <summary>
    /// Gets or sets the base price of the product. 
    /// </summary>
    public decimal? BasePrice { get; set; }

    /// <summary>
    /// Gets or sets the price for double occupancy of the product. 
    /// </summary>
    public decimal? DoubleOccupancyPrice { get; set; }

    /// <summary>
    /// Gets or sets the price for single supplement of the product. 
    /// </summary>
    public decimal? SingleSupplementPrice { get; set; }

    // Physical Details
    /// <summary>
    /// Gets or sets the square footage of the product.  
    /// </summary>
    public decimal? SquareFeet { get; set; }

    /// <summary>
    /// Gets or sets the bed type of the product. 
    /// </summary>
    public string? BedType { get; set; }

    /// <summary>
    /// Gets or sets the number of bedrooms in the product. 
    /// </summary>
    public int? BathroomCount { get; set; }

    // Features
    /// <summary>
    /// Gets or sets a value indicating whether the product has a balcony. 
    /// </summary>
    public bool HasBalcony { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has a window. 
    /// </summary>
    public bool HasWindow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is accessible. 
    /// </summary>
    public bool IsAccessible { get; set; }

    /// <summary>
    /// Gets or sets the amenities of the product. 
    /// </summary>
    public string? Amenities { get; set; }

    /// <summary>
    /// Gets or sets the image URL of the product.   
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the description of the product. 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets additional notes about the product.
    /// </summary>
    public string? Notes { get; set; }

    // Related Data
    /// <summary>
    /// Gets or sets the name of the venue associated with the product. 
    /// </summary>
    public string? VenueName { get; set; }

    /// <summary>
    /// Gets or sets the name of the section associated with the product.   
    /// </summary>
    public string? SectionName { get; set; }

    /// <summary>
    /// Gets or sets the name of the category associated with the product. 
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the name of the product type associated with the product. 
    /// </summary>
    public string? ProductTypeName { get; set; }

    // Availability
    /// <summary>
    /// Gets or sets a value indicating whether the product is currently available. 
    /// </summary>
    public bool IsCurrentlyAvailable { get; set; }

    /// <summary>
    /// Gets or sets the number of upcoming events associated with the product. 
    /// </summary>
    public int UpcomingEvents { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was created. 
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was last modified. 
    /// </summary>
    public DateTime ModifiedDate { get; set; }
}