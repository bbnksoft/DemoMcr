namespace REZsupport.Application.DTOs.Product;

public class CreateProductDto
{
    public Guid TenantId { get; set; }
    public Guid VenueId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public Guid? ProductTypeId { get; set; }
    public Guid? ProductCategoryId { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public int? AdultCapacity { get; set; }
    public int? ChildCapacity { get; set; }
    public decimal? BasePrice { get; set; }
    public string? Currency { get; set; }
    public string? UnitOfMeasure { get; set; }
    public Guid? SectionId { get; set; }
}
