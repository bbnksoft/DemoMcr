using MediatR;
using REZsupport.Application.Commands.Company;
using REZsupport.Application.DTOs.Common;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, ApiResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var company = await _unitOfWork.Companies.GetByIdAsync(request.CompanyId, cancellationToken);

            if (company == null)
            {
                return ApiResponse<bool>.ErrorResponse("Company not found.");
            }

            //// Check for dependencies
            //var hasContacts = await _context.Contacts
            //    .AnyAsync(c => c.CompanyId == request.CompanyId, cancellationToken);

            //if (hasContacts)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete company with existing contacts. Consider deactivating instead.");
            //}

            //var hasVenues = await _context.Venues
            //    .AnyAsync(v => v.OperatorCompanyId == request.CompanyId, cancellationToken);

            //if (hasVenues)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete company that operates venues. Consider deactivating instead.");
            //}

            await _unitOfWork.Companies.DeleteAsync(company, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Company deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting company: {ex.Message}");
        }
    }
}
