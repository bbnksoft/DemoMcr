using Demo.Application.DTOs.Common;
using Demo.Application.Queries.Merchandise;
using Demo.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using REZsupport.Application.DTOs.Merchandise;

namespace Demo.Application.Handlers.Merchandise;

public class GetMerchandisesQueryHandler : IRequestHandler<GetMerchandisesQuery, ApiResponse<PagedResponse<MerchandiseListDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetMerchandisesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<PagedResponse<MerchandiseListDto>>> Handle(GetMerchandisesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _context.Merchandises.Include(m => m.Category).AsQueryable();

            // Apply filters
            if (request.TenantId.HasValue)
            {
                query = query.Where(m => m.TenantId == request.TenantId.Value);
            }

            if (request.CategoryId.HasValue)
            {
                query = query.Where(m => m.CategoryId == request.CategoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.ProductType))
            {
                query = query.Where(m => m.ProductType == request.ProductType);
            }

            if (request.InStock.HasValue)
            {
                if (request.InStock.Value)
                {
                    query = query.Where(m => m.StockQuantity > 0);
                }
                else
                {
                    query = query.Where(m => m.StockQuantity == 0);
                }
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();
                query = query.Where(m => 
                    m.ProductName.ToLower().Contains(searchLower) ||
                    m.SKU.ToLower().Contains(searchLower) ||
                    (m.ShortDescription != null && m.ShortDescription.ToLower().Contains(searchLower)));
            }

            // Get total count
            var totalRecords = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = request.SortBy.ToLower() switch
            {
                "sku" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(m => m.SKU) 
                    : query.OrderBy(m => m.SKU),
                "price" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(m => m.BasePrice) 
                    : query.OrderBy(m => m.BasePrice),
                "stock" => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(m => m.StockQuantity) 
                    : query.OrderBy(m => m.StockQuantity),
                _ => request.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(m => m.ProductName) 
                    : query.OrderBy(m => m.ProductName)
            };

            // Apply pagination
            var merchandises = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var merchandiseDtos = merchandises.Select(m => new MerchandiseListDto
            {
                MerchandiseId = m.MerchandiseId,
                SKU = m.SKU,
                ProductName = m.ProductName,
                CategoryName = m.Category?.CategoryName,
                UnitPrice = m.BasePrice,
                Currency = "USD",
                QuantityInStock = m.StockQuantity,
                AvailabilityStatus = m.StockQuantity > 0 ? "In Stock" : "Out of Stock"
            }).ToList();

            var pagedResponse = new PagedResponse<MerchandiseListDto>
            {
                Items = merchandiseDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalRecords
            };

            return ApiResponse<PagedResponse<MerchandiseListDto>>.SuccessResponse(pagedResponse);
        }
        catch (Exception ex)
        {
            return ApiResponse<PagedResponse<MerchandiseListDto>>.ErrorResponse($"Error retrieving merchandises: {ex.Message}");
        }
    }
}
