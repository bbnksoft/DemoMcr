namespace Inventory.Application.Responses.Products;

/// <summary>
/// Response model for product category details.
/// </summary>
public class ProductCategoryResponse
{
    /// <summary>
    /// Gets or sets the unique identifier for the product category. 
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the product type associated with the category. 
    /// </summary>
    public Guid ProductTypeId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the product category.
    /// </summary>
    public string? CategoryCode { get; set; }

    /// <summary>
    /// Gets or sets the description of the product category.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the capacity of the product category.
    /// </summary>
    public int? Capacity { get; set; }

    /// <summary>
    /// Gets or sets the display order of the product category.
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product category is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the name of the product type associated with the category.
    /// </summary>
    public string? ProductTypeName { get; set; }

    /// <summary>
    /// Gets or sets the count of products in this category.
    /// </summary>
    public int ProductCount { get; set; }
}
