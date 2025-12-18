namespace Inventory.Application.Responses.Products;

/// <summary>
/// Response model for a product list item. 
/// </summary>
public class ProductListItemResponse
{
    /// <summary>
    /// Unique identifier for the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Code representing the product.
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Name of the section the product belongs to.
    /// </summary>
    public string SectionName { get; set; } = string.Empty;

    /// <summary>
    /// Name of the category the product belongs to.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the product.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Maximum capacity of the product.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Price for single occupancy.
    /// </summary>
    public decimal? DoubleOccupancyPrice { get; set; }

    /// <summary>
    /// Indicates if the product has a balcony.
    /// </summary>
    public bool HasBalcony { get; set; }

    /// <summary>
    /// Indicates if the product is accessible. 
    /// </summary>
    public bool IsAccessible { get; set; }
}
