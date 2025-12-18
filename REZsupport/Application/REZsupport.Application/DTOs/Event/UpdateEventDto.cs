namespace REZsupport.Application.DTOs.Event;
public class UpdateEventDto
{
    public string EventName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public int? TotalCapacity { get; set; }
    public bool IsActive { get; set; }
}
