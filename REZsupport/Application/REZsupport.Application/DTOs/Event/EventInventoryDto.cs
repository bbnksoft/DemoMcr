namespace REZsupport.Application.DTOs.Event;

public class EventInventoryDto
{
    public Guid EventInventoryId { get; set; }
    public Guid EventId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ProductCode { get; set; }
    public int? TotalQuantity { get; set; }
    public int? AvailableQuantity { get; set; }
    public decimal? DynamicPrice { get; set; }
    public string? Currency { get; set; }
    public string? ReservationStatus { get; set; }
    public bool IsActive { get; set; }
}
