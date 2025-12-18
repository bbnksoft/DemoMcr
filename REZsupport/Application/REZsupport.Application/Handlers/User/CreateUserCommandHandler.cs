using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.User;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.User;

namespace Demo.Application.Handlers.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserDto>>
{
    private readonly ApplicationDbContext _context;

    public CreateUserCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if email already exists
            var existingEmail = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.User.Email, cancellationToken);

            if (existingEmail != null)
            {
                return ApiResponse<UserDto>.ErrorResponse("Email already exists.");
            }

            // Create new user - Note: In production, hash the password properly
            var user = new Demo.Infrastructure.Persistence.Entities.User
            {
                UserId = Guid.NewGuid(),
                TenantId = request.User.TenantId,
                Username = request.User.Email,
                Email = request.User.Email,
                PasswordHash = request.User.Password,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                PhoneNumber = request.User.PhoneNumber,
                EmailConfirmed = false,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.Users.Add(user);
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

            return ApiResponse<UserDto>.SuccessResponse(userDto, "User created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<UserDto>.ErrorResponse($"Error creating user: {ex.Message}");
        }
    }
}
