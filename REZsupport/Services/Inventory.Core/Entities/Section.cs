namespace Inventory.Core.Entities;

public class Section : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid VenueId { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public string? SectionType { get; set; }
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public Venue Venue { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
