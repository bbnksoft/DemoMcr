using MediatR;

namespace Inventory.Application.Features.Products.Commands;
public class DeleteProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteProductCommand(Guid id) { Id = id; }
}
