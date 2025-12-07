namespace Inventory.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; } = true;
    
    // Navigation property
    public Section Section { get; set; } = null!;
}
