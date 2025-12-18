using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;

namespace REZsupport.Application.Queries.Tenant;

public class GetTenantsQuery : IRequest<ApiResponse<PagedResponse<TenantDto>>>
{
    public bool? IsActive { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
