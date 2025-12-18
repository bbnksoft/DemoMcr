using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;
using REZsupport.Application.Queries.Tenant;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Tenant;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, ApiResponse<TenantDto>>
{

    private readonly IUnitOfWork _unitOfWork;
    public GetTenantByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<TenantDto>> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate tenant code uniqueness
            var tenant = await _unitOfWork.Tenants.GetByIdAsync(request.TenantId, cancellationToken);

            if (tenant == null)
            {
                return ApiResponse<TenantDto>.ErrorResponse("Tenant not found.");
            }

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

            return ApiResponse<TenantDto>.SuccessResponse(tenantDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<TenantDto>.ErrorResponse($"Error retrieving tenant: {ex.Message}");
        }
    }
}
