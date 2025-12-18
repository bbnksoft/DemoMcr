using MediatR;
using REZsupport.Application.Commands.Tenant;
using REZsupport.Application.DTOs.Common;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Tenant;
public class DeleteTenantCommandHandler : IRequestHandler<DeleteTenantCommand, ApiResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTenantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<bool>> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = await _unitOfWork.Tenants.GetByIdAsync(request.TenantId, cancellationToken);

            if (tenant == null)
            {
                return ApiResponse<bool>.ErrorResponse("Tenant not found.");
            }

            //// Check for dependent records
            //var hasUsers = await _context.Users
            //    .AnyAsync(u => u.TenantId == request.TenantId, cancellationToken);

            //if (hasUsers)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete tenant. Users exist for this tenant.");
            //}

            //var hasCompanies = await _context.Companies
            //    .AnyAsync(c => c.TenantId == request.TenantId, cancellationToken);

            //if (hasCompanies)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete tenant. Companies exist for this tenant.");
            //}

            //var hasEvents = await _context.Events
            //    .AnyAsync(e => e.TenantId == request.TenantId, cancellationToken);

            //if (hasEvents)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete tenant. Events exist for this tenant.");
            //}

            await _unitOfWork.Tenants.DeleteAsync(tenant, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Tenant deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting tenant: {ex.Message}");
        }
    }
}
