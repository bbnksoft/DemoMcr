using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Product;

namespace REZsupport.Application.Queries.Product;

public class GetProductsQuery : IRequest<ApiResponse<PagedResponse<ProductListDto>>>
{
    public Guid? TenantId { get; set; }
    public Guid? VenueId { get; set; }
    public Guid? ProductTypeId { get; set; }
    public Guid? ProductCategoryId { get; set; }
    public string? SearchTerm { get; set; }
    public bool? IsActive { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public string SortOrder { get; set; } = "asc";
}
