using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;

namespace REZsupport.Application.Queries.Contact;

public class GetContactsQuery : IRequest<ApiResponse<PagedResponse<ContactListDto>>>
{
    public Guid? TenantId { get; set; }
    public Guid? CompanyId { get; set; }
    public string? ContactType { get; set; }
    public string? SearchTerm { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "lastname";
    public string SortOrder { get; set; } = "asc";
}
