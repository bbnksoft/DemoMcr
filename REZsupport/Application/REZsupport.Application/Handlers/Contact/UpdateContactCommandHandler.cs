using MediatR;
using REZsupport.Application.Commands.Contact;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Contact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ApiResponse<ContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<ContactDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Retrieve the existing contact
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactId, cancellationToken);

            if (contact == null)
            {
                return ApiResponse<ContactDto>.ErrorResponse("Contact not found.");
            }

            // Update contact properties
            contact.FirstName = request.Contact.FirstName;
            contact.LastName = request.Contact.LastName;
            contact.MiddleName = request.Contact.MiddleName;
            contact.Email = request.Contact.Email;
            contact.Phone = request.Contact.Phone;
            contact.JobTitle = request.Contact.JobTitle;
            contact.Department = request.Contact.Department;
            contact.AddressLine1 = request.Contact.AddressLine1;
            contact.AddressLine2 = request.Contact.AddressLine2;
            contact.City = request.Contact.City;
            contact.StateProvince = request.Contact.StateProvince;
            contact.PostalCode = request.Contact.PostalCode;
            contact.Country = request.Contact.Country;
            contact.CustomerStatus = request.Contact.IsActive ? "Active" : "Inactive";
            contact.ModifiedDate = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var contactDto = new ContactDto
            {
                ContactId = contact.ContactId,
                TenantId = contact.TenantId,
                CompanyId = contact.CompanyId,
                CompanyName = contact.Company?.CompanyName,
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

            return ApiResponse<ContactDto>.SuccessResponse(contactDto, "Contact updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<ContactDto>.ErrorResponse($"Error updating contact: {ex.Message}");
        }
    }
}
