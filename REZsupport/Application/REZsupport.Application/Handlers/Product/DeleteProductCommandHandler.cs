using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.Product;

namespace Demo.Application.Handlers.Product;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<bool>>
{
    private readonly ApplicationDbContext _context;

    public DeleteProductCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken);

            if (product == null)
            {
                return ApiResponse<bool>.ErrorResponse("Product not found", new List<string> { $"Product with ID '{request.ProductId}' does not exist" });
            }

            // Check if product is used in any reservations or events
            var hasReservations = await _context.ReservationProducts
                .AnyAsync(rp => rp.ProductId == request.ProductId, cancellationToken);

            var hasEvents = await _context.EventInventories
                .AnyAsync(ei => ei.ProductId == request.ProductId, cancellationToken);

            if (hasReservations || hasEvents)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Cannot delete product",
                    new List<string> { "Product is associated with existing reservations or events. Consider deactivating instead." }
                );
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Product deleted successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse("Failed to delete product", new List<string> { ex.Message });
        }
    }
}
