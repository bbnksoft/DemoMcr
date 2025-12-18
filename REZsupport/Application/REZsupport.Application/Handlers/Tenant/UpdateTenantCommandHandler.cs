using MediatR;
using REZsupport.Application.Commands.Tenant;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Tenant;
public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, ApiResponse<TenantDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTenantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<TenantDto>> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = await _unitOfWork.Tenants.GetByIdAsync(request.TenantId, cancellationToken);

            if (tenant == null)
            {
                return ApiResponse<TenantDto>.ErrorResponse("Tenant not found.");
            }

            // Update tenant properties
            tenant.CompanyName = request.Tenant.TenantName;
            tenant.ContactEmail = request.Tenant.ContactEmail ?? string.Empty;
            tenant.ContactPhone = request.Tenant.ContactPhone;
            tenant.IsActive = request.Tenant.IsActive;
            tenant.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var tenantDto = new TenantDto
            {
                TenantId = tenant.TenantId,
                TenantCode = tenant.TenantCode,
                TenantName = tenant.CompanyName,
                BusinessVertical = tenant.PrimaryVertical,
                ContactEmail = tenant.ContactEmail,
                ContactPhone = tenant.ContactPhone,
                IsActive = tenant.IsActive,
                CreatedDate = tenant.CreatedDate
            };

            return ApiResponse<TenantDto>.SuccessResponse(tenantDto, "Tenant updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<TenantDto>.ErrorResponse($"Error updating tenant: {ex.Message}");
        }
    }
}
