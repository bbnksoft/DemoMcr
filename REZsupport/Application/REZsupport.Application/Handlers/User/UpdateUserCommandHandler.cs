using Demo.Application.Commands.User;
using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.User;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.User;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResponse<UserDto>>
{
    private readonly ApplicationDbContext _context;

    public UpdateUserCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return ApiResponse<UserDto>.ErrorResponse("User not found.");
            }

            // Update user properties
            user.FirstName = request.User.FirstName;
            user.LastName = request.User.LastName;
            user.PhoneNumber = request.User.PhoneNumber;
            user.IsActive = request.User.IsActive;
            user.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            // Map to DTO
            var userDto = new UserDto
            {
                UserId = user.UserId,
                TenantId = user.TenantId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                CreatedDate = user.CreatedDate,
                Roles = new List<string>()
            };

            return ApiResponse<UserDto>.SuccessResponse(userDto, "User updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<UserDto>.ErrorResponse($"Error updating user: {ex.Message}");
        }
    }
}
