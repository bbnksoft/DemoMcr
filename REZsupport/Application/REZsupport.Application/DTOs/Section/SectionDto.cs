namespace REZsupport.Application.DTOs.Section;

public class SectionDto
{
    public Guid SectionId { get; set; }
    public Guid VenueId { get; set; }
    public string SectionCode { get; set; } = string.Empty;
    public string SectionName { get; set; } = string.Empty;
    public string? SectionType { get; set; }
    public int? Capacity { get; set; }
    public bool IsActive { get; set; }
}