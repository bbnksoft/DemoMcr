using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;
using REZsupport.Application.Queries.Contact;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Contact;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ApiResponse<ContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetContactByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse<ContactDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate tenant code uniqueness
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactId, cancellationToken);

            if (contact == null)
            {
                return ApiResponse<ContactDto>.ErrorResponse("Contact not found.");
            }

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

            return ApiResponse<ContactDto>.SuccessResponse(contactDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<ContactDto>.ErrorResponse($"Error retrieving contact: {ex.Message}");
        }
    }
}
