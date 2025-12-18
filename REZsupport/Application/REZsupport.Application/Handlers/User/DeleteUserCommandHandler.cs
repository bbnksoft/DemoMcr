using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.User;

namespace Demo.Application.Handlers.User;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse<bool>>
{
    private readonly ApplicationDbContext _context;

    public DeleteUserCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                return ApiResponse<bool>.ErrorResponse("User not found.");
            }

            // Check for dependencies
            var hasReservations = await _context.Reservations
                .AnyAsync(r => r.CreatedBy == request.UserId.ToString(), cancellationToken);

            if (hasReservations)
            {
                return ApiResponse<bool>.ErrorResponse("Cannot delete user with existing reservations. Consider deactivating instead.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "User deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting user: {ex.Message}");
        }
    }
}
