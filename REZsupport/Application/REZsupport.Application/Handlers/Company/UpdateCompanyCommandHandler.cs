using MediatR;
using REZsupport.Application.Commands.Company;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ApiResponse<CompanyDto>>
{

    private readonly IUnitOfWork _unitOfWork;
    public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Retrieve the existing company
            var company = await _unitOfWork.Companies.GetByIdAsync(request.CompanyId, cancellationToken);

            if (company == null)
            {
                return ApiResponse<CompanyDto>.ErrorResponse("Company not found.");
            }

            // Update company properties
            company.CompanyName = request.Company.CompanyName;
            company.CompanyType = request.Company.CompanyType;
            company.Website = request.Company.Website;
            company.AddressLine1 = request.Company.AddressLine1;
            company.AddressLine2 = request.Company.AddressLine2;
            company.City = request.Company.City;
            company.StateProvince = request.Company.StateProvince;
            company.PostalCode = request.Company.PostalCode;
            company.Country = request.Company.Country;
            company.AccountStatus = request.Company.IsActive ? "Active" : "Inactive";
            company.ModifiedDate = DateTime.UtcNow;

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

            return ApiResponse<CompanyDto>.SuccessResponse(companyDto, "Company updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<CompanyDto>.ErrorResponse($"Error updating company: {ex.Message}");
        }
    }
}
