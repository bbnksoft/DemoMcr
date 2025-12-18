using System;
namespace REZsupport.Application.DTOs.Event;

public class EventListDto
{
    public Guid EventId { get; set; }
    public string EventCode { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string? EventType { get; set; }
    public string? VenueName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public int? TotalCapacity { get; set; }
    public int? AvailableCapacity { get; set; }
}
