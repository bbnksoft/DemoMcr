using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.Product;

public class DeleteProductCommand : IRequest<ApiResponse<bool>>
{
    public Guid ProductId { get; set; }

    public DeleteProductCommand(Guid productId)
    {
        ProductId = productId;
    }
}
