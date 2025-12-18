using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;
using REZsupport.Application.Queries.Company;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;
public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, ApiResponse<PagedResponse<CompanyListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    public GetCompaniesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<PagedResponse<CompanyListDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _unitOfWork.Companies.GetQueryAsync(null, cancellationToken);

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(c => c.TenantId == request.TenantId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.CompanyType))
            {
                query = query.Where(c => c.CompanyType == request.CompanyType);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();
                query = query.Where(c =>
                    c.CompanyName.ToLower().Contains(searchLower) ||
                    (c.CompanyCode != null && c.CompanyCode.ToLower().Contains(searchLower)) ||
                    (c.LegalName != null && c.LegalName.ToLower().Contains(searchLower)));
            }

            // Get total count
            var totalRecords = query.Count();

            // Apply sorting
            query = request.SortBy.ToLower() switch
            {
                "code" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.CompanyCode)
                    : query.OrderBy(c => c.CompanyCode),
                "type" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.CompanyType)
                    : query.OrderBy(c => c.CompanyType),
                "createdate" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.CreatedDate)
                    : query.OrderBy(c => c.CreatedDate),
                _ => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.CompanyName)
                    : query.OrderBy(c => c.CompanyName)
            };

            var companies = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var companyDtos = companies.Select(c => new CompanyListDto
            {
                CompanyId = c.CompanyId,
                CompanyCode = c.CompanyCode ?? string.Empty,
                CompanyName = c.CompanyName,
                CompanyType = c.CompanyType,
                IndustryVertical = c.IndustryType,
                AccountStatus = c.AccountStatus,
                IsActive = c.AccountStatus == "Active"
            }).ToList();

            var pagedResponse = new PagedResponse<CompanyListDto>
            {
                Items = companyDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<CompanyListDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<CompanyListDto>>.ErrorResponse($"Error retrieving companies: {ex.Message}");
        }
    }
}
