namespace REZsupport.Application.DTOs.Product;
public class ProductListDto
{
    public Guid ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? ProductTypeName { get; set; }
    public string? ProductCategoryName { get; set; }
    public int? Capacity { get; set; }
    public decimal? BasePrice { get; set; }
    public string? Currency { get; set; }
    public string? AvailabilityStatus { get; set; }
    public bool IsActive { get; set; }
}