namespace REZsupport.Application.DTOs.Merchandise;

public class CreateMerchandiseCategoryDto
{
    public Guid TenantId { get; set; }
    public string CategoryCode { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
