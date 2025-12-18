using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;

namespace REZsupport.Application.Queries.Tenant;

public class GetTenantByIdQuery : IRequest<ApiResponse<TenantDto>>
{
    public Guid TenantId { get; set; }
}
