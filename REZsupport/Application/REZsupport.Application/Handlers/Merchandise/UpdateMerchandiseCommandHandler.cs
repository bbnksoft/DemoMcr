using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.Merchandise;
using REZsupport.Application.DTOs.Merchandise;

namespace Demo.Application.Handlers.Merchandise;

public class UpdateMerchandiseCommandHandler : IRequestHandler<UpdateMerchandiseCommand, ApiResponse<MerchandiseDto>>
{
    private readonly ApplicationDbContext _context;

    public UpdateMerchandiseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<MerchandiseDto>> Handle(UpdateMerchandiseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var merchandise = await _context.Merchandises
                .FirstOrDefaultAsync(m => m.MerchandiseId == request.MerchandiseId, cancellationToken);

            if (merchandise == null)
            {
                return ApiResponse<MerchandiseDto>.ErrorResponse("Merchandise not found.");
            }

            // Update merchandise properties
            merchandise.ProductName = request.Merchandise.ProductName;
            merchandise.ShortDescription = request.Merchandise.Description;
            merchandise.BasePrice = request.Merchandise.UnitPrice ?? merchandise.BasePrice;
            merchandise.StockQuantity = request.Merchandise.QuantityInStock ?? merchandise.StockQuantity;
            merchandise.LowStockThreshold = request.Merchandise.ReorderLevel ?? merchandise.LowStockThreshold;
            merchandise.IsActive = request.Merchandise.IsActive;
            merchandise.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            var merchandiseDto = new MerchandiseDto
            {
                MerchandiseId = merchandise.MerchandiseId,
                TenantId = merchandise.TenantId,
                MerchandiseCategoryId = merchandise.CategoryId,
                CategoryName = merchandise.Category?.CategoryName,
                SKU = merchandise.SKU,
                ProductName = merchandise.ProductName,
                Description = merchandise.ShortDescription,
                UnitPrice = merchandise.BasePrice,
                Currency = "USD",
                QuantityInStock = merchandise.StockQuantity,
                AvailabilityStatus = merchandise.StockQuantity > 0 ? "In Stock" : "Out of Stock",
                IsActive = merchandise.IsActive,
                CreatedDate = merchandise.CreatedDate
            };

            return ApiResponse<MerchandiseDto>.SuccessResponse(merchandiseDto, "Merchandise updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<MerchandiseDto>.ErrorResponse($"Error updating merchandise: {ex.Message}");
        }
    }
}
