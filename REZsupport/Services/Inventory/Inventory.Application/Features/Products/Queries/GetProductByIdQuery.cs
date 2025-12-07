using MediatR;
using Inventory.Application.Responses.Products;

namespace Inventory.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public Guid Id { get; set; }
    public GetProductByIdQuery(Guid id) { Id = id; }
}
