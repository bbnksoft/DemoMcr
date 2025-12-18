using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Product;

namespace REZsupport.Application.Commands.Product;

public class CreateProductCommand : IRequest<ApiResponse<ProductDto>>
{
    public CreateProductDto Product { get; set; } = null!;

    public CreateProductCommand(CreateProductDto product)
    {
        Product = product;
    }
}
