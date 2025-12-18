using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.Tenant;
public class DeleteTenantCommand : IRequest<ApiResponse<bool>>
{
    public Guid TenantId { get; set; }
}
