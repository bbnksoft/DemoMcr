namespace REZsupport.Application.DTOs.Event;

public class CreateEventDto
{
    public Guid TenantId { get; set; }
    public Guid? VenueId { get; set; }
    public string EventCode { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string? EventType { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? TimeZone { get; set; }
    public int? TotalCapacity { get; set; }
    public int? MinAttendees { get; set; }
    public int? MaxAttendees { get; set; }
    public string? Currency { get; set; }
}
