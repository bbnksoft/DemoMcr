using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.User;
using Demo.Application.Queries.User;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.User;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
{
    private readonly ApplicationDbContext _context;

    public GetUserByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Users.AsQueryable();

            if (request.TenantId.HasValue)
            {
                query = query.Where(u => u.TenantId == request.TenantId.Value);
            }

            var user = await query
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return ApiResponse<UserDto>.ErrorResponse("User not found.");
            }

            var userDto = new UserDto
            {
                UserId = user.UserId,
                TenantId = user.TenantId,
                Email = user.Email,
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                LastLoginDate = user.LastLoginDate,
                CreatedDate = user.CreatedDate,
                Roles = new List<string>()
            };

            return ApiResponse<UserDto>.SuccessResponse(userDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<UserDto>.ErrorResponse($"Error retrieving user: {ex.Message}");
        }
    }
}
