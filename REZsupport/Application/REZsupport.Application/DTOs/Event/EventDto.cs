namespace REZsupport.Application.DTOs.Event;
public class EventDto
{
    public Guid EventId { get; set; }
    public Guid TenantId { get; set; }
    public Guid? VenueId { get; set; }
    public string? VenueName { get; set; }
    public string EventCode { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string? EventType { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public int? TotalCapacity { get; set; }
    public int? AvailableCapacity { get; set; }
    public string? Currency { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<EventInventoryDto> Inventory { get; set; } = new();
}
