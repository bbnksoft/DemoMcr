using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;

namespace REZsupport.Application.Commands.Tenant;
public class UpdateTenantCommand : IRequest<ApiResponse<TenantDto>>
{
    public Guid TenantId { get; set; }
    public UpdateTenantDto Tenant { get; set; } = new();
}
