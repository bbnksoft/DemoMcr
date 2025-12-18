using Demo.Application.DTOs.Common;
using Demo.Application.Queries.Merchandise;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.DTOs.Merchandise;

namespace Demo.Application.Handlers.Merchandise;

public class GetMerchandiseByIdQueryHandler : IRequestHandler<GetMerchandiseByIdQuery, ApiResponse<MerchandiseDto>>
{
    private readonly ApplicationDbContext _context;

    public GetMerchandiseByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<MerchandiseDto>> Handle(GetMerchandiseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Merchandises.AsQueryable();

            if (request.TenantId.HasValue)
            {
                query = query.Where(m => m.TenantId == request.TenantId.Value);
            }

            var merchandise = await query
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.MerchandiseId == request.MerchandiseId, cancellationToken);

            if (merchandise == null)
            {
                return ApiResponse<MerchandiseDto>.ErrorResponse("Merchandise not found.");
            }

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

            return ApiResponse<MerchandiseDto>.SuccessResponse(merchandiseDto);
        }
        catch (Exception ex)
        {
            return ApiResponse<MerchandiseDto>.ErrorResponse($"Error retrieving merchandise: {ex.Message}");
        }
    }
}
