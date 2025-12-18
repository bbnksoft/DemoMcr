using MediatR;
using REZsupport.Application.Commands.Tenant;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Tenant;
public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, ApiResponse<TenantDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateTenantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<TenantDto>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate tenant code uniqueness
            var existingTenant = await _unitOfWork.Tenants.FindAsync(t => t.TenantCode == request.Tenant.TenantCode, cancellationToken);

            if (existingTenant != null)
            {
                return ApiResponse<TenantDto>.ErrorResponse("Tenant code already exists.");
            }

            // Create new tenant entity

            var tenant = new REZsupport.Core.Entities.Tenant
            {
                TenantId = Guid.NewGuid(),
                TenantCode = request.Tenant.TenantCode,
                CompanyName = request.Tenant.CompanyName,
                ContactEmail = request.Tenant.ContactEmail ?? string.Empty,
                ContactPhone = request.Tenant.ContactPhone,
                PrimaryVertical = request.Tenant.PrimaryVertical,
                SubscriptionTier = request.Tenant.SubscriptionTier ?? "Basic",
                IsActive = true,
                MaxUsers = request.Tenant.MaxUsers ?? 10,
                MaxEvents = request.Tenant.MaxEvents ?? 50,
                StorageQuotaGB = request.Tenant.StorageQuotaGB ?? 10,
                Companies = new List<REZsupport.Core.Entities.Company>(),
                Contacts = new List<REZsupport.Core.Entities.Contact>(),
                Venues = new List<REZsupport.Core.Entities.Venue>(),
                Events = new List<REZsupport.Core.Entities.Event>(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

                //CreatedBy = request.Tenant.CreatedBy,
                //UpdatedBy = request.Tenant.CreatedBy,
            };

            await _unitOfWork.Tenants.AddAsync(tenant, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Map to TenantDto
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

            return ApiResponse<TenantDto>.SuccessResponse(tenantDto, "Tenant created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<TenantDto>.ErrorResponse($"Error creating tenant: {ex.Message}");
        }
    }
}
