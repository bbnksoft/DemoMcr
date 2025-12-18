using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Venue;

namespace REZsupport.Application.Queries.Venue;
public class GetVenuesQuery : IRequest<ApiResponse<PagedResponse<VenueListDto>>>
{
    public Guid? TenantId { get; set; }
    public string? VenueType { get; set; }
    public string? SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "name";
    public string SortOrder { get; set; } = "asc";
}
