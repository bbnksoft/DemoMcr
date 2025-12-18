using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;
using REZsupport.Application.Queries.Company;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ApiResponse<CompanyDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate tenant code uniqueness
            var company = await _unitOfWork.Companies.GetByIdAsync(request.CompanyId, cancellationToken);

            if (company == null)
            {
                return ApiResponse<CompanyDto>.ErrorResponse("Company not found.");
            }

            var companyDto = new CompanyDto
            {
                CompanyId = company.CompanyId,
                TenantId = company.TenantId,
                CompanyCode = company.CompanyCode ?? string.Empty,
                CompanyName = company.CompanyName,
                CompanyType = company.CompanyType,
                IndustryVertical = company.IndustryType,
                Website = company.Website,
                AddressLine1 = company.AddressLine1,
                City = company.City,
                StateProvince = company.StateProvince,
                Country = company.Country,
                PostalCode = company.PostalCode,
                AccountStatus = company.AccountStatus,
                IsActive = company.AccountStatus == "Active",
                CreatedDate = company.CreatedDate
            };

            return ApiResponse<CompanyDto>.SuccessResponse(companyDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<CompanyDto>.ErrorResponse($"Error retrieving company: {ex.Message}");
        }
    }
}
