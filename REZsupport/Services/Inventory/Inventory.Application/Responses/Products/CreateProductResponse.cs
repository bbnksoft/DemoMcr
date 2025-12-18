namespace Inventory.Application.Responses.Products;

/// <summary>
/// Represents the response data for creating a new product in the inventory system.
/// </summary>
public class CreateProductResponse
{
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
    /// Gets or sets the unique identifier of the tenant associated with the product. 
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the product. 
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the status of the product.
    /// </summary>
    public string Status { get; set; } = "Available";

    /// <summary>
    /// Gets or sets the capacity of the product. 
    /// </summary>
    public int Capacity { get; set; }

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

    /// <summary>
    /// Indicates whether the product has a balcony. 
    /// </summary>
    public bool HasBalcony { get; set; }

    /// <summary>
    /// Indicates whether the product has a window. 
    /// </summary>
    public bool HasWindow { get; set; }

    /// <summary>
    /// Indicates whether the product is accessible. 
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
}
