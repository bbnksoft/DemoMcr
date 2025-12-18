using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;

namespace REZsupport.Application.Commands.Tenant;

public class CreateTenantCommand : IRequest<ApiResponse<TenantDto>>
{
    public CreateTenantDto Tenant { get; set; } = new();
}
