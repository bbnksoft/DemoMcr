namespace Inventory.Application.DTOs;

public class SectionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateSectionDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; } = true;
}

public class UpdateSectionDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; }
}
