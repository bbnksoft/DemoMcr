using Demo.Application.DTOs.Common;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.Merchandise;
using REZsupport.Application.DTOs.Merchandise;

namespace Demo.Application.Handlers.Merchandise;

public class CreateMerchandiseCommandHandler : IRequestHandler<CreateMerchandiseCommand, ApiResponse<MerchandiseDto>>
{
    private readonly ApplicationDbContext _context;

    public CreateMerchandiseCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<MerchandiseDto>> Handle(CreateMerchandiseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Check if SKU already exists for the tenant
            var existingMerchandise = await _context.Merchandises
                .FirstOrDefaultAsync(m => m.TenantId == request.Merchandise.TenantId 
                    && m.SKU == request.Merchandise.SKU, cancellationToken);

            if (existingMerchandise != null)
            {
                return ApiResponse<MerchandiseDto>.ErrorResponse("SKU already exists for this tenant.");
            }

            // Validate category if provided
            if (request.Merchandise.MerchandiseCategoryId.HasValue)
            {
                var categoryExists = await _context.MerchandiseCategories
                    .AnyAsync(c => c.CategoryId == request.Merchandise.MerchandiseCategoryId.Value, cancellationToken);

                if (!categoryExists)
                {
                    return ApiResponse<MerchandiseDto>.ErrorResponse("Category not found.");
                }
            }

            var merchandise = new Demo.Infrastructure.Persistence.Entities.Merchandise
            {
                MerchandiseId = Guid.NewGuid(),
                TenantId = request.Merchandise.TenantId,
                CategoryId = request.Merchandise.MerchandiseCategoryId,
                SKU = request.Merchandise.SKU,
                ProductName = request.Merchandise.ProductName,
                ShortDescription = request.Merchandise.Description,
                ProductType = "Physical",
                StockQuantity = request.Merchandise.QuantityInStock ?? 0,
                LowStockThreshold = request.Merchandise.ReorderLevel ?? 10,
                BasePrice = request.Merchandise.UnitPrice ?? 0,
                CostPrice = request.Merchandise.CostPrice,
                IsActive = true,
                CreatedBy = request.Merchandise.TenantId.ToString(),
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = request.Merchandise.TenantId.ToString(),
                ModifiedDate = DateTime.UtcNow
            };

            _context.Merchandises.Add(merchandise);
            await _context.SaveChangesAsync(cancellationToken);

            var merchandiseDto = new MerchandiseDto
            {
                MerchandiseId = merchandise.MerchandiseId,
                TenantId = merchandise.TenantId,
                MerchandiseCategoryId = merchandise.CategoryId,
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

            return ApiResponse<MerchandiseDto>.SuccessResponse(merchandiseDto, "Merchandise created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<MerchandiseDto>.ErrorResponse($"Error creating merchandise: {ex.Message}");
        }
    }
}
