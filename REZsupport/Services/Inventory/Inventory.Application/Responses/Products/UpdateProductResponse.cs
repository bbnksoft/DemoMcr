namespace Inventory.Application.Responses.Products;

/// <summary>
/// Represents the response data for updating an existing product in the inventory system.
/// </summary>
public class UpdateProductResponse : CreateProductResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the product. 
    /// </summary>
    public Guid ProductId { get; set; }
}
