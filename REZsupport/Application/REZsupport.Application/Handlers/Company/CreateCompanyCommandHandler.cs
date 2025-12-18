using MediatR;
using REZsupport.Application.Commands.Company;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ApiResponse<CompanyDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if company code already exists for the tenant
            if (!string.IsNullOrWhiteSpace(request.Company.CompanyCode))
            {
                // Validate company code uniqueness within the tenant
                var existingCompany = await _unitOfWork.Companies
                   .FindAsync(t => t.CompanyCode == request.Company.CompanyCode, cancellationToken);

                if (existingCompany != null)
                {
                    return ApiResponse<CompanyDto>.ErrorResponse("Company code already exists for this tenant.");
                }
            }

            var company = new REZsupport.Core.Entities.Company
            {
                CompanyId = Guid.NewGuid(),
                TenantId = request.Company.TenantId,
                CompanyCode = request.Company.CompanyCode,
                CompanyName = request.Company.CompanyName,
                CompanyType = request.Company.CompanyType,
                PrimaryContactId = request.Company.PrimaryContactId,
                Website = request.Company.Website,
                AddressLine1 = request.Company.AddressLine1,
                AddressLine2 = request.Company.AddressLine2,
                City = request.Company.City,
                StateProvince = request.Company.StateProvince,
                PostalCode = request.Company.PostalCode,
                Country = request.Company.Country,
                AccountStatus = "Active",
                CreatedBy = request.Company.TenantId.ToString(),
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = request.Company.TenantId.ToString(),
                ModifiedDate = DateTime.UtcNow
            };

            await _unitOfWork.Companies.AddAsync(company, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var companyDto = new CompanyDto
            {
                CompanyId = company.CompanyId,
                TenantId = company.TenantId,
                CompanyCode = company.CompanyCode ?? string.Empty,
                CompanyName = company.CompanyName,
                CompanyType = company.CompanyType,
                Website = company.Website,
                AddressLine1 = company.AddressLine1,
                City = company.City,
                StateProvince = company.StateProvince,
                Country = company.Country,
                AccountStatus = company.AccountStatus,
                IsActive = company.AccountStatus == "Active",
                CreatedDate = company.CreatedDate
            };

            return ApiResponse<CompanyDto>.SuccessResponse(companyDto, "Company created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<CompanyDto>.ErrorResponse($"Error creating company: {ex.Message}");
        }
    }
}
