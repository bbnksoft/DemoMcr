using REZsupport.Application.DTOs.Section;

namespace REZsupport.Application.DTOs.Venue;
public class VenueDto
{
    public Guid VenueId { get; set; }
    public Guid TenantId { get; set; }
    public string VenueCode { get; set; } = string.Empty;
    public string VenueName { get; set; } = string.Empty;
    public string? VenueType { get; set; }
    public string? Description { get; set; }
    public string? AddressLine1 { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public int? TotalCapacity { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<SectionDto> Sections { get; set; } = new();
}