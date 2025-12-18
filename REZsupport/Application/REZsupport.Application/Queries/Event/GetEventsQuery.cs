using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Event;

namespace REZsupport.Application.Queries.Event;

public class GetEventsQuery : IRequest<ApiResponse<PagedResponse<EventListDto>>>
{
    public Guid? TenantId { get; set; }
    public Guid? VenueId { get; set; }
    public string? EventType { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDateFrom { get; set; }
    public DateTime? StartDateTo { get; set; }
    public string? SearchTerm { get; set; }
    public bool? IsActive { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public string SortOrder { get; set; } = "asc";
}
