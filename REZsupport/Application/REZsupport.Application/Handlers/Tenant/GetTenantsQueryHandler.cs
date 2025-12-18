using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Tenant;
using REZsupport.Application.Queries.Tenant;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Tenant;

public class GetTenantsQueryHandler : IRequestHandler<GetTenantsQuery, ApiResponse<PagedResponse<TenantDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetTenantsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<PagedResponse<TenantDto>>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _unitOfWork.Tenants.GetQueryAsync(null, cancellationToken);

            // Apply filters
            if (request.IsActive.HasValue)
            {
                query = query.Where(t => t.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(t =>
                    t.TenantCode.Contains(request.SearchTerm) ||
                    t.CompanyName.Contains(request.SearchTerm) ||
                    (t.ContactEmail != null && t.ContactEmail.Contains(request.SearchTerm)));
            }

            // Apply sorting
            query = request.SortBy?.ToLower() switch
            {
                "code" => request.IsDescending ? query.OrderByDescending(t => t.TenantCode) : query.OrderBy(t => t.TenantCode),
                "name" => request.IsDescending ? query.OrderByDescending(t => t.CompanyName) : query.OrderBy(t => t.CompanyName),
                "createdate" => request.IsDescending ? query.OrderByDescending(t => t.CreatedDate) : query.OrderBy(t => t.CreatedDate),
                _ => query.OrderBy(t => t.TenantCode)
            };

            var totalRecords = query.Count();

            var tenants = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var tenantDtos = tenants.Select(t => new TenantDto
            {
                TenantId = t.TenantId,
                TenantCode = t.TenantCode,
                TenantName = t.CompanyName,
                BusinessVertical = t.PrimaryVertical,
                ContactEmail = t.ContactEmail,
                ContactPhone = t.ContactPhone,
                IsActive = t.IsActive,
                CreatedDate = t.CreatedDate
            }).ToList();

            var pagedResponse = new PagedResponse<TenantDto>
            {
                Items = tenantDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<TenantDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<TenantDto>>.ErrorResponse($"Error retrieving tenants: {ex.Message}");
        }
    }
}
