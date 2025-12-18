using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Product;
using Demo.Application.Queries.Product;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Product;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Products
                .Include(p => p.Venue)
                .AsQueryable();

            if (request.TenantId.HasValue)
            {
                query = query.Where(p => p.TenantId == request.TenantId.Value);
            }

            var product = await query.FirstOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken);

            if (product == null)
            {
                return ApiResponse<ProductDto>.ErrorResponse("Product not found", new List<string> { $"Product with ID '{request.ProductId}' does not exist" });
            }

            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                TenantId = product.TenantId,
                VenueId = product.VenueId,
                VenueName = product.Venue?.VenueName ?? string.Empty,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductCategoryId = product.CategoryId != Guid.Empty ? product.CategoryId : null,
                AvailabilityStatus = product.Status,
                CreatedDate = product.CreatedDate
            };

            return ApiResponse<ProductDto>.SuccessResponse(productDto, "Product retrieved successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDto>.ErrorResponse("Failed to retrieve product", new List<string> { ex.Message });
        }
    }
}
