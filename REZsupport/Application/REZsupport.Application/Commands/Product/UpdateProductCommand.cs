using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Product;

namespace REZsupport.Application.Commands.Product;

public class UpdateProductCommand : IRequest<ApiResponse<ProductDto>>
{
    public Guid ProductId { get; set; }
    public UpdateProductDto Product { get; set; } = null!;

    public UpdateProductCommand(Guid productId, UpdateProductDto product)
    {
        ProductId = productId;
        Product = product;
    }
}
