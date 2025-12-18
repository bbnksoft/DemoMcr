using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Contact;
using REZsupport.Application.Queries.Contact;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Company;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, ApiResponse<PagedResponse<ContactListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetContactsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<PagedResponse<ContactListDto>>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _unitOfWork.Contacts.GetQueryAsync(null, cancellationToken);

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(c => c.TenantId == request.TenantId.Value);
            }

            if (request.CompanyId.HasValue)
            {
                query = query.Where(c => c.CompanyId == request.CompanyId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.ContactType))
            {
                query = query.Where(c => c.ContactType == request.ContactType);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();
                query = query.Where(c =>
                    c.FirstName.ToLower().Contains(searchLower) ||
                    c.LastName.ToLower().Contains(searchLower) ||
                    (c.Email != null && c.Email.ToLower().Contains(searchLower)) ||
                    (c.ContactCode != null && c.ContactCode.ToLower().Contains(searchLower)));
            }

            // Get total count
            var totalRecords = query.Count();

            // Apply sorting
            query = request.SortBy.ToLower() switch
            {
                "firstname" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.FirstName)
                    : query.OrderBy(c => c.FirstName),
                "email" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.Email)
                    : query.OrderBy(c => c.Email),
                "createdate" => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.CreatedDate)
                    : query.OrderBy(c => c.CreatedDate),
                _ => request.SortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(c => c.LastName)
                    : query.OrderBy(c => c.LastName)
            };

            // Apply pagination
            var contacts = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var contactDtos = contacts.Select(c => new ContactListDto
            {
                ContactId = c.ContactId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                CompanyName = c.Company?.CompanyName,
                ContactType = c.ContactType,
                CustomerStatus = c.CustomerStatus
            }).ToList();

            var pagedResponse = new PagedResponse<ContactListDto>
            {
                Items = contactDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<ContactListDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<ContactListDto>>.ErrorResponse($"Error retrieving contacts: {ex.Message}");
        }
    }
}
