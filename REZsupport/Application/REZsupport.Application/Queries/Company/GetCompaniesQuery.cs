using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;
using MediatR;

namespace REZsupport.Application.Queries.Company;
public class GetCompaniesQuery : IRequest<ApiResponse<PagedResponse<CompanyListDto>>>
{
    public Guid? TenantId { get; set; }
    public string? CompanyType { get; set; }
    public string? SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "name";
    public string SortOrder { get; set; } = "asc";
}
