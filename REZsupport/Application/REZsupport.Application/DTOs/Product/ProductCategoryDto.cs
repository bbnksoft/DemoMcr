namespace REZsupport.Application.DTOs.Product;

public class ProductCategoryDto
{
    public Guid ProductCategoryId { get; set; }
    public Guid TenantId { get; set; }
    public string CategoryCode { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public bool IsActive { get; set; }
}
