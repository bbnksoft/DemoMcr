namespace REZsupport.Application.DTOs.Merchandise;

public class MerchandiseListDto
{
    public Guid MerchandiseId { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? CategoryName { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? Currency { get; set; }
    public int? QuantityInStock { get; set; }
    public string? AvailabilityStatus { get; set; }
}
