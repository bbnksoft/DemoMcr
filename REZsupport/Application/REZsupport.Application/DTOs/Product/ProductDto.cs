namespace REZsupport.Application.DTOs.Product;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public Guid TenantId { get; set; }
    public Guid VenueId { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public Guid? ProductTypeId { get; set; }
    public string? ProductTypeName { get; set; }
    public Guid? ProductCategoryId { get; set; }
    public string? ProductCategoryName { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public int? AdultCapacity { get; set; }
    public int? ChildCapacity { get; set; }
    public decimal? BasePrice { get; set; }
    public string? Currency { get; set; }
    public string? AvailabilityStatus { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}
