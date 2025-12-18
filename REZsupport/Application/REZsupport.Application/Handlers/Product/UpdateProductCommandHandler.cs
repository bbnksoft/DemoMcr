using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Product;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.Commands.Product;

namespace Demo.Application.Handlers.Product;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<ProductDto>>
{
    private readonly ApplicationDbContext _context;

    public UpdateProductCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _context.Products
                .Include(p => p.Venue)
                .FirstOrDefaultAsync(p => p.ProductId == request.ProductId, cancellationToken);

            if (product == null)
            {
                return ApiResponse<ProductDto>.ErrorResponse("Product not found", new List<string> { $"Product with ID '{request.ProductId}' does not exist" });
            }

            // Update properties
            product.ProductName = request.Product.ProductName;
            if (request.Product.ProductCategoryId.HasValue)
            {
                product.CategoryId = request.Product.ProductCategoryId.Value;
            }
            product.Status = request.Product.AvailabilityStatus ?? "Available";
            product.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

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

            return ApiResponse<ProductDto>.SuccessResponse(productDto, "Product updated successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDto>.ErrorResponse("Failed to update product", new List<string> { ex.Message });
        }
    }
}
