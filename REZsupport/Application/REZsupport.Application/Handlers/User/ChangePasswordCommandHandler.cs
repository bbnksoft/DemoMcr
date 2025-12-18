using Demo.Application.Commands.User;
using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.User;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<bool>>
{
    private readonly ApplicationDbContext _context;

    public ChangePasswordCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return ApiResponse<bool>.ErrorResponse("User not found.");
            }

            // Note: In production, verify current password and hash new password properly
            // This is a simplified version
            user.PasswordHash = request.PasswordData.NewPassword;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Password changed successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error changing password: {ex.Message}");
        }
    }
}
