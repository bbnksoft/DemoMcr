using Demo.Application.DTOs.Common;
using Demo.Application.DTOs.Product;
using Demo.Application.Queries.Product;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Handlers.Product;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ApiResponse<PagedResponse<ProductListDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetProductsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<PagedResponse<ProductListDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Products
                .AsQueryable();

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(p => p.TenantId == request.TenantId.Value);
            }

            if (request.VenueId.HasValue)
            {
                query = query.Where(p => p.VenueId == request.VenueId.Value);
            }

            if (request.ProductCategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == request.ProductCategoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(p =>
                    (p.ProductName != null && p.ProductName.ToLower().Contains(searchTerm)) ||
                    p.ProductCode.ToLower().Contains(searchTerm)
                );
            }

            // IsActive not in entity, skip this filter

            // Get total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = ApplySorting(query, request.SortBy, request.SortOrder);

            // Apply pagination
            var products = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductListDto
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    AvailabilityStatus = p.Status
                })
                .ToListAsync(cancellationToken);

            var pagedResponse = new PagedResponse<ProductListDto>
            {
                Items = products,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            };

            return ApiResponse<PagedResponse<ProductListDto>>.SuccessResponse(pagedResponse, "Products retrieved successfully");
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<ProductListDto>>.ErrorResponse("Failed to retrieve products", new List<string> { ex.Message });
        }
    }

    private IQueryable<Infrastructure.Persistence.Entities.Product> ApplySorting(
        IQueryable<Infrastructure.Persistence.Entities.Product> query,
        string? sortBy,
        string sortOrder)
    {
        var isDescending = sortOrder.ToLower() == "desc";

        return sortBy?.ToLower() switch
        {
            "name" => isDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName),
            "code" => isDescending ? query.OrderByDescending(p => p.ProductCode) : query.OrderBy(p => p.ProductCode),
            "createdate" => isDescending ? query.OrderByDescending(p => p.CreatedDate) : query.OrderBy(p => p.CreatedDate),
            _ => query.OrderBy(p => p.ProductName)
        };
    }
}
