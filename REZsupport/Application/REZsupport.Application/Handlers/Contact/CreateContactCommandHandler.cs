using MediatR;
using REZsupport.Application.Commands.Contact;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Contact;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ApiResponse<ContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<ContactDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate company if provided
            if (request.Contact.CompanyId.HasValue)
            {
                var companyExists = await _unitOfWork.Companies.AnyAsync(c => c.CompanyId == request.Contact.CompanyId.Value, cancellationToken);

                if (!companyExists)
                {
                    return ApiResponse<ContactDto>.ErrorResponse("Company not found.");
                }
            }

            var contact = new REZsupport.Core.Entities.Contact
            {
                ContactId = Guid.NewGuid(),
                TenantId = request.Contact.TenantId,
                CompanyId = request.Contact.CompanyId,
                ContactType = request.Contact.ContactType ?? "Individual",
                FirstName = request.Contact.FirstName,
                LastName = request.Contact.LastName,
                MiddleName = request.Contact.MiddleName,
                Email = request.Contact.Email,
                Phone = request.Contact.Phone,
                JobTitle = request.Contact.JobTitle,
                Department = request.Contact.Department,
                AddressLine1 = request.Contact.AddressLine1,
                AddressLine2 = request.Contact.AddressLine2,
                City = request.Contact.City,
                StateProvince = request.Contact.StateProvince,
                PostalCode = request.Contact.PostalCode,
                Country = request.Contact.Country,
                DateOfBirth = request.Contact.DateOfBirth,
                CustomerStatus = "Active",
                CreatedBy = request.Contact.TenantId.ToString(),
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = request.Contact.TenantId.ToString(),
                ModifiedDate = DateTime.UtcNow
            };

            await _unitOfWork.Contacts.AddAsync(contact, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var contactDto = new ContactDto
            {
                ContactId = contact.ContactId,
                TenantId = contact.TenantId,
                CompanyId = contact.CompanyId,
                ContactType = contact.ContactType,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                JobTitle = contact.JobTitle,
                Department = contact.Department,
                AddressLine1 = contact.AddressLine1,
                City = contact.City,
                Country = contact.Country,
                CustomerStatus = contact.CustomerStatus,
                CustomerSince = contact.CustomerSince,
                IsActive = contact.CustomerStatus == "Active",
                CreatedDate = contact.CreatedDate
            };

            return ApiResponse<ContactDto>.SuccessResponse(contactDto, "Contact created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<ContactDto>.ErrorResponse($"Error creating contact: {ex.Message}");
        }
    }
}
