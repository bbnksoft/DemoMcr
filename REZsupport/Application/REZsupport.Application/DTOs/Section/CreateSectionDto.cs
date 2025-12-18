namespace REZsupport.Application.DTOs.Section;

public class CreateSectionDto
{
    public Guid VenueId { get; set; }
    public Guid TenantId { get; set; }
    public string SectionCode { get; set; } = string.Empty;
    public string SectionName { get; set; } = string.Empty;
    public string? SectionType { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public Guid? ParentSectionId { get; set; }
}
