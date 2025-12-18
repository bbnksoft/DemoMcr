using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.User;
using Demo.Application.Queries.User;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.User;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ApiResponse<PagedResponse<UserDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetUsersQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<PagedResponse<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Users.AsQueryable();

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(u => u.TenantId == request.TenantId.Value);
            }

            if (request.EmailConfirmed.HasValue)
            {
                query = query.Where(u => u.EmailConfirmed == request.EmailConfirmed.Value);
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(u => u.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();
                query = query.Where(u => 
                    u.Username.ToLower().Contains(searchLower) ||
                    u.Email.ToLower().Contains(searchLower) ||
                    (u.FirstName != null && u.FirstName.ToLower().Contains(searchLower)) ||
                    (u.LastName != null && u.LastName.ToLower().Contains(searchLower)));
            }

            // Get total count
            var totalRecords = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = request.SortBy.ToLower() switch
            {
                "email" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(u => u.Email) 
                    : query.OrderBy(u => u.Email),
                "createdate" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(u => u.CreatedDate) 
                    : query.OrderBy(u => u.CreatedDate),
                "lastname" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(u => u.LastName) 
                    : query.OrderBy(u => u.LastName),
                _ => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(u => u.Username) 
                    : query.OrderBy(u => u.Username)
            };

            // Apply pagination
            var users = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var userDtos = users.Select(u => new UserDto
            {
                UserId = u.UserId,
                TenantId = u.TenantId,
                Email = u.Email,
                FirstName = u.FirstName ?? string.Empty,
                LastName = u.LastName ?? string.Empty,
                PhoneNumber = u.PhoneNumber,
                IsActive = u.IsActive,
                LastLoginDate = u.LastLoginDate,
                CreatedDate = u.CreatedDate,
                Roles = new List<string>()
            }).ToList();

            var pagedResponse = new PagedResponse<UserDto>
            {
                Items = userDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<UserDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<UserDto>>.ErrorResponse($"Error retrieving users: {ex.Message}");
        }
    }
}
