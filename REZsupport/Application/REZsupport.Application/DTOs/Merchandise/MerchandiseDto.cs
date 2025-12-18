namespace REZsupport.Application.DTOs.Merchandise;

public class MerchandiseDto
{
    public Guid MerchandiseId { get; set; }
    public Guid TenantId { get; set; }
    public Guid? MerchandiseCategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? Currency { get; set; }
    public string? MeasurementUnit { get; set; }
    public int? QuantityInStock { get; set; }
    public string? AvailabilityStatus { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}