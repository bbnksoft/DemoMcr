namespace Inventory.Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; } = true;
}

public class UpdateProductDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; }
}
