using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.Merchandise;

namespace Demo.Application.Handlers.Merchandise;

public class DeleteMerchandiseCommandHandler : IRequestHandler<DeleteMerchandiseCommand, ApiResponse<bool>>
{
    private readonly ApplicationDbContext _context;

    public DeleteMerchandiseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteMerchandiseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var merchandise = await _context.Merchandises
                .FirstOrDefaultAsync(m => m.MerchandiseId == request.MerchandiseId, cancellationToken);

            if (merchandise == null)
            {
                return ApiResponse<bool>.ErrorResponse("Merchandise not found.");
            }

            // In a real application, you might want to check for dependencies
            // like orders or transactions that reference this merchandise

            _context.Merchandises.Remove(merchandise);
            await _context.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Merchandise deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting merchandise: {ex.Message}");
        }
    }
}
