namespace REZsupport.Application.DTOs.Event;

public class CreateEventInventoryDto
{
    public Guid EventId { get; set; }
    public Guid ProductId { get; set; }
    public Guid TenantId { get; set; }
    public int? TotalQuantity { get; set; }
    public int? AvailableQuantity { get; set; }
    public decimal? DynamicPrice { get; set; }
    public string? Currency { get; set; }
}
