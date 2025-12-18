using MediatR;
using REZsupport.Application.Commands.Product;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Product;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validate venue exists
            var venueExists = await _unitOfWork.Venues.AnyAsync(v => v.VenueId == request.Product.VenueId && v.TenantId == request.Product.TenantId, cancellationToken);

            if (!venueExists)
            {
                return ApiResponse<ProductDto>.ErrorResponse("Venue not found", new List<string> { "Invalid venue ID" });
            }

            // Check if product code already exists
            var codeExists = await _unitOfWork.Products
                .AnyAsync(p => p.VenueId == request.Product.VenueId && p.ProductCode == request.Product.ProductCode, cancellationToken);

            if (codeExists)
            {
                return ApiResponse<ProductDto>.ErrorResponse("Product code already exists", new List<string> { $"Product code '{request.Product.ProductCode}' is already in use for this venue" });
            }

            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                TenantId = request.Product.TenantId,
                VenueId = request.Product.VenueId,
                SectionId = request.Product.SectionId ?? Guid.Empty,
                CategoryId = request.Product.ProductCategoryId ?? Guid.Empty,
                ProductCode = request.Product.ProductCode,
                ProductName = request.Product.ProductName,
                ProductType = request.Product.ProductTypeId?.ToString(),
                Status = "Available",
                CreatedDate = DateTime.UtcNow
            };

            _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Fetch the created product with related data
            var createdProduct = await _unitOfWork.Products
                .Include(p => p.Venue)
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId, cancellationToken);

            var productDto = new ProductDto
            {
                ProductId = createdProduct!.ProductId,
                TenantId = createdProduct.TenantId,
                VenueId = createdProduct.VenueId,
                VenueName = createdProduct.Venue?.VenueName ?? string.Empty,
                ProductCode = createdProduct.ProductCode,
                ProductName = createdProduct.ProductName,
                ProductCategoryId = createdProduct.CategoryId != Guid.Empty ? createdProduct.CategoryId : null,
                AvailabilityStatus = createdProduct.Status,
                CreatedDate = createdProduct.CreatedDate
            };

            return ApiResponse<ProductDto>.SuccessResponse(productDto, "Product created successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<ProductDto>.ErrorResponse("Failed to create product", new List<string> { ex.Message });
        }
    }
}
