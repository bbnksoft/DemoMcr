namespace REZsupport.Application.DTOs.Product;

public class UpdateProductDto
{
    public string ProductName { get; set; } = string.Empty;
    public Guid? ProductCategoryId { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public int? AdultCapacity { get; set; }
    public int? ChildCapacity { get; set; }
    public decimal? BasePrice { get; set; }
    public string? AvailabilityStatus { get; set; }
    public bool IsActive { get; set; }
}
