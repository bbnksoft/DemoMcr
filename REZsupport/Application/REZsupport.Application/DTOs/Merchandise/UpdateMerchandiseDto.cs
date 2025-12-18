namespace REZsupport.Application.DTOs.Merchandise;

public class UpdateMerchandiseDto
{
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? QuantityInStock { get; set; }
    public int? ReorderLevel { get; set; }
    public string? AvailabilityStatus { get; set; }
    public bool IsActive { get; set; }
}