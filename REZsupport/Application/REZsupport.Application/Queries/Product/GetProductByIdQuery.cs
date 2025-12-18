using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Product;

namespace REZsupport.Application.Queries.Product;

public class GetProductByIdQuery : IRequest<ApiResponse<ProductDto>>
{
    public Guid ProductId { get; set; }
    public Guid? TenantId { get; set; }

    public GetProductByIdQuery(Guid productId, Guid? tenantId = null)
    {
        ProductId = productId;
        TenantId = tenantId;
    }
}
